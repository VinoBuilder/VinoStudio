namespace VinoStudioCore.Actions
{
    public abstract class Action
    {
        public TimeSpan Duration { get; private set; }

        protected Action(TimeSpan duration)
        {
            Duration = duration;
        }

        public abstract Task StartExecute();

        public virtual Task StopExecute()
        {
            return Task.CompletedTask;
        }
    }
}
