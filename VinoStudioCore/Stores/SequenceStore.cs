using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinoStudioCore.Stores
{
    public class SequenceStore
    {
        private readonly Dictionary<int?, Sequence> sequences = [];
        public async Task<Sequence?> GetSequence(int? id)
        {
            try
            {
                return sequences[id];
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
