using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    
    private BunnyController player;
    private MovementManagerBunny player2;
    public AudioSource tpSound;
   
    public List<Transform> teleportLocations = new List<Transform>();
    private int starsInPlayer;
    private void Start()
    {
        player = GameObject.FindObjectOfType<BunnyController>();
        player2 = GameObject.FindObjectOfType<MovementManagerBunny>();
        tpSound = GetComponent<AudioSource>();

    }
    private void OnTriggerEnter2D(Collider2D col)
    {   
        if(col == player.GetComponent<CapsuleCollider2D>() || col == player2.GetComponent<CapsuleCollider2D>() )
        {
            starsInPlayer = player.collectedStars;
            tpSound.Play();   
                 
            if(teleportLocations.Count == 1)
            {
                col.transform.position = new Vector2(teleportLocations[0].transform.position.x, teleportLocations[0].transform.position.y);
            }
            else
            {
                for(int i = 0; i < teleportLocations.Count; i++)
                {
                    if(starsInPlayer == i)
                    {
                        col.transform.position = new Vector2(teleportLocations[i].transform.position.x, teleportLocations[i].transform.position.y);
                    }
                }
            }

            

        }
    }
}
