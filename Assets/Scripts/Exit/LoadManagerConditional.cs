using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManagerConditional : MonoBehaviour
{
    private GameObject player;
    private MovementManager mm;
    [SerializeField] private string Scene;
   
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        
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
            
            mm = FindObjectOfType<MovementManager>();
            if (mm.starCollected == true)
            {
                SceneManager.LoadScene(Scene);
            }

        }
    }


}
