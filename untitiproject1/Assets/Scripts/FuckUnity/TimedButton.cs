using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class TimedButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool pointerDown;
    public UnityEvent m_onDown;
    public UnityEvent m_onTime;
    public UnityEvent m_onUp;
    public UnityEvent m_onClick;
    public float waittime;
    public float time = 0;
    public bool BTNdown = false;
    bool executed = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        BTNdown = true;
        m_onDown.Invoke();
        
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        BTNdown = false;
        time = 0;
        executed = false;
        m_onUp.Invoke();
    }
    public void onClick(PointerEventData eventData)
    {
        m_onClick.Invoke();
    }
    void Update(){
        if (BTNdown){
            time+=Time.deltaTime;
            if (time>waittime){
                if (!executed) m_onTime.Invoke();
                executed = true;
            }
        }
    }
}

