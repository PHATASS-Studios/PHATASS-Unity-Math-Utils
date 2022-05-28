using IDisposable = System.IDisposable;
using IEnumerator = System.Collections.IEnumerator;
using System.Collections.Generic;

namespace PHATASS.Utils.Enumerables
{
	// This class acts as an enumerator that allows casted access to any IEnumerable
	// every element will be enumerated casted as TOut
	public class ListCastedEnumerator <TIn, TOut> :
		IEnumerator<TOut>
		where TOut : class
	{
	//IEnumerator
		object IEnumerator.Current { get { return this.current; }}
		bool IEnumerator.MoveNext () { return this.MoveNext(); }
		void IEnumerator.Reset () { this.Reset(); }
	//ENDOF IEnumerator

	//IEnumerator<TOut>
		TOut IEnumerator<TOut>.Current { get { return this.current; }}
	//ENDOF IEnumerator<TOut>

	//IDisposable
		void IDisposable.Dispose () { /*intentionally left empty*/ }
	//ENDOF IDisposable

	//Constructor
		public ListCastedEnumerator (IList<TIn> inputList)
		{ this.list = inputList; }
	//ENDOF Constructor

	//private fields
		private IList<TIn> list;
		private int index = -1;
		private TOut current = null;
	//ENDOF private fields

	//private methods
		private bool MoveNext ()
		{
			this.index++;
			if (this.index >= this.list.Count) { return false; }
			this.current = (this.list[index] as TOut);
			return true;
		}

		private void Reset ()
		{
			this.index = -1;
			this.current = null;
		}
	//ENDOF private methods
	}
}