using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameOverView : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button m_play;
    [SerializeField] TextMeshProUGUI m_currScore;
    [SerializeField] TextMeshProUGUI m_bestscore;
    [SerializeField] Bird m_bird;
    [SerializeField] GameObject m_goldmedal;
    [SerializeField] GameObject m_brozenmedal;
    [SerializeField] GameObject m_slivermedal;
    [SerializeField] GameObject m_gameOverView;
    [SerializeField] GameController m_gameController;
    //[SerializeField] GameObject m_blackSence; 
    // Start is called before the first frame update
    void Start()
    {
        m_play.onClick.AddListener(ReplayGame); 
    }
    public void showUI()
    {
        m_gameOverView.SetActive(true);
        if(m_gameController.Currscore >= 15)
        {
            m_brozenmedal.SetActive(true); 
        }
        else if (m_gameController.Currscore >= 30)
        {
            m_slivermedal.SetActive(true);
        }
        m_currScore.text = m_gameController.Currscore.ToString();
        m_bestscore.text = m_gameController.Bestscore.ToString(); 
    }
    public void HideUI()
    {
        m_gameOverView.SetActive(false);
        if (m_gameController.Currscore > 15)
        {
            m_brozenmedal.SetActive(false);
        }
        else if (m_gameController.Currscore > 30)
        {
            m_slivermedal.SetActive(false);
        }
    }
    public void ReplayGame()
    {
        HideUI();
        m_gameController.ReplayGame(); 
        m_bird.MoveBack();
        //m_blackSence.SetActive(true); 
    }
    
}
