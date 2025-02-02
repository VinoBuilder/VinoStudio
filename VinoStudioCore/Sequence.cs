namespace VinoStudioCore
{
    public class Sequence
    {
        public int Id { get; private set; }
        private Timeline[] timelines = [];
        public int? NextSequenceId { get; private set; }

        public Sequence(int id, Timeline[] timelines, int? nextSequenceID = null)
        {
            Id = id;
            this.timelines = timelines;
            NextSequenceId = nextSequenceID;
        }

        public Timeline GetTimeline(int index)
        {
            return timelines[index];
        }

        public bool AbleToSwitchToNextTimeline(int index)
        {
            return index != timelines.Length - 1;
        }
    }
}
