/*// [WARNING] This needs to stay commented until a way to overcome this button hiding the joint's connected body properties

using UnityEditor;
using UnityEngine;

namespace PHATASS.Utils.Extensions
{
	[CustomEditor(typeof(ConfigurableJoint))]
	public class ConfigurableJointCustomEditor : UnityEditor.Editor
	{
		public override void OnInspectorGUI ()
		{
			if (GUILayout.Button("Auto-configure anchors as chain"))
			{
				(target as Joint).EMSetChainAnchor();
			}
			base.OnInspectorGUI();
		}
	}
}
//*/
