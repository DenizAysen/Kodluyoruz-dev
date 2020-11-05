using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private float speed = 1000f;
    bool left, right;
   [SerializeField] private GameState gameState;
    void Update()
    {
        
        if (Input.touchCount > 0)
        {
            Touch finger = Input.GetTouch(0);

            if(finger.phase == TouchPhase.Began)
            {
                gameState.ChangeScore(30);
            }

            if (finger.deltaPosition.x > 100f)
            {
                right = true;
                left = false;
                
            }

            if (finger.deltaPosition.x < -100f)
            {
                right = false;
                left = true;
               
            }

        }
        // -4.56 +4.56
        if(right == true)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(4f, transform.position.y, transform.position.z),5*Time.deltaTime);
           
        }

        if(left == true)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(-4f, transform.position.y, transform.position.z), 5*Time.deltaTime);
           
        }

      // transform.Translate(0, 0, 40* Time.deltaTime);
        GetComponent<Rigidbody>().AddForce((Vector3.forward * GameValues.Instance().ball_speed* Time.deltaTime));
    }
}
