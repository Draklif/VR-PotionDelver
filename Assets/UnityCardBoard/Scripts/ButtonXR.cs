using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class ButtonXR : MonoBehaviour
{
   
    private Camera XRCamera;
   
    void Start()
    {
        XRCamera = CameraPointerManager.Instance.gameObject.GetComponent<Camera>();
    }

    public void OnPointerClickXR()
    {
        PointerEventData pointerEvent = PlacePointer();
        ExecuteEvents.Execute(this.gameObject, pointerEvent, ExecuteEvents.pointerClickHandler);
        SceneManager.LoadScene("Test");
    }

    private PointerEventData PlacePointer ()
    {
        Vector3 screenPos = XRCamera.WorldToScreenPoint(CameraPointerManager.Instance.hitPoint);
        var pointer = new PointerEventData(EventSystem.current);
        pointer.position = new Vector3(screenPos.x, screenPos.y);
        return pointer;
    }


}