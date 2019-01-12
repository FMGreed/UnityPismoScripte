using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaling : MonoBehaviour
{
    void Update()
    {
        transform.localScale += new Vector3(transform.localScale.x * 0.06f, 0, 0);
    }
}
