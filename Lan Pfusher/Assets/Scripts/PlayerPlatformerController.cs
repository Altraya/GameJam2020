using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.SceneManagement;

public class PlayerPlatformerController : MonoBehaviour
{
    [HideInInspector]
    public bool facingRight = true;			// For determining which way the player is currently facing.

    public float speed;            
    private float jumpForce = 10;       
    public float jumpHeight;
    public Vector2 windForce = new Vector2();


    public UnityEngine.UI.Text debugText;

    private bool isJumping;

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
        //feetCollider = (from bc2d in GetComponents<BoxCollider2D>() where bc2d.tag.Equals("feet") select bc2d).FirstOrDefault(); 
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        Vector2 jumpVector = Vector2.zero;

        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");
        

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.

        Vector2 horizontalMovement = new Vector2(moveHorizontal * speed, rb2d.velocity.y );

        rb2d.velocity = horizontalMovement + windForce;

        if(moveVertical > 0)
        {
            //Jump(moveVertical);
        }

  

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

    private void Jump(float verticalAxis)
    {
        if( false)
        {
            isJumping = true;
            jumpHeight = transform.position.y + 4;
            
            //When the jump starts, the Vertical force becomes jumpForce
            if (verticalAxis > 0)
            {
                rb2d.AddForce((Vector2.up * jumpForce) - (rb2d.velocity * Vector2.up), ForceMode2D.Force);
                //transform.Translate(Vector2.up * Time.fixedTime);
                // Set the Jump animator trigger parameter.
                anim.SetTrigger("Jump");
            }
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(!collision.isTrigger)//todo check if ground ?
        isJumping = false;
    }

    void Flip()
    {
        facingRight = !facingRight;
        //transform.localScale *= new Vector2(-1,1);
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Jump(0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Contains("Water"))
        {



            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains("Enemy"))
        {
            SceneManager.LoadScene("Intro");
        }
    }
}