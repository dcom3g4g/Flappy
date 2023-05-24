using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private bool m_start = false; 
    [SerializeField] GameObject m_Pile;
    [SerializeField] GameObject m_Pile1;
    private Vector2 m_firstPos= new Vector2(4, 0);
    private Vector2 m_firstPos1 = new Vector2(8, 0);
    private int m_random = 0; 
    public void StartSpawn()
    {
        
        m_start = true; 
    }
    public void MoveBack()
    {
        m_Pile.transform.position = m_firstPos;
        m_Pile1.transform.position = m_firstPos1;
    }
    public void Stopspawn()
    {
        m_start = false; 
    }
    
    // Update is called once per frame
    void Update()
    {
        if (m_start)
        {
            
            if (m_Pile.transform.position.x < -3.5)
            { 
                m_random = Random.Range(-2, 2);
                m_Pile.transform.position = new Vector2(m_firstPos.x, m_firstPos.y+m_random/2);
            }
            if (m_Pile1.transform.position.x < -3.5)
            {
                m_random = Random.Range(-2, 2);
                m_Pile1.transform.position = new Vector2(m_firstPos.x, m_firstPos1.y + m_random / 2);
            }
        }
    }
}
