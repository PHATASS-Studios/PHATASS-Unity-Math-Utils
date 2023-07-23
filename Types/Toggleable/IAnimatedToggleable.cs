namespace PHATASS.Utils.Types
{
	// Interface representing an element that can be toggled on/off (true/false)
	// with the specification that the change between on/off states happens over a certain ammount of time
	//
	//	base.toggleState { get; set; }
	//		set() performs an animated state change over time
	//		get() returns currently DESIRED state
	//
	public interface IAnimatedToggleable : IToggleable
	{
	// Returns the state of the transition between enabled (1f) and disabled (0f)
	//	> 0 means fully disabled/false
	//	> 1 means fully enabled/true
	//	> Decimal values between 0 and 1 represents the current progress of the change between those states
		float analogTransitionProgress { get; }

	// Returns true ONLY if any transition between states has finished AND current state is requiredState
		bool StrictStateCheck (bool requiredState);

	// Transitions current state to desiredState, and triggers finishingCallback when transition finished
	//	returns false if transition fails because initial state == desiredState, true otherwise
	//	finishingCallback can be null, in which case it won't get invoked
		bool TransitionStateWithCallback (bool desiredState, DParameterlessDelegate finishingCallback);

	// Immediately force set given state
		void ForceSetState (bool desiredState);	
	}

	public delegate void DParameterlessDelegate ();	
}
