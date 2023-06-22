namespace PHATASS.Utils.Extensions
{
//Extension methods and utilities regarding time management
	public static class TimeExtensions
	{
	//takes a nullable time (float) value, if it's null substitutes with UnityEngine's deltaTime, and returns it as a non-nullable float value
		public float EValidateDeltaTime (this float? timeStep)
		{
			if (timeStep == null) { return UnityEngine.Time.deltaTime; }
			else { return (float) timeStep; }
		}
	}
}