namespace VinoStudioClient.Sections.Layout.ComponentPlacer.Components.Meta.General.Size
{
	internal class FixedMeasurement : Measurement
	{
		public FixedMeasurement(double value)
		{
			Value = value;
		}
		public override MeasurementDescription Description => MeasurementDescription.FIXED;
	}
}
