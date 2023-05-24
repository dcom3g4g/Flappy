using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{

    
    private static bool m_start=true;
    public bool start { get => m_start; set => m_start = value; }
    [SerializeField] private MoveAndScrollConfiguration m_moveAndScroll;
    Rigidbody2D m_myRigi;

    void Start()
    {
        m_myRigi = GetComponent<Rigidbody2D>();
        m_start = false; 
    }
    private void FixedUpdate()
    {
        if (m_myRigi != null)
        {
            
            if (m_start)
            {
                transform.Translate(Vector3.left * 2f * Time.deltaTime);
            }
            else
            {
                //m_myRigi.velocity = m_moveAndScroll.m_veloStop;
            }
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Contains(m_moveAndScroll.m_bird))
        {
            m_moveAndScroll.
               m_start = false;
            
        }
    }

}
