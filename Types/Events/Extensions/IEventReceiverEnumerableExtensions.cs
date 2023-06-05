using System.Collections.Generic;
using PHATASS.Utils.Events;

namespace PHATASS.Utils.Events
{
	public static class IEventReceiverEnumerableExtensions
	{
		public static void ETriggerAll <TParam0> (this IEnumerable<ISimpleEventReceiver<TParam0>> enumerable, TParam0 param0)
		{
			foreach (ISimpleEventReceiver<TParam0> receiver in enumerable)
			{ receiver.Event(param0); }
		}
	}
}