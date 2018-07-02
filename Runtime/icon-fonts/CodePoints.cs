using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;

namespace BeatThat.IconFonts
{
    public static class CodePoints 
	{
		private static Dictionary<CodePointsAsset, Dictionary<string, string>> m_codePointsByAsset;

		public static bool TryGetCode(CodePointsAsset codePoints, string key, out string code, bool asHex = false)
		{

			#if UNITY_EDITOR
			if(!Application.isPlaying) {
				for (int i = 0; i < codePoints.m_codePoints.Length; i++) {
					if(codePoints.m_codePoints[i].key == key) {
						if(asHex) {
							code = codePoints.m_codePoints[i].code;
							return true;
						}
						if (!Hex2Code (codePoints.m_codePoints[i].code, out code)) {
							Debug.LogWarning ("Cannot parse hex to unicode '" + codePoints.m_codePoints[i].code + "'");
							return false;
						}
						return true;
					}
				}

				code = null;
				return false;
			}
			#endif

			if (m_codePointsByAsset == null) {
				m_codePointsByAsset = new Dictionary<CodePointsAsset, Dictionary<string, string>> ();
			}

			Dictionary<string, string> codePointsByKey;
			if (!m_codePointsByAsset.TryGetValue (codePoints, out codePointsByKey)) {
				codePointsByKey = new Dictionary<string, string> ();
				m_codePointsByAsset [codePoints] = codePointsByKey;

				string hex;
				for (int i = 0; i < codePoints.m_codePoints.Length; i++) {
					hex = codePoints.m_codePoints [i].code;
					if (!Hex2Code (hex, out code)) {
						Debug.LogWarning ("Cannot parse hex to unicode '" + hex + "'");
						continue;
					}
					codePointsByKey [codePoints.m_codePoints [i].key] = code;
				}
			}

			// TODO handle asHex = true
            if(!codePointsByKey.TryGetValue (key, out code)) {
                return false;
            }

            code = asHex ? Code2Hex(code): code;

            return true;
		}

        public static string Code2Hex(string code)
        {
            return System.Text.Encoding.Unicode.GetBytes(code)
            .Aggregate("", (agg, val) => agg + val.ToString("X2"));    
        }

		public static bool Hex2Code(string hex, out string code)
		{
			int c;
			if (!int.TryParse (hex, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out c)) {
				code = null;
				return false;
			}
			code = char.ConvertFromUtf32(c);
			return true;
		}
	}
}


