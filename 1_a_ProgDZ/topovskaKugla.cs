using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topovskaKugla : MonoBehaviour {

    public GameObject kuglaPrefab;
    public Transform kuglaSpawn;
   
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    void Fire()
{
    // Stvara se kugla od kuglaPrefab
    var bullet = (GameObject)Instantiate (
        kuglaPrefab,
       kuglaSpawn.position,
       kuglaSpawn.rotation);

    // dodaje se monmentum kugli
    bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

    // Unistava se kugla za 5 sekundi
    Destroy(bullet, 5.0f);
}
}
