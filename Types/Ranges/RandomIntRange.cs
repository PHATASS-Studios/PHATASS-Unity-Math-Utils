using TInt = System.Int32;

namespace PHATASS.Utils.Types.Ranges
{
	//floating point numeric range subclass
	[System.Serializable]
	public class RandomIntRange : BaseNumericRange<TInt>
	{
	//constructor
		public RandomIntRange (TInt minimum, TInt maximum) : base(minimum, maximum) {}
	//ENDOF constructor

	//property overrides
		protected override TInt difference
		{ get { return this.maximum - this.minimum; }}
	//ENDOF property overrides

	//method overrides
		protected override TInt GetValue ()
		{ return this.random; }

		protected override TInt FromNormal (float normal)
		{
			return this.minimum + (TInt) (this.difference * normal);
		}

		//returns a normalized (0 to 1) from a value within the range, without any consideration for value clamping
		protected override float ToNormal (TInt value)
		{
			return ((float) (value - this.minimum)) / this.difference;
		}

		//clamps a value between minimum and maximum, inclusive
		protected override TInt Clamp (TInt value)
		{ return UnityEngine.Mathf.Clamp(value: value, min: this.minimum, max: this.maximum);	}
	//ENDOF method overrides

	//operator overrides
		public static implicit operator RandomIntRange(TInt value) { return new RandomIntRange(value, value); }
	//ENDOF operator overrides
	}
}