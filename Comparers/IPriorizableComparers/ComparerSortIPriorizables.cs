using UnityEngine;
using System.Collections.Generic;	//IComparer<T>

using Priorizables = PHATASS.Utils.Types.Priorizables;

namespace PHATASS.Utils.Comparers
{
	//IComparer used to sort a list of TPriorizables. Uses IPriorizable<T>.CompareTo() implementation
	public class ComparerSortIPriorizablesByPriority <TPriorizable> :
		IComparer<TPriorizable>
		where TPriorizable : Priorizables.IPriorizable<TPriorizable>
	{
	//Constructor and private fields
		private bool reverse = false;
		public ComparerSortIPriorizablesByPriority (bool reverseOrder = false)
		{ reverse = reverseOrder; }
	//ENDOF Constructor and private fields

	//IComparer
		int IComparer<TPriorizable>.Compare (TPriorizable elementA, TPriorizable elementB)
		{ return this.Compare(elementA, elementB); }
			protected virtual int Compare (TPriorizable elementA, TPriorizable elementB)
			{
				if (this.reverse) { return -1 * elementA.CompareTo(elementB); }
				return elementA.CompareTo(elementB);
			}
	//ENDOF IComparer
	}

	//IComparer used to sort a list of TPriorizables by their priority and distance to a central point
	//comparison is always priority-first, only priority ties un-tie through distance
	//elements not inheriting from UnityEngine.Component are always considered farther
	public class ComparerSortIPriorizablesByPriorityAndDistanceToPosition <TPriorizable> :
		ComparerSortIPriorizablesByPriority <TPriorizable>
		where TPriorizable : Priorizables.IPriorizable<TPriorizable>
	{
	//Constructor and private fields
		private Vector3 center;

		public ComparerSortIPriorizablesByPriorityAndDistanceToPosition (Vector3 originPosition, bool reverseOrder = false)
		: base(reverseOrder)
		{ this.center = originPosition; }
	//ENDOF Constructor and private fields

	//overrides
		protected override int Compare (TPriorizable elementA, TPriorizable elementB)
		{
			int result = base.Compare(elementA, elementB);

			//if priority is not equal, diference in priority primes
			if (result != 0) { return result; }

			//resolve ties by distance
			Component componentA = (elementA as Component);
			Component componentB = (elementB as Component);

			if (componentA == null && componentB == null) { return 0; }
			if (componentA == null) { return 1; }
			if (componentB == null) { return -1; }

			//if A is closer to origin, Difference sign is negative
			float distanceDifference =
				  Vector3.Distance(center, componentA.transform.position)
				- Vector3.Distance(center, componentB.transform.position);

			//return comparison result
			return (distanceDifference == 0)
				? 0	//if both elements are at the same distance return 0, they are equal
				: (int) Mathf.Sign(distanceDifference); //otherwise return 1 or -1 indicating closer collider
		}
	//ENDOF overrides
	}
}