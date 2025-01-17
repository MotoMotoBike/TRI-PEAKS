using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickReceiver : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent Action;

    public void OnPointerClick(PointerEventData eventData)
    {
        Action?.Invoke();
    }
}
