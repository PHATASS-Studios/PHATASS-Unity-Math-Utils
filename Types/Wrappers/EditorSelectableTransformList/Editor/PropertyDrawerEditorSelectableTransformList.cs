using System.Collections.Generic;

using UnityEditor;
using UnityEngine;

using static PHATASS.Utils.Editor.Enumerables.SerializedPropertyEnumerables;
using static PHATASS.Utils.Extensions.Editor.UnityObjectArrayToSelectionExtensions;

using VisualElement = UnityEngine.UIElements.VisualElement;
using PropertyField = UnityEditor.UIElements.PropertyField;

namespace PHATASS.Utils.Types.Wrappers
{
	[CustomPropertyDrawer(typeof(EditorSelectableTransformList))]
	public class PropertyDrawerEditorSelectableTransformList : PropertyDrawer
	{
		/*
		public override VisualElement CreatePropertyGUI (SerializedProperty property)
		{
			Debug.Log("TRolololó");
			VisualElement container = new VisualElement();
			if (GUILayout.Button("Select elements in scene"))
			{
				(target as IList<UnityEngine.Object>).ESetObjectListAsSelected();
			}

			container.Add(new PropertyField(property.FindPropertyRelative("_list")));

			return container;
		}
		*/
	//PropertyDrawer lifecycle
		//[TO-DO] Move this to a base array editor extending class
		public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginProperty(position, label, property);
			//Debug.Log("McArio");
			//Debug.Log(position);
			//Debug.Log(property.type);

			SerializedProperty listProperty = property.FindPropertyRelative("_list");
			
			int baseIndent = EditorGUI.indentLevel;

			EditorGUI.indentLevel = baseIndent + 2;

			//EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

			EditorGUI.indentLevel = baseIndent;

			EditorGUI.PropertyField(position, listProperty, label);

			//*
			if (GUI.Button(position: ContainerToButtonRect(position), text: "Select transforms"))
			{
				IList<Transform> list = listProperty.EToValueList<Transform>();

				Debug.Log(list.Count);
				list.ESetObjectListAsSelected();
				Debug.Log("Press " + listProperty.type);
			}
			//*/

			/*if (GUILayout.Button("Select elements in scene"))
			{
				//(target as IList<UnityEngine.Object>).ESetObjectListAsSelected();
				Debug.Log("Press");
			}*/

			EditorGUI.EndProperty();

			Rect ContainerToButtonRect (Rect container)
			{
				return new Rect(
					x: container.x,
					y: container.y + container.height - EditorGUIUtility.singleLineHeight,
					width:	container.width - 80,
					height: EditorGUIUtility.singleLineHeight
				);
			}
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			int lineCount = this.ListPropertyToLineCount(property.FindPropertyRelative("_list"));

			return	(EditorGUIUtility.singleLineHeight * lineCount)
				+	(EditorGUIUtility.standardVerticalSpacing * lineCount -1);
		}
	//PropertyDrawer lifecycle

	//private
		private int ListPropertyToLineCount (SerializedProperty property)
		{
			if (property.isExpanded)
			{
				if (property.arraySize <= 0) { return 4; }
				else { return property.arraySize + 3; }
			}
			else { return 2; }
		}
	//ENDOF private
	}
}
