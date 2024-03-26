using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BookBehaviour : MonoBehaviour
{
    GameObject canvas;
    PlateBehaviour plate;
    BookGenerator bookGenerator;

    string actualOrder;

    [SerializeField] public TextMeshProUGUI canvasText;

    private void Start()
    {
        canvas = transform.GetChild(0).gameObject;
        plate = GameObject.Find("Plate").GetComponent<PlateBehaviour>();
        bookGenerator = GameObject.Find("BookManager").GetComponent<BookGenerator>();
        actualOrder = bookGenerator.GenerateOrder();
    }
    public void OnPointerClickXR()
    {
        canvas.transform.LookAt(GameObject.Find("Player").transform.position);
        canvas.transform.Rotate(transform.up, 180);
        
        if (plate.heldObject != null)
        {
            GrabObject plateObject = plate.heldObject.GetComponent<GrabObject>();
            if (bookGenerator.ValidateOrder(plateObject.type, actualOrder))
            {
                canvasText.text = "¡Bien!";
            }
            else
            {
                canvasText.text = "¡Incorrecto!";
            }

            if (plateObject.type.Equals("Potion"))
            {
                plateObject.GetComponent<GrabObject>().Respawn();
                plate.heldObject = null;
            }
            else
            {
                plateObject.GetComponent<GrabObject>().Delete();
                plate.heldObject = null;
            }

            actualOrder = bookGenerator.GenerateOrder();
        }
        else
        {
            canvasText.text = "?";
        }
    }

    public void OnPointerEnterXR()
    {
        canvas.SetActive(true);
        canvas.transform.LookAt(GameObject.Find("Player").transform.position);
        canvas.transform.Rotate(transform.up, 180);
        canvasText.text = actualOrder;
    }

    public void OnPointerExitXR()
    {
        canvas.SetActive(false);
    }
}
