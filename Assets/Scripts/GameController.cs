using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private Spawn m_spawn;
    [SerializeField] private PipeMove m_pileMove;
    
    private int m_currscore = 0;
    private int m_bestscore = 0;
    [SerializeField] private GameOverView m_gameOverView ;
    [SerializeField] private HomeViewUI m_homeView; 
    [SerializeField] private Bird m_bird;
    [SerializeField] private Scroll m_scroll;
    [SerializeField] private SpriteRenderer m_backGround;
    [SerializeField] private Sprite m_backGroundDay;
    [SerializeField] private Sprite m_backGroundNight;
    [SerializeField] private SpriteRenderer m_birdsprite;
    [SerializeField] private Sprite m_birdorange;
    [SerializeField] private Sprite m_birdblue;


    public int Currscore { get => m_currscore; set => m_currscore = value; }
    public int Bestscore { get => m_bestscore; set => m_bestscore = value; }
   
    void Start()
    {
        SetUpWithTime(); 
        m_scroll.StartScroll(); 
    }
    void SetUpWithTime()
    {
        if (System.DateTime.Now.Hour<12)
        {
            Debug.Log("aaaa"); 
            m_backGround.sprite = m_backGroundDay;
            m_birdsprite.sprite = m_birdblue; 
        }
        else
        {
            m_backGround.sprite = m_backGroundNight;
            m_birdsprite.sprite = m_birdorange;
            m_bird.SetAnimation(1); 
        }
    }
    public void StartGame()
    {
        m_currscore = 0; 
        m_spawn.StartSpawn();
        m_bird.StartGame();
        m_pileMove.start = true;
    }
    public void ReplayGame()
    {
        Currscore = 0;
        m_scroll.StartScroll();
        m_spawn.MoveBack(); 
        m_homeView.StartPreGame();
         
    }
    public void GameOver()
    {
        m_scroll.StopScroll(); 
        m_spawn.Stopspawn();
        m_pileMove.start = false;
        if (Currscore > Bestscore)
            Bestscore = Currscore;
        if (m_currscore>20)
        {

        }
        m_gameOverView.showUI(); 
        
    }
}
