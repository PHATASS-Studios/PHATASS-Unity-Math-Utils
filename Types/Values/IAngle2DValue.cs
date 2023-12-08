using IAngle2D = PHATASS.Utils.Types.Angles.IAngle2D;

namespace PHATASS.Utils.Types.Values
{
	public interface IAngle2DValue: IValue <IAngle2D> {}

	public interface IAngle2DValueMutable : IAngle2DValue, IValueMutable <IAngle2D> { }
}