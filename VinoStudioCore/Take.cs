using VinoStudioCore.Stores;

namespace VinoStudioCore
{
    public class Take
    {
        public int Id { get; set; }
        public int CurrentTimelineID { get; private set; }
        public string Name { get; private set; } = string.Empty;

        public Take(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public async Task<Timeline> SetCurrentTimeline(int id, TimelineStore timelineStore)
        {
            Timeline? timeline = await timelineStore.GetTimeline(id);
            if (timeline == null) 
            {
                throw new Exception($"Timeline with id: [${id}] does not exist!");
            }

            CurrentTimelineID = id;
            return timeline;
        }
    }
}
