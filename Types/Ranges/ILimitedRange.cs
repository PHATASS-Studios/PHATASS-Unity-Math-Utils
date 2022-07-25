namespace PHATASS.Utils.Types.Ranges
{
	//Interface defining a limited range of values of any abstract type
	//has a minimum, maximum, and interpolated values
	public interface ILimitedRange <TRangeType> :
		PHATASS.Utils.MathUtils.IValue <TRangeType>
	{
		//min and max values of the range
		TRangeType minimum { get; }
		TRangeType maximum { get; }

		//get a random value within this range
		TRangeType random { get; }

		//difference between maximum and minimum values
		TRangeType difference { get; }

		//generate a number within the range from a normalized (0 to 1) value. value will be clamped within minimum and maximum unless clamped = false
		TRangeType FromNormalized (float normalized, bool clamped = true);

		//get a normalized value (0 to 1) from a numeric value within the range. value will be clamped within minimum and maximum unless clamped = false
		float ToNormalized (TRangeType value, bool clamped = true);
	}

	//Mutable variation of ILimitedRange interface
	public interface ILimitedRangeMutable <TRangeType> :
		ILimitedRange <TRangeType>,
		PHATASS.Utils.MathUtils.IValueMutable <TRangeType>
	{
		//setters for min and max values of the range
		new TRangeType minimum { set; }
		new TRangeType maximum { set; }
	}
}
