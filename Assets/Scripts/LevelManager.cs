using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
   public enum nameOfScene 
    {
        Start,
        Level_01,
        GameOver,
        Win
    }


    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
