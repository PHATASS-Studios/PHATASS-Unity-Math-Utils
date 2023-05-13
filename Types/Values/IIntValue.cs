namespace PHATASS.Utils.Types
{
	public interface IIntValue: IValue <int> {}

	public interface IIntValueMutable : IIntValue, IValueMutable <int> { }
}