using UnityEngine;

using SerializableAnimatorVariableIdentifier = PHATASS.Utils.Types.SerializableAnimatorVariableIdentifier;

using DParameterlessDelegate = PHATASS.Utils.Types.Toggleables.DParameterlessDelegate;

namespace PHATASS.Utils.Types.Toggleables
{
// Base MonoBehaviour that offers a basic implementation of IAnimatedToggleable through an UnityEngine.Animator
//	
//	> State change request is done by setting an animator bool to true/false
//	> analogTransitionProgress is tracked through a serialized float field that MUST be changed through the animator - otherwise it won't be tracked.
//	> StrictStateCheck() is resolved by checking analogTransitionProgress
//	> ForceSetState() is achieved by setting a ForcedStateChange trigger on the animator alongside the state change bool. How is it handled depends entirely on the animators/animations related.
//	> TransitionStateWithCallback() enqueues an additional callback delegate to trigger after current transition is completed
//
	public abstract class BaseAnimatorToggleableBehaviour :
		MonoBehaviour,
		IAnimatedToggleable
	{
	//Serialized fields
		[Tooltip("Animator component used to handle state transitions")]
		[SerializeField]
		private Animator animator;

		[Tooltip("State animator bool variable. Will be set to true/false to request state change.")]
		[SerializeField]
		private SerializableAnimatorVariableIdentifier desiredStateBoolId = "State";

		[Tooltip("Animator trigger variable. If ForceSetState() is requested this trigger will be set alongside the state change bool.")]
		[SerializeField]
		private SerializableAnimatorVariableIdentifier forcedStateChangeTriggerId = "Forced";

		[Tooltip("MUST SET THIS THROUGH THE ANIMATOR. Transition progress tracker. The animator should set this serialized field to 0f (fully disabled) through 1f (fully enabled) over time as state changes.")]
		[SerializeField]
		private float transitionProgress;
		protected float clampedTransitionProgress
		{ get { return System.Math.Clamp(value: this.transitionProgress, min: 0f, max: 1f); }}

		[Tooltip("If this is true, animator's gameObject will be disabled when disabled state is reached")]
		[SerializeField]
		private bool disableGameObject = true;
	//ENDOF Serialized

	//IAnimatedToggleable
		// Toggles this element on or off, or returns the currently DESIRED state
		bool IToggleable.state
		{
			get { return this.state; }
			set { this.state = value; }
		}

		// Returns the state of the transition between enabled (1f) and disabled (0f)
		//	> 0 means fully disabled/false
		//	> 1 means fully enabled/true
		//	> Decimal values between 0 and 1 represents the current progress of the change between those states
		float IAnimatedToggleable.analogTransitionProgress
		{ get { return this.clampedTransitionProgress; }}

		// Returns true ONLY if any transition between states has finished AND current state is requiredState
		bool IAnimatedToggleable.StrictStateCheck (bool requiredState)
		{ return this.StrictStateCheck(requiredState); }

		// Transitions current state to desiredState, and triggers finishingCallback when transition finished
		//	returns false if transition fails because initial state == desiredState, true otherwise
		//	finishingCallback can be null, in which case it won't get invoked
		bool IAnimatedToggleable.TransitionStateWithCallback (bool desiredState, DParameterlessDelegate finishingCallback)
		{ return this.TransitionStateWithCallback(desiredState, finishingCallback); }

		// Immediately force set given state
		void IAnimatedToggleable.ForceSetState (bool desiredState)
		{ this.ForceSetState(desiredState); }
	//ENDOF IAnimatedToggleable

	//MonoBehaviour lifecycle
		protected virtual void Awake ()
		{
			if (this.animator == null) { this.animator = this.GetComponent<Animator>(); }
		}

		protected virtual void Update ()
		{
			this.TryTriggerCallbacks();
		}
	//ENDOF MonoBehaviour

	//protected members
		//sets or gets current desired state from the animator
		protected bool state 
		{
			get
			{
				if (!this.animator.gameObject.activeInHierarchy) { return false; }
				return this.animator.GetBool(this.desiredStateBoolId);
			}
			set {
				if (value == true && !this.animator.gameObject.activeSelf)
				{ this.animator.gameObject.SetActive(true); }
				if (this.state == value) { return; }
				this.animator.SetBool(this.desiredStateBoolId, value);
			}
		}

		//returns true if this toggleable's state is changing. Returns false only if it has arrived at target state
		protected bool isTransitioning
		{ get {
			bool desiredState = this.state;
			if (desiredState == true && this.transitionProgress >= 1f
			||	desiredState == false && this.transitionProgress <= 0f)
			{
				return false;
			}
			return true;
		}}

		// Returns true ONLY if any transition between states has finished AND current state is requiredState
		protected bool StrictStateCheck (bool requiredState)
		{
			if (requiredState != this.state) { return false; }

			return !this.isTransitioning;
		}

		protected void ForceSetState (bool desiredState)
		{
			this.animator.SetTrigger(this.forcedStateChangeTriggerId);
			this.state = desiredState;
		}

		protected bool TransitionStateWithCallback (bool desiredState, DParameterlessDelegate finishingCallback)
		{
			if (this.state == desiredState) { return false; }

			if (desiredState == true) { this.queuedOnEnableCallback = finishingCallback; }
			else { this.queuedOnDisableCallback = finishingCallback; }

			this.state = desiredState;
			return true;
		}
	//ENDOF protected

	//private
		private DParameterlessDelegate queuedOnEnableCallback = null;
		private DParameterlessDelegate queuedOnDisableCallback = null;

		//tries to trigger OnEnable/OnDisable callbacks if necessary, then resets them.
		private void TryTriggerCallbacks ()
		{
			bool desiredState = this.state;

			if (this.queuedOnEnableCallback != null)
			{
				if (desiredState == true && this.transitionProgress >= 1f)
				{ this.TriggerOnEnableCallbacks(); }
			}

			if (this.queuedOnDisableCallback != null)
			{
				if (desiredState == false && this.transitionProgress <= 0f)
				{ this.TriggerOnDisableCallbacks(); }
			}
		}

		protected virtual void TriggerOnEnableCallbacks ()
		{
			this.queuedOnEnableCallback.Invoke();
			this.queuedOnEnableCallback = null;			
		}

		protected virtual void TriggerOnDisableCallbacks ()
		{
			this.queuedOnDisableCallback.Invoke();
			this.queuedOnDisableCallback = null;

			//check if we must disable gameobject after triggering disable callbacks
			if (this.disableGameObject)
			{ this.animator.gameObject.SetActive(false); }
		}
	//ENDOF private
	}	
}
