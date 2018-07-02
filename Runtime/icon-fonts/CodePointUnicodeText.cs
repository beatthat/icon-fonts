using BeatThat.Properties;
using BeatThat.TransformPathExt;
using UnityEngine;

namespace BeatThat.IconFonts
{
    public class CodePointUnicodeText : TextProp
	{
		public string m_icon;
		public CodePointsAsset m_codePoints;

		#region implemented abstract members of TextProp

		protected override string GetValue ()
		{
			if (m_codePoints == null) {
				return "";
			}

			if (string.IsNullOrEmpty (m_icon)) {
				return "";
			}

			string codePoint;
			return m_codePoints.TryGetCode (m_icon, out codePoint)? codePoint: "";
		}

		protected override void _SetValue (string s)
		{
			#if UNITY_EDITOR || DEBUG_UNSTRIP
			Debug.LogWarning("[" + Time.frameCount + "] set-value not supported for " 
				+ GetType() + " (at " + this.Path() + ")");
			#endif
		}

		#endregion
	}
}

