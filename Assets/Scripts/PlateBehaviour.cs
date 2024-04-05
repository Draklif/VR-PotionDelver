using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateBehaviour : MonoBehaviour
{
    GrabManager grabManager;
    [SerializeField] GameObject holder;
    
    public GameObject heldObject;

    void Start()
    {
        grabManager = GameObject.Find("GrabManager").GetComponent<GrabManager>();
    }

    void FixedUpdate()
    {
        if (heldObject != null)
        {
            heldObject.transform.Rotate(Vector3.up * (10 * Time.deltaTime));
        }
    }

    public void OnPointerClickXR()
    {
        if (grabManager.heldItem != null)
        {
            if (heldObject != null)
            {
                heldObject.GetComponent<GrabObject>().Respawn();
            }
            heldObject = grabManager.heldItem;
            grabManager.heldItem.GetComponent<GrabObject>().Place(holder.transform.position);
        }
        else
        {
            if (heldObject != null)
            {
                heldObject.GetComponent<GrabObject>().Grab();
                heldObject = null;
            }
        }
    }
}
