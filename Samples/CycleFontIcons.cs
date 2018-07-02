using BeatThat.Properties;
using UnityEngine;

namespace BeatThat.IconFonts.Samples
{
    public class CycleFontIcons : MonoBehaviour
    {

        public FontIcon m_fontIcon;
        public HasText m_iconKey;
        public HasText m_iconCode;

        public float m_intervalSecs = 0.75f;
        public int m_curIconIndex = 0;
        public float m_timer;

        // Use this for initialization
        void Start()
        {
            m_fontIcon = (m_fontIcon != null) ? m_fontIcon : FindObjectOfType<FontIcon>();
        }

        void Update()
        {
            var codePoints = m_fontIcon.codePoints.GetCodePoints();

            m_timer += Time.deltaTime;
            if(m_timer > m_intervalSecs) {
                m_timer = Mathf.Min(m_timer - m_intervalSecs, 0f);
                m_curIconIndex = (m_curIconIndex + 1 < codePoints.Length) ? m_curIconIndex + 1 : 0;
            }

            m_fontIcon.SetIcon(codePoints[m_curIconIndex].key);

            var cp = codePoints[m_curIconIndex];
            var key = cp.key;
            string codeHex;
            codeHex = m_fontIcon.codePoints.TryGetCode(key, out codeHex, asHex: true) ? codeHex : "hex";

            m_iconKey.value = key;
            m_iconCode.value = codeHex;
        }
    }

}
