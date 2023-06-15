using SerializeField = UnityEngine.SerializeField;

namespace PHATASS.Utils.Types.Ranges
{
	//Base class defining a range of values of any abstract type
	//includes a minimum, maximum, and interpolated values
	[System.Serializable]
	public abstract class BaseNumericRange <TRangeType>
		: ILimitedRange<TRangeType>
	{
	//serialized fields
		[SerializeField]
		protected TRangeType minimum;

		[SerializeField]
		protected TRangeType maximum;
	//ENDOF serialized fields

	//IValue<TRangeType>
		//value currently represented by this range
		TRangeType IValue<TRangeType>.value { get { return this.GetValue(); }}
	//ENDOF IValue<TRangeType>

	//IConstraint<TRangeType>
		//clamps a value between minimum and maximum, inclusive
		TRangeType PHATASS.Utils.Types.Constraints.IConstraint<TRangeType>.Clamp (TRangeType value) { return this.Clamp(value); }

		// Returns true if value is in or on the constraint's limits defined
		bool PHATASS.Utils.Types.Constraints.IConstraint<TRangeType>.Contains (TRangeType value) { return this.Contains(value); }
	//ENDOF IConstraint<TRangeType>

	//ILimitedRange<TRangeType> implementation
		//min and max values of the range
		TRangeType ILimitedRange<TRangeType>.minimum
		{ get { return this.minimum; }}

		TRangeType ILimitedRange<TRangeType>.maximum
		{ get { return this.maximum; }}

		//get a random value within this range
		TRangeType ILimitedRange<TRangeType>.random { get { return this.random; }}

		//difference between maximum and minimum values
		TRangeType ILimitedRange<TRangeType>.difference { get { return this.difference; }}

		//generate a number within the range from a normalized (0 to 1) value.
		//value will be clamped within minimum and maximum unless clamped = false
		TRangeType ILimitedRange<TRangeType>.FromNormalized (float normalized, bool clamped) { return this.FromNormalized(normalized, clamped); }
		protected TRangeType FromNormalized (float normalized, bool clamped) 
		{
			if (clamped)
			{ normalized = UnityEngine.Mathf.Clamp(value: normalized, min: 0f, max: 1f); }

			return this.FromNormal(normalized);
		}

		//get a normalized value (0 to 1) from a numeric value within the range.
		//value will be clamped within minimum and maximum unless clamped = false
		float ILimitedRange<TRangeType>.ToNormalized (TRangeType value, bool clamped) { return this.ToNormalized(value, clamped); }
		protected float ToNormalized (TRangeType value, bool clamped)
		{
			float normal = this.ToNormal(value);

			if (clamped)
			{ normal = UnityEngine.Mathf.Clamp(value: normal, min: 0f, max: 1f); }

			return normal;
		}

		// Returns the distance between given value and the closest point of the range.
		//	If given value falls inside the range, returned value is 0.
		//	If keepSign = true, return sign is negative for values below minimum. Otherwise Sign is always positive.
		TRangeType ILimitedRange<TRangeType>.DistanceFromRange (TRangeType value, bool keepSign) { return this.DistanceFromRange(value, keepSign); }
	//ENDOF ILimitedRange

	/*
	//ILimitedRangeMutable implementation
		//setters for min and max values of the range
		TRangeType ILimitedRangeMutable<TRangeType>.minimum
		{ set { this.minimum = value; }}

		TRangeType ILimitedRangeMutable<TRangeType>.maximum
		{ set { this.maximum = value; }}
	//ENDOF ILimitedRangeMutable 
	*/

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

		//difference between maximum and minimum values
		protected abstract TRangeType difference { get; }
	//ENDOF overridable properties

	//overridable methods
		//gets value within defined range currently represented by this object
		protected abstract TRangeType GetValue ();

		// Returns value within the range from a 0 to 1 value
		//needs not have any consideration for value clamping, this is handled by base class
		protected abstract TRangeType FromNormal (float normal); //return minimum + (difference * normalized);

		// Returns a normalized (0 to 1) from a value within the range
		//needs not have any consideration for value clamping, this is handled by base class
		protected abstract float ToNormal (TRangeType value);

		// Clamps a value between minimum and maximum, inclusive
		protected abstract TRangeType Clamp (TRangeType value);

		// Returns true if value is in or on the constraint's limits defined
		protected abstract bool Contains (TRangeType value);

		// Returns the distance between given value and the closest point of the range.
		//	If given value falls inside the range, returned value is 0.
		//	If keepSign = true, return sign is negative for values below minimum. Otherwise Sign is always positive.
		protected abstract TRangeType DistanceFromRange (TRangeType value, bool keepSign);
	//ENDOF overridable methods
	}
}
