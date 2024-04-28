using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    private GameObject player;
    public GameObject sprite;
    
   
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            sprite.SetActive(false);

        }
    }
}

