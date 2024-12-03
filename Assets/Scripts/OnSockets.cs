using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSockets : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has a HatOn component
        if (other.TryGetComponent(out HatOn hat))
        {
            Debug.Log("Collected: " + hat.gameObject.name);
            GameManager.Instance.CollectedHat(hat); // Call to collect the hat
        }
    }
}
