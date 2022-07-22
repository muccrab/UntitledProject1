using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class HoldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private bool pointerDown;
    public UnityEvent m_onDown;
    public UnityEvent m_onUp;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        m_onDown.Invoke();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        m_onUp.Invoke();
    }


}
