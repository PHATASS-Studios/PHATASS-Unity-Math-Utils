using TRangeType = System.Int32;

namespace PHATASS.Utils.Math.Ranges
{
	//floating point numeric range subclass
	[System.Serializable]
	public class RandomIntRange : BaseNumericRange<TRangeType>
	{
	//constructor
		public RandomIntRange (TRangeType minimum, TRangeType maximum) : base(minimum, maximum) {}
	//ENDOF constructor

	//property overrides
		protected override TRangeType value
		{ get { return this.random; }}

		public override TRangeType difference
		{ get { return this.maximum - this.minimum; }}
	//ENDOF property overrides

	//method overrides
		protected override TRangeType FromNormal (float normal)
		{
			return this.minimum + (TRangeType) (this.difference * normal);
		}

		//returns a normalized (0 to 1) from a value within the range, without any consideration for value clamping
		protected override float ToNormal (TRangeType value)
		{
			return ((float) (value - this.minimum)) / this.difference;
		}
	//ENDOF method overrides
	}
}