namespace PHATASS.Utils.Extensions
{
	public static class FrameIndependentSmoothingExtensions
	{
	//smoothly damps value by damping rate per second. Damps towards 0, and properly smooths by frame delta time
		public static float EFrameIndependentDamp (this float value, float dampingRate, float? deltaTime = null)
		{
			return value * System.MathF.Pow((1 - dampingRate), ValidateDeltaTime(deltaTime));
		}
		public static double EFrameIndependentDamp (this double value, float dampingRate, float? deltaTime = null)
		{
			return value * (double) System.MathF.Pow((1 - dampingRate), ValidateDeltaTime(deltaTime));
		}

	//smoothly lerps from value towards another, at a rate of rate per second, for a time of deltaTime. if deltaTime is not provided it will be acquired from current frame
		public static float EFrameIndependentLerp (this float from, float to, float rate, float? deltaTime = null)
		{
			return to + ((from - to) * System.MathF.Pow(rate, ValidateDeltaTime(deltaTime)));
		}
		public static double EFrameIndependentLerp (this double from, double to, float rate, float? deltaTime = null)
		{
			return to + ((from - to) * (double)System.MathF.Pow(rate, ValidateDeltaTime(deltaTime)));
		}

	//PRIVATE static
		private static float ValidateDeltaTime (float? inputDeltaTime)
		{
			if (inputDeltaTime != null) { return (float) inputDeltaTime; }
			else { return UnityEngine.Time.deltaTime; }
		}
	//ENDOF PRIVATE static
	}
}