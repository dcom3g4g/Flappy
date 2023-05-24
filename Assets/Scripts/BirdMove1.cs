using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove1 : MonoBehaviour
{
    //-1 0.31
    [SerializeField] private bool m_start = false;
    [SerializeField] private Rigidbody2D m_rigid;
    [SerializeField] private GameConfiguration m_gameconfiguration; 
    [SerializeField] private AudioSource m_fly;
    [SerializeField] private BirdInput m_input;
    
    // Start is called before the first frame update

    private void Start()
    {
        m_input.OnClickMouse.AddListener(Jump);
    }

    private void OnDestroy()
    {
        m_input.OnClickMouse.RemoveListener(Jump);
    }

    public void Force()
    {
        m_rigid.AddForce(m_gameconfiguration.m_force);
        m_rigid.gravityScale = 3f;
    }

    public void Jump()
    {
        if (m_start)
        {

            if (m_rigid != null)
            {
                m_rigid.gravityScale = m_gameconfiguration.m_gravity;
                m_fly.Play();
                //transform.Translate(new Vector2(0,0.7f)); 
                m_rigid.AddForce(m_gameconfiguration.m_force);
                m_gameconfiguration.m_Rotate = true; 
            }
        }
        else
        {
            m_rigid.gravityScale = 0;
        };
    }

    private void Update()
    {
        if (m_rigid.velocity.y > m_gameconfiguration.m_maxvelo)
        {
            m_rigid.velocity = m_gameconfiguration.m_velomax;

            
            
        }
        //if( m_start)
        //    transform.Rotate(m_gameconfiguration.m_rotate, 0.1f);
        if (m_start)
        {
            if (m_gameconfiguration.m_Rotate)
            {
                m_gameconfiguration.time += Time.deltaTime; 
                transform.Rotate(m_gameconfiguration.m_rotate, m_gameconfiguration.m_RotateUp);
                
                if (transform.rotation.z > m_gameconfiguration.m_maxRotationZ)
                {
                    transform.rotation = Quaternion.Euler(m_gameconfiguration.m_rotation);
                    
                }
                if (m_gameconfiguration.time > m_gameconfiguration.m_timereset)
                {
                    m_gameconfiguration.time = 0;
                    m_gameconfiguration.m_Rotate = false; 
                }
            }
            
            else
                transform.Rotate(m_gameconfiguration.m_rotate, m_gameconfiguration.m_RotateDown);
        }
        

    }
    public void Die()
    {
        m_start = false;
        transform.Rotate(m_gameconfiguration.m_rotate, m_gameconfiguration.m_angle); 
        m_rigid.velocity = m_gameconfiguration.m_velodie;
        
        
    }

    public void RotateaAgian()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    public void StartMove()
    {

        m_rigid.velocity = m_gameconfiguration.m_velodown;
        m_start = true;
        m_gameconfiguration.m_Rotate = false; 
    }

    public void StopMove()
    {
        m_start = false;
    }

}
