using System.Collections;       //6
using System.Collections.Generic;
using UnityEngine;

public class BGSpawner : MonoBehaviour
    //collector will collect the background and BG Spawner will be going to reactivate those backgrounds.
{
    private GameObject[] bgs;  //array of backgrounds
    private float height; //height of background
    private float highest_Y_Pos;

    private void Awake()
    {
        bgs = GameObject.FindGameObjectsWithTag("BG"); //GameObjectS.....this will put all the backgrounds in this array 
    } /* But using FindObjectswithtag function does not guarantees the order of BG's in array*/


    // Start is called before the first frame update
    void Start()
    {
        height = bgs[0].GetComponent<BoxCollider2D>().bounds.size.y; //dosent matter if it is bgs[1] or bgs[2]...its just we are getting the size of one background
        highest_Y_Pos = bgs[0].transform.position.y;
        /* since no guarantee of order of BG's in array  */
        //and we are not sure that's the highest y pos we will

        for (int i = 1; i < bgs.Length; i++)
        {
            if (bgs[i].transform.position.y > highest_Y_Pos)
                highest_Y_Pos = bgs[i].transform.position.y;
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "BG")
        {
            if (target.transform.position.y >= highest_Y_Pos) //that means we collided with the highest Y BG and than what we will be going to do...
            {
                Vector3 temp = target.transform.position; //we are storing the current position of the highest background.

                for (int i = 0; i < bgs.Length; i++)
                {
                    //if  the BG at i index is NOT active in the hierarchy

                    if (!bgs[i].activeInHierarchy)
                    {
                        temp.y = temp.y + height;
                        bgs[i].transform.position = temp;
                        bgs[i].gameObject.SetActive(true);

                        highest_Y_Pos = temp.y;
                    }
                }


            }
        }
    }
    //at this point everything is working correctly so what we will do to give finishing touches to the game.
    //Now finally after everything we need to create bounds for our player so that he cannot leave the camera view.
    //so for that we will create a game object under main camera with collider and set its pos and dimentions.
    //after that we will realize that on pressing the respective side arrow key monkey will be stuck to the side wall.
    //for that simply add a physics material with no friction 





}//class end








































