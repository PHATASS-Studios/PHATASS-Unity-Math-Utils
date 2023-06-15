namespace PHATASS.Utils.Types.Constraints
{
// Interface representing a generic constraint of any type TValue. Can constrain or clamp any value of type TValue.
	public interface IConstraint <TValue>
	{
		// Clamps and returns passed value as determined by this constraint. Returns value unchanged if is considered within the constraint's limits
		TValue Clamp (TValue value);

		// Returns true if value is in or on the constraint's limits defined
		bool Contains (TValue value);
	}
}