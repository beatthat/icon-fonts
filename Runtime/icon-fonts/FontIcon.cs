using BeatThat.Properties;
using UnityEngine;

namespace BeatThat
{
    public class FontIcon : PropertyBinding<IHasText, HasText>, IDrive<IHasText>
	{
        [SerializeField][HideInInspector]private string m_icon;
        [SerializeField] [HideInInspector]private CodePointsAsset m_codePoints;

		//#region IDrive implementation
		//public object GetDrivenObject ()
		//{
		//	return this.driven;
		//}
		//public bool ClearDriven ()
		//{
		//	m_driven = null; return true;
		//}
		//#endregion
		//#region IDrive implementation
		//public HasText m_driven;
		//public IHasText driven { get { return m_driven?? (m_driven = this.GetSiblingComponent<HasText>()); } } 
		//#endregion

		//void Start()
		//{
		//	UpdateDisplay ();
		//}
		
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

