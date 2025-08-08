using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    PlayerControls controls;
    float direction;
    bool isFacingRight = true;


    [Header("Jumping")]
    [SerializeField] private int currectNumberOfJumps = 0;
    [SerializeField] private int maxJumps = 1;
    private int availableJumps;
    [SerializeField] private float jumpVelocity = 6;
    [SerializeField] private bool isGrounded;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private LayerMask groundLayer;

    [Header("Camera follow")]
    [SerializeField] Camera camera;
    [SerializeField] private float dampingSpeed;
    [SerializeField] private float speed = 150;


    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] Animator animator;
    [SerializeField] private int collectedStars;

    private void Awake()
    {

        // DontDestroyOnLoad(gameObject);
       
        camera = Camera.main;
        
        collectedStars = 0;
        controls = new PlayerControls();
        controls.Enable();


        controls.Forest.Move.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();

        };

        controls.Forest.Jump.performed += ctx => Jump();


    }

    // Start is called before the first frame update
    void Start()
    {
        availableJumps = maxJumps;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, 0.1f, groundLayer);
        animator.SetBool("isGrounded", isGrounded);

        if (isGrounded && playerRB.velocity.y <= 0)
        {
            currectNumberOfJumps = 0;
        }


        playerRB.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, playerRB.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(direction));

        if (isFacingRight && direction < 0 || !isFacingRight && direction > 0)
        {
            FlipPlater();
        }

        camera.transform.position = Vector3.Lerp(new Vector3(camera.transform.position.x, camera.transform.position.y, -10), transform.position, Time.deltaTime * dampingSpeed);
    }

    void FlipPlater()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    void Jump()
    {
        if (isGrounded || currectNumberOfJumps < availableJumps)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpVelocity);
            currectNumberOfJumps++;
            animator.SetTrigger("Jump");

            StartCoroutine(JumpCD());
        }
    }

    IEnumerator JumpCD()
    {
        yield return new WaitForSeconds(0.1f);
        animator.ResetTrigger("Jump");
    }

    public void CollectedCarrot()
    {
        maxJumps++;
        availableJumps = maxJumps;
    }

    public void CollectedStar()
    {
        collectedStars++;
    }

    public int getCollectedStars()
    {
        return collectedStars;
    }




    // private void OnEnable()
    // {
    //     SceneManager.sceneLoaded += OnSceneLoaded;
    // }

    // private void OnDisable()
    // {
    //     SceneManager.sceneLoaded -= OnSceneLoaded;
    // }

    // private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    // {
    //     camera = Camera.main;
    //     transform.position = Vector3.zero;
    //     //  groundcheck = transform.Find("GroundCheck");
    // }
 
    private void OnDestroy()
    {
    if (controls != null)
    {
        controls.Disable();
        controls.Dispose();
    }
    }   
}
