using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] shipt;

    public static bool boss = false;
    public static bool bosson = false;


    private bool movingRight = false;
    public float speedOfEnemy = 4f;

    private float xmax;
    private float xmin;

    public float with;
    public float hight;

    public float nextEnemty;
    private float nextEnemytmp;

    public static int level;
    private int[] points;

    private EnemyScript enemy;

    private void Awake()
    {
        enemy = FindObjectOfType<EnemyScript>();

        nextEnemytmp = nextEnemty;
        level = 1;
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(this.transform.position, new Vector3(with, hight, 0f));
    }

    void SetEnemy()
    {
        var positon = GameObject.FindGameObjectsWithTag("Position");
        int countPosition = positon.Length;

        GameObject[] enemy = new GameObject[countPosition];
        int i = 0;
        foreach (Transform child in transform)
        {
            enemy[i] = Instantiate(shipt[level-1], new Vector3(child.position.x, child.position.y, 0f), Quaternion.identity) as GameObject;
            enemy[i].transform.parent = child;
            i++;
        }
    }
    void SetClark()
    {
      xmin =  Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
      xmax = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0)).x;
    }
    void MoveEnemy()
    {

        if (movingRight)
        {
            transform.position += new Vector3(speedOfEnemy * Time.deltaTime, 0f, 0f);
            if (transform.position.x + with / 2 > xmax) movingRight = false;
        }
        else
        {
            transform.position -= new Vector3(speedOfEnemy * Time.deltaTime, 0f, 0f);
            if (transform.position.x - with / 2 < xmin) movingRight = true;
        }
    }
        

    void RespawnDeadEnemy()
    {
        var positon = GameObject.FindGameObjectsWithTag("Position");

        foreach (var child in positon)
        {
            if (child.transform.childCount ==0)
            {
                nextEnemytmp -= Time.deltaTime;

                if(nextEnemytmp < 0)
                {
                    int max = 0;

                    max = level;
                    if(level>5)
                    {
                        max = 5;
                        boss = true;
                    }

                    if (!boss)
                    {
                        GameObject enemy = Instantiate(shipt[max - 1], new Vector3(child.transform.position.x, child.transform.position.y, 0f), Quaternion.identity) as GameObject;
                        enemy.transform.parent = child.transform;
                        nextEnemytmp = nextEnemty;
                    }else
                    {
                        if (!bosson)
                        {
                            GameObject enemy = Instantiate(shipt[max], new Vector3(child.transform.position.x, child.transform.position.y, 0f), Quaternion.identity) as GameObject;
                            bosson = true;
                            enemy.transform.parent = child.transform;
                            nextEnemytmp = nextEnemty;
                        }
                    }
                }
               
            }


        }
    }

    void SetLevel()
    {
        int points = ShipScript.points;

        if(points> level*100)
        {
            ShipScript.live += level;
            
                level++;
            
            if(level>5)
            {
                if (enemy.maxfrecvencyOfFire > 3)
                {
                    enemy.maxfrecvencyOfFire -= 1;
                }
            }

        }
    }

    private void Start()
    {
        SetEnemy();
        SetClark();

    }
     private void Update()
    {
        MoveEnemy();
        RespawnDeadEnemy();
        SetLevel();
    }
  
    

}
 