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
    [SerializeField] GameConfiguration m_birdConfigation; 
    [SerializeField] private Animator m_animator;

    public void SetAnimation(int index)
    {
        if(index==1)
        {
            m_animator.SetBool("Check", true);
            Debug.Log("xxxxxxx"); 
        }
    }
    public void StartGame()
    {
        m_BirdMove.StartMove();
        
    }
    public void MoveBack()
    {
        m_BirdMove.Rotateaagian();
        m_animator.enabled = true ;
        transform.position = m_birdConfigation.m_StartPos;
        m_BirdMove.StopMove(); 
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
        
        if (collision.gameObject.name.Contains(m_birdConfigation.m_botPile)  || collision.gameObject.name.Contains(m_birdConfigation.m_topPile) || collision.gameObject.name.Contains(m_birdConfigation.m_ground) )
        {
            
            m_hit.Play();
            Die();
            m_gamecontrol.GameOver();
            transform.position -= m_birdConfigation.m_moveLeft;
             
        }
    }
}
 