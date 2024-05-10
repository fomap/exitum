using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MovementManagerBunny : MonoBehaviour //, ITeleport 
{




    public  FixedJoystick _fixedJoystick;
   
    public Transform player;
    public float _moveSpeed;
    public float _rotationSpeed;
    public Animator _animator;

    public Rigidbody2D _rb;
    private Vector2 _joystickInput;

    public bool _canDoubleJump;
    public int _numOfJumps = 0;
    public int _maxNumberOfJumps = 2;
    
    public Transform groundCheck;
    public LayerMask groundLayer;
    
    public int collectedStars;

    private float jumpingPower = 8f;
    // public AudioSource _walkSound;
 

    [SerializeField] private Camera _camera; 
    [SerializeField] private float _dampingSpeed;
    // public int sceneID;


    // public float[,] initPoints =
    // {
    //     {-6, -4},
    //     {-8, -8.5f},

    // };
    

    // private void Awake()
    
    // {
        
    //     sceneID = SceneManager.GetActiveScene().buildIndex - 1;
    //     transform.position = new Vector2(initPoints[sceneID, 0], initPoints[sceneID, 1]);
    // }

    private void Start() {
    //    _camera= GameObject.FindObjectOfType<Camera>();
        _canDoubleJump = false;
         collectedStars = 0;
        // _walkSound = GetComponent<AudioSource>();
        // _camera = Camera.main;
        // _camera.enabled = true; 
    }
    private void Update()
    {


        // horizontal = Input.GetAxis("Horizontal");


        // if(Input.GetKey(KeyCode.Space))
        // {
        //     Jump();   
        // }

     




        _joystickInput = _fixedJoystick.Direction;
    
        var vel = _joystickInput.magnitude;

        if (vel == 0 )//|| horizontal == 0)
        {
            _animator.SetBool("isRunning", false);
            // _walkSound.Stop();
        }
        // else if (horizontal != 0 || vel != 0 )
        else
        {
            _animator.SetBool("isRunning", true);
        //    if(!_walkSound.isPlaying)
        //    {
        //     _walkSound.Play();

        //    }
            //_walkSound.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
        }

        if(_joystickInput.x < 0) // || horizontal < 0f)
        {   
            transform.localScale = new Vector2(-1f, 1f);
        }
        else
        {  
            transform.localScale = new Vector2(1f,1f);
        }

        
        if(!isGrounded())
        {
            _animator.SetBool("isJumping", false);

        }
     


    }

    private void FixedUpdate()
    {
        var targetPos = (Vector2)player.position + new Vector2(_joystickInput.x, 0) * (Time.deltaTime * _moveSpeed);
        player.transform.position = targetPos;

        // _rb.velocity = new Vector2(horizontal * speed, _rb.velocity.y);

        _camera.transform.position = Vector3.Lerp(new Vector3(_camera.transform.position.x,  _camera.transform.position.y,  -10), transform.position, Time.deltaTime * _dampingSpeed);


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
        // Debug.Log("hewwo");
        // if(_rb.velocity.y > 0f)
        // {
        //      _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * 0.5f);
        // }
        // else
        // {

        // if(isGrounded() || _doubleJump)
        // {
        //     _rb.velocity = new Vector2(_rb.velocity.x, jumpingPower);
        //     _animator.SetBool("isJumping", true);

        //     _doubleJump = !_doubleJump;

        // }
        // }
        
        if(_joystickInput != Vector2.zero)
        {
            jumpingPower +=2;
        }  
       
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
        jumpingPower = 8f;
    }
    // private void OnTriggerEnter2D(Collider2D other) {
        
    //     if(other.gameObject.tag == "Pickup")
    //     {
    //         starCollected = true;
    //         Debug.Log("collected");
    //     }
     

    // }

}
