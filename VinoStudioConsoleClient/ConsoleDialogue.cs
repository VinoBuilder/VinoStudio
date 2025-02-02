using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinoStudioCore.Components;

namespace VinoStudioClient
{
    public class ConsoleDialogueComponent : IDialogueComponent
    {
        public Task SetText(string text)
        {
            Console.Clear();
            Console.WriteLine(text);
            return Task.CompletedTask;
        }
    }
}
