using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

	public int playerSpeed = 6; //start speed of player
	public int rotSpeed = 50; //rotation speed of player
	public float scaleY = 1f;
	public float scaleZ = 1f;
	public int coins=0; //starting number of coins
	
	/** UI Text **/
	public Text numCoins; 
	public Text gameOver;
	public Text resetText;
	public Text tutorialText;
	public Text exitText;
	/**/
	
	/* declaring bools for checking if game is paused or not (or started?!)*/
	bool isPaused=false;
	bool hasStarted=false;
	
	
	public GameObject[] playerLook; //array of player gameObject parts... This includes all possible parts
	
	int controlModifier = 1; //variable for switching rotation
	
	
	// Use this for initialization
	void Start () {
		tutorialText.text = "Press Space to start!"; /** starting UI text */
		
		Time.timeScale = 0.0f; //time is stopped on start
		Destroy(tutorialText,5f); /**destroys text after 5 seconds (after time is started again) */
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasStarted){ /* check if started, and if is allow the use of controls... else not */
			if(Input.GetKeyDown(KeyCode.Space)){ //if spacebar is pressed once
					hasStarted=true; /* game started */
					Time.timeScale=1.0f; //time started
					tutorialText.text = "Use Left and Right to move"; /** UI show tutorial */
			}
		}
		
		//------ Controls --------- //
		var x = Time.deltaTime * playerSpeed;
		//var y = Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed;
		var z = Input.GetAxis("Horizontal") * Time.deltaTime * rotSpeed * controlModifier;
	
		transform.Translate(x, 0, 0);
		transform.Rotate(z, 0, 0);
		
		// increase the speed of player depending on total number of coins  			 ----       ##Change later##
		playerSpeed=10+coins/12;
		
		if(Input.GetKeyDown(KeyCode.R)){	//reset on R key pressed
			Time.timeScale = 1.0f;
				Application.LoadLevel(2); //reload level
		}
		if(!isPaused){ /* check if paused or not */ 
			if(Input.GetKeyDown(KeyCode.Q)){ //Open menu on Q key
				Debug.Log("Test"); //debug ---- ##delete later##
				exitText.text="Press ENTER to exit"; /**show menu UI*/
				Time.timeScale = 0.0f; //stop time
				isPaused=true; /* set if paused is true*/
			}
		}
		else if(isPaused){ /* if it is paused then do this*/
			if(Input.GetKeyDown(KeyCode.Q)){//Close menu on Q key
				Time.timeScale = 1.0f; //start time again
				exitText.text=""; /** Hide menu UI*/
				isPaused=false; /* set if paused to false*/
			}
			if(Input.GetKeyDown(KeyCode.Return)){ //Close game on Return key
				Application.Quit(); //close game
			}
		}
		
	}
	
	void OnTriggerEnter(Collider other) { //check if player entered trigger
        if(other.tag == "coin"){ //on collide with coin
			coins++; //increase the num of coins
			numCoins.text = "" + coins; /** Update coin num in UI */
			Destroy(other.gameObject); //destroy coin after collision
		}
		if(other.tag == "die"){ //on collide with wall
			gameOver.text = "Game Over!"; /** Show gameOver UI */
			resetText.text = "Press R to Reset"; /** show tutorial text */
			Time.timeScale = 0.0f; //stop time on death
		}
		
		if(other.tag == "Door"){ //on collide with door trigger     (Door trigger is placed 10 meters before the door so the player can know what shape to turn in to
			transform.Rotate(5 * Random.Range(-5,5), 0, 0); //rotate player randomly to make game harder
			controlModifier *= -1; //switch rotation direction                       ------- ##Randomise later## --------------
			if(other.GetComponent<DoorTriggerScript>().id==0){ //changes player shape based on door id
				for(int i=0;i<=24;i++){
					playerLook[i].SetActive(false);  //resets all parts of player and hides(disables) them
				}
				playerLook[6].SetActive(true);  //show(enable) only parts that are required for current door id
				playerLook[7].SetActive(true);
				playerLook[8].SetActive(true);
				playerLook[11].SetActive(true);
				playerLook[12].SetActive(true);
				playerLook[13].SetActive(true);
				playerLook[16].SetActive(true);
				playerLook[17].SetActive(true);
				playerLook[18].SetActive(true);
				
			}
			
			/** Same rules are applied below... based on door id */
			if(other.GetComponent<DoorTriggerScript>().id==1){
				for(int i=0;i<=24;i++){
					playerLook[i].SetActive(false);
				}
				playerLook[7].SetActive(true);
				playerLook[11].SetActive(true);
				playerLook[13].SetActive(true);
				playerLook[17].SetActive(true);
				
			}
			if(other.GetComponent<DoorTriggerScript>().id==2){
				for(int i=0;i<=24;i++){
					playerLook[i].SetActive(false);
				}
				playerLook[12].SetActive(true);
			}
            if (other.GetComponent<DoorTriggerScript>().id == 3)
            {
                for (int i = 0; i <= 24; i++)
                {
                    playerLook[i].SetActive(false);
                }
                playerLook[11].SetActive(true);
                playerLook[12].SetActive(true);
                playerLook[13].SetActive(true);

            }
            if (other.GetComponent<DoorTriggerScript>().id == 4)
            {
                for (int i = 0; i <= 24; i++)
                {
                    playerLook[i].SetActive(false);
                }
                playerLook[7].SetActive(true);
                playerLook[11].SetActive(true);
                playerLook[12].SetActive(true);
                playerLook[13].SetActive(true);
                playerLook[17].SetActive(true);

            }
            if (other.GetComponent<DoorTriggerScript>().id == 5)
            {
                for (int i = 0; i <= 24; i++)
                {
                    playerLook[i].SetActive(false);
                }
                playerLook[6].SetActive(true);
                playerLook[7].SetActive(true);
                playerLook[8].SetActive(true);
                playerLook[11].SetActive(true);
                playerLook[13].SetActive(true);
                playerLook[16].SetActive(true);
                playerLook[17].SetActive(true);
                playerLook[18].SetActive(true);

            }


        }

    }
	
}
