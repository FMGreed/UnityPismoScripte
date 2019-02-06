using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public GameObject forcefield;
    public GameObject player;
    public float timer;
    Vector3 point;
    void Start()
    {
        point = player.transform.position;
    }
    void OnTriggerStay(Collider other)
    {
        Debug.Log(other.bounds);
        if (other.bounds.Contains(point))
        {
            timer = Time.deltaTime;
            Debug.Log(timer);
        }
    }
}
