#if UNITY_EDITOR

using UnityEngine;

namespace PHATASS.Utils.Extensions
{
//Rect editor gizmo drawing extensions
	public static partial class RectEditorExtensions
	{
		//Draws a Rect as an outline with given color
		public static void EDrawGizmo (this Rect rect, Color? color = null, string label = null, float zPosition = 0f)
		{
			//store original color and set desired color
			Color previousColor = Gizmos.color;
			if (color != null) { Gizmos.color = (Color) color; }

			//draw the gizmo
				//left line
			Gizmos.DrawLine(
				rect.ENormalizedToVector3(Vector2.zero, zPosition),
				rect.ENormalizedToVector3(Vector2.up, zPosition)
			);
				//top line
			Gizmos.DrawLine(
				rect.ENormalizedToVector3(Vector2.up, zPosition),
				rect.ENormalizedToVector3(Vector2.one, zPosition)
			);
				//right line
			Gizmos.DrawLine(
				rect.ENormalizedToVector3(Vector2.one, zPosition),
				rect.ENormalizedToVector3(Vector2.right, zPosition)
			);
				//bottom line
			Gizmos.DrawLine(
				rect.ENormalizedToVector3(Vector2.right, zPosition),
				rect.ENormalizedToVector3(Vector2.zero, zPosition)
			);
			
			//restore original gizmos color
			if (color != null) { Gizmos.color = previousColor; }

			//Handle label
			if (label != null)
			{
				Vector3 labelPosition = new Vector3 (x: rect.xMin, y: rect.yMax, z: zPosition - 0.1f);

				previousColor = UnityEditor.Handles.color;
				if (color != null) { UnityEditor.Handles.color = (Color) color; }

				UnityEditor.Handles.Label(labelPosition, label);
				if (color != null) { UnityEditor.Handles.color = previousColor; }

			}
		}
	//ENDOF Rect scaling
	}
}
#endif