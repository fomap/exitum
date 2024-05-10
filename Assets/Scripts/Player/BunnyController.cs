using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BunnyController : MonoBehaviour
{
    private float horizontal;
    private float speed = 5;
    private bool isFacingRight = true;
 
   
    public Transform player;
    public float _moveSpeed;
    public float _rotationSpeed;
    public Animator _animator;

    public Rigidbody2D _rb;


    public bool _canDoubleJump;
    public int _numOfJumps = 0;
    public int _maxNumberOfJumps = 2;

   
    public Transform groundCheck;
    public LayerMask groundLayer;
    
    private float jumpingPower = 8.5f;

    [SerializeField] private Camera _camera; 
    [SerializeField] private float _dampingSpeed;

    public int collectedStars;


    private void Start() {
       _canDoubleJump = false;
         collectedStars = 0;
    
    }
    private void Update()
    {


        horizontal = Input.GetAxis("Horizontal");
        _rb.velocity = new UnityEngine.Vector2(horizontal * speed, _rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();   
            // Debug.Log("GEllo");
        }

        // Flip();
     




        // _joystickInput = _fixedJoystick.Direction;
    
        // var vel = _joystickInput.magnitude;

        // if (horizontal == 0)
        // {
        //     _animator.SetBool("isRunning", false);
            
        // }
        // else
        // {
        //     _animator.SetBool("isRunning", true);
        // }

        if( horizontal < 0f)
        {   
            transform.localScale = new UnityEngine.Vector2(-1f, 1f);
        }
        else
        {  
            transform.localScale = new UnityEngine.Vector2(1f,1f);
        }

        
        if(!isGrounded())
        {
            _animator.SetBool("isJumping", false);

        }
     
        // Debug.Log(horizontal);


    }

    private void FixedUpdate()
    {
        // var targetPos = (Vector2)player.position + _joystickInput * (Time.deltaTime * _moveSpeed);
        // player.transform.position = targetPos;

        // _rb.velocity = new Vector2(horizontal * speed, _rb.velocity.y);

        // Debug.Log(_rb.velocity);

        float inputDir = Input.GetAxis("Horizontal");

        // _spriteBob.flipX = inputDir < 0;

        if (inputDir != 0)
        {
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }
        // _animator.SetFloat("MoveSpeed", Mathf.Abs(inputDir));

       // transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + inputDir, transform.position.y, 0), Time.deltaTime * speed);
        _camera.transform.position = UnityEngine.Vector3.Lerp(new UnityEngine.Vector3(_camera.transform.position.x,  _camera.transform.position.y,  -10), transform.position, Time.deltaTime * _dampingSpeed);

       // transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + inputDir, transform.position.y, 0), Time.deltaTime * speed);
        // var targetPos = player.position.x + horizontal * (Time.deltaTime * speed);
        // player.transform.position = targetPos;
       // player.transform.position = Vector3.Lerp(player.transform.position, new Vector3(player.transform.position.x + inputDir, player.transform.position.y, 0), Time.deltaTime * speed);

    }
    
    // private void Flip()
    // {
    //     if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
    //     {
    //         isFacingRight  =  !isFacingRight;
    //         UnityEngine.Vector3 localScale = transform.localScale;
    //         localScale.x = -1f;
    //         transform.localScale = localScale;
    //     }
    // }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        
    }


    public void Teleport(Transform destination)
    {
        player.transform.position = destination.transform.position;
    }

    public void Jump()
    {
        // Debug.Log("hewwo");
        
        // Debug.Log(isGrounded());
        // if(isGrounded() || _doubleJump)
        // {
        //     _rb.velocity = new UnityEngine.Vector2(_rb.velocity.x, jumpingPower);
        //     _animator.SetBool("isJumping", true);

        //     _doubleJump = !_doubleJump;

        // }


        // if(isGrounded())
        // {
        //     Debug.Log("Hello");
        //   _rb.velocity = new UnityEngine.Vector2(_rb.velocity.x, jumpingPower);
        //     _doubleJump = true;

        // }
        // else
        // {
        //     if(_doubleJump)
        //     {
        //           _doubleJump = false;
        //          _rb.velocity = new UnityEngine.Vector2(_rb.velocity.x, jumpingPower);

        //     }
        // }


            // if(isGrounded() && _numOfJumps >= _maxNumberOfJumps)
            // {   

            //     if(isGrounded() || _numOfJumps < _maxNumberOfJumps)
            // {  

            if((isGrounded()) || (isGrounded() == false &&_numOfJumps < _maxNumberOfJumps && _canDoubleJump))
            {
                // Debug.Log("Hello");
                _rb.velocity = new UnityEngine.Vector2(_rb.velocity.x, jumpingPower);
                _animator.SetBool("isJumping", true);
            }

            if(_numOfJumps == 0) StartCoroutine(WaitForLanding());
            _numOfJumps++;

    }


    private IEnumerator WaitForLanding()
    {
        yield return new WaitUntil(() => !isGrounded());
        yield return new WaitUntil(isGrounded);
        _numOfJumps = 0;
    }
}
