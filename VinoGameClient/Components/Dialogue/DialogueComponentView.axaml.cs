using Avalonia.Controls;

namespace VinoGameClient.Components.Dialogue;

public partial class DialogueComponentView : UserControl
{
    public DialogueComponentView()
    {
        InitializeComponent();
        DataContext = new DialogueComponentViewModel();
    }
}