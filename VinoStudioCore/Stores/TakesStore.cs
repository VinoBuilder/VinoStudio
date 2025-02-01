namespace VinoStudioCore.Stores
{
    public class TakesStore
    {
        private readonly Dictionary<int, Take> takes = [];

        public async Task<Take> GetTake(int takeId)
        {
            return takes[takeId];
        }

        public async Task SaveTake(Take take)
        {
            takes[take.Id] = take;
        }

        public async Task<Take[]> GetAllTakes()
        {
            return takes.Values.ToArray();
        }
    }
}
