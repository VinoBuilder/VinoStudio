using CommunityToolkit.Mvvm.ComponentModel;

namespace VinoStudioClient.Sections.Layout.ComponentPlacer.Components.Meta.General.Size
{
    internal partial class Sizing : ObservableObject
    {
        [ObservableProperty]
        private Measurement width;

        [ObservableProperty]
        private Measurement height;

        [ObservableProperty]
        private FixedMeasurement? maxHeight;

        [ObservableProperty]
        private FixedMeasurement? minHeight;

        [ObservableProperty]
        private FixedMeasurement? maxWidth;

        [ObservableProperty]
        private FixedMeasurement? minWidth;

        public Sizing(Measurement width, Measurement height)
        {
            Width = width;
            Height = height;
        }
    }
}
