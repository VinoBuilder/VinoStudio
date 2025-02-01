using VinoStudioApp.DTOs;
using VinoStudioCore.Stores;
using VinoStudioCore.Triggers.TakeTriggers;

namespace VinoStudioCore.Services
{
    public class TakeService
    {
        private readonly TakesStore takesStore;
        public Take? CurrentlyLoadedTake { get; private set; } = null;

        public TakeService(TakesStore takesStore)
        {
            this.takesStore = takesStore;
        }

        public async Task LoadTake(int takeID)
        {
            LoadTakeTrigger trigger = new(takeID, takesStore);
            await trigger.Execute();
            CurrentlyLoadedTake = trigger.LoadedTake;
        }

        public async Task CreateTake(int takeID, string takeName)
        {
            CreateTakeTrigger trigger = new (takesStore, takeID, takeName);
            await trigger.Execute();
            CurrentlyLoadedTake = trigger.CreatedTake;
        }

        public async Task<IEnumerable<TakeDTO>> GetAllTakes()
        {
            GetAllTakesTrigger trigger = new(takesStore);
            await trigger.Execute();
            if(trigger.AllTakes == null)
            {
                throw new Exception("Either all takes were not loaded or failed to load them.");
            }
            return trigger.AllTakes.Select(take => new TakeDTO(take.Id, take.Name));
        }
    }
}
