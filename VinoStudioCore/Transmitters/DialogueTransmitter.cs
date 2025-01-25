using System.Text;
using VinoStudioCore.Actions;
using VinoStudioCore.Components;

namespace VinoStudioCore.Transmitters
{
    public class DialogueTransmitter
    {
        private readonly IDialogueComponent component;

        public DialogueTransmitter(IDialogueComponent component)
        {
            this.component = component;
        }

        public async Task Accept(DialogueFillupAction action)
        {
            if (action.Duration == TimeSpan.Zero)
            {
                await component.SetText(action.Value);
            }
            else
            {
                StringBuilder sb = new StringBuilder(action.Value.Length);
                int totalCharacters = action.Value.Length;
                int intervalMilliseconds = 50;
                double totalMilliseconds = action.Duration.TotalMilliseconds;
                int charactersPerInterval = (int)Math.Ceiling(totalCharacters / (totalMilliseconds / intervalMilliseconds));

                for (int i = 0; i < totalCharacters; i += charactersPerInterval)
                {
                    sb.Append(action.Value.Substring(i, Math.Min(charactersPerInterval, totalCharacters - i)));
                    await component.SetText(sb.ToString());
                    await Task.Delay(intervalMilliseconds);
                }
            }
        }
    }
}
