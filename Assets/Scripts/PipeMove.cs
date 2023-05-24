using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    private static bool m_start = true;
    [SerializeField] GameObject m_botPile;
    [SerializeField] GameObject m_topPile;
    private BoxCollider2D m_topPileCollider;
    private BoxCollider2D m_botPileCollider;
    public bool start {
        get => m_start;
        set => m_start = value;
    }

    [SerializeField] private MoveAndScrollConfiguration m_moveAndScroll;

    void Start()
    {
        m_start = false;
        m_botPileCollider = m_botPile.GetComponent<BoxCollider2D>();
        m_topPileCollider = m_topPile.GetComponent<BoxCollider2D>();
    }
    public void SetIsTriggerFalse()
    {
        m_botPileCollider.isTrigger = false;
        m_botPileCollider.isTrigger = false;
    }
    private void Update()
    {
        if (!m_start)
        {
            m_botPileCollider.isTrigger = true;
            m_topPileCollider.isTrigger = true;
            return;
        }
            

        transform.Translate(Vector3.left * 2f * Time.deltaTime);
        SetIsTriggerFalse(); 
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Contains(m_moveAndScroll.m_bird))
        {
            m_moveAndScroll.m_start = false;
            
        }
    }

}
