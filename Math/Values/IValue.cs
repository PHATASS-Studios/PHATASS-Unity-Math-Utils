namespace PHATASS.Utils.Math
{
	public interface IValue <TValueType>
	{
		TValueType value { get; }
	}

	public interface IValueMutable <TValueType> :
		IValue <TValueType>
	{
		new TValueType value { set; }
	}
}