using System.Collections;                   //8
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    private AudioSource soundFX;

    [SerializeField]
    private AudioClip jumpSound, gameOverSound;

    private void Awake()         /* using instance in Awake means that this script will have funcitons that will be called in other scripts.     */
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void JumpSoundFX()
    {
        soundFX.clip = jumpSound;
        soundFX.Play();
    }


    public void GameOverSoundFX()
    {
        soundFX.clip = gameOverSound;
        soundFX.Play();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
