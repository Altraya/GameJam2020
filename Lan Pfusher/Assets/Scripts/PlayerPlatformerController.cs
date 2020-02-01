using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.SceneManagement;

public class PlayerPlatformerController : MonoBehaviour
{
    [HideInInspector]
    public bool facingRight = true;			// For determining which way the player is currently facing.

    public float speed;            

    public UnityEngine.UI.Text debugText;

    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.

    private Animator anim;                  // Reference to the player's animator component.

    void Awake()
    {
        // Setting up references.
        //groundCheck = transform.Find("groundCheck");
        anim = GetComponent<Animator>();
    }


    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");
        

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.

        Vector2 horizontalMovement = new Vector2(moveHorizontal * speed, rb2d.velocity.y );

        rb2d.velocity = horizontalMovement;

  
        if (moveHorizontal < 0 && facingRight || moveHorizontal > 0 && !facingRight)
        {
            Flip();
        }
        try
        {
            debugText.text = moveHorizontal.ToString();
        }
        catch { }
        if (Mathf.Abs(moveHorizontal) >= 0.5f)
        {
            anim.SetTrigger("Move");
        }
        else
        {
            anim.SetTrigger("Idle");
        }
        //debugText.text = rb2d.velocity.x.ToString();
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}