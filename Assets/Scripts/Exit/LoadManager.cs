using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
  
    private int index;
    public int achieved;
    [SerializeField] private string Scene;
   
    void Start()
    {
        achieved = PlayerPrefs.GetInt("Name");
        index = SceneManager.GetActiveScene().buildIndex;
        
    }




     private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if(achieved == 0)
            {
                if (this.enabled)
                {
                    index++;
                    achieved++;
                    PlayerPrefs.SetInt("highestLevel", index);
                    PlayerPrefs.SetInt(Scene, achieved);
                    PlayerPrefs.Save();
                    SceneManager.LoadScene(Scene);
                }
            }

            if(achieved == 1)
            {
                SceneManager.LoadScene(Scene);
            }
         
        }
    }


}
