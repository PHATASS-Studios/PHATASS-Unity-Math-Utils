using System.Collections.Generic;
using System.Collections;
using Transform = UnityEngine.Transform;

namespace PHATASS.Utils.Types.Wrappers
{
	[System.Serializable]
	public struct EditorSelectableTransformList : IList<Transform>
	{
	//private fields
		[UnityEngine.SerializeField]
		private List<Transform> _list;
		private IList<Transform> list { get { return this._list; }}
	//ENDOF private fields

	//IList<Transform>
		Transform IList<Transform>.this[int index]
		{ get { return this.list[index]; } set { this.list[index] = value; }}

		int IList<Transform>.IndexOf (Transform item)
		{ return this.list.IndexOf(item); }

		void IList<Transform>.Insert (int index, Transform item)
		{ this.list.Insert(index, item); }

		void IList<Transform>.RemoveAt (int index)
		{ this.list.RemoveAt(index); }
	//ENDOF IList<Transform>

	//ICollection<Transform>
		int ICollection<Transform>.Count
		{ get { return this.list.Count; }}

		bool ICollection<Transform>.IsReadOnly
		{ get { return this.list.IsReadOnly; }}

		void ICollection<Transform>.Add (Transform item)
		{ this.list.Add(item); }

		void ICollection<Transform>.Clear ()
		{ this.list.Clear(); }

		bool ICollection<Transform>.Contains (Transform item)
		{ return this.list.Contains(item); }

		void ICollection<Transform>.CopyTo(Transform[] array, int arrayIndex)
		{ this.list.CopyTo(array, arrayIndex); }

		bool ICollection<Transform>.Remove (Transform item)
		{ return this.list.Remove(item); }
	//ENDOF ICollection<Transform>

	//IEnumerable<Transform>
		IEnumerator<Transform> IEnumerable<Transform>.GetEnumerator ()
		{ return this.list.GetEnumerator(); }
	//ENDOF IEnumerable<Transform>

	//IEnumerable
		IEnumerator IEnumerable.GetEnumerator ()
		{ return this.list.GetEnumerator(); }
	//ENDOF IEnumerable
	}
}