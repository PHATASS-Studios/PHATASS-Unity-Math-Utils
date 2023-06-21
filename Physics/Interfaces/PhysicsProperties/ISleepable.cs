namespace PHATASS.Utils.Physics
{
// Interface representing an object that can become asleep for physics optimization
	public interface ISleepable
	{
	// While asleep = true, the following is true:
	//	> A body's energy/momentum is considered 0
	//	> All physics operations that operate upon an object's current energy/momentum can be skipped
	//	> Physics operations that add forces should NOT be skipped. They will awake the object as necessary.
		bool asleep { get; }
	}
}
