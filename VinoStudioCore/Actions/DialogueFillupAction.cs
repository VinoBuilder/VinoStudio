using System;
using System.Text;
using VinoStudioCore.Components;

namespace VinoStudioCore.Actions
{
    public class DialogueFillupAction : Action
    {
        private readonly string value = "";
        private readonly IDialogueComponent component;

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
                    sb.Append(value.Substring(i, Math.Min(charactersPerInterval, totalCharacters - i)));
                    await component.SetText(sb.ToString());
                    await Task.Delay(intervalMilliseconds);
                }
            }
        }

        public override async Task StopExecute()
        {
            await component.SetText(value);
        }

        private DialogueFillupAction(string value, TimeSpan duration, IDialogueComponent component) : base(duration)
        {
            this.value = value;
            this.component = component;
        }
    }
}
