using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
//using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class ButtonXREnter : MonoBehaviour
{
    public UnityEvent OnXRPointerEnter;
    public UnityEvent OnXRPointerExit;
    private Camera xRCamera;

    public PlayableDirector playableDirector;


    // Start is called before the first frame update
    void Start()
    {
        xRCamera = CameraPointerManager.Instance.gameObject.GetComponent<Camera>();
    }

    public void OnPointerClickXR()
    {
        PointerEventData pointerEvent = PlacePointer();
        ExecuteEvents.Execute(this.gameObject, pointerEvent, ExecuteEvents.pointerClickHandler);
   
        if(playableDirector != null)
        {
            playableDirector.Play();
        }
        //SceneManager.LoadScene("SampleScene");
    }

    public void OnPointerEnterXR()
    {
        GazeManager.Instance.SetUpGaze(1.5f);
        OnXRPointerEnter?.Invoke();
        PointerEventData pointerEvent = PlacePointer();
        ExecuteEvents.Execute(this.gameObject, pointerEvent, ExecuteEvents.pointerDownHandler);
    }

    public void OnPointerExitXR()
    {
        GazeManager.Instance.SetUpGaze(2.5f);
        OnXRPointerExit?.Invoke();
        PointerEventData pointerEvent = PlacePointer();
        ExecuteEvents.Execute(this.gameObject, pointerEvent, ExecuteEvents.pointerUpHandler);
    
    
    
    }
    
    private PointerEventData PlacePointer ()
    {
        Vector3 screePos= xRCamera.WorldToScreenPoint(CameraPointerManager.Instance.hitPoint);
        var pointer = new PointerEventData(EventSystem.current);
        pointer.position = new Vector3(screePos.x, screePos.y);
        return pointer;
    }


}