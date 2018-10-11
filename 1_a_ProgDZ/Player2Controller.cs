using UnityEngine;

public class Player2Controller : MonoBehaviour {

    public float speed;
    public float ballControll;
    public float ballShootSpeed;
    public float slideSpeed;
    public float slideTime;
    private float slideTimer;

    private float moveX;
    private float moveY;
    private Rigidbody2D rb;

    private Rigidbody2D ball;
    private bool hasBall;
    private bool shooting;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody2D>();
        slideTimer = slideTime;
    }


    void Update()
    {
        moveX = Input.GetAxisRaw("P2Horizontal");
        moveY = Input.GetAxisRaw("P2Vertical");

        shooting = false;
        slideTimer -= Time.deltaTime;

        if (Input.GetButtonDown("P2Fire1"))
        {
            if (hasBall)
            {
                shooting = true;
                ball.velocity = new Vector2(moveX * ballShootSpeed, moveY * ballShootSpeed);
            }
            else
            {
                if (slideTimer <= 0)
                {
                    rb.velocity = new Vector2(moveX * slideSpeed, moveY * slideSpeed);
                    slideTimer = slideTime;
                }
            }
        }
    }


    void FixedUpdate()
    {
        if (slideTimer <= 0)
        {
            rb.velocity = new Vector2(moveX * speed, moveY * speed);
        }
    }


    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>() == ball && !shooting && slideTimer <= 0)
        {
            hasBall = true;
            ball.velocity = new Vector2(moveX * ballControll, moveY * ballControll);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>() == ball)
        {
            hasBall = false;
        }
    }

}
