using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeViewUI : MonoBehaviour
{
    [SerializeField] private GameController m_gamecontrol;
    [SerializeField] private GameObject m_homeView;
    [SerializeField] private PrestartViewUI m_preview;
    [SerializeField] private CheckStart m_checkStart; 
    [SerializeField] private Button m_play;
    [SerializeField] private Bird m_bird;

    //[SerializeField] List<GameObject> m_listspritehide;

    // Start is called before the first frame update
    void Start()
    {
        m_play.onClick.AddListener(StartPreGame); 
    }
    private void OnDestroy()
    {
        m_play.onClick.RemoveListener(StartPreGame); 
    }
    public void StartPreGame()
    {
        m_bird.MoveBack(); 
        m_checkStart.Check = true; 
        m_preview.ShowUI();
        m_homeView.SetActive(false); 
    }



}
