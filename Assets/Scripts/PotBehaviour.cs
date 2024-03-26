using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotBehaviour : MonoBehaviour
{
    GrabManager grabManager;

    [SerializeField] GameObject fireRed, fireGreen, fireBlue;

    void Start()
    {
        grabManager = GameObject.Find("GrabManager").GetComponent<GrabManager>();
    }

    public void OnPointerClickXR()
    {
        if (grabManager.heldItem != null)
        {
            string name = grabManager.heldItem.GetComponent<GrabObject>().transform.name;

            if (name.Equals("Bottle_01"))
            {
                grabManager.heldItem.GetComponent<GrabObject>().Drop();
                fireRed.SetActive(true);
            }
            if (name.Equals("Bottle_02"))
            {
                grabManager.heldItem.GetComponent<GrabObject>().Drop();
                fireGreen.SetActive(true);
            }
            if (name.Equals("Bottle_03"))
            {
                grabManager.heldItem.GetComponent<GrabObject>().Drop();
                fireBlue.SetActive(true);
            }
        }
        else
        {
            CheckColor();
        }
    }

    private void CheckColor()
    {
        List<GameObject> products = grabManager.products;
        foreach (GameObject product in products)
        {
            GrabObject grabObject = product.GetComponent<GrabObject>();
            if (fireRed.activeSelf)
            {
                if (fireGreen.activeSelf && !fireBlue.activeSelf)
                {
                    if (grabObject.type.Equals("RG"))
                    {
                        product.SetActive(true);
                        DisableFire();
                    }
                    
                    continue;
                }
                if (fireBlue.activeSelf && !fireGreen.activeSelf)
                {
                    if (grabObject.type.Equals("RB"))
                    {
                        product.SetActive(true);
                        DisableFire();  
                    }
                    continue;
                }
                if (fireGreen.activeSelf && fireBlue.activeSelf)
                {
                    if (grabObject.type.Equals("RGB"))
                    {
                        product.SetActive(true);
                        DisableFire();
                    }
                    continue;
                }
            }
            if (fireGreen.activeSelf)
            {
                if (fireBlue.activeSelf)
                {
                    if (grabObject.type.Equals("GB"))
                    {
                        product.SetActive(true);
                        DisableFire();
                    }
                    continue;
                }
            }
        }
        
        DisableFire();
    }

    private void DisableFire()
    {
        fireRed.SetActive(false);
        fireGreen.SetActive(false);
        fireBlue.SetActive(false);
    }
}