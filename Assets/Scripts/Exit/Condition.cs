using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condition : MonoBehaviour
{
   
    public LoadManager loadManager;
    
    public int starsToPass; 
  
    private BunnyController player;
    private MovementManagerBunny player2;
    void Start()
    {   
        loadManager.GetComponent<LoadManager>().enabled = false;
        player2 = GameObject.FindObjectOfType<MovementManagerBunny>();
        player = GameObject.FindObjectOfType<BunnyController>();
    }

    void Update()
    {
        if(player.collectedStars == starsToPass || player2.collectedStars == starsToPass )
        {
            loadManager.GetComponent<LoadManager>().enabled = true;
        }
    }
}
