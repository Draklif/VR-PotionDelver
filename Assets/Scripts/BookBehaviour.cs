using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BookBehaviour : MonoBehaviour
{
    GameObject canvas;
    PlateBehaviour plate;

    string actualOrder;
    List<string> listOrder = new List<string>();

    [SerializeField] public TextMeshProUGUI canvasText;

    private void Start()
    {
        canvas = transform.GetChild(0).gameObject;
        plate = GameObject.Find("Plate").GetComponent<PlateBehaviour>();

        listOrder.Add("Ruturium");
        listOrder.Add("Gelum");
        listOrder.Add("Baruffio");
        listOrder.Add("Cepperum");
        listOrder.Add("Moxicida");
        listOrder.Add("Yeritaserum");
        listOrder.Add("Kamortenia");

        actualOrder = GenerateOrder();
    }
    public void OnPointerClickXR()
    {
        canvas.transform.LookAt(GameObject.Find("Player").transform.position);
        canvas.transform.Rotate(transform.up, 180);
        
        if (plate.heldObject != null)
        {
            GrabObject plateObject = plate.heldObject.GetComponent<GrabObject>();
            if (ValidateOrder(plateObject.type, actualOrder))
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

            actualOrder = GenerateOrder();
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

    private string GenerateOrder()
    {
        int random = Random.Range(0, listOrder.Count);
        string orderName = listOrder[random];
        return orderName;
    }

    private bool ValidateOrder(string type, string order)
    {
        if (type.Equals("Potion"))
        {
            if (order.Equals("Ruturium") || order.Equals("Gelum") || order.Equals("Baruffio"))
            {
                return true;
            }
        }

        if (type.Equals("GB") && order.Equals("Ceperum")) return true;
        if (type.Equals("RB") && order.Equals("Moxicida")) return true;
        if (type.Equals("RG") && order.Equals("Yeritaserum")) return true;
        if (type.Equals("RGB") && order.Equals("Kamortenia")) return true;

        return false;
    }
}
