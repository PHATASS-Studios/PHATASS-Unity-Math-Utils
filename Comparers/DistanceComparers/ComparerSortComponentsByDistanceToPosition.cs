using UnityEngine;
using System.Collections.Generic;	//IComparer<T>
using IComparer = System.Collections.IComparer;

namespace PHATASS.Utils.Comparers
{
	//IComparer used to sort a list of items by its distance from a Vector3 worldspace position
	public class ComparerSortComponentsByDistanceToPosition :
		IComparer<Component>,
		IComparer
	{
		private Vector3 center;

		private bool nullsFirst = false;

		//Constructor: Takes position to use as center for upcoming comparison
		public ComparerSortComponentsByDistanceToPosition (Vector3 originPosition, bool nullsFirst = false)
		{
			center = originPosition;
			this.nullsFirst = nullsFirst;
		}

		int IComparer<Component>.Compare (Component componentA, Component componentB)
		{ return this.Compare(componentA, componentB); }

		int IComparer.Compare (System.Object componentA, System.Object componentB)
		{ return this.Compare(componentA as Component, componentB as Component); }

		private int Compare (Component componentA, Component componentB)
		{
			if (componentA == null && componentB == null) { return 0; }
			if (componentA == null) { return 1; }
			if (componentB == null) { return -1; }

			//if A is closer to origin, Difference sign is negative
			float distanceDifference =
				  Vector3.Distance(center, componentA.transform.position)
				- Vector3.Distance(center, componentB.transform.position);

			//return comparison result
			return (distanceDifference == 0)
				? 0	//if both colliders are at the same distance return 0, they are equal
				: (int) Mathf.Sign(distanceDifference); //otherwise return 1 or -1 indicating closer collider
		}
	}
}