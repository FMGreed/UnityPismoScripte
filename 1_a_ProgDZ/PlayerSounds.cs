using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script that contains clips and functions for reproducing sounds. Script should be Attached to the player
public class PlayerSounds : MonoBehaviour {

    public AudioSource source; //Reference to player's Audio Source component for reproducing clips

    public AudioClip jump; //Variable that contains audio for the jump movement sound

    public AudioClip shoot; //Variable that contains audio for the shoot sound

    //Function that adds sound into the AudioSource and plays it
	public void PlaySound(AudioClip audioClip)
    {
        source.clip = audioClip; //adding audioClip into AudiSource.clip
        source.Play(); //Playing AudioSource
    }
}
