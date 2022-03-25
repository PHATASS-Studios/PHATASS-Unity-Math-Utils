using static UnityEngine.Random;

namespace PHATASS.Utils.RandomUtils
{
	//static methods providing random sign values
	public static class RandomSign
	{
		//returns 1 or -1, randomly
		public static int Int ()
		{ return ((UnityEngine.Random.Range(0, 2) * 2) - 1); }

		//returns 1 or -1, randomly
		public static float Float ()
		{ return (float) RandomSign.Int(); }
	}
}
