using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using VinoStudioCore.Components;

namespace VinoGameClient.Components.Dialogue
{
    internal partial class DialogueComponentViewModel : ObservableObject, IDialogueComponent
    {
        [ObservableProperty]
        private string text = "Hello there";

        public Task SetText(string text)
        {
            Text = text;
            return Task.CompletedTask;
        }
    }
}
