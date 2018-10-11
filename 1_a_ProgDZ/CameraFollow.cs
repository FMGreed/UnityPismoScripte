using UnityEngine;

public class CameraFollow : MonoBehaviour {


    public float smoothSpeed;               //ovo je brzina uglađivanja kamere decimalni broj
    public Vector3 offset;                  //ovo je offset varijabla koja pozicionira kameru

    private Vector3 velocity = Vector3.zero;// ovo je varijabla za brzinu
    private GameObject player;              //varijabla koja dohvača playera


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");        //dohvačamo playera
    }

    void LateUpdate()
    {
        // ovo je pozicija kojoj kamera teži konačno
        Vector3 desiredPosition = player.transform.position + offset;
        // ovo nam pomiče kameru glatkko prema desiredPosition
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        transform.position = smoothedPosition;   
    }


}
