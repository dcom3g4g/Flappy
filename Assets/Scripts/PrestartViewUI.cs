using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrestartViewUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject m_ui;
    [SerializeField] GameObject m_score;

    public void HideUI()
    {
        m_ui.SetActive(false); 
    }
    public void ShowUI()
    {
        m_ui.SetActive(true);
        m_score.SetActive(true); 
    }
    
}
