using System;

namespace VinoStudioClient.Sections.Layout.ComponentPlacer.Components.Meta.General.Size
{
    internal class PercentageMeasurement : Measurement
    {
        public override MeasurementDescription Description => MeasurementDescription.PERCENTAGE;

        protected override bool ValidateValue(double val)
        {
            return val >= 0 && val <= 100;
        }
    }
}
