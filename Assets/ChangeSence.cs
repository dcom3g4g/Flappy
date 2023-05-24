using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSence : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Color m_startColor;
    [SerializeField] Color m_endColor;
    [SerializeField] float m_fadeInTime=1f;

    [SerializeField] float m_fadeDelay = 1f;
    [SerializeField] SpriteRenderer m_render;
    private float m_startPoint = 0.01f;
    private void OnEnable()
    {
        StartCoroutine(colorLerpIn());
    }
   
    IEnumerator colorLerpIn()
    {
        for (float i=m_startPoint;m_startPoint<m_fadeInTime;i+=m_startPoint)
        {
            m_render.material.color = Color.Lerp(m_startColor, m_endColor, i / m_fadeInTime);
            yield return null; 
        }
        
    }
    
}
