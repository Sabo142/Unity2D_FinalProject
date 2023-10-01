using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IDragHandler/*, IBeginDragHandler, IEndDragHandler */
{
    [SerializeField] private GameObject highlightObject;
    [SerializeField] private Image itemIconImage;
    public void OnDragBegin(PointerEventData eventData)
    {
        itemIconImage.color = new Color(itemIconImage.color.r, itemIconImage.color.g, itemIconImage.color.b, 0.5f);
        highlightObject.SetActive(true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        // transform.position = (Vector3)eventData.position;
    }
    public void OnDragEnd(PointerEventData eventData) 
    {
        itemIconImage.color = new Color(itemIconImage.color.r, itemIconImage.color.g, itemIconImage.color.b, 1f);
        highlightObject.SetActive(false);
    }
}
