using CommunityToolkit.Mvvm.ComponentModel;
using VinoStudioClient.Base;
using VinoStudioClient.Sections.Layout;
using VinoStudioClient.Sections.Other;

namespace VinoStudioClient.General.Section
{
    internal partial class SectionViewModel : ViewModelBase
    {
        private readonly ViewModelBase[] Sections =
        {
            new LayoutSectionViewModel(),
            new OtherSectionViewModel()
        };

        [ObservableProperty]
        private ViewModelBase currentSection;
    }
}
