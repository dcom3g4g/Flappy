using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BirdInput : MonoBehaviour
{
    public UnityEvent OnClickMouse= new UnityEvent(); 
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnClickMouse.Invoke();
        }
    }
}
