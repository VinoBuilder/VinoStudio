using CommunityToolkit.Mvvm.ComponentModel;
using VinoStudioClient.Base;
using VinoStudioClient.Sections.Layout.ComponentPlacer.Components.Meta.General;
using VinoStudioClient.Sections.Layout.ComponentPlacer.Components.Meta.General.Size;

namespace VinoStudioClient.Sections.Layout.ComponentPlacer.Components
{
    internal abstract partial class ComponentViewModel : ViewModelBase
    {
        [ObservableProperty]
        private Position coords;

        [ObservableProperty]
        private Sizing sizing;

        protected ComponentViewModel(Position coords, Sizing sizing)
        {
            this.coords = coords;
            this.sizing = sizing;
        }
    }
}
