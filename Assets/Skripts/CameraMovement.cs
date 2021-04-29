using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Camera1;
    public float speed;
    float h;
 
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            h = 0;
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.position.x > (Screen.width / 2))
                {
                    //Since i do not know how much right you wanna go
                    // This will just go left or right as long as there is a touch 
                    h = 1;
                }
                if (touch.position.x < (Screen.width / 2))
                {
                    h = -1;
                }
            }
        }
        else
        {
            h = Input.GetAxis("Horizontal");

        }
        float v = Input.GetAxis("Vertical");


        Camera1.transform.Translate(h * speed, 0f, v * speed);

        if (Camera1.transform.position.x < -24.5f)    
        {
            Camera1.transform.position = new Vector3(-24.5f, Camera1.transform.position.y, Camera1.transform.position.z);
            
        }

        if (Camera1.transform.position.x > 15f)
        {
            Camera1.transform.position = new Vector3(15f, Camera1.transform.position.y, Camera1.transform.position.z);
        }
    }
}
