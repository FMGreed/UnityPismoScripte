using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructables : MonoBehaviour {

	public float health=30f;
	public float maxHealth=30f;
	public Material[] materials;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(health<=0){
			Destroy(gameObject);
		}
		if(health/maxHealth >= .7f){
			GetComponent<Renderer>().material=materials[0];
		}
		else if(health/maxHealth < .7f&&health/maxHealth >= .35f){
			GetComponent<Renderer>().material=materials[1];
		}
		else if(health/maxHealth < .35f){
			GetComponent<Renderer>().material=materials[2];
		}
		//Debug.Log(health/maxHealth);
	}
}
