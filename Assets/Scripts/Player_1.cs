using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_1 : MonoBehaviour
{
    public float distance_move_faster = 3.0f;
    public float distance_move = 2.5f;
    public int playerSpeed = 10;
    public int playerJumpPower = 1250;
    private bool facingRight = false;

    Animator anim;
    Rigidbody2D player_0;
    Rigidbody2D player_1;

    float distance;
    bool throw_collide = false;
    bool check_land = false;
    public bool throwPlayer = false;
    float velocity = 0;
    int trigger = 0;

    public static bool ground;
    public static Vector3 dir;
    public static int rightPower;

    void Awake()
    {
        player_0 = GameObject.Find("Player_0").GetComponent<Rigidbody2D>();
        player_1 = GameObject.Find("Player_1").GetComponent<Rigidbody2D>();
    }

	// Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
	}

	// Update is called once per frame
    void Update()
    {
        if (Character_Move.jumpWait)
        {
            if (Mathf.Abs(player_0.transform.position.x - player_1.transform.position.x) < 1 || ground)
            {
                Character_Move.waitPause = false;
                Character_Move.jumpWait = false;
            }
        }
        else if (!throwPlayer && !Character_Move.waitPause && ground) 
        {
            if (Character_Move.player_1_jump && Mathf.RoundToInt(player_1.transform.position.x) == Mathf.RoundToInt(Character_Move.coordinate))
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Character_Move.velocity * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
                Jump();
                Character_Move.player_1_jump = false;
            }
            if (ground)
            {
                PlayerMove();
            }
        }

        if (Character_Move.midAir != Vector2.zero)
        {
            StartCoroutine(WaitMidAir());
        }
        
        if (Character_Move.state == 1)
        {
            anim.SetBool("Ground", true);
            anim.SetInteger("Animate", 1);
        }
        else if (Character_Move.state == 2)
        {
            anim.SetInteger("Animate", 2);
        }
        else if (Character_Move.state == 3)
        {
            anim.SetInteger("Animate", 3);
        }
        else if (Character_Move.state == 4)
        {
            anim.SetInteger("Animate", 4);
        }
        else if (Character_Move.state == 5)
        {
            anim.SetInteger("Animate", 5);
        }
        else
        {
            //player_image.sprite = imageList[0];
            anim.SetInteger("Animate", 0);
        }
        //Character_Move.state = 5;
	}

    IEnumerator WaitMidAir()
    {
        yield return new WaitUntil(() => Mathf.RoundToInt(player_1.position.x) == Mathf.RoundToInt(Character_Move.midAir.x));
        gameObject.GetComponent<Rigidbody2D>().velocity = Character_Move.MidAirVel;
        Character_Move.midAir = Vector2.zero;
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        ground = false;
        anim.SetBool("Ground", false);
    }

    void PlayerMove()
    {
        Vector2 localScale = gameObject.transform.localScale;
        distance = player_0.transform.position.x - player_1.transform.position.x;

        if (Mathf.Abs(distance) <= distance_move)
            velocity = 0;
        else if (distance > 0)
        {
            if (distance > distance_move_faster)
                velocity = 1.5f;
            else
                velocity = 1;
        }
        else
        {
            if (distance < -distance_move_faster)
                velocity = -1.5f;
            else
                velocity = -1;
        }
        
        if (distance > distance_move)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
            if (facingRight)
                FlipPlayer();
        }
        else if (distance < -distance_move)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
            if (!facingRight)
                FlipPlayer();
        }
        anim.SetFloat("Speed", Mathf.Abs(velocity));
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    public void ThrowPlayer() {
        throwPlayer = true;
        check_land = false;
        StartCoroutine(WaitFunction());
        StartCoroutine(MidAirFunction());
        InvokeRepeating("CheckCollide", 0, 0.01667f);
    }

    private void CheckCollide()
    {
        if (!check_land && throw_collide)
        {
            Character_Move.state = 5;
            player_1.velocity = Vector2.zero;
            player_1.AddForce(dir * rightPower);
            check_land = true;
        }
        if (check_land && ground || check_land && Mathf.RoundToInt(player_1.transform.position.x) == Mathf.RoundToInt(player_0.transform.position.x))
        {
            player_1.velocity = Vector2.zero;
            player_1.gravityScale = 6.0f;
            player_1.drag = 1;
            throwPlayer = false;
            Character_Move.state = 0;
            CancelInvoke("CheckCollide");
        }
    }

    private IEnumerator MidAirFunction()
    {
        yield return new WaitForSeconds(1f);
        if (check_land && !ground)
        {
            player_1.velocity = Vector2.zero;
            player_1.gravityScale = 6.0f;
            player_1.drag = 1;
            throwPlayer = false;
            Character_Move.state = 0;
            CancelInvoke("CheckCollide");
        }
    }

    private IEnumerator WaitFunction()
    {
        yield return new WaitForSeconds(0.5f);
        if (!check_land)
        {
            Character_Move.state = 5;
            player_1.velocity = Vector2.zero;
            player_1.AddForce(dir * rightPower);
            check_land = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") {
            trigger++;
            if (trigger > 0)
            {
                ground = true;
                anim.SetBool("Ground", true);
                Character_Move.state = 0;
            }
        }

        throw_collide = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") {
            trigger--;
            if (trigger <= 0)
            {
                ground = false;
                if (!Character_Move.pause && !Character_Move.jumpWait)
                    anim.SetBool("Ground", false);
            }
        }

        throw_collide = false;
    }
}
