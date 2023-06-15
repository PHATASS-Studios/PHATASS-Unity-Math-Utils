using UnityEngine;

namespace PHATASS.Utils.Types
{
	[System.Serializable]
	public class IntAccumulator : IIntAccumulator
	{
	//Serialized fields
		[Tooltip("Current accumulated value.")]
		[SerializeField]
		private int value = 0;
	//ENDOF Serialized fields

	//IAccumulator<int>
		void PHATASS.Utils.Events.ISimpleEventReceiver<int>.Event (int param0)
		{ this.Add(param0); }
	//ENDOF IAccumulator<int>

	//IValue<int>
		int PHATASS.Utils.Types.Values.IValue<int>.value { get { return this.value; }}
	//ENDOF IValue<int>

	//IResettable
		void PHATASS.Utils.Types.IResettable.Reset ()
		{ this.Reset(); }
	//ENDOF IResettable

	//private
		private void Add (int addendum)
		{ this.value += addendum; }

		private void Reset ()
		{ this.value = 0; }
	//ENDOF private
	}
}
