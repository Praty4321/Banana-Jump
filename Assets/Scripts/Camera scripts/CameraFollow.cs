using System.Collections;   //2
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    private bool followPlayer;
    public float min_Y_Threshold = -2.6f;

    // Start is called before the first frame update
    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }
    
    void Follow()
    {
        /* How to limit the camera to only follow player when it goes Upwards*/
        if(target.position.y < (transform.position.y - min_Y_Threshold))
        {
            followPlayer = false;
        }

        if (target.position.y > transform.position.y )
        {
            followPlayer = true;
        }

        if (followPlayer)
        {
            Vector3 temp = transform.position;
            temp.y = target.position.y;
            transform.position = temp;
        }
        /* How to limit the camera to only follow player when it goes Upwards*/
    }
}
