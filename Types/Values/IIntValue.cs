namespace PHATASS.Utils.Types.Values
{
	public interface IIntValue: IValue <int> {}

	public interface IIntValueMutable : IIntValue, IValueMutable <int> { }
}