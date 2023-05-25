using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource m_hit;
    [SerializeField] AudioSource m_fly;
    [SerializeField] AudioSource m_point;
    [SerializeField] AudioSource m_swoosh; 
    // Start is called before the first frame update
    public void Hit()
    {
        m_hit.Play(); 
    }
    public void Fly()
    {
        m_fly.Play();
    }
    public void Point()
    {
        m_point.Play();
    }
    public void Swoosh()
    {
        m_swoosh.Play();
    }
}
