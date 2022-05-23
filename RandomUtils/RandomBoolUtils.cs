using static UnityEngine.Random;

namespace PHATASS.Utils.RandomUtils
{
	public static class RandomBoolUtils
	{
		// Returns true or false at random
		public static bool randomBool { get { return (UnityEngine.Random.Range(0,2) == 0); }}
	}
}