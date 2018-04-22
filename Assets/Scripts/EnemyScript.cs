using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private MusicManager music;
    private ParticleDestroy particle;

    public int live;

    public GameObject bull;
    public GameObject firepoint;

    public float maxfrecvencyOfFire;
    public float minfrecvencyOfFire;

    private float TimeToFire;

    void SetTimeToFire()
    {
        TimeToFire = Random.Range(minfrecvencyOfFire, maxfrecvencyOfFire);
    }

    private void Awake()
    {
        SetTimeToFire();
        music = FindObjectOfType<MusicManager>();
        particle = FindObjectOfType<ParticleDestroy>();
        maxfrecvencyOfFire = 10 / EnemySpawner.level;
        minfrecvencyOfFire = 5 / EnemySpawner.level;
    }

    void Fire()
    {
        music.PlayEnemyFire();
        Instantiate(bull, firepoint.transform.position, Quaternion.identity);
    }

    void SetFire()
    {
        TimeToFire -= Time.deltaTime;

        if (TimeToFire < 0)
        {
            Fire();
            SetTimeToFire();
        }
    }


    private void Update()
    {
        SetFire();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShipScript.points++;
        live--;
        if (live <= 0)
        {
            music.PlayDestroy();
            particle.PlayDestroy(this.transform.position);
            Destroy(gameObject);
            ShipScript.points++;
        }

    }

    
    
    


}   
