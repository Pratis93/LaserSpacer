using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipScript : MonoBehaviour
{

    private MusicManager music;

    private LevelManager level;

    public GameObject bull;
    public GameObject firepoint;

    public Text liveText;
    public Text pointText;

    public static int live = 10;
    public static int points = 0;

    public int speedOfSheep;
    public float frekvencyOfBull;
    private float counterTimebull;


    static public float ymin;
    static public float ymax;
    float xmin;
    float xmax;


    private void Awake()
    {
        music = FindObjectOfType<MusicManager>();
        level = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        live--;
        music.PlayHit();
        Debug.Log("Mam żyć: " + live.ToString());
        if (live <= 0)
        {
            live = 10;
            EnemySpawner.level = 1;
            level.LoadScene("GameOver");

        }

    }



    void SetClamForShip()
    {
        ymin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        xmin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        ymax = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0)).y;
        xmax = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0)).x;
    }


    private void Start()
    {
        SetClamForShip();
    }


    /// <summary>
    /// Zarzadzanie klawiatura
    /// </summary>
    void KeyManager()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.transform.position.x > xmin)
            {
                this.transform.position += new Vector3(-speedOfSheep * Time.deltaTime, 0f, 0f);
            }
        } else
        if (Input.GetKey(KeyCode.RightArrow))
        {

            if (this.transform.position.x < xmax)
            {
                this.transform.position += new Vector3(speedOfSheep * Time.deltaTime, 0f, 0f);
            }
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (this.transform.position.y < ymax)
            {
                this.transform.position += new Vector3(0f, speedOfSheep * Time.deltaTime, 0f);
            }
        } else

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (this.transform.position.y > ymin)
            {
                this.transform.position += new Vector3(0f, -speedOfSheep * Time.deltaTime, 0f);
            }
        }

        if (Input.GetKey(KeyCode.L))
        {
            live = live + 10;
        }

    }

    void UpdateStats()
    {
        liveText.text = "Lives: " + live.ToString();
        pointText.text = "Points: " + points.ToString();
    }


    void Fire()
    {
        counterTimebull += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            if (counterTimebull > 1 / frekvencyOfBull)
            {
                music.PlayMyFire();
                Instantiate(bull, firepoint.transform.position, Quaternion.identity);
                counterTimebull = 0;
            }
        }

    }

    void Checkwin()
    {
        if(points>704)
        {
            level.LoadScene("Win");
        }
    }

    private void Update()
    {
        KeyManager();
        Fire();
        UpdateStats();
        Checkwin();
    }


}
