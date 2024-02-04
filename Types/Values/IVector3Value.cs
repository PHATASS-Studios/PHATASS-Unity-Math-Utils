using Vector3 = UnityEngine.Vector3;

namespace PHATASS.Utils.Types.Values
{
	public interface IVector3Value: IValue <Vector3> {}

	public interface IVector3ValueMutable : IVector3Value, IValueMutable <Vector3> { }
}