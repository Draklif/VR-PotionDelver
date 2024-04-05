using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TeleportPoint : MonoBehaviour
{
    
    public UnityEvent OnTeleportEnter;
    public UnityEvent OnTeleport;
    public UnityEvent OnTeleportExit;

    public AudioClip soundSteps;

    private AudioSource player;
    private bool isEnabled = true;

    void Start()
    {
        player = GetComponent<AudioSource>();
        transform.GetChild(0).gameObject.SetActive(false);
    } 

    public void OnPointerEnterXR()
    {
        OnTeleportEnter?.Invoke();
    }

    public void OnPointerClickXR()
    {
        if (isEnabled)
        {
            player.PlayOneShot(soundSteps);
            ExecuteTeleport();
            OnTeleport?.Invoke();
            TeleportManager.Instance.DisableTeleportPoint(gameObject);
        }
    }

    public void OnPointerExitXR()
    {
        OnTeleportExit?.Invoke();
    }

    private void ExecuteTeleport()
    {
        GameObject player = TeleportManager.Instance.Player;
        GameObject position  = transform.GetChild(0).gameObject;
        player.transform.position = position.transform.position;
    }

    public void SwitchTeleport(bool value) 
    { 
        isEnabled = value;
    }

    public void SwitchInteract(bool value)
    {
        BoxCollider boxCollider = GetComponent<BoxCollider>();
        boxCollider.enabled = value;
    }
}

