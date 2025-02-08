using System.Diagnostics;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using VinoStudioClient.Sections.Layout.ComponentPlacer.Components;
using VinoStudioClient.Sections.Layout.ComponentPlacer.Components.Dialogue;
using VinoStudioClient.Sections.Layout.ComponentPlacer.Components.Meta.General;
using VinoStudioClient.Sections.Layout.ComponentPlacer.Components.Meta.General.Size;

namespace VinoStudioClient.Sections.Layout.ComponentSelector;

public partial class ComponentSelectorSubview : UserControl
{
    public ComponentSelectorSubview()
    {
        InitializeComponent();
        DraggableScroller.AddHandler(PointerPressedEvent, PointerPressed, RoutingStrategies.Bubble);
    }

    private new async Task PointerPressed(object? sender, PointerPressedEventArgs e)
    {
        // Get the control that was actually clicked
        var control = e.Source as Control;

        while (control is not null && control.Name is null)
        {
            control = control.Parent as Control; // Move up the hierarchy if Name is missing
        }

        if (control is null)
        {
            return;
        }

        var controlName = control.Name;
        var data = new DataObject();

        switch (controlName)
        {
            case "DialoguePreview":
                data.Set(ComponentDataFormats.ComponentViewModel, new DialogueViewModel(
                    Position.Zero,
                    new Sizing(new FixedMeasurement(500), new FixedMeasurement(200))
                ));
                break;
            default:
                break;
        }

        var result = await DragDrop.DoDragDrop(e, data, DragDropEffects.Copy);
        Debug.WriteLine(result);
    }
}