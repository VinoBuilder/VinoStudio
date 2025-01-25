using VinoStudioClient;
using VinoStudioCore;
using VinoStudioCore.Actions;
using VinoStudioCore.Components;
using Action = VinoStudioCore.Actions.Action;

IDialogueComponent dialogueComponent = new ConsoleDialogueComponent();
Action fillupAction = DialogueFillupAction.Create("hello", TimeSpan.Zero, dialogueComponent);
Action fillupAction2 = DialogueFillupAction.Create("goodbye", TimeSpan.FromSeconds(1), dialogueComponent);


Timeline timeline = new Timeline();
timeline.AddActions(TimeSpan.FromSeconds(1), [fillupAction]);
timeline.AddActions(TimeSpan.FromSeconds(4), [fillupAction2]);

await timeline.Execute();