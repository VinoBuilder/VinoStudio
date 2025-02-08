using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using VinoStudioClient.Base;

namespace VinoStudioClient
{
    public class ViewLocator : IDataTemplate
    {
        public Control? Build(object? param)
        {
            if (param is null)
            {
                return null;
            }

            var name = param.GetType().FullName!.Replace("ViewModel", "View", StringComparison.Ordinal);
            var type = Type.GetType(name);

            if (type != null)
            {
                return (Control)Activator.CreateInstance(type)!;
            }

            var subviewVmNname = param.GetType().FullName!.Replace("ViewModel", "Subview", StringComparison.Ordinal);
            var subviewType = Type.GetType(subviewVmNname);

            return subviewType != null ? (Control)Activator.CreateInstance(subviewType)! : new TextBlock { Text = "Not Found: " + name };
        }

        public bool Match(object? data)
        {
            return data is ViewModelBase;
        }
    }
}
