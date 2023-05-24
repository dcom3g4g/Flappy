using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class score2 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI m_score;
    [SerializeField] AudioSource m_point;
    [SerializeField] GameController m_gameControl;
    private const string m_botPile = "BotPile"; 
    // Update is called once per frame
    void Update()
    {
        m_score.text = m_gameControl.Currscore.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.name.Contains("Bird") && !collision.gameObject.name.Contains("PipeHolder") && !collision.gameObject.name.Contains("Exp"))
        {
            
            m_gameControl.Currscore++;

            m_score.text = m_gameControl.Currscore.ToString();
            m_point.Play();
        };
        

    }
}
