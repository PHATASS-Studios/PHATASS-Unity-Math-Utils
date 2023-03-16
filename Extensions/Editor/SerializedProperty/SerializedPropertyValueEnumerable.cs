using System.Collections.Generic;
using System.Collections;
using IDisposable = System.IDisposable;

using SerializedProperty = UnityEditor.SerializedProperty;

namespace PHATASS.Utils.Extensions.Editor
{
	// sub-class containing enumerables for static class SerializedPropertyExtensions
	public static partial class SerializedPropertyExtensions
	{
	// Enumerables
		private struct SerializedPropertyValueEnumerable : IEnumerable
		{
		//IEnumerable<T>
			IEnumerator IEnumerable.GetEnumerator ()
			{ return new SerializedPropertyEnumeratorToValueEnumerator(this.property.GetEnumerator()); }

			//IEnumerator<T> IEnumerable<T>.GetEnumerator ()	{ return new SerializedPropertyArrayEnumerator<T>(property); }
		//ENDOF IEnumerable<T>

		//constructor
			public SerializedPropertyValueEnumerable (SerializedProperty property)
			{
				this.property = property;
			}
		//ENDOF constructor

		//private
			private SerializedProperty property;
		//ENDOF private
		}

		private struct SerializedPropertyCastedValueEnumerable<T> : IEnumerable<T>
		{
		//IEnumerable<T>
			IEnumerator IEnumerable.GetEnumerator ()
			{ return this.GetEnumerator(); }

			IEnumerator<T> IEnumerable<T>.GetEnumerator ()
			{ return this.GetEnumerator(); }
		//ENDOF IEnumerable<T>

		//constructor
			public SerializedPropertyValueEnumerable (SerializedProperty property)
			{
				this.property = property;
			}
		//ENDOF constructor

		//private
			private IEnumerator<T> GetEnumerator
			{
				get
				{
					return
						new SerializedPropertyEnumeratorToValueEnumerator(this.property.GetEnumerator())
						.EToCastedEnumerator<T>();
				}
			}

			private SerializedProperty property;
		//ENDOF private
		}

	//ENDOF Enumerables

	// Enumerators
		private struct SerializedPropertyEnumeratorToValueEnumerator : IEnumerator
		{
		//IDisposable implementation
		//	void IDisposable.Dispose () { this.propertyEnumerator.Dispose(); }
		//ENDOF IDisposable implementation		

		//IEnumerator
			System.Object IEnumerator.Current { get { return this.current; }}
			bool IEnumerator.MoveNext () { return this.propertyEnumerator.MoveNext(); }
			void IEnumerator.Reset () { this.propertyEnumerator.Reset(); }
		//ENDOF IEnumerator

		//IEnumerator<T>
		//	T IEnumerator<T>.Current { get { return this.current; }}
		//ENDOF IEnumerator<T>

		//constructor
			public SerializedPropertyEnumeratorToValueEnumerator (IEnumerator propertyEnumerator)
			{
				this.propertyEnumerator = propertyEnumerator;
				this.propertyEnumerator.Reset();
			}
		//ENDOF constructor

		//private
			private System.Object current { get { return null;}}//propertyEnumerator.Current.boxedValue; }}//this.property.GetArrayElementAtIndex(this.index); }}

			private IEnumerator propertyEnumerator;
		//ENDOF private
		}
	//ENDOF Enumerator

/*
		private struct SerializedPropertyArrayEnumerator<T> : IEnumerator<T>
		{
		//IDisposable implementation
			void IDisposable.Dispose () { }
		//ENDOF IDisposable implementation		

		//IEnumerator
			System.Object IEnumerator.Current { get { return this.current; }}
			bool IEnumerator.MoveNext () { return this.MoveNext(); }
			void IEnumerator.Reset () { this.index = -1; }
		//ENDOF IEnumerator

		//IEnumerator<T>
			T IEnumerator<T>.Current { get { return this.current; }}
		//ENDOF IEnumerator<T>

		//constructor
			public SerializedPropertyArrayEnumerator (SerializedProperty property)
			{
				this.property = property;
				this.index = -1;
			}
		//ENDOF constructor

		//private
			private T current { get { return null; }}//this.property.GetArrayElementAtIndex(this.index); }}

			private SerializedProperty property;
			private int index;

			private bool MoveNext ()
			{
				this.index++;
				return this.property.arraySize > this.index;
			}
		//ENDOF private
		}
*/
	}
}