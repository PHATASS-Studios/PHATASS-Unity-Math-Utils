using System.Collections.Generic;
using IEnumerator = System.Collections.IEnumerator;
using IDisposable = System.IDisposable;
//using Object = System.Object;

namespace PHATASS.Utils.Enumerables
{
//This enumerator iterates over another enumerator, avoiding and skipping over null values
	public class NullOmittingEnumerator<TOut> : IEnumerator<TOut>
	{
	//IDisposable implementation
		void IDisposable.Dispose () { this.enumerator.Dispose(); }
	//ENDOF IDisposable implementation		

	//IEnumerator
		System.Object IEnumerator.Current { get { return this.TypelessCurrent; }}
		bool IEnumerator.MoveNext () { return this.MoveNext(); }
		void IEnumerator.Reset () { this.enumerator.Reset(); }
	//ENDOF IEnumerator

	//IEnumerator<TOut>
		TOut IEnumerator<TOut>.Current { get { return this.Current; }}
	//ENDOF IEnumerator<TOut>

	//constructor
		public NullOmittingEnumerator (IEnumerator<TOut> originalEnumerator)
		{ this.enumerator = originalEnumerator; }
	//ENDOF constructor

	//private fields
		//original enumerator we're accessing
		private IEnumerator<TOut> enumerator;
	//ENDOF private fields

	//protected properties
		protected virtual System.Object TypelessCurrent { get { return this.Current; }} 
		protected virtual TOut Current { get { return this.enumerator.Current; }}
	//ENDOF protected properties

	//protected methods
		//MoveNext advances UNTIL a non-null element is found
		protected virtual bool MoveNext ()
		{
			while (true)
			{
				if (!this.enumerator.MoveNext()) { return false; }
				if (this.Current != null) { return true; }
			} 
		}
	//ENDOF protected methods
	}
}