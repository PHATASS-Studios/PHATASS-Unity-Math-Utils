namespace PHATASS.Utils.MathUtils
{
	//simple mathematics on floats
	public static class FloatExtensions
	{
		//steps a float towards another by given step value
		public static float EStepTowards (this float value, float target, float step = 1)
		{
			//limit step to avoid overshooting
			if (value.EDifference(target) < step)
			{ step = value.EDifference(target); }

			return	(value > target)	
						? value - step	//if greater than target, decrement
				  :	(value < target)
						? value + step //if smaller than target, increment
						: target;	//if on target return target
		}

		//returns the absolute difference between two floats
		public static float EDifference (this float a, float b)
		{
			return System.Math.Abs(a - b);
		}

		//returns the sign of this number (1 for positive, -1 for negative, 0 for zero)
		public static int ESign (this float number)
		{
			return System.Math.Sign(number);
		}
	}
}