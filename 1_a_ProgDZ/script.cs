using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour {
{
    // jane varijable
    public float projMuzzleVelocity; // javna varijabla za modifiranje metka
    public GameObject projPrefab; //javni game object za metke
    public float RateOfFire; //javna varijabla za brzinu pucanja
    public float Inaccuracy; //javna varijabla za nepreciznost

    // privatna varijabla za vrijeme pucanja
    private float fireTimer;

    
    void Start()
    {
        fireTimer = Time.time + RateOfFire; //vrijeme pucanja jednak je vremenu plus brzina pucanja
    }

    //updata se svaki jedan frame
    void Update()
    {
        Debug.DrawLine(transform.position, transform.position + transform.forward, Color.red); //radi liniju za metke kad su ispaljeni iz puske
        if (Time.time > fireTimer) //ako je vrijeme vece od vremena pucnja
        {
            GameObject projectile; //game object"METAK"
            Vector3 muzzlevelocity = transform.forward;// da game object(metak)putuje u jednoj ravnini

            if (Inaccuracy != 0) 
            {
                Vector2 rand = Random.insideUnitCircle;
                muzzlevelocity += new Vector3(rand.x, rand.y, 0) * Inaccuracy;//ako je nepreciznost jednaka 0 onda cee pucati nasumicno u odredenom krugu ako ne onda ce se vratiti u normalnu varijablu
            }

            muzzlevelocity = muzzlevelocity.normalized * projMuzzleVelocity; //ako je preciznost metka jednaka 0 onda metak leti normalno

            projectile = Instantiate(projPrefab, transform.position, transform.rotation) as GameObject;
            //projectile.GetComponent<"vlastita scripta">().muzzleVelocity = muzzlevelocity; //vrijedi samo ako postoji"VLASTITA SCRIPTA"iz koje ce se vuci komponent za pucanje
            fireTimer = Time.time + RateOfFire; 
        }
        else
            return;//vraca je u prvu varijablu
    }
}