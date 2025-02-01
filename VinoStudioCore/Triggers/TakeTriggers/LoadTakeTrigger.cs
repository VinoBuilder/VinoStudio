using VinoStudioCore.Stores;

namespace VinoStudioCore.Triggers.TakeTriggers
{
    public class LoadTakeTrigger : ITrigger
    {
        private readonly TakesStore takesStore;

        public Take? LoadedTake { get; private set; } = null;

        private readonly int takeID;
        public LoadTakeTrigger(int takeID, TakesStore takesStore)
        {
            this.takeID = takeID;
            this.takesStore = takesStore;
        }
        public async Task Execute()
        {
            Take take = await takesStore.GetTake(takeID);
            LoadedTake = take;
        }
    }
}
