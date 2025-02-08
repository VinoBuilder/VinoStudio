using Avalonia.Controls;
using Avalonia.Input;
using VinoStudioClient.Sections.Layout.ComponentPlacer.Components;
using VinoStudioClient.Sections.Layout.ComponentPlacer.Components.Meta.General;

namespace VinoStudioClient.Sections.Layout.ComponentPlacer;

public partial class ComponentPlacerSubview : UserControl
{
    public ComponentPlacerSubview()
    {
        InitializeComponent();
        DataContext = new ComponentPlacerViewModel();

        PlacerCanvas.AddHandler(DragDrop.DragOverEvent, DragOverHandler);
        PlacerCanvas.AddHandler(DragDrop.DropEvent, DropHandler);
    }

    private void DragOverHandler(object? sender, DragEventArgs e)
    {
        if (e.Data.Get(ComponentDataFormats.ComponentViewModel) is ComponentViewModel viewModel)
        {
            // Get mouse position relative to the Canvas
            var position = e.GetPosition(PlacerCanvas);

            // Convert Y coordinate to be relative to the bottom-left corner
            double bottomLeftY = PlacerCanvas.Bounds.Height - position.Y;

            // Store adjusted position in the ViewModel
            viewModel.Coords = new Position { X = position.X, Y = bottomLeftY };
        }
    }

    private void DropHandler(object? sender, DragEventArgs e)
    {
        var vm = e.Data.Get(ComponentDataFormats.ComponentViewModel);

        if (vm is ComponentViewModel viewModel && DataContext is ComponentPlacerViewModel placerViewModel)
        {
            // Update the dropped position
            var position = e.GetPosition(PlacerCanvas);
            double bottomLeftY = position.Y;

            viewModel.Coords = new Position { X = position.X, Y = bottomLeftY };

            // Add the component to the ViewModel’s collection
            placerViewModel.Components.Add(viewModel);
        }
    }
}