using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler ,IEndDragHandler
{
    public int sortingOrderOffset = 220;
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin drag");
        //transform.GetComponent<CanvasRenderer>().sortingOrder = sortingOrderOffset;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End drag");
        //transform.GetComponent<CanvasRenderer>().sortingOrder -= sortingOrderOffset;
    }

}
