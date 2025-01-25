using System;
using System.Text;
using VinoStudioCore.Components;

namespace VinoStudioCore.Actions
{
    public class DialogueFillupAction : Action
    {
        private readonly string value = "";
        private readonly IDialogueComponent component;
        private CancellationTokenSource cancellationTokenSource;

        public static DialogueFillupAction Create(string value, TimeSpan duration, IDialogueComponent component)
        {
            if (duration < TimeSpan.Zero || duration > TimeSpan.FromSeconds(5))
            {
                throw new ArgumentOutOfRangeException(nameof(duration), "Duration must be between 0 and 5 seconds.");
            }

            return new DialogueFillupAction(value, duration, component);
        }

        public override async Task StartExecute()
        {
            cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;

            if (Duration == TimeSpan.Zero)
            {
                await component.SetText(value);
            }
            else
            {
                StringBuilder sb = new StringBuilder(value.Length);
                int totalCharacters = value.Length;
                int intervalMilliseconds = 50;
                double totalMilliseconds = Duration.TotalMilliseconds;
                int charactersPerInterval = (int)Math.Ceiling(totalCharacters / (totalMilliseconds / intervalMilliseconds));

                for (int i = 0; i < totalCharacters; i += charactersPerInterval)
                {
                    if (token.IsCancellationRequested) // Break if cancellation is requested
                        break;

                    sb.Append(value.Substring(i, Math.Min(charactersPerInterval, totalCharacters - i)));
                    await component.SetText(sb.ToString());
                    try
                    {
                        await Task.Delay(intervalMilliseconds, token); // Cancelable delay
                    }
                    catch (TaskCanceledException)
                    {
                        break; // Break loop on cancellation
                    }
                }
            }
        }

        public override async Task StopExecute()
        {
            cancellationTokenSource?.Cancel();
            await component.SetText(value); // Immediately set the final text
        }

        private DialogueFillupAction(string value, TimeSpan duration, IDialogueComponent component) : base(duration)
        {
            this.value = value;
            this.component = component;
        }
    }
}
