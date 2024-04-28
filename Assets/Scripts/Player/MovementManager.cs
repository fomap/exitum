using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Animations;
using UnityEngine;


public class MovementManager : MonoBehaviour //, ITeleport 
{
    public  FixedJoystick _fixedJoystick;
    public Transform player;
    public float _moveSpeed;
    public float _rotationSpeed;
    public Animator _animator;

    public Rigidbody2D _rb;
    private Vector2 _joystickInput;
    public bool starCollected = false;
    


    private void Update()
    {
        _joystickInput = _fixedJoystick.Direction;
        var vel = _joystickInput.magnitude;

        if (vel == 0)
        {
            _animator.SetBool("isRunning", false);
            
        }
        else
        {
            _animator.SetBool("isRunning", true);
        }

        if(_joystickInput.x < 0)
        {   
            transform.localScale = new Vector2(-0.3f, 0.3f);
        }
        else
        {  
            transform.localScale = new Vector2(0.3f, 0.3f);
        }
    
       

    }

    private void FixedUpdate()
    {
        var targetPos = (Vector2)player.position + _joystickInput * (Time.deltaTime * _moveSpeed);
        player.transform.position = targetPos;


    }




    public void Teleport(Transform destination)
    {
        player.transform.position = destination.transform.position;
    }


   
    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.tag == "Pickup")
        {
            starCollected = true;
            Debug.Log("collected");
        }
     

    }

}
