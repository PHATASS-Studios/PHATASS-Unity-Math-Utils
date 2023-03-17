using System.Collections.Generic;
using System.Collections;

using IDisposable = System.IDisposable;
using System.Collections.Generic;

namespace PHATASS.Utils.Enumerables
{
// Enumerators allowing casted element access for any IEnumerables/IEnumerators
//	Casts returned items to type <TOut>	
//	miscasts return as null
	public static class TypeCastedEnumerables
	{
//extension methods
		public static IEnumerator<TOut> EToCastedEnumerator <TOut> (this IEnumerator enumerator)
		{ return new TypeCastedEnumerator<TOut>(enumerator); }

		public static IEnumerable<TOut> EToCastedEnumerable <TOut> (this IEnumerable enumerable)
		{ return new TypeCastedEnumerable<TOut>(enumerable); }
//ENDOF extension methods	

// IEnumerables/IEnumerators
		private struct TypeCastedEnumerator <TOut> :
			IEnumerator<TOut>
			//where TOut : class
		{
		//IEnumerator
			object IEnumerator.Current { get { return this.enumerator.Current; }}
			bool IEnumerator.MoveNext () { return this.enumerator.MoveNext(); }
			void IEnumerator.Reset () { this.enumerator.Reset(); }
		//ENDOF IEnumerator

		//IEnumerator<TOut>
			TOut IEnumerator<TOut>.Current { get { return (this.enumerator.Current as TOut); }}
		//ENDOF IEnumerator<TOut>

		//IDisposable
			void IDisposable.Dispose () { (this.enumerator as IDisposable)?.Dispose(); }
		//ENDOF IDisposable

		//Constructor
			public TypeCastedEnumerator (IEnumerator enumerator)
			{ this.enumerator = enumerator; }
		//ENDOF Constructor

		//private fields
			private IEnumerator enumerator;
		//ENDOF private fields
		}

		private struct TypeCastedEnumerable<TOut> : IEnumerable<TOut>
		{
			IEnumerator IEnumerable.GetEnumerator ()
			{ return new TypeCastedEnumerator<TOut>((enumerable as IEnumerable).GetEnumerator()); }

			IEnumerator<TOut> IEnumerable<TOut>.GetEnumerator ()
			{ return new TypeCastedEnumerator<TOut>(enumerable.GetEnumerator()); }

			public TypeCastedEnumerable (IEnumerable<TOut> enumerable)
			{
				this.enumerable = enumerable;
			}

			private IEnumerable<TOut> enumerable;
		}
	}
//ENDOF IEnumerables/IEnumerators
}
