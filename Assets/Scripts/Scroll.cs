using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Scroll : MonoBehaviour
{
    
    [SerializeField] private PipeMove m_pileMove;
    [SerializeField] private Rigidbody2D m_rigid ;
    [SerializeField] private MoveAndScrollConfiguration m_moveAndScroll; 
    // Start is called before the first frame update    

    public void StartScroll()
    {
        m_moveAndScroll.m_start = true; 
    }
    public void StopScroll()
    {
        m_moveAndScroll.m_start = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (m_moveAndScroll.m_start)
        {
            //m_rigid.velocity = m_moveAndScroll.m_veloMove;
            transform.Translate(Vector3.left * 2f * Time.deltaTime);
        }
        else
        {
            //m_rigid.velocity = m_moveAndScroll.m_veloStop;
        }
            
        if (transform.position.x < -m_moveAndScroll.m_posReset)
        {
            transform.position -= new Vector3(transform.position.x, 0, 0);

        }
    }
    private void FixedUpdate()
    {
        
    }
}
