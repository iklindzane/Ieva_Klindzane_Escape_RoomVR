using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;


public class XrButtonInteractable : XRSimpleInteractable
{
    [SerializeField] Image buttonImage;
    [SerializeField] Color[] buttonColor = new Color[4];

    private Color normalColor;
    private Color highlightedColor;
    private Color pressedColor;
    private Color selectedColor;
    private bool isPressed;

    void Start()
    {
        normalColor = buttonColor[0];
        highlightedColor = buttonColor[1];
        pressedColor = buttonColor[2];
        selectedColor = buttonColor[3];
        buttonImage.color = normalColor;

    }

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        isPressed = false;
        buttonImage.color = highlightedColor;
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
        if (!isPressed)
        {
            buttonImage.color = normalColor;
        }
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        isPressed = true;
        buttonImage.color = pressedColor;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        buttonImage.color = selectedColor;
    }

    public void ResetColor()
    {
        if (buttonImage != null) 
        {
            buttonImage.color = normalColor;
        }
        else
        {
            Debug.LogError("buttonImage is null! Cannot reset color.", this);
        }
    } 

}
