using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class ButtonExtension : MonoBehaviour,  IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    public float pressDurationTime = 1;
    public bool responseOnceByPress = false;
    public float doubleClickIntervalTime = 0.5f;

    public UnityEvent onDoubleClick;
    public UnityEvent onPress;
    public UnityEvent onClick;
    public UnityEvent offPress;

    private bool isPress = false;
    private bool isDown = false;


    void Update()
    {
        if (isDown)
        {
            isPress = true;
            onPress.Invoke();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDown = false;
        isPress = false;
        offPress.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isDown = false;
        isPress = false;
        offPress.Invoke();
    }


}