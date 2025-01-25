using VinoStudioClient;
using VinoStudioCore;
using VinoStudioCore.Actions;
using VinoStudioCore.Components;
using Action = VinoStudioCore.Actions.Action;

IDialogueComponent dialogueComponent = new ConsoleDialogueComponent();
Action fillupAction = DialogueFillupAction.Create("hellohelhellohellohellohellohellohellohellohellohellohellohellohellohellohellohellohellolohellohello", TimeSpan.FromSeconds(4), dialogueComponent);
Action fillupAction2 = DialogueFillupAction.Create("goodbyegoodbyegoodbyegoodbyegoodbyegoodbye", TimeSpan.FromSeconds(4), dialogueComponent);


Timeline timeline = new Timeline();
timeline.AddActions(TimeSpan.FromSeconds(0), [fillupAction]);
timeline.AddActions(TimeSpan.FromSeconds(0), [fillupAction2]);

// Run the timeline execution in a background task
var timelineTask = timeline.Execute();

// Simulate user input to skip
await Task.Delay(1000); // Simulate some delay
await timeline.CompleteAllActionsRequest();

// Wait for execution to complete
await timelineTask;