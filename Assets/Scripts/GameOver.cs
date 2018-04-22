using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text points;

    private void Awake()
    {
        points.text = "PUNKTY: " + ShipScript.points.ToString();
    }




}

