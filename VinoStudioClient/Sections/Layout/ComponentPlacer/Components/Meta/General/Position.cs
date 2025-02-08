using CommunityToolkit.Mvvm.ComponentModel;

namespace VinoStudioClient.Sections.Layout.ComponentPlacer.Components.Meta.General
{
    internal partial class Position : ObservableObject
    {
        [ObservableProperty]
        private double x;

        [ObservableProperty]
        private double y;

        public static Position Zero => new Position { X = 0, Y = 0 };
    }
}
