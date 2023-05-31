using System;
using System.Collections;
using System.Collections.Generic;

using static PHATASS.Utils.Extensions.IListExtensions;

using PHATASS.Interfaces.Mergeables;	//IMergeable<TMergeable>
using PHATASS.Utils.Types.Priorizables;	//IPriorizable<TPriorizable>
using static PHATASS.Utils.Types.Priorizables.PriorizableExtensions;

using NotSupportedException = System.NotSupportedException;

using Debug = UnityEngine.Debug;

using SerializedTypeRestrictionAttribute = PHATASS.Utils.Attributes.SerializedTypeRestrictionAttribute;

using GameObject = UnityEngine.GameObject;
using IAction = PHATASS.ActionSystem.IAction;

namespace PHATASS.Utils.Callbacks
{
	[System.Serializable]
	public class UpdatableCallbackStack : IUpdatableCallbackStack
	{
	//IUpdatableCallbackStack
	//ENDOF IUpdatableCallbackStack

	//IMerger<IUpdatableCallbackStack>
		IUpdatableCallbackStack IMerger<IUpdatableCallbackStack>.Merge (IList<IUpdatableCallbackStack> mergeables)
		{
			//first sort candidates by priority
			mergeables = mergeables.ESortByPriority<IUpdatableCallbackStack>();

			//count the total amount of IUpdatableCallback items in the stacks
			int totalCount = 0;
			foreach (IUpdatableCallbackStack stack in mergeables)
			{ totalCount += stack.Count; }

			IUpdatableCallback[] callbacks = new IUpdatableCallback[totalCount];

			totalCount = 0;
			foreach (IUpdatableCallbackStack stack in mergeables)
			{
				stack.CopyTo(callbacks, totalCount);
				totalCount += stack.Count;
			}

			return new UpdatableCallbackStack(callbacks);
		}
	//ENDOF IMerger<IUpdatableCallbackStack>

	//IComparable<IUpdatableCallbackStack>
		int IComparable<IUpdatableCallbackStack>.CompareTo (IUpdatableCallbackStack other)
		{
			/* [DEBUG]
			Debug.Log(string.Format("{0}.CompareTo({1})", typeof(IUpdatableCallbackStack), other));
			if (other == null) { Debug.Log("!> other is NULL"); }
			//*/

			if (other == null) { return 1; }

			return this.priority.CompareTo(other.priority);
		}

		/*
		//comparison operators overload. Compares between objects of this class and IPriorizable<T> of a similar type T
		public static bool operator > (UpdatableCallbackStack operand1, IPriorizable<IUpdatableCallbackStack> operand2)
		{ return operand1.CompareTo(operand2) > 0; }

		public static bool operator < (UpdatableCallbackStack operand1, IPriorizable<IUpdatableCallbackStack> operand2)
		{ return operand1.CompareTo(operand2) < 0; }

		public static bool operator >= (UpdatableCallbackStack operand1, IPriorizable<IUpdatableCallbackStack> operand2)
		{ return operand1.CompareTo(operand2) >= 0; }

		public static bool operator <= (UpdatableCallbackStack operand1, IPriorizable<IUpdatableCallbackStack> operand2)
		{ return operand1.CompareTo(operand2) <= 0; }

		public static bool operator == (UpdatableCallbackStack operand1, IPriorizable<IUpdatableCallbackStack> operand2)
		{ return operand1.CompareTo(operand2) == 0; }

		public static bool operator != (UpdatableCallbackStack operand1, IPriorizable<IUpdatableCallbackStack> operand2)
		{ return operand1.CompareTo(operand2) != 0; }
		//*/
	//ENDOF IComparable<IUpdatableCallbackStack>

	//IPriorizable<IUpdatableCallbackStack>
		[UnityEngine.SerializeField]
		[UnityEngine.Tooltip("Merge priority of this stack")]
		private int _priority;
		private int priority { get { return this._priority; }}
		int IPriorizable<IUpdatableCallbackStack>.priority { get { return this.priority; }}
	//ENDOF IPriorizable<IUpdatableCallbackStack>

	//IUpdatableCallback
		void IUpdatableCallback.ExecuteStart (ICallbackContext context)
		{
			foreach (IUpdatableCallback callback in this.callbackList)
			{ callback.ExecuteStart(context); }
		}

		void IUpdatableCallback.ExecuteUpdate (ICallbackContext context)
		{
			foreach (IUpdatableCallback callback in this.callbackList)
			{ callback.ExecuteUpdate(context); }
		}

		void IUpdatableCallback.ExecuteEnded (ICallbackContext context)
		{
			foreach (IUpdatableCallback callback in this.callbackList)
			{ callback.ExecuteEnded(context); }
		}
	//ENDOF IUpdatableCallback

	//IList<IUpdatableCallback>
		IUpdatableCallback IList<IUpdatableCallback>.this[int index]
		{
			get { return this.callbackList[index]; }
			set { throw new NotSupportedException("UpdatableCallbackStack is READONLY, this[#].set unsuported"); }
		}

		int IList<IUpdatableCallback>.IndexOf (IUpdatableCallback item)
		{ return this.callbackList.IndexOf(item); }

		void IList<IUpdatableCallback>.Insert (int index, IUpdatableCallback item)
		{ throw new NotSupportedException("UpdatableCallbackStack is READONLY, Insert() unsuported"); }

		void IList<IUpdatableCallback>.RemoveAt (int index)
		{ throw new NotSupportedException("UpdatableCallbackStack is READONLY, RemoveAt() unsuported"); }
	//ENDOF IList<IUpdatableCallback>

	//IEnumerable<IUpdatableCallback>
		IEnumerator IEnumerable.GetEnumerator ()
		{ return this.callbackList.GetEnumerator(); }
		
		IEnumerator<IUpdatableCallback> IEnumerable<IUpdatableCallback>.GetEnumerator ()
		{ return this.callbackList.GetEnumerator(); }
	//ENDOF IEnumerable<IUpdatableCallback>

	//ICollection<IUpdatableCallback>
		int ICollection<IUpdatableCallback>.Count { get { return this.callbackList.Count; }}
		bool ICollection<IUpdatableCallback>.IsReadOnly { get { return true; }}
		//public bool IsSynchronized { get { return callbackList.IsSynchronized; }}
		//public System.Object SyncRoot { get { return callbackList.SyncRoot; }}

		void ICollection<IUpdatableCallback>.Add (IUpdatableCallback item)
		{ throw new NotSupportedException("UpdatableCallbackStack is READONLY, Add() unsuported"); }

		void ICollection<IUpdatableCallback>.Clear ()
		{ throw new NotSupportedException("UpdatableCallbackStack is READONLY, Clear() unsuported"); }

		bool ICollection<IUpdatableCallback>.Contains (IUpdatableCallback item)
		{ return this.callbackList.Contains(item); }

		void ICollection<IUpdatableCallback>.CopyTo (IUpdatableCallback[] array, int arrayIndex)
		{ this.callbackList.CopyTo(array, arrayIndex); }

		bool ICollection<IUpdatableCallback>.Remove (IUpdatableCallback item)
		{ throw new NotSupportedException("UpdatableCallbackStack is READONLY, Remove() unsuported"); }
	//ENDOF ICollection<IUpdatableCallback>

	//constructor
		public UpdatableCallbackStack ()
		{
			this._callbackList = new List<UnityEngine.Object>();
		}

		public UpdatableCallbackStack (IList<IUpdatableCallback> callbacks)
		{
			this._callbackList = callbacks
				//.ESortByPriority<IUpdatableCallbackStack>(alloc: true)
				.EMListCastToList<IUpdatableCallback, UnityEngine.Object>();
		}
	//ENDOF constructor

	//private fields
		//action callbacks backing list
		[UnityEngine.Tooltip("List of callbacks")]
		[UnityEngine.SerializeField]
		[SerializedTypeRestriction(typeof(IUpdatableCallback))]
		private List<UnityEngine.Object> _callbackList = null;
		private IList<IUpdatableCallback> _callbackListAccessor = null;
		private IList<IUpdatableCallback> callbackList
		{
			get
			{
				//create accessor if unavailable
				if (this._callbackListAccessor == null && this._callbackList != null)
				{ this._callbackListAccessor = new PHATASS.Utils.Types.Wrappers.UnityObjectListCastedAccessor<IUpdatableCallback>(this._callbackList); }

				return this._callbackListAccessor;
			}
		}
	//ENDOF private fields
	}
}