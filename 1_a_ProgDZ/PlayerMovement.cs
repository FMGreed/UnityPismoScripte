using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    public CharacterController2D controller;    //Reference on script that is managing player's physics
    
    public Animator animator;                   //Reference on Animator component for managing animations
    public PlayerSounds playerSounds;

    public float runSpeed;                      //Number that represent player's movement speed
    
    float horizontalMove = 0f;                  //Number that is referencing horizontal input from 1 to -1
    bool jump = false;                          //Bool that is switching when jump key is pressed
    public bool crouch = false;                 //Bool that is switching when chrouch key is pressed

    public bool facingForward = true;           //Bool that is switching when A or D key is pressed

    public bool onMainGround;

    public GameObject bullet;
    public Transform spawnPoint;

    // Update is called once per frame
    void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetKeyDown(KeyCode.A))
        {
            facingForward = false;
            
        }
        else if (Input.GetKeyDown(KeyCode.D))
            facingForward = true;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump")) 
        {
            jump = true;
            animator.SetBool("IsJumping", true);
            playerSounds.PlaySound(playerSounds.jump);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("Attack");
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
            
	}

    //Update for accurete physics calculations
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    //Function that is connected to Character Controller's event 'On Land Event'
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    //Function that is connected to Character Controller's event 'On Crouch Event'
    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "MainGround")
        {
            onMainGround = true;
        }
        else
        {
            onMainGround = false;
        }
    }

    //Function that is called on last frame of Attack animation event
    public void CastSpellAttack()
    {
        GameObject go = Instantiate(bullet,spawnPoint.position,spawnPoint.rotation);
        if (facingForward)
        {
            go.GetComponent<Rigidbody2D>().velocity = new Vector3(10, 0, 0);
        }
        else
        {
            go.GetComponent<Rigidbody2D>().velocity = new Vector3(-10, 0, 0);
        }
        playerSounds.PlaySound(playerSounds.shoot);
        Destroy(go, 0.6f);
    }
}
