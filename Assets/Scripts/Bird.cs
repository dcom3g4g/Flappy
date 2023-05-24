using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameController m_gamecontrol; 
    [SerializeField] private BirdMove1 m_BirdMove;
    [SerializeField] private AudioSource m_hit;
    [SerializeField] private Rigidbody2D m_rigi; 
    [SerializeField] private AudioSource m_swoosh;
    [SerializeField] private GameConfiguration m_birdConfigation; 
    [SerializeField] private Animator m_animator;
    [SerializeField] private GameObject m_splash;
    [SerializeField] GameObject m_checkpile ;
    
    public void SetAnimation(int index)
    {
        if(index==1)
        {
            m_animator.SetBool("Check", true);

        }
    }
    public void StartGame()
    {
        m_BirdMove.StartMove();
        m_birdConfigation.m_isPre = false; 
    }
    public void MoveBack()
    {
        m_BirdMove.RotateaAgian();
        m_animator.enabled = true ;
        transform.position = m_birdConfigation.m_StartPos;
        m_BirdMove.StopMove();
        m_birdConfigation.m_isPre = true; 
    }
    public void StopMove()
    {
        m_BirdMove.StopMove();
        
        
    }
    public void Die()
    {
        m_BirdMove.Die();
        m_swoosh.Play();
        m_animator.enabled = false; 
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.name.Contains(m_birdConfigation.m_botPile) || collision.gameObject.name.Contains(m_birdConfigation.m_topPile)
            || collision.gameObject.name.Contains(m_birdConfigation.m_ground)) && !m_checkpile.activeSelf)
        {
            m_splash.SetActive(false);
            m_splash.SetActive(true);
            m_hit.Play();
            Die();
            m_gamecontrol.GameOver();


            //transform.position -= m_birdConfigation.m_moveLeft;

        }
    }
    private void Update()
    {
        if (m_birdConfigation.m_isPre)
        {
            if (m_birdConfigation.m_count <= m_birdConfigation.m_countMin)
            {
                transform.position += m_birdConfigation.m_vectorMove;

            }
            else
            {
                transform.position -= m_birdConfigation.m_vectorMove;

                if (m_birdConfigation.m_count == m_birdConfigation.m_countMax) m_birdConfigation.m_count = 0;
            }
            m_birdConfigation.m_count++;
        }
    }
}
 