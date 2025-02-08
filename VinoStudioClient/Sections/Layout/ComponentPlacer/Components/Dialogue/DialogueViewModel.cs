using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using VinoStudioClient.Sections.Layout.ComponentPlacer.Components.Meta.General;
using VinoStudioClient.Sections.Layout.ComponentPlacer.Components.Meta.General.Size;

namespace VinoStudioClient.Sections.Layout.ComponentPlacer.Components.Dialogue
{
    internal partial class DialogueViewModel : ComponentViewModel
    {
        [ObservableProperty]
        private IBrush background;

        public DialogueViewModel(Position coords, Sizing sizing) : base(coords, sizing)
        {
            Background = Brush.Parse("Black");
        }
    }
}
