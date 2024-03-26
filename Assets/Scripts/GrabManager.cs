using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabManager : MonoBehaviour
{
    public GameObject[] interactables;
    public List<GameObject> potions;
    public List<GameObject> products;

    public GameObject heldItem;
    void Start()
    {
        interactables = GameObject.FindGameObjectsWithTag("Interactable");
        foreach (GameObject item in interactables)
        {
            if (item.GetComponent<GrabObject>())
            {
                potions.Add(item);
                if (!item.GetComponent<GrabObject>().type.Equals("Potion"))
                {
                    products.Add(item);
                    item.SetActive(false);
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (heldItem != null)
        {
            GameObject pointer = GameObject.Find("GazePointer");
            Vector3 pointerPos = pointer.transform.position;
            heldItem.transform.position = new Vector3(pointerPos.x, pointerPos.y + 0.5f, pointerPos.z);
        }
    }
}
