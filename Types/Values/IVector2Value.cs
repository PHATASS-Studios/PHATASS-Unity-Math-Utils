using Vector2 = UnityEngine.Vector2;

namespace PHATASS.Utils.Types.Values
{
	public interface IVector2Value: IValue <Vector2> {}

	public interface IVector2ValueMutable : IFloatValue, IValueMutable <Vector2> { }
}