using TFloat = System.Single;

namespace PHATASS.Utils.Types.Ranges
{
	//floating point numeric range subclass
	[System.Serializable]
	public class RandomFloatRange : BaseNumericRange<TFloat>
	{
	//constructor
		public RandomFloatRange (TFloat minimum, TFloat maximum) : base(minimum, maximum){}
	//ENDOF constructor

	//property overrides
		protected override TFloat difference
		{ get { return this.maximum - this.minimum; }}
	//ENDOF property overrides

	//method overrides
		protected override TFloat FromNormal (float normal)
		{
			return this.minimum + (this.difference * normal);
		}

		//returns a normalized (0 to 1) from a value within the range, without any consideration for value clamping
		protected override float ToNormal (TFloat value)
		{
			return (value - this.minimum) / this.difference;
		}

		//clamps a value between minimum and maximum, inclusive
		protected override TFloat Clamp (TFloat value)
		{ return UnityEngine.Mathf.Clamp(value: value, min: this.minimum, max: this.maximum); }

		// Returns true if value is in or on the constraint's limits defined
		protected override bool Contains (TFloat value)
		{ return value >= this.minimum && value <= this.maximum; }

		// Returns the distance between given value and the closest point of the range.
		//	If given value falls inside the range, returned value is 0.
		//	If keepSign = true, return sign is negative for values below minimum. Otherwise Sign is always positive.
		protected override TFloat DistanceFromRange (TFloat value, bool keepSign)
		{
			if (value >= this.minimum)
			{
				//if value is above minimum and below maximum, it is inside the range and we return 0
				if (value <= this.maximum) { return 0f; }
				else { return value - this.maximum; } //if value is above maximum return difference
			}
			else
			{
				//if value is below minimum return difference
				if (keepSign) { return value - this.minimum; }	//if keepSign == true, sign is meant to represent direction
				else { return this.minimum - value; }
			}
		}
	//ENDOF method overrides

	//operator overrides
		public static implicit operator RandomFloatRange(TFloat value) { return new RandomFloatRange(value, value); }
	//ENDOF operator overrides
	}
}