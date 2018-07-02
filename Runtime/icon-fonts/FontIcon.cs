using BeatThat.Properties;
using UnityEngine;

namespace BeatThat.IconFonts
{
    public class FontIcon : PropertyBinding<IHasText, HasText>, IDrive<IHasText>
	{
        [SerializeField][HideInInspector]private string m_icon;
        [SerializeField] [HideInInspector]private CodePointsAsset m_codePoints;

        public CodePointsAsset codePoints { get { return m_codePoints; } }
        public string icon { get { return m_icon; } }

        public void SetIcon(string icon, bool updateDisplay = true)
        {
            m_icon = icon;
            if(updateDisplay) {
                UpdateDisplay();
            }
        }

        override protected void BindProperty()
        {
            UpdateDisplay();            
        }

        public void UpdateDisplay()
        {
            if (m_codePoints == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(m_icon))
            {
                this.driven.value = "";
                return;
            }

            string codePoint;
            if (m_codePoints.TryGetCode(m_icon, out codePoint))
            {
                this.driven.value = codePoint;
                return;
            }
        }
    }
}

