using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_1_follow: MonoBehaviour
{
     public int playerSpeed = 10;
    public int playerJumpPower = 1250;

    public float moveX;

    bool facingRight = false;
    bool pause = false;

    public bool ground;
    bool dash;
    int trigger = 0;
    public Player_1 Player_1_Function;

    public static bool waitPause = false;
    public static bool jumpWait = false;
    public static bool player_1_jump = false;
    public static float coordinate;
    public static float velocity;
    
    Rigidbody2D player_0;
    Rigidbody2D player_1;

    Animator anim;

    SpriteRenderer arrow;

    private void Awake()
    {
        Player_1_Function = FindObjectOfType<Player_1>();
        player_0 = GameObject.Find("Player_0").GetComponent<Rigidbody2D>();
        player_1 = GameObject.Find("Player_1").GetComponent<Rigidbody2D>();
        arrow = GameObject.Find("Arrow").GetComponent<SpriteRenderer>();
        arrow.enabled = false;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pause)
        {
            WaitForRelease();
        } else
        {
            if (ground && Player_1.ground)
            {
                dash = false;
            }
            PlayerMove();
            DisableMovement();
        }
    }

    void WaitForRelease()
    {
        if (Input.GetMouseButtonUp(0))
        {
            pause = false;
            player_0.isKinematic = false;
            arrow.enabled = false;

            Vector3 sp = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 dir = (Input.mousePosition - sp).normalized;
            player_0.AddForce(dir * 2500);
            anim.SetBool("Ground", false);

            StartCoroutine(WaitForPlayer(dir));
        }
        else if (Input.GetMouseButtonUp(1))
        {
            pause = false;
            jumpWait = true;
            player_0.isKinematic = false;
            arrow.enabled = false;
            
            Vector3 sp = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 dir = (Input.mousePosition - sp).normalized;

            Player_1.dir = -dir;
            player_1.isKinematic = false;
            player_1.gravityScale = 0f;
            player_1.AddForce(dir * 1500);
            player_1.drag = 0;

            Player_1_Function.ThrowPlayer();
        }
    }

    private IEnumerator WaitForPlayer(Vector3 dir)
    {
        yield return new WaitForSeconds(0.5f);
        jumpWait = true;
        player_1.isKinematic = false;
        player_1.AddForce(dir * 2500);
    }
 

    void PlayerMove()
    {
        moveX = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(moveX));

        if (Input.GetButtonDown("Jump") && ground)
        {
            if (moveX != 0)
            {
                player_1_jump = true;
                coordinate = player_0.transform.position.x;
                velocity = moveX;
            }
            Jump();
        }

        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) && dash)
        {
            DisableMovement();
        }

        if (moveX < 0.0f && !facingRight)
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && facingRight)
        {
            FlipPlayer();
        }

        if (ground && moveX != 0)
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        else if( moveX != 0){
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }

    }

    void DisableMovement()
    {
        // // Pause
        // pause = true;
        // waitPause = true;

        // // Disable Player_0 Gravity
        // player_0.isKinematic = true;
        // player_0.velocity = Vector2.zero;
        // moveX = 0;

        // // Disable Player_0 Animation
        // anim.SetFloat("Speed", 0);

        // player_1.isKinematic = true;
        // player_1.velocity = Vector2.zero;

        // dash = false;


        // Transport Player_1 position to Player_0
        player_0.transform.Translate(Vector3.up * 0.01f, Space.World);
        Vector3 temp = new Vector3(player_0.transform.position.x-(5-(Time.unscaledTime/10)),player_0.transform.position.y);
        player_1.transform.position = temp;


        // // Show Arrow
        // arrow.enabled = true;
        // ground = false;
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        ground = false;
        anim.SetBool("Ground", false);
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;

        Vector2 arrowLocalScale = arrow.transform.localScale;
        arrowLocalScale.x *= -1;
        arrow.transform.localScale = arrowLocalScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            trigger++;
            if (trigger > 0)
            {
                ground = true;
                anim.SetBool("Ground", true);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            trigger--;
            if (trigger <= 0)
                ground = false;
        }
    }
}
