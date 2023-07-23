namespace PHATASS.Utils.Types
{
	// Interface representing an element that can be toggled on/off (true/false)
	public interface IToggleable
	{
		// Toggles this element on or off, or returns the currently DESIRED state
		bool toggleState { get; set; }
	}
}
