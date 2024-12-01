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
    private Vector3 limitPositions;
    [SerializeField] private Vector3 limitDistances = new Vector3(0.02f, 0.02f, 0);

    private const string defaultLayer = "Default";
    private const string grabLayer = "Grab";

    void Start()
    {
        if (keySocket != null)
        {
            keySocket.selectEntered.AddListener(OnKeyInserted);
            keySocket.selectExited.AddListener(OnKeyRemoved);
        }

        parentTransform = transform.parent;
        limitPositions = drawerTransform.localPosition;
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
        base.OnSelectEntered(args); // Call base class method

        if (!isLocked)
        {
            transform.SetParent(parentTransform);  // Set parent to maintain position relative to the drawer
            isGrabbed = true;

            Debug.Log("Drawer is grabbed and active.");
        }
        else
        {
            ChangeLayerMask(defaultLayer); // Call ChangeLayerMask to set layer
        }
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args); // Call base class method
        ChangeLayerMask(grabLayer); // Set layer mask on exit

        isGrabbed = false;
        transform.localPosition = drawerTransform.localPosition; // Reset position as necessary

        Debug.Log("Drawer has been released.");
    }

    void Update()
    {
        if (isGrabbed && drawerTransform != null)
        {
            drawerTransform.localPosition = new Vector3(drawerTransform.localPosition.x,
                                                         drawerTransform.localPosition.y,
                                                         transform.localPosition.z);
            CheckLimits(); // Call to check limits
        }
    }

    private void CheckLimits()
    {
        // Check x-axis limits
        if (transform.localPosition.x >= limitPositions.x + limitDistances.x ||
            transform.localPosition.x <= limitPositions.x - limitDistances.x)
        {
            ChangeLayerMask(defaultLayer); // Calls to change layer back to default (limit checks dosent work )
        }

        // Check Y-axis limits
        if (transform.localPosition.y >= limitPositions.y + limitDistances.y ||
            transform.localPosition.y <= limitPositions.y - limitDistances.y)
        {
            ChangeLayerMask(defaultLayer); // Calls to change layer back to default
        }
    }

    private void ChangeLayerMask(string mask)
    {
        // Assuming you have a method to actually do something with the layer mask
        var layerMask = InteractionLayerMask.GetMask(mask); // Get the layer mask based on the input string
        // Apply the layerMask appropriately if necessary
    }
}