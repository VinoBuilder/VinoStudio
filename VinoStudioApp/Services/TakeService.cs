using VinoStudioApp.DTOs;
using VinoStudioCore.Stores;

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
            Take take = await takesStore.GetTake(takeID);
            CurrentlyLoadedTake = take;
        }

        public async Task CreateTake(int takeID, string takeName)
        {
            Take newTake = new Take(takeID, takeName);
            await takesStore.SaveTake(newTake);
            CurrentlyLoadedTake = newTake;
        }

        public async Task<IEnumerable<TakeDTO>> GetAllTakes()
        {
            var takes = await takesStore.GetAllTakes();
            if (takes == null)
            {
                throw new Exception("Either all takes were not loaded or failed to load them.");
            }

            return takes.Select(take => new TakeDTO(take.Id, take.Name));
        }
    }
}
