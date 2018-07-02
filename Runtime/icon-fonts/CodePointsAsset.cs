using System;
using UnityEngine;

namespace BeatThat.IconFonts
{
    [Serializable]
	public class CodePointsAsset : ScriptableObject
	{
		[Serializable]
		public struct CodePoint 
		{
			public string key;
			public string code;
		}

		public CodePoint[] m_codePoints;

        public CodePoint[] GetCodePoints() { return m_codePoints; }

		public void Sort()
		{
			Array.Sort (m_codePoints, (x, y) => x.key.CompareTo (y.key));
		}
	}

	public static class CodePointsAssetExt
	{

		public static bool TryGetCode(this CodePointsAsset codePoints, string key, out string code, bool asHex = false)
		{
			return CodePoints.TryGetCode (codePoints, key, out code, asHex);
		}
	}


}


