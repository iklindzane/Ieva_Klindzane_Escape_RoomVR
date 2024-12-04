using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatOn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out HatOn hatOn))

        {
            Debug.Log("Collected: " + hatOn.gameObject.name);
        }
    }

}