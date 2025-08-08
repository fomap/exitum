using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
  
    public SpriteRenderer spriteOfObject;
    public Collider2D colliderOfObject;
    private PlayerMovement player;
    public Type item;
    public AudioSource soundEffect;
    public enum Type
    {
        star,
        carrot
    }

   
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        soundEffect = GetComponent<AudioSource>();
        spriteOfObject = GetComponent<SpriteRenderer>();
        colliderOfObject = GetComponent<Collider2D>();
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
    
        if(col == player.GetComponent<CapsuleCollider2D>() )
        {

            soundEffect.Play();
            if(item == Type.star)
            {
                
               player.CollectedStar();
            }
            else if(item == Type.carrot)
            {
                player.CollectedCarrot();
            }

     
            spriteOfObject.enabled = false;
            colliderOfObject.enabled = false;
            
        }
    }

}
