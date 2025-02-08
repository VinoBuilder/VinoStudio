using System.Collections.ObjectModel;
using VinoStudioClient.Base;
using VinoStudioClient.Sections.Layout.ComponentPlacer.Components;

namespace VinoStudioClient.Sections.Layout.ComponentPlacer
{
    internal partial class ComponentPlacerViewModel : ViewModelBase
    {
        public ObservableCollection<ComponentViewModel> Components { get; } = [];
    }
}
