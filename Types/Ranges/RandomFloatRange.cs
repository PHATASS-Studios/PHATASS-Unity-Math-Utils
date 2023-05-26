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
		protected override TFloat GetValue ()
		{ return this.random; }

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
	//ENDOF method overrides

	//operator overrides
		public static implicit operator RandomFloatRange(TFloat value) { return new RandomFloatRange(value, value); }
	//ENDOF operator overrides
	}
}