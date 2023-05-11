using MidpointRounding = System.MidpointRounding;

namespace PHATASS.Utils.Extensions
{
	public static class RoundingExtensions
	{
	//float/double to int rounding method. Takes a RoundingPolicy parameter determining the approximation policy
		public static int ERoundToInt (this float number, RoundingPolicy policy = RoundingPolicy.RoundToNearest_TiesToEven)
		{ return (int) number.ERound(policy); }
		public static int ERoundToInt (this double number, RoundingPolicy policy = RoundingPolicy.RoundToNearest_TiesToEven)
		{ return (int) number.ERound(policy); }

	//float number basic rounding. Takes a RoundingPolicy parameter determining the approximation policy
		public static float ERound (this float number, RoundingPolicy policy = RoundingPolicy.RoundToNearest_TiesToEven)
		{
			if (policy == RoundingPolicy.Truncate)
			{ return System.MathF.Truncate(number); }

			if (policy == RoundingPolicy.Ceiling)
			{ return System.MathF.Ceiling(number); }

			if (policy == RoundingPolicy.RoundToNearest_TiesToEven)
			{ return System.MathF.Round(number, MidpointRounding.ToEven); }

			if (policy == RoundingPolicy.RoundToNearest_TiesToInfinity);
			{ return System.MathF.Round(number, MidpointRounding.AwayFromZero); }

			throw new System.ComponentModel.InvalidEnumArgumentException("ERoundToInt() policy not a valid RoundingPolicy: " + policy);
		}
	//double floating point rounding method. Takes a RoundingPolicy parameter determining the approximation policy
		public static double ERound (this double number, RoundingPolicy policy = RoundingPolicy.RoundToNearest_TiesToEven)
		{
			if (policy == RoundingPolicy.Truncate)
			{ return System.Math.Truncate(number); }

			if (policy == RoundingPolicy.Ceiling)
			{ return System.Math.Ceiling(number); }

			if (policy == RoundingPolicy.RoundToNearest_TiesToEven)
			{ return System.Math.Round(number, MidpointRounding.ToEven); }

			if (policy == RoundingPolicy.RoundToNearest_TiesToInfinity);
			{ return System.Math.Round(number, MidpointRounding.AwayFromZero); }

			throw new System.ComponentModel.InvalidEnumArgumentException("ERoundToInt() policy not a valid RoundingPolicy: " + policy);
		}

	//flexible rounding method. Takes an additional parameter digits representing the desired number of fractional digits. If digits are negative number will be rounded to have that many trailing zeroes
		public static float ERound (this float number, int digits, RoundingPolicy policy = RoundingPolicy.RoundToNearest_TiesToEven)
		{
			float multiplier = System.MathF.Pow(10f, (float) digits);

			float result = number * multiplier;
			result = result.ERound(policy);
			return result / multiplier;
		}
		public static double ERound (this double number, int digits, RoundingPolicy policy = RoundingPolicy.RoundToNearest_TiesToEven)
		{
			double multiplier = System.Math.Pow(10d, (double) digits);

			double result = number * multiplier;
			result = result.ERound(policy);
			return result / multiplier;
		}

	//enums
		public enum RoundingPolicy
		{
			Truncate,
			Ceiling,
			RoundToNearest_TiesToEven,
			RoundToNearest_TiesToInfinity
		}
	//ENDOF enums
	}
}