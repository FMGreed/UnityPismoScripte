using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour {

	public string[] tutorialText;
	public Text tutorial;
	public int id = 0;
	// Use this for initialization
	void Start () {
		tutorialText[0] = "Use W A S D to move around!";
		tutorialText[1] = "Press Spacebar to jump!";
		tutorialText[2] = "Use mouse to aim and shoot!";
		tutorialText[3] = "Now try to defeat enemy!";
		tutorialText[4] = "Use the key to unlock the door!";
		tutorialText[5] = "Now destroy the wall!";
		tutorialText[6] = "Good job!";
		tutorialText[7] = "Try to finish the level!";
	}
	
	// Update is called once per frame
	void Update () {
		tutorial.text = tutorialText[id];
	}
}
