using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    private GameObject player;
    private int index;
    public int achieved;
    // public string Name;
    [SerializeField] private string Scene;
   
    void Start()
    {
        achieved = PlayerPrefs.GetInt("Name");
        player = GameObject.FindWithTag("Player");
        index = SceneManager.GetActiveScene().buildIndex;
        
    }


    // private void OnTriggerEnter2D(Collider2D col)
    // {
    //     if(col.gameObject.tag == "Player")
    //     {
    //         SceneManager.LoadScene(Scene);
    //     }
    // }


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
                 } //Debug.Log(GameManager.Instance.player.collectedStars);//

            }

            if(achieved == 1)
            {
                SceneManager.LoadScene(Scene);
            }
           //v Debug.Log(GameManager.Instance.player.collectedStars);

        }
    }


}
