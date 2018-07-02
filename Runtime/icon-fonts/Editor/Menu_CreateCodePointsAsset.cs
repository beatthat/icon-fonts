using System.IO;
using UnityEditor;
using UnityEngine;

namespace BeatThat.IconFonts
{

    public static class Menu_CreateCodePointsAsset
	{
		[MenuItem("Assets/Create/Ape - CodePoints", false, 100)]
		public static void CreateCodePoints()
		{
			CreateAsset<CodePointsAsset>();
		}

		public static T CreateAsset<T>() where T : ScriptableObject
		{
			var dirPath = "Assets";
			foreach (Object obj in Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.Assets)) {
				dirPath = AssetDatabase.GetAssetPath(obj);
				if (File.Exists(dirPath)) {
					dirPath = Path.GetDirectoryName(dirPath);
				}
				break;
			}

			string fileName = typeof(T).Name;
			int i = 0;
			T asset = null;
			while((asset = AssetDatabase.LoadAssetAtPath(Path.Combine(dirPath, fileName+ ".asset"), typeof(T)) as T) != null) {
				fileName = string.Format("{0}{1}", typeof(T).Name, (++i));
			}

			asset = ScriptableObject.CreateInstance<T>();
			AssetDatabase.CreateAsset(asset, Path.Combine(dirPath, fileName+ ".asset"));

			EditorUtility.SetDirty(asset);
			AssetDatabase.SaveAssets();

			AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(asset));  

			return asset;
		}
	}
}


