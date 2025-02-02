using VinoStudioCore;
using VinoStudioCore.Stores;

namespace VinoStudioApp.Services
{
    public class TimelineService
    {
        private readonly TakeService takeService;
        private readonly SequenceStore sequenceStore;
        private Sequence? currentlyLoadedSequence = null;
        public event Action TimelineChanged;

        public TimelineService(TakeService takeService)
        {
            this.takeService = takeService;
        }

        public async Task SwitchToNextTimeline()
        {
            Take? take = takeService.CurrentlyLoadedTake;
            if(take != null)
            {
                int currentTimelineIndex = take.CurrentTimelineIndex;
                if(currentlyLoadedSequence == null)
                {
                    currentlyLoadedSequence = await sequenceStore.GetSequence(take.CurrentSequenceId);
                }

                Timeline? newTimeline = await take.SwitchToNextTimeline(currentlyLoadedSequence!, sequenceStore);
                if (newTimeline != null)
                {
                    TimelineChanged();                    
                }
            }
        }
    }
}
