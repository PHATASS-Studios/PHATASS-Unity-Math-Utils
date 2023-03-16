using IDisposable = System.IDisposable;
using IEnumerator = System.Collections.IEnumerator;
using System.Collections.Generic;

namespace PHATASS.Utils.Enumerables
{
	// This class acts as an enumerator that allows casted access to any IEnumerable<TIn>
	// every element will be enumerated casted as TOut.
	//	miscasts return as null.
	public class TypeCastedEnumerator <TOut> :
		IEnumerator<TOut>
		where TOut : class
	{
	//IEnumerator
		object IEnumerator.Current { get { return this.inputEnumerator.Current; }}
		bool IEnumerator.MoveNext () { return this.inputEnumerator.MoveNext(); }
		void IEnumerator.Reset () { this.inputEnumerator.Reset(); }
	//ENDOF IEnumerator

	//IEnumerator<TOut>
		TOut IEnumerator<TOut>.Current { get { return (this.inputEnumerator.Current as TOut); }}
	//ENDOF IEnumerator<TOut>

	//IDisposable
		void IDisposable.Dispose () { (this.inputEnumerator as IDisposable)?.Dispose(); }
	//ENDOF IDisposable

	//Constructor
		public TypeCastedEnumerator (IEnumerator inputEnumerator)
		{ this.inputEnumerator = inputEnumerator; }
	//ENDOF Constructor

	//private fields
		private IEnumerator inputEnumerator;
	//ENDOF private fields

	//private methods
	//ENDOF private methods
	}
}