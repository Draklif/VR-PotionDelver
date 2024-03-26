using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrabObject : MonoBehaviour
{
    GrabManager grabManager;
    BoxCollider boxCollider;
    Vector3 spawnerPosition;
    Quaternion spawnerRotation;

    [SerializeField] public string type = "Potion";
    [SerializeField] public GameObject spawner;

    void Start()
    {
        spawnerPosition = spawner.transform.position;
        spawnerRotation = spawner.transform.rotation;
        boxCollider = GetComponent<BoxCollider>();
        grabManager = GameObject.Find("GrabManager").GetComponent<GrabManager>();
    }

    public void Grab()
    {
        if (grabManager.heldItem != null)
        {
            grabManager.heldItem.GetComponent<GrabObject>().Drop();
        }
        grabManager.heldItem = transform.gameObject;
        boxCollider.enabled = false;
    }

    public void Drop()
    {
        transform.position = spawnerPosition;
        transform.rotation = spawnerRotation;
        grabManager.heldItem = null;
        boxCollider.enabled = true;
    }

    public void Delete()
    {
        transform.position = spawnerPosition;
        transform.rotation = spawnerRotation;
        grabManager.heldItem = null;
        boxCollider.enabled = true;
        transform.gameObject.SetActive(false);
    }

    public void Respawn()
    {
        transform.position = spawnerPosition;
        transform.rotation = spawnerRotation;
        boxCollider.enabled = true;
        transform.gameObject.SetActive(true);
    }

    public void Place(Vector3 position)
    {
        transform.position = position;
        grabManager.heldItem = null;
        boxCollider.enabled = true;
    }

    public void OnPointerClickXR()
    {
        Grab();
    }
}
