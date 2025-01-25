using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinoStudioCore.Components
{
    public interface IDialogueComponent : IComponent
    {
        Task SetText(string text);
    }
}
