using System.Collections;   //4
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    /*what we will do here ? */
    //every platform will spawn its own banana so that the monkey will keep moving upwards

    [SerializeField]
    private GameObject One_Banana, Bananas;

    [SerializeField]
    private Transform spawn_Point;

    private void Start()
    {
        GameObject newBanana = null;

        if(Random.Range(0,10) > 3)
        {
            newBanana = Instantiate(One_Banana, spawn_Point.position, Quaternion.identity); // one banana will have normal push and
        } else
        {
            newBanana = Instantiate(Bananas, spawn_Point.position, Quaternion.identity); // bananas will have extra push
        }

        newBanana.transform.parent = transform;
    }
}
