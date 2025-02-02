using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinoStudioCore.Stores
{
    public class TimelineStore
    {
        private readonly Dictionary<int, Timeline> timelines = [];

        public async Task<Timeline?> GetTimeline(int id)
        {
            try
            {
                return timelines[id];
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
