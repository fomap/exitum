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
 
    public Transform player;
    public float _moveSpeed;
    public float _rotationSpeed;
    public Animator _animator;

    public Rigidbody2D _rb;


    public bool _canDoubleJump;
    public int _numOfJumps = 0;
    public int _maxNumberOfJumps = 1;

   
    public Transform groundCheck;
    public LayerMask groundLayer;
    
    private float jumpingPower = 8.5f;

    [SerializeField] private Camera _camera; 
    [SerializeField] private float _dampingSpeed;

    public int collectedStars;


    private void Start() {
        _canDoubleJump = false;
        collectedStars = 0;
        _maxNumberOfJumps = 1;
    
    }
    private void Update()
    {


        horizontal = Input.GetAxis("Horizontal");
        _rb.velocity = new UnityEngine.Vector2(horizontal * speed, _rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();               
        }

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
    
    }

    private void FixedUpdate()
    {
        float inputDir = Input.GetAxis("Horizontal");

        if (inputDir != 0)
        {
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }
       
        _camera.transform.position = UnityEngine.Vector3.Lerp(new UnityEngine.Vector3(_camera.transform.position.x,  _camera.transform.position.y,  -10), transform.position, Time.deltaTime * _dampingSpeed);
    }
    

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
       
        if((isGrounded()) || (isGrounded() == false && _numOfJumps < _maxNumberOfJumps && _canDoubleJump))
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
