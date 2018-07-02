using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace BeatThat
{
    [CustomEditor(typeof(CodePointsAsset), true)]
	[CanEditMultipleObjects]
	public class CodePointsAssetEditor : UnityEditor.Editor
	{
		override public void OnInspectorGUI() 
		{
			var codePointsAsset = this.target as CodePointsAsset;

			base.OnInspectorGUI ();

			if(GUILayout.Button("Sort")) {
				
				codePointsAsset.Sort ();
			}

			if (GUILayout.Button ("Rebuild from Code Points File")) {
				var file = EditorUtility.OpenFilePanel ("Code Points File", "", "txt");
				if (!string.IsNullOrEmpty (file)) {
					var list = new List<CodePointsAsset.CodePoint> ();
					var lines = File.ReadAllLines (file);
					foreach (var oneLine in lines) {
						var keyVal = oneLine.Split (' ');
						if (keyVal.Length != 2) {
							continue;
						}
						list.Add (new CodePointsAsset.CodePoint { key = keyVal [0], code = keyVal [1] });
					}

					codePointsAsset.m_codePoints = list.ToArray ();
					codePointsAsset.Sort ();
				}
			}

			string min = null, max = null;
			foreach(var cp in codePointsAsset.m_codePoints) {
				min = (min != null && min.CompareTo(cp.code) < 0) ? min: cp.code;
				max = (max != null && max.CompareTo(cp.code) > 0) ? max: cp.code;
			}

			if (!string.IsNullOrEmpty (min) && !string.IsNullOrEmpty (max)) {
				EditorGUILayout.HelpBox ("Values range from " + min + "-" + max, MessageType.Info);
			}

		}
	}
}
