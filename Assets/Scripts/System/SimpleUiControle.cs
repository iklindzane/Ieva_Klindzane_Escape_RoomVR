using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class SimpleUiControl : MonoBehaviour
{
    [SerializeField] XrButtonInteractable startButton; 
    [SerializeField] string[] msgStrings; 
    [SerializeField] TMP_Text[] msgTexts; 
    [SerializeField] GameObject keyIndicatorLight; 

    
    void Start()
    {
        
        if (startButton != null)
        {
            startButton.selectEntered.AddListener(StartButtonPressed); 
        }
    }

    private void StartButtonPressed(SelectEnterEventArgs arg0)
    {
        
        if (msgStrings.Length > 1) 
        {
            SetText(msgStrings[1]); 
        }

        if (keyIndicatorLight != null)
        {
            keyIndicatorLight.SetActive(true); 
        }
    }

    public void SetText(string msg)
    {
        
        foreach (var msgText in msgTexts)
        {
            msgText.text = msg; 
        }
    }
}