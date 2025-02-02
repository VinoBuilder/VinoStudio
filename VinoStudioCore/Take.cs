using VinoStudioCore.Stores;

namespace VinoStudioCore
{
    public class Take
    {
        public int Id { get; set; }
        public int CurrentTimelineIndex { get; private set; } = 0;
        public int? CurrentSequenceId { get; private set; } = null;
        public string Name { get; private set; } = string.Empty;

        public Take(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public async Task<Timeline?> SwitchToNextTimeline(Sequence sequence, SequenceStore store)
        {
            if(sequence.AbleToSwitchToNextTimeline(CurrentTimelineIndex))
            {
                CurrentTimelineIndex++;
                return sequence.GetTimeline(CurrentTimelineIndex);

            }
            else if(sequence.NextSequenceId != null)
            {
                Sequence nextSequence = await store.GetSequence(sequence.NextSequenceId);
                if(nextSequence == null)
                {
                    throw new Exception("Sequence with this id was not found!");
                }

                CurrentTimelineIndex = 0;
                CurrentSequenceId = nextSequence.Id;

                return nextSequence.GetTimeline(CurrentTimelineIndex);
            }
            return null;
        }
    }
}
