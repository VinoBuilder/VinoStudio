using System;

namespace VinoStudioCore.Actions
{
    public class DialogueFillupAction : IAction
    {
        public string Value { get; set; } = "";

        private TimeSpan _duration;

        public TimeSpan Duration
        {
            get => _duration;
            set
            {
                if (value < TimeSpan.Zero || value > TimeSpan.FromSeconds(5))
                {
                    throw new ArgumentOutOfRangeException(nameof(Duration), "Duration must be between 0 and 5 seconds.");
                }
                _duration = value;
            }
        }

        public DialogueFillupAction(string value, TimeSpan duration)
        {
            Value = value;
            Duration = duration;
        }
    }
}
