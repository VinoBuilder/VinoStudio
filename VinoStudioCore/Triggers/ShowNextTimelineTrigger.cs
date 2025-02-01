using VinoStudioCore;
using VinoStudioCore.Stores;
using VinoStudioCore.Triggers;

namespace VinoStudioApp.Triggers
{
    public class ShowNextTimelineTrigger : ITrigger
    {
        private readonly Take take;
        private readonly TimelineStore timelineStore;

        internal ShowNextTimelineTrigger(Take take, TimelineStore timelineStore)
        {
            this.take = take;
            this.timelineStore = timelineStore;
        }

        public async Task Execute()
        {
            await take.SetCurrentTimeline(take.CurrentTimelineID + 1, timelineStore);   
        }
    }
}
