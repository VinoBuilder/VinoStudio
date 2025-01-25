using System.Diagnostics;
using Action = VinoStudioCore.Actions.Action;

namespace VinoStudioCore
{
    public class Timeline
    {
        private readonly SortedDictionary<TimeSpan, Action[]> actions = [];
        private Action[] CurrentActions = [];
        private bool CompleteAllActionsRequested = false;

        public void AddActions(TimeSpan timing, Action[] actionsToAdd)
        {
            actions[timing] = actionsToAdd;
        }

        public async Task Execute()
        {
            if (!actions.Any())
                return;

            var totalDuration = actions.Keys.Last() + actions.Values.Last().Max(a => a.Duration);
            var stopwatch = Stopwatch.StartNew();

            var currentTiming = stopwatch.Elapsed;

            while (currentTiming <= totalDuration || actions.Any())
            {
                if (CompleteAllActionsRequested)
                {
                    // Finish all remaining actions immediately
                    await CompleteAllActions();
                    break; // Exit the loop after completing all actions
                }

                // Execute actions scheduled at the current time
                foreach (var timing in actions.Keys.Where(k => k <= currentTiming).ToList())
                {
                    currentTiming = timing;
                    CurrentActions = actions[timing];
                    var tasks = CurrentActions.Select(action => action.StartExecute()).ToArray();
                    Task.WhenAll(tasks);
                    // Mark actions as executed
                    actions.Remove(timing);
                }
                currentTiming = stopwatch.Elapsed;
                await Task.Delay(10);
            }

            stopwatch.Stop();
        }

        public async Task CompleteAllActionsRequest()
        {
            CompleteAllActionsRequested = true;
        }

        private async Task CompleteAllActions()
        {
            // Stop all currently running actions
            foreach (var currentAction in CurrentActions)
            {
                await currentAction.StopExecute(); // Ensures actions complete cleanly
            }

            // Execute remaining actions in parallel
            var allRemainingTasks = actions.Values
                .SelectMany(actionArray => actionArray)
                .Select(action => action.StopExecute())
                .ToArray();

            await Task.WhenAll(allRemainingTasks);

            // Clear all pending actions
            actions.Clear();
        }
    }
}