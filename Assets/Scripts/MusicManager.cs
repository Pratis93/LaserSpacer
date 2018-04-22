using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip hitMe;
    public AudioClip enemyFire;
    public AudioClip myFire;
    public AudioClip destroy;

    private AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }




    public void PlayHit()
    {
        audio.clip = hitMe;
        audio.Play();
    }

    public void PlayEnemyFire()
    {
        audio.clip = enemyFire;
        audio.Play();
    }

   public  void PlayMyFire()
    {
        audio.clip = myFire;
        audio.Play();
    }

    public void PlayDestroy()
    {
        audio.clip = destroy;
        audio.Play();
    }
	
}

