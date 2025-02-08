using System.Diagnostics;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Input;
using VinoStudioClient.Sections.Layout.ComponentPlacer.Components;
using VinoStudioClient.Sections.Layout.ComponentPlacer.Components.Meta.General;

namespace VinoStudioClient.Sections.Layout.ComponentPlacer;

public partial class ComponentPlacerSubview : UserControl
{
    private Position _dragOffset;

    public ComponentPlacerSubview()
    {
        InitializeComponent();
        DataContext = new ComponentPlacerViewModel();

        PlacerCanvas.AddHandler(PointerPressedEvent, PointerPressed);
        PlacerCanvas.AddHandler(DragDrop.DragOverEvent, DragOverHandler);
        PlacerCanvas.AddHandler(DragDrop.DropEvent, DropHandler);
    }

    private new async Task PointerPressed(object? sender, PointerPressedEventArgs e)
    {
        var control = e.Source as Control;

        // Traverse up the tree to find the control that has a valid DataContext
        while (control is not null && control.DataContext is null)
        {
            control = control.Parent as Control; // Move up the hierarchy
        }

        // Ensure we found a control with a DataContext
        if (control is not null && control.DataContext is null)
        {
            return;
        }
        var viewModel = (ComponentViewModel)control.DataContext;
        var mousePosition = e.GetPosition(PlacerCanvas);
        // Store the offset between mouse and component's top-left corner
        _dragOffset = new Position() { X = mousePosition.X - viewModel.Coords.X, Y = mousePosition.Y - viewModel.Coords.Y };

        var data = new DataObject();

        // Compiler is fucking stupid, don't worry about it being null
        data.Set(ComponentDataFormats.ComponentViewModel, control.DataContext);

        var result = await DragDrop.DoDragDrop(e, data, DragDropEffects.Move);
        Debug.WriteLine(result);
    }

    private void DragOverHandler(object? sender, DragEventArgs e)
    {
        if (e.Data.Get(ComponentDataFormats.ComponentViewModel) is ComponentViewModel viewModel
            && DataContext is ComponentPlacerViewModel vm)
        {
            var position = e.GetPosition(PlacerCanvas);

            // For copies, translate from top-left to bottom-left
            if (e.DragEffects == DragDropEffects.Copy)
            {
                viewModel.Coords = new Position
                {
                    X = position.X,
                    Y = PlacerCanvas.Bounds.Height - position.Y // Flipping needed for new components
                };
            }
            else if (e.DragEffects == DragDropEffects.Move)
            {
                viewModel.Coords = new Position
                {
                    X = position.X - _dragOffset.X, // Apply offset
                    Y = position.Y - _dragOffset.Y  // Apply offset
                };

                // Ensure it's in the collection
                if (!vm.Components.Contains(viewModel))
                {
                    vm.Components.Add(viewModel);
                }
            }
        }
    }


    private void DropHandler(object? sender, DragEventArgs e)
    {
        var vm = e.Data.Get(ComponentDataFormats.ComponentViewModel);

        if (vm is ComponentViewModel viewModel && DataContext is ComponentPlacerViewModel placerViewModel)
        {
            // Update the dropped position
            var position = e.GetPosition(PlacerCanvas);

            if (e.DragEffects == DragDropEffects.Copy)
            {
                viewModel.Coords = new Position { X = position.X, Y = position.Y };
            }
            else if (e.DragEffects == DragDropEffects.Move)
            {
                viewModel.Coords = new Position
                {
                    X = position.X - _dragOffset.X, // Apply offset
                    Y = position.Y - _dragOffset.Y  // Apply offset
                };
            }

            // Add the component to the ViewModel’s collection
            placerViewModel.Components.Add(viewModel);
        }
    }
}