using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Drawer_My : XRGrabInteractable
{
    [SerializeField] private Transform drawerTransform; 
    [SerializeField] private XRSocketInteractor keySocket;
    [SerializeField] private bool isLocked = true;

    private Transform parentTransform;
    private bool isGrabbed;

    private const string defaultLayer = "Default";
    private const string grabLayer = "Grab";
    private bool isGrabbedd;

    void Start()
    {
        if (keySocket != null)
        {
            keySocket.selectEntered.AddListener(OnKeyInserted);
            keySocket.selectExited.AddListener(OnKeyRemoved);
        }

        parentTransform = transform.parent;
    }

    private void OnKeyInserted(SelectEnterEventArgs arg0)
    {
        isLocked = false;  // Unlock the drawer
        Debug.Log("****DRAWER Unlocked*****");
    }

    private void OnKeyRemoved(SelectExitEventArgs arg0)
    {
        isLocked = true; // Lock the drawer
        Debug.Log("****DRAWER Locked*****");
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        if (!isLocked)
        {
            transform.SetParent(parentTransform);
            isGrabbed = true;

            Debug.Log("Drawer is grabbed and active.");
        }
        else
        {
            Debug.Log("Drawer is locked and cannot be grabbed.");
        }
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        isGrabbed = false; 

        Debug.Log("Drawer has been released.");
    }

    void Update ()
    {
        if (isGrabbed && drawerTransform != null) 
        {
           
            drawerTransform.localPosition = new Vector3(drawerTransform.localPosition.x,
                                                         drawerTransform.localPosition.y,
                                                         transform.localPosition.z);
        }
    }
}