using UnityEngine;
using System.Collections.Generic;

using static PHATASS.Utils.Events.IEventReceiverEnumerableExtensions;

using SerializedTypeRestrictionAttribute = PHATASS.Utils.Attributes.SerializedTypeRestrictionAttribute;

namespace PHATASS.Utils.Events
{
// Generic event conditional repropagator
//	When receiving an Event(param) call, a condition is checked
//	If this condition is validated, repropagates the event to all registered receivers
	public abstract class BaseConditionalSimpleEventPropagatorBehaviour <TParam0> :
		MonoBehaviour,
		ISimpleEventReceiver<TParam0>
	{
	//ISimpleEventReceiver<TParam0>
		void ISimpleEventReceiver<TParam0>.Event (TParam0 param0)
		{ this.Event(param0); }
	//ENDOF ISimpleEventReceiver<TParam0>

	//abstract members
		// Propagation condition checking method. Whenever an event is received, re-propagation will only be performed if this returns true.
		protected abstract bool CheckCondition (TParam0 param0);

		// Override this with the serialized list of receivers
		protected abstract List<UnityEngine.Object> receiversBacking { get; }
		/*
		[Tooltip("List of Event receivers to which received events will be propagated if condition is met.")]
		[SerializeField]
		[SerializedTypeRestriction(typeof(ISimpleEventReceiver<TParam0>))]
		*/
	//ENDOF abstract

	//private
		private IList<ISimpleEventReceiver<TParam0>> _receiversAccessor = null;	// Wrapper cache. We store here our IList<ISimpleEventReceiver<TParam0>> wrapper for easy access
		private IList<ISimpleEventReceiver<TParam0>> receivers						// Getter property. Access this to get a usable IList<ISimpleEventReceiver<TParam0>>
		{ get {
				if (this._receiversAccessor == null && this.receiversBacking != null) //create accessor if unavailable
				{ this._receiversAccessor = new PHATASS.Utils.Types.Wrappers.UnityObjectListCastedAccessor<ISimpleEventReceiver<TParam0>>(this.receiversBacking); }

				return this._receiversAccessor;
			}
		}

		private void Event (TParam0 param0)
		{
			if (this.CheckCondition(param0))
			{ this.Propagate(param0); }
		}

		private void Propagate (TParam0 param0)
		{
			this.receivers.ETriggerAll(param0);
		}
	//ENDOF private
	}
}