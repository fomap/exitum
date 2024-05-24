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

    /*Because during development phase if was uncomfotable to use joystick on a screen with mouse, 
    seperate controller that uses keyboards was created, hence or statement in 37th line*/
   
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

            soundEffect.Play();
            if(item == Type.star)
            {
                
                player2.collectedStars += 1;
                player.collectedStars += 1;
            }
            else
            {
                player2._canDoubleJump = true;
                player._canDoubleJump = true;
                player._maxNumberOfJumps+=1;
                player2._maxNumberOfJumps+=1;

            }

     
            spriteOfObject.enabled = false;
            colliderOfObject.enabled = false;
            
        }
    }

}
