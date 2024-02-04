using Vector3 = UnityEngine.Vector3;

namespace PHATASS.Utils.Types.Values
{
	public interface IStringValue : IValue <string> {}

	public interface IStringValueMutable : IStringValue, IValueMutable <string> { }
}