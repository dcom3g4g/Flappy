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
    float duration1 = 0.5f;
    float duration2 = 0.2f;
    private Vector3 m_scoreBoardPosFirst = new Vector3(0.06365f, 9.23f);
    private Vector3 m_playBTPosFirst = new Vector3(-0.29f, -10.26f);
    private Vector3 m_rankBTPosFirst = new Vector3(-0.29f, -10.26f);
    private Vector3 m_gameOverFirst = new Vector3(0.32f, 2.11f);
    private Vector3 m_scoreBoardPosLast = new Vector3(0.06365f, -0.34f);
    private Vector3 m_playBTPosLast = new Vector3(-0.29f, -3.26f);
    private Vector3 m_rankBTPosLast = new Vector3(0.15f, -3.41f);
    private Vector3 m_gameOverLast = new Vector3(-0.29f, -3.26f);
    [SerializeField] GameObject m_scoreboard;
    [SerializeField] GameObject m_gameOverImg;
    [SerializeField] GameObject m_playAgainbt;
    [SerializeField] GameObject m_rankBT;
    [SerializeField] GameObject m_score;
    void Start()
    {
        m_play.onClick.AddListener(ReplayGame);
    }
    public void showUI()
    {
        m_gameOverView.SetActive(true);
        m_score.SetActive(false); 
        m_playAgainbt.gameObject.transform.position = m_rankBTPosFirst;
        m_rankBT.gameObject.transform.position = m_rankBTPosFirst;
        Debug.Log(m_scoreboard.gameObject.transform.position);
        Debug.Log("GameOver " + m_gameOverImg.gameObject.transform.position);
        Debug.Log("Rank " + m_rankBT.gameObject.transform.position);
        Debug.Log("Play " + m_playAgainbt.gameObject.transform.position);
        StartCoroutine( MoveToTarget());
        
        
        m_currScore.text = m_gameController.Currscore.ToString();
        m_bestscore.text = m_gameController.Bestscore.ToString();
    }
    public void HideUI()
    {
        m_score.SetActive(true);
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
        
    }

    IEnumerator MoveToTarget()
    {
        float elapsedTime = 0f;
        m_scoreboard.gameObject.transform.position = m_scoreBoardPosFirst;
        while (elapsedTime < duration1)
        {
            float t = elapsedTime / duration1;
            m_scoreboard.gameObject.transform.position = Vector3.Lerp(m_scoreBoardPosFirst, m_scoreBoardPosLast, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        m_scoreboard.gameObject.transform.position = m_scoreBoardPosLast;
        elapsedTime = 0f;
        
        while (elapsedTime < duration2)
        {
            float t = elapsedTime / duration2;
            m_playAgainbt.gameObject.transform.position = Vector3.Lerp(m_rankBTPosFirst, m_rankBTPosLast, t);
            m_rankBT.gameObject.transform.position = Vector3.Lerp(m_rankBTPosFirst, m_rankBTPosLast, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        m_rankBT.gameObject.transform.position = m_rankBTPosLast;
        m_playAgainbt.gameObject.transform.position = m_rankBTPosLast;
        if (m_gameController.Currscore >= 15)
        {
            m_brozenmedal.SetActive(true);
        }
        else if (m_gameController.Currscore >= 30)
        {
            m_slivermedal.SetActive(true);
        }
    }
}
