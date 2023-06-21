namespace PHATASS.Utils.Extensions
{
	public static class FrameIndependentSmoothingExtensions
	{
	//smoothly damps value by damping rate per second. Damps towards 0, and properly smooths by frame delta time
		public static float EFrameIndependentDamp (this float value, float dampingRate, float? deltaTime = null)
		{
			//Debug.LogWarning("EFrameIndependentDamp float value: " + value + " dampingRate: " + dampingRate);
			if (value == 0f) { return 0f; }
			if (dampingRate >= 1f) { dampingRate = 1f; }
			return value * System.MathF.Pow((1f - dampingRate), ValidateDeltaTime(deltaTime));
		}
		public static double EFrameIndependentDamp (this double value, double dampingRate, float? deltaTime = null)
		{
			//Debug.LogWarning("EFrameIndependentDamp double value: " + value + " dampingRate: " + dampingRate);
			if (value == 0f) { return 0f; }
			if (dampingRate >= 1f) { dampingRate = 1f; }
			return value * (double) System.Math.Pow((1d - dampingRate), (double) ValidateDeltaTime(deltaTime));
		}

	//smoothly lerps from value towards another, at a rate of rate per second, for a time of deltaTime. if deltaTime is not provided it will be acquired from current frame
		public static float EFrameIndependentLerp (this float from, float towards, float rate, float? deltaTime = null)
		{
			return towards + ((from - towards) * System.MathF.Pow(1 - rate, ValidateDeltaTime(deltaTime)));
		}
		public static double EFrameIndependentLerp (this double from, double towards, float rate, float? deltaTime = null)
		{
			return towards + ((from - towards) * (double)System.MathF.Pow(1 - rate, ValidateDeltaTime(deltaTime)));
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