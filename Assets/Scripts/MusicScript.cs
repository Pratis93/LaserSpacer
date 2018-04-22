using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicScript : MonoBehaviour
{

    static GameObject instance = null;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = gameObject;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        Debug.Log("Instacne ID " + GetInstanceID().ToString());
    }

}
