using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportNew : MonoBehaviour
{
    public Transform exit;
    private GameObject player;
   
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            // Debug.Log("Jello");
           player.transform.position = new Vector2(exit.transform.position.x, exit.transform.position.y);

        }
    }
}
