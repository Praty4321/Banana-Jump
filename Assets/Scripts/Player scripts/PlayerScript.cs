using System;        // 1
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float move_Speed = 2f;

    public float normal_Push = 10f;
    public float extra_Push = 14f;

    private bool initial_Push;

    private int push_Count; // will be used to know when to spawn another platform cycle jaise 2 push ke baad ususally aur bhi platforms ki zarurat pad hi jayegi.
    private bool player_Died;

    //for score
    [SerializeField]private Text bananaScore ; //simply drag and drop Banana Score from UI.
    private int bananaCount = 0;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if(player_Died == true)
        {
            return;
        }

        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            rb.velocity = new Vector2(move_Speed, rb.velocity.y);
        } else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            rb.velocity = new Vector2(-move_Speed, rb.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D target) // make sure to check trigger box....can be any of the two colliders colliding.
    {
        if (player_Died == true) //doing this just to simply exit the funciton when player is dead.
        {
            return;//code below this will never be executed.
        }

        if (target.tag == "ExtraPush") //agar aise banana se takraaye jispe ExtraPush ka tag laga ho.
        {
            if(!initial_Push) // agar pehle se push nahi hai
            {
                initial_Push = true;
                rb.velocity = new Vector2 (rb.velocity.x, 18f); //velocity dedi
                target.gameObject.SetActive(false); //takraate hi gayab ho jayega banana

                //Banana Score
                ExtraScoreIncrease();

                //soundManager

                //Exit from onTriggerEnter bcoz of extra push
                return;

            } // initial push

            //outside of initial Push
        }

        if(target.tag == "NormalPush")
        {
            rb.velocity = new Vector2(rb.velocity.x, normal_Push);
            target.gameObject.SetActive(false);
            push_Count++;

            //SoundManager
            SoundManager.instance.JumpSoundFX();

            //Banana Score
            NormalScoreIncrease();
        }

        if (target.tag == "ExtraPush")
        {
            rb.velocity = new Vector2(rb.velocity.x, extra_Push);
            target.gameObject.SetActive(false);
            push_Count++;

            //SoundManager
            SoundManager.instance.JumpSoundFX();

            //score
            ExtraScoreIncrease();
        }

        if(push_Count == 2) //this time we are using this technique to create infinite BG effect and not the usual way.
        {
            push_Count = 0;
            PlatformSpawner.instance.SpawnPlatforms();
        }

        if(target.tag == "FallDown" || target.tag == "Bird")
        {
            player_Died = true;

            //Game manager to restart game 
            GameManager.instance.RestartGame();

            //soundmanager
            SoundManager.instance.GameOverSoundFX();

        }

        

    } // on trigger enter

    private void NormalScoreIncrease()
    {
        bananaCount += 1;
        bananaScore.text = bananaCount.ToString();
    }
    public void ExtraScoreIncrease()
    {
        bananaCount += 2;
        bananaScore.text = bananaCount.ToString();
    }


} //class end


























