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
    [SerializeField] private float m_RotateUp=-5f ; 
    [SerializeField] private float m_RotateDown = 1f;
    [SerializeField] private float m_timereset = 0.2f; 
    private bool m_Rotate = false  ;
    private float time = 0; 
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
        m_rigid.AddForce(new Vector2(0, 800));
        m_rigid.gravityScale = 3f;
    }
    public void Jump()
    {
        if (m_start)
        {

            if (m_rigid != null)
            {
                m_rigid.gravityScale = 3f;
                m_fly.Play();
                //transform.Translate(new Vector2(0,0.7f)); 
                m_rigid.AddForce(new Vector2(0, 800));
                m_Rotate = true; 
            }
        }
        else
        {
            m_rigid.gravityScale = 0;
        };
    }

    private void Update()
    {
        if (m_rigid.velocity.y > 7.2f)
        {
            m_rigid.velocity = m_gameconfiguration.m_velomax;
            Debug.Log(">2");
            
            
        }
        //if( m_start)
        //    transform.Rotate(m_gameconfiguration.m_rotate, 0.1f);
        if (m_start)
        {
            if (m_Rotate)
            {
                time += Time.deltaTime; 
                transform.Rotate(m_gameconfiguration.m_rotate, m_RotateUp);
                Debug.Log(transform.rotation.z);
                if (transform.rotation.z > 0.25)
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 25f));
                    Debug.Log(">30");
                }
                if (time>m_timereset)
                {
                    time = 0;
                    m_Rotate = false; 
                }
            }
            
            else
                transform.Rotate(m_gameconfiguration.m_rotate, m_RotateDown);
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
    }
    public void StopMove()
    {
        m_start = false;
    }

}
