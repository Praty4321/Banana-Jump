using System.Collections;   //3
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public static PlatformSpawner instance;

    [SerializeField]
    private GameObject left_Platform, right_Platform;

    private float left_X_min = -4.4f, left_X_max = -2.8f, right_X_max = 2.8f, right_X_min = 4.4f; //these are range of random values at which the platforms will be spawned.
    private float Y_Threshold = 2.6f; //this is the difference between any two platforms spawnned OR how high above the old plat, new platform will come.
    private float last_Y;

    public int spawn_Count = 8;// how many plats per spawn will be created/spawned.
    private int platform_Spawned; //this will determine whether left or right plat will be spawned.

    [SerializeField]
    private Transform platform_Parent;


    //more variables to spawn bird enemy .... made at the last of scripting process
    [SerializeField]
    private GameObject bird;
    public float bird_Y = 5f;//how we get this....by placing bird on screen and moving in y direction....andaaje se 
    private float bird_X_min = -2.51f, bird_X_max = 2.51f; //ye bhi andaaje se

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    private void Start()
    {
        last_Y = transform.position.y;
        SpawnPlatforms();
    }


    public void SpawnPlatforms()
    {
        Vector2 temp = transform.position;
        GameObject newPlatform = null;

        for (int i = 0; i < spawn_Count; i++)
        {
            temp.y = last_Y;
            /*  temp vector2 is the temporary position of the platform spawned   */

            //we have even no.....right plat will be spawned.
            if ((platform_Spawned % 2) == 0)
            {
                temp.x = Random.Range(left_X_min, left_X_max);
                newPlatform = Instantiate(right_Platform, temp, Quaternion.identity);
            }
            else // we have odd no.....left platform will be...
            {
                temp.x = Random.Range(right_X_min, right_X_max);
                newPlatform = Instantiate(left_Platform, temp, Quaternion.identity);
            }


            newPlatform.transform.parent = platform_Parent; // We are doing this coz we want all the platforms created during play will be under a parent and that will look organized.


            // Also make sure both platform prefabs are 

            last_Y += Y_Threshold;
            platform_Spawned++;

        }
        if (Random.Range(0, 2) > 0) //this is a very smart way of creating a 50 50 chance for this function to execute.
        {
            SpawnBird();
        }

    } //spawnPlatforms

    void SpawnBird()
    {
        Vector2 temp = transform.position; //here vector2 means it will give only the x and y position. 
        temp.x = Random.Range(bird_X_min, bird_X_max);
        temp.y += bird_Y;

        GameObject newBird = Instantiate(bird, temp, Quaternion.identity);
        newBird.transform.parent = platform_Parent;
    }


}// class end



























































