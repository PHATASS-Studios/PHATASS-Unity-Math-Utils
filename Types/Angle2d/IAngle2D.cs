namespace PHATASS.Utils.Types
{
	// Exposes properties and ways to manage a single angle
	// Degrees/radians must always be wrapped around the 0-360 degrees range
	public interface IAngle2D
	{
	//value accessors
		float degrees { get; }
		float radians { get; }

	//Mathematical operations
		IAngle2D Invert ();	//inverts the sign of the angle

		IAngle2D Add (IAngle2D angle);
		IAngle2D Subtract (IAngle2D angle);

		IAngle2D Multiply (float multiplier);
		IAngle2D Divide (float divider);

		IAngle2D Modulus (IAngle2D divider);
	}
}
