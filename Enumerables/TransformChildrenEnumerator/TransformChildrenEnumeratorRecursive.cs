using System.Collections.Generic;
using IEnumerator = System.Collections.IEnumerator;
using IEnumerable = System.Collections.IEnumerable;
using IDisposable = System.IDisposable;

using Transform = UnityEngine.Transform;

namespace PHATASS.Utils.Enumerables
{
// This IEnumerator iterates over every children and grandchildren of transform, recursively, depth-first
	public struct TransformChildrenRecursiveEnumerable : IEnumerable<Transform>
	{
		IEnumerator IEnumerable.GetEnumerator ()
		{ return new TransformChildrenEnumeratorRecursive(root, includeRootTransform); }

		IEnumerator<Transform> IEnumerable<Transform>.GetEnumerator ()
		{ return new TransformChildrenEnumeratorRecursive(root, includeRootTransform); }

		public TransformChildrenRecursiveEnumerable (Transform root, bool includeRootTransform)
		{
			this.root = root;
			this.includeRootTransform = includeRootTransform;
		}

		private Transform root;
		private bool includeRootTransform;
	}

	public class TransformChildrenEnumeratorRecursive
	: IEnumerator<Transform>
	{
	//IEnumerator<Transform>
		Transform IEnumerator<Transform>.Current { get { return this.current; }}
		private Transform current { get; set; }
	//ENDOF IEnumerator<Transform>

	//IEnumerator
		System.Object IEnumerator.Current { get { return this.current; }}

		bool IEnumerator.MoveNext () { return this.MoveNext(); }

		void IEnumerator.Reset () { this.Reset(); }
	//ENDOF IEnumerator

	//IDisposable
		void IDisposable.Dispose () { (this.subEnumerator as IDisposable)?.Dispose(); }
	//ENDOF IDisposable

	//Constructor & initialization
		public TransformChildrenEnumeratorRecursive (Transform root, bool includeRootTransform = true)
		{
			this.Reset(root, includeRootTransform);
		}

		private void Reset (Transform root, bool includeRootTransform = true)
		{
			this.root = root;
			this.includeRootTransform = includeRootTransform;
			this.Reset();
		}

		private void Reset ()
		{
			this.currentChildIndex = (this.includeRootTransform)
				? -2	//if root must be included, reset to -2
				: -1;	//if root is unnecessary reset to -1

			this.subEnumerator?.Reset(null, true);
		}
	//ENDOF Constructor

	//private properties
	//ENDOF private properties

	//private fields
		private Transform root;	//root transform from which to return its children
		private bool includeRootTransform;	//if true, must include the root transform at the start of the enumerator

		private int currentChildIndex; //index for the current child being iterated
		private TransformChildrenEnumeratorRecursive subEnumerator;	//IEnumerator used to iterate over the children
	//ENDOF private

	//private methods
		private bool MoveNext ()
		{
			//If no root element, immediately end feed
			if (this.root == null) { return false; }

			//check index explicitly if we need to return the root as first element
			if (this.currentChildIndex < -1)
			{
				this.current = this.root;
				this.currentChildIndex = -1;
				return true;
			}

			//Ensure Sub-Enumerator exists
			if (this.subEnumerator == null) { this.subEnumerator = new TransformChildrenEnumeratorRecursive(null, true); }

			//Try to advance the current sub-enumerator
			//If current sub-enumerator is ended, advance it to the next immediate child
			while (this.subEnumerator.MoveNext() == false)
			{
				//if we ran out of children to iterate we return false indicating end of feed
				if (this.SetSubEnumeratorToNextChild() == false) { return false; }
			}

			//store next current element and return true to indicate feed continues
			this.current = (this.subEnumerator as IEnumerator<Transform>).Current;
			return true;	
		}

		private bool SetSubEnumeratorToNextChild ()
		{
			this.currentChildIndex++;

			if (this.currentChildIndex >= this.root.childCount)
			{
				return false;
			}
			else
			{
				this.subEnumerator.Reset(this.root.GetChild(this.currentChildIndex), true);
				return true;
			}
		}
	//ENDOF private methods
	}
}