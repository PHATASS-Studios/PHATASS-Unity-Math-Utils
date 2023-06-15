namespace PHATASS.Utils.Types.Ranges
{
	//Interface defining a limited range of values of any abstract type
	//has a minimum, maximum, and interpolated values
	public interface ILimitedRange <TRangeType> :
		PHATASS.Utils.Types.Constraints.IConstraint<TRangeType>
	{
		// Min and max values of the range
		TRangeType minimum { get; }
		TRangeType maximum { get; }

		// Get a random value within this range
		TRangeType random { get; }

		// Difference between maximum and minimum values
		TRangeType difference { get; }

		// Generate a number within the range from a normalized (0 to 1) value. value will be clamped within minimum and maximum unless clamped = false
		TRangeType FromNormalized (float normalized, bool clamped = true);

		// Get a normalized value (0 to 1) from a numeric value within the range. value will be clamped within minimum and maximum unless clamped = false
		float ToNormalized (TRangeType value, bool clamped = true);

		// Returns the distance between given value and the closest point of the range.
		//	If given value falls inside the range, returned value is 0.
		//	If keepSign = true, return sign is negative for values below minimum. Otherwise Sign is always positive.
		TRangeType DistanceFromRange (TRangeType value, bool keepSign = false);

	//Inherited members
		// Clamps a value between minimum and maximum, inclusive
		//TRangeType PHATASS.Utils.Types.Constraints.IConstraint<TRangeType>.Clamp (TRangeType value);
	//ENDOF Inherited members
	}

	//Mutable variation of ILimitedRange interface
	public interface ILimitedRangeMutable <TRangeType> :
		ILimitedRange <TRangeType>
	{
		//setters for min and max values of the range
		new TRangeType minimum { set; }
		new TRangeType maximum { set; }
	}
}
