using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condition : MonoBehaviour
{
   
    [SerializeField] private LoadManager loadManager;
    [SerializeField] private int starsToPass; 
    private PlayerMovement player;
    void Start()
    {   
        loadManager.GetComponent<LoadManager>().enabled = false;
        player = GameObject.FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        if(player.getCollectedStars() == starsToPass)
        {
            loadManager.GetComponent<LoadManager>().enabled = true;
        }
    }
}
