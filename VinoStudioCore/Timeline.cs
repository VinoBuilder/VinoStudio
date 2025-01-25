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

            var totalDuration = actions.Keys.Last() + actions.Values.Last().Max(a => a.Duration);
            var stopwatch = Stopwatch.StartNew();

            while (stopwatch.Elapsed <= totalDuration || actions.Any())
            {
                var currentTime = stopwatch.Elapsed;

                // Execute actions scheduled at the current time
                foreach (var timing in actions.Keys.Where(k => k <= currentTime).ToList())
                {
                    var actionsToExecute = actions[timing];

                    // Start tasks in parallel
                    var tasks = actionsToExecute.Select(action => action.StartExecute()).ToArray();
                    await Task.WhenAll(tasks);

                    // Mark actions as executed
                    actions.Remove(timing);
                }

                // Prevent busy-waiting
                await Task.Delay(10);
            }

            stopwatch.Stop();
        }

    }
}
