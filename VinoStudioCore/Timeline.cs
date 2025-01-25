using System.Diagnostics;
using Action = VinoStudioCore.Actions.Action;

namespace VinoStudioCore
{
    public class Timeline
    {
        private readonly SortedDictionary<TimeSpan, Action[]> actions = [];

        public void AddActions(TimeSpan timing, Action[] actionsToAdd)
        {
            actions[timing] = actionsToAdd;
        }

        public async Task Execute()
        {
            if (!actions.Any())
                return;

            // Track the total duration of all tasks + spaces
            var totalDuration = actions.Keys.Last() + actions.Values.Last().Max(a => a.Duration);

            var stopwatch = Stopwatch.StartNew();

            while (stopwatch.Elapsed <= totalDuration)
            {
                var currentTime = stopwatch.Elapsed;

                // Execute actions scheduled at the current time
                foreach (var timelineAction in actions.Where(a => a.Key <= currentTime))
                {
                    var timing = timelineAction.Key;
                    var actionsToExecute = timelineAction.Value;

                    // Start tasks in parallel
                    var tasks = actionsToExecute.Select(action => action.StartExecute()).ToArray();
                    await Task.WhenAll(tasks);

                    // Remove the executed actions to prevent re-execution
                    actions.Remove(timing);
                }

                // Brief delay to prevent busy-waiting
                await Task.Delay(10);
            }

            stopwatch.Stop();
        }
    }
}
