using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DiffDraggableItem : MonoBehaviour
{
    private bool dragging = false;
    private Vector3 dragOffset;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left) return;
        dragging = true;
        Vector3 worldpoint;
        if (DragWorldPoint(eventData, out worldpoint))
        {
            dragOffset = GetComponent<RectTransform>().position - worldpoint;
        }
        else
        {
            dragOffset = Vector3.zero;
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left) return;
        dragging = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left) return;

        Vector3 worldpoint;
        if (DragWorldPoint(eventData, out worldpoint))
        {
            RectTransform rt = GetComponent<RectTransform>();
            rt.position = worldpoint + dragOffset;
        }
    }

    // Gets the point in worldspace corresponding to where the mouse is
    private bool DragWorldPoint(PointerEventData eventData, out Vector3 worldPoint)
    {
        return RectTransformUtility.ScreenPointToWorldPointInRectangle(
            GetComponent<RectTransform>(),
            eventData.position,
            eventData.pressEventCamera,
            out worldPoint);
    }
}
