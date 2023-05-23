using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckStart : MonoBehaviour
{
    [SerializeField] private GameController m_control;
    [SerializeField] private PrestartViewUI m_uiHide;
    [SerializeField] private BirdMove1 m_bird;  
    private bool m_check = false;

    public bool Check { get => m_check; set => m_check = value; }


    private void Hideobject()
    {
        m_uiHide.HideUI(); 
    }
    // Update is called once per frame
    void Update()
    {
        if (m_check)
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                m_control.StartGame();
                m_bird.Force(); 
                Hideobject();
                m_check = false; 
            }
                
        }
    }
}
