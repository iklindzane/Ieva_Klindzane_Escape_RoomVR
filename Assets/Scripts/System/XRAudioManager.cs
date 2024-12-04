using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRAudioManager : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable[] grabInteractables;
    [SerializeField] private AudioClip grabSound;

    private AudioSource audioSource;

    private void OnEnable()
    {
        grabInteractables = FindObjectsOfType<XRGrabInteractable>();
        audioSource = gameObject.AddComponent<AudioSource>();

        foreach (var interactable in grabInteractables)
        {
            interactable.onSelectEntered.AddListener(PlayGrabSound);
        }
    }

    private void OnDisable()
    {
        foreach (var interactable in grabInteractables)
        {
            interactable.onSelectEntered.RemoveListener(PlayGrabSound);
        }
    }

    private void PlayGrabSound(XRBaseInteractor interactor)
    {
        if (grabSound != null)
        {
            audioSource.PlayOneShot(grabSound);
        }
    }
}