using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookGenerator : MonoBehaviour
{
    private List<string> nameList = new List<string>();

    private void Start()
    {
        nameList.Add("Ruturium");
        nameList.Add("Gelum");
        nameList.Add("Baruffio");

        nameList.Add("Cepperum");
        nameList.Add("Moxicida");
        nameList.Add("Yeritaserum");
        nameList.Add("Kamortenia");
    }

    public string GenerateOrder()
    {
        int random = Random.Range(0, nameList.Count);
        string orderName = nameList[random];
        return orderName;
    }

    public bool ValidateOrder(string type, string order)
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
