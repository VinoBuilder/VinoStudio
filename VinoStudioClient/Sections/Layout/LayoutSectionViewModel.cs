using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using VinoStudioClient.Base;
using VinoStudioClient.General.Navigation;
using VinoStudioClient.Sections.Layout.ComponentDetails;
using VinoStudioClient.Sections.Layout.ComponentSelector;
using VinoStudioClient.Sections.Layout.ComponentStructure;

namespace VinoStudioClient.Sections.Layout
{
    internal partial class LayoutSectionViewModel : ViewModelBase
    {
        public ObservableCollection<NavigationItemViewModel> Subviews
        {
            get; private set;
        }

        [ObservableProperty]
        private NavigationItemViewModel? selectedSubview;

        public LayoutSectionViewModel()
        {
            Subviews = [
                new NavigationItemViewModel("Selector", new ComponentSelectorViewModel()),
                new NavigationItemViewModel("Structure", new ComponentStructureViewModel()),
                new NavigationItemViewModel("Details", new ComponentDetailsViewModel())
            ];
            SelectedSubview = Subviews[0];
        }
    }
}
