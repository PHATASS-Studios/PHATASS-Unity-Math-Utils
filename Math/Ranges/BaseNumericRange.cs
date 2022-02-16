using SerializeField = UnityEngine.SerializeField;

namespace PHATASS.Utils.Math.Ranges
{
	//Base class defining a range of values of any abstract type
	//includes a minimum, maximum, and interpolated values
	[System.Serializable]
	public abstract class BaseNumericRange <TRangeType>
		: ILimitedRangeMutable<TRangeType>
	{
	//serialized fields
		[SerializeField]
		protected TRangeType minimum;

		[SerializeField]
		protected TRangeType maximum;
	//ENDOF serialized fields

	//ILimitedRange<TRangeType> implementation
		//min and max values of the range
		TRangeType ILimitedRange<TRangeType>.minimum
		{ get { return this.minimum; }}

		TRangeType ILimitedRange<TRangeType>.maximum
		{ get { return this.maximum; }}

		//get value currently represented by this range
		TRangeType ILimitedRange<TRangeType>.value { get { return this.value; }}

		//get a random value within this range
		TRangeType ILimitedRange<TRangeType>.random { get { return this.random; }}

		//difference between maximum and minimum values
		TRangeType ILimitedRange<TRangeType>.difference { get { return this.difference; }}

		//generate a number within the range from a normalized (0 to 1) value.
		//value will be clamped within minimum and maximum unless clamped = false
		TRangeType ILimitedRange<TRangeType>.FromNormalized (float normalized, bool clamped)
		{
			if (clamped)
			{ normalized = UnityEngine.Mathf.Clamp(value: normalized, min: 0f, max: 1f); }

			return this.FromNormal(normalized);
		}

		//get a normalized value (0 to 1) from a numeric value within the range.
		//value will be clamped within minimum and maximum unless clamped = false
		float ILimitedRange<TRangeType>.ToNormalized (TRangeType value, bool clamped)
		{
			float normal = this.ToNormal(value);

			if (clamped)
			{ normal = UnityEngine.Mathf.Clamp(value: normal, min: 0f, max: 1f); }

			return normal;
		}
	//ENDOF ILimitedRange

	//ILimitedRangeMutable implementation
		//setters for min and max values of the range
		TRangeType ILimitedRangeMutable<TRangeType>.minimum
		{ set { this.minimum = value; }}

		TRangeType ILimitedRangeMutable<TRangeType>.maximum
		{ set { this.maximum = value; }}
	//ENDOF ILimitedRangeMutable 

	//constructor
		public BaseNumericRange (TRangeType minimum, TRangeType maximum)
		{
			this.minimum = minimum;
			this.maximum = maximum;
		}
	//ENDOF constructor

	//overridable properties
		//get a random value within this range
		//simply generates a value from a random 0.0 - 1.0 floating value
		protected virtual TRangeType random
		{ get { return this.FromNormal(UnityEngine.Random.value); }}

		//gets value within defined range currently represented by this object
		protected abstract TRangeType value { get; }

		//difference between maximum and minimum values
		protected abstract TRangeType difference { get; }
	//ENDOF overridable properties

	//overridable methods
		//returns value within the range from a 0 to 1 value
		//needs not have any consideration for value clamping, this is handled by base class
		protected abstract TRangeType FromNormal (float normal); //return minimum + (difference * normalized);

		//returns a normalized (0 to 1) from a value within the range
		//needs not have any consideration for value clamping, this is handled by base class
		protected abstract float ToNormal (TRangeType value);
	//ENDOF overridable methods
	}
}
