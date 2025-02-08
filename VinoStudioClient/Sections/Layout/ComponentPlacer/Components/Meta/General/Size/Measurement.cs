using CommunityToolkit.Mvvm.ComponentModel;

namespace VinoStudioClient.Sections.Layout.ComponentPlacer.Components.Meta.General.Size
{
    internal abstract partial class Measurement : ObservableObject
    {
        private double value;

        public double Value
        {
            get => value;
            set
            {
                if (ValidateValue(value))
                {
                    SetProperty(ref this.value, value);
                }
            }
        }

        public abstract MeasurementDescription Description { get; }

        protected virtual bool ValidateValue(double val)
        {
            return true;
        }
    }
}
