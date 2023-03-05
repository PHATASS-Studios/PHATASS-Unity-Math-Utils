using System.Collections.Generic;
using IEnumerable = System.Collections.IEnumerable;
using IEnumerator = System.Collections.IEnumerator;
using IDisposable = System.IDisposable;

using IAngle2D = PHATASS.Utils.Types.Angles.IAngle2D;
using static PHATASS.Utils.Types.Angles.IAngle2DFactory;

using Vector2 = UnityEngine.Vector2;
using Debug = UnityEngine.Debug;

namespace PHATASS.Utils.Types.Boundaries
{
	//This class calculates an asymetrical ellipsoid boundary
	// This file encompasses the enumerators used for 
	public static class Boundary2DEnumerators
	{
		//Boundary points Enumerator<Vector2> 
		public struct Boundary2DPerimeterEnumerable : IEnumerable<Vector2>
		{
			private ushort totalPoints;
			private IBoundary2D boundary;
			public Boundary2DPerimeterEnumerable (IBoundary2D boundary, ushort totalPoints)
			{
				this.boundary = boundary;
				this.totalPoints = totalPoints;
			}

			IEnumerator<Vector2> IEnumerable<Vector2>.GetEnumerator()
			{ return new Boundary2DPerimeterEnumerator(this.boundary, this.totalPoints); }

			IEnumerator IEnumerable.GetEnumerator()
			{ return new Boundary2DPerimeterEnumerator(this.boundary, this.totalPoints); }
		}

		private class Boundary2DPerimeterEnumerator : IEnumerator<Vector2>
		{
		//Constructor
			public Boundary2DPerimeterEnumerator (IBoundary2D boundary, ushort totalPoints)
			{
				this.boundary = boundary;
				this.totalPoints = totalPoints;
				this.stepCount = -1;
				this.stepAngle = (360f/totalPoints).EDegreesToAngle2D();
			}
		//ENDOF Constructor

		//IEnumerator<Vector2>
			Vector2 IEnumerator<Vector2>.Current { get { return this.current; }}
			System.Object IEnumerator.Current { get { return this.current; }}

			bool IEnumerator.MoveNext ()
			{
				this.stepCount++;
				Debug.Log(this.currentAngle + "º > " + this.current);
				return (this.stepCount < this.totalPoints);
			}

			void IEnumerator.Reset ()
			{
				this.stepCount = -1;
			}

			void IDisposable.Dispose () {}
		//ENDOF IEnumerator<Vector2>

		//privates
			private ushort totalPoints;
			private IBoundary2D boundary;

			private int stepCount;
			private IAngle2D stepAngle;

			private IAngle2D currentAngle
			{ get { return this.stepAngle * this.stepCount; }}
			private Vector2 current
			{
				get
				{
					return this.boundary.PointAtAngleFromCenter(
						normalizedDistance: 1f,
						angle: this.currentAngle);
				}
			}
		//ENDOF privates
		}
	}
	//ENDOF Boundary Enumerator
}
