using CommunityToolkit.Mvvm.ComponentModel;
using VinoStudioClient.Base;

namespace VinoStudioClient.General.Navigation
{
    public partial class NavigationItemViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string name = "";


        [ObservableProperty]
        private ViewModelBase viewModel;

        public NavigationItemViewModel(string name, ViewModelBase viewModel)
        {
            Name = name;
            ViewModel = viewModel;
        }
    }
}
