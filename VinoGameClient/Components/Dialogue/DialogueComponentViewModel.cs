using CommunityToolkit.Mvvm.ComponentModel;

namespace VinoGameClient.Components.Dialogue
{
    internal partial class DialogueComponentViewModel : ObservableObject
    {
        [ObservableProperty]
        private string text = "Hello there";
    }
}
