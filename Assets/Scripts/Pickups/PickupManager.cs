using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
  
    public SpriteRenderer spriteOfObject;
    public Collider2D colliderOfObject;
    private BunnyController player;
    private MovementManagerBunny player2;
    public Type item;
    public AudioSource soundEffect;
    public enum Type
    {
        star,
        carrot
    }
    
   
    void Start()
    {
        player = GameObject.FindObjectOfType<BunnyController>();
        player2  = GameObject.FindObjectOfType<MovementManagerBunny>();
        soundEffect = GetComponent<AudioSource>();
        spriteOfObject = GetComponent<SpriteRenderer>();
        colliderOfObject = GetComponent<Collider2D>();
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
    
        if(col == player.GetComponent<CapsuleCollider2D>() || col == player2.GetComponent<CapsuleCollider2D>() )
        {

        //     if(col == player2.GetComponent<CapsuleCollider2D>() )
        // {
            soundEffect.Play();
            // Debug.Log("Hello");
            if(item == Type.star)
            {
                
                player2.collectedStars += 1;
                player.collectedStars += 1;
            }
            else
            {
                player2._canDoubleJump = true;
                player._canDoubleJump = true;

            }

     
            spriteOfObject.enabled = false;
            colliderOfObject.enabled = false;
            
             
        //    Debug.Log(player._doubleJump);
           //player2.collectedStars++;
        //    Debug.Log( player.collectedStars++);

        }
    }

}
