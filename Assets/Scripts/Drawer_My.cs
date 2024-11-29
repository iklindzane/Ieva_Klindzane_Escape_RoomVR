using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Drawer_My : MonoBehaviour
{
    [SerializeField] XRSocketInteractor keySocket; // Reference to the socket for the key
    [SerializeField] bool isLocked = true; // Initialize the drawer as locked

    void Start()
    {
        // Check if keySocket is not null and add listener for when the key is inserted
        if (keySocket != null)
        {
            keySocket.selectEntered.AddListener(OnDrawerUnlocked);
            keySocket.selectExited.AddListener(OnDrawerUnlocked);
        }
    }

    private void OnDrawerUnlocked(SelectExitEventArgs arg0)
    {
        isLocked = true; // Unlock the drawer
        Debug.Log("****DRAWER Locked*****");
        // Additional logic for unlocking the drawer can be added here
    }

    private void OnDrawerUnlocked(SelectEnterEventArgs arg0)
    {
        isLocked = false; // Unlock the drawer
        Debug.Log("****DRAWER Unlocked*****");
        // Additional logic for unlocking the drawer can be added here
    }

    // Update is called once per frame
    void Update()
    {
        // Update logic can be implemented here if necessary
    }
}