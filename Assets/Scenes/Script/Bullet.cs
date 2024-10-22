using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Target")
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 2f);
        }
    }
}
