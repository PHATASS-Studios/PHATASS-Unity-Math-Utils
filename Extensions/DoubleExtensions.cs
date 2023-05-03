using System;
using System.Collections.Generic;

namespace PHATASS.Utils.Extensions
{
	//simple mathematics on doubles
	public static class DoubleExtensions
	{
		//steps a double towards another by given step value
		public static double EStepTowards (this double value, double target, double step = 1)
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

		//returns the absolute value of a double
		public static double EAbs (this double a)
		{
			return System.Math.Abs(a);
		}

		//returns the absolute difference between two doubles
		public static double EDifference (this double a, double b)
		{
			return System.Math.Abs(a - b);
		}

		//returns the sign of this number (1 for positive, -1 for negative, 0 for zero)
		public static int ESign (this double number)
		{
			return System.Math.Sign(number);
		}

		//clamps the number between minimum and maximum
		public static double EClamp (this double number, double minimum, double maximum)
		{
			return System.Math.Clamp(number, minimum, maximum);
		}

	//comparison methods
		//returns the SMALLEST from an enumerable of double values
		//implementation provided by PHATASS.Utils.Types.IComparableExtensions
		public static double EMinimum (this double[] doubleArray)
		{
			IComparable<double>[] comparableArray = Array.ConvertAll<double, IComparable<double>>(
				array: doubleArray,
				converter: item => (IComparable<double>)item
			);
			return (double) ((IEnumerable<IComparable<double>>) comparableArray).EMinimum();
		}

		//returns the LARGEST from an enumerable of double values
		//implementation provided by PHATASS.Utils.Types.IComparableExtensions
		public static double EMaximum (this double[] doubleArray)
		{
			IComparable<double>[] comparableArray = Array.ConvertAll<double, IComparable<double>>(
				array: doubleArray,
				converter: item => (IComparable<double>)item
			);
			return (double) ((IEnumerable<IComparable<double>>) comparableArray).EMaximum();
		}

		//returns true if value is between a and b
		public static bool EIsBetween (this double value, double a, double b)
		{
			if (a < b && a < value && value < b) { return true; }
			if (a > b && a > value && value > b) { return true; }
			return false;
		}

	//ENDOF comparison methods
	}
}