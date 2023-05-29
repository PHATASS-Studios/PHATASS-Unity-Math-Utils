using UnityEngine;
using System.Collections.Generic;	//IComparer<T>

using static PHATASS.Utils.Extensions.ColliderConfigurationExtensions;

namespace PHATASS.Utils.Comparers
{
	//IComparer used to sort a list of items by its distance from a Vector3 worldspace position
	public class ComparerSortCollidersByDistanceToPosition : IComparer<Collider>
	{
	
		private Vector3 center;

	//Constructor
		//Takes position to use as center for upcoming comparison
		public ComparerSortCollidersByDistanceToPosition (Vector3 originPosition)
		{
			center = originPosition;
		}
	//ENDOF Constructor

	//IComparer
		int IComparer<Collider>.Compare (Collider colliderA, Collider colliderB)
		{
			//if (colliderA == colliderB) return 0;

			Vector3 colliderAPos = colliderA.EGetColliderAbsolutePosition();
			Vector3 colliderBPos = colliderB.EGetColliderAbsolutePosition();

			//if A is closer to origin, Difference sign is negative
			float distanceDifference =
				  Vector3.Distance(center, colliderAPos)
				- Vector3.Distance(center, colliderBPos);

			//return comparison result
			return (distanceDifference == 0)
				? 0	//if both colliders are at the same distance return 0, they are equal
				: (int) Mathf.Sign(distanceDifference); //otherwise return 1 or -1 indicating closer collider
		}
	//ENDOF IComparer
	}
}