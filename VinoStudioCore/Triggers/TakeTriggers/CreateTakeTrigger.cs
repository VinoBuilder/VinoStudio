using VinoStudioCore.Stores;

namespace VinoStudioCore.Triggers.TakeTriggers
{
    public class CreateTakeTrigger : ITrigger
    {
        private readonly TakesStore takesStore;
        private readonly int id;
        private readonly string name;
        public Take? CreatedTake { get; private set; }
        public CreateTakeTrigger(TakesStore takesStore, int id, string name)
        {
            this.takesStore = takesStore;
            this.id = id;
            this.name = name;
        }
        public async Task Execute()
        {
            Take newTake = new Take(id, name);
            await takesStore.SaveTake(newTake);
            CreatedTake = newTake;
        }
    }
}
