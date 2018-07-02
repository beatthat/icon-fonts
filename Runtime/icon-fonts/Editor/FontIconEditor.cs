using System;
using System.Collections.Generic;
using System.Linq;
using BeatThat.Properties;
using UnityEditor;
using UnityEngine;

namespace BeatThat.IconFonts
{
    [CustomEditor(typeof(FontIcon), true)]
	[CanEditMultipleObjects]
    public class FontIconEditor : PropertyBindingEditor
	{
		override public void OnInspectorGUI() 
		{
			EditorGUI.BeginChangeCheck();

            base.OnInspectorGUI();


			var codePointsProp = this.serializedObject.FindProperty("m_codePoints");
			EditorGUILayout.PropertyField(codePointsProp, new GUIContent("Code Points", "The code point mappings"));

			var codePoints = codePointsProp.objectReferenceValue as CodePointsAsset;


			var iconProp = this.serializedObject.FindProperty("m_icon");

			if (codePoints != null) {

				var byIcon = new Dictionary<string, string> ();
				foreach (var cp in codePoints.m_codePoints) {
					byIcon [cp.key] = cp.code;
				}

				var icons = byIcon.Keys.ToArray ();
				Array.Sort (icons);
				var curIx = Array.BinarySearch (icons, iconProp.stringValue);
				var newIx = EditorGUILayout.Popup ("Icon", curIx, icons);
				if (newIx < 0) {
					EditorGUILayout.HelpBox ("No codepoint found for icon '" + iconProp.stringValue + "'", MessageType.Error);
				}
				else if(newIx != curIx) {
					iconProp.stringValue = icons [newIx];
				} 
			}

			this.serializedObject.ApplyModifiedProperties();

			if(EditorGUI.EndChangeCheck()) {
				(this.target as FontIcon).UpdateDisplay();
			}

			var icon = iconProp.stringValue;
			string hex;
			if (codePoints != null && !string.IsNullOrEmpty (icon)) {
				EditorGUILayout.LabelField ("Unicode hex value", codePoints.TryGetCode (icon, out hex, asHex: true) ? hex : "unknown");
			}

		}
	}
}
