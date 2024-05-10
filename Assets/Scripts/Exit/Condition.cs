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
        // player = GameManager.Instance.player;
         player2 = GameObject.FindObjectOfType<MovementManagerBunny>();
         player = GameObject.FindObjectOfType<BunnyController>();
    }

    void Update()
    {
        
           if(player.collectedStars == starsToPass || player2.collectedStars == starsToPass )
           {

        //        if(player2.collectedStars == starsToPass)
        //    {
            //    Debug.Log(GameManager.Instance.player.collectedStars);

                loadManager.GetComponent<LoadManager>().enabled = true;
               // Debug.Log(loadManager.GetComponent<LoadManager>().enabled);
           }

        
    }
    


    // private void OnTriggerEnter2D(Collider2D col)
    // {
       
    // }
}
