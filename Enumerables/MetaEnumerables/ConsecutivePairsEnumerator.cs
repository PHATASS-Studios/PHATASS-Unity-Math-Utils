using System.Collections.Generic;

using IEnumerator = System.Collections.IEnumerator;
using IEnumerable = System.Collections.IEnumerable;
using IDisposable = System.IDisposable;

using Object = System.Object;

namespace PHATASS.Utils.Enumerables
{
	public static class ConsecutivePairsEnumerables
	{
		//Extension method returning a pair enumerator from origin enumerator
		public static IEnumerable<(TOut,TOut)> EToConsecutivePairs <TOut> (this IEnumerable<TOut> enumerable)
		{ return new ConsecutivePairsEnumerable<TOut>(enumerable); }

	// This enumerator iterates over another subEnumerator returning every pair of consecutive elements
		// For every input element returns a tuple containing that element and the next, in that order
		//	(TOut Item1, TOut Item2)
		// If input subEnumerator has less than 2 elements this returns nothing
		private struct ConsecutivePairsEnumerator<TOut> : IEnumerator<(TOut, TOut)>
		{
		//IDisposable implementation
			void IDisposable.Dispose () { this.subEnumerator.Dispose(); }
		//ENDOF IDisposable implementation		

		//IEnumerator
			object IEnumerator.Current { get { return this.current; }}
			bool IEnumerator.MoveNext () { return this.MoveNext(); }
			void IEnumerator.Reset () { this.Reset(); }
		//ENDOF IEnumerator

		//IEnumerator<TOut>
			(TOut, TOut) IEnumerator<(TOut, TOut)>.Current { get { return this.current; }}
		//ENDOF IEnumerator<TOut>

		//constructor
			public ConsecutivePairsEnumerator (IEnumerable<TOut> enumerable)
			{
				subEnumerator = enumerable.GetEnumerator();
				previous = default(TOut);

				this.Reset();
			}

			public ConsecutivePairsEnumerator (IEnumerator<TOut> enumerator)
			{
				subEnumerator = enumerator;
				previous = default(TOut);

				this.Reset();
			}
		//ENDOF constructor

		//private
			//original enumerator we're accessing
			private IEnumerator<TOut> subEnumerator;

			private (TOut, TOut) current
			{ get { return (previous, this.subEnumerator.Current); }}

			private TOut previous;

			private void Reset()
			{
				this.subEnumerator.Reset();
				this.subEnumerator.MoveNext();
			}

			private bool MoveNext ()
			{
				this.previous = this.subEnumerator.Current;
				return this.subEnumerator.MoveNext();
			}
		//ENDOF private
		}
	//ENDOF Enumerator

	// Enumerable
		private struct ConsecutivePairsEnumerable <TOut> : IEnumerable<(TOut, TOut)>
		{
		//IEnumerator<(TOut, TOut)>
			IEnumerator<(TOut, TOut)> IEnumerable<(TOut, TOut)>.GetEnumerator () { return this.GetEnumerator(); }
			IEnumerator IEnumerable.GetEnumerator () { return this.GetEnumerator(); }
			private IEnumerator<(TOut, TOut)> GetEnumerator ()
			{ return new ConsecutivePairsEnumerator<TOut>(this.enumerator); }
		//ENDOF IEnumerator<(TOut, TOut)>

		//Constructor
			public ConsecutivePairsEnumerable (IEnumerable<TOut> enumerable)
			{ this.enumerator = enumerable.GetEnumerator(); }

			public ConsecutivePairsEnumerable (IEnumerator<TOut> enumerator)
			{ this.enumerator = enumerator; }		
		//ENDOF Constructor

		//fields
			private IEnumerator<TOut> enumerator;
		//ENDOF fields
		}
	//ENDOF Enumerable
	}
}