using VinoStudioCore.Stores;

namespace VinoStudioCore.Triggers.TakeTriggers
{
    public class GetAllTakesTrigger : ITrigger
    {
        private readonly TakesStore takesStore;
        public IEnumerable<Take>? AllTakes { get; private set; } = null;

        public GetAllTakesTrigger(TakesStore takesStore)
        {
            this.takesStore = takesStore;
        }

        public async Task Execute()
        {
            var takes = await takesStore.GetAllTakes();
            AllTakes = takes;
        }
    }
}
