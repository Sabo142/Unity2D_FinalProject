using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DragItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private GameObject highlightObject;
    [SerializeField] private Image itemIconImage;
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        itemIconImage.color = new Color(itemIconImage.color.r, itemIconImage.color.g, itemIconImage.color.b, 1f);
        highlightObject.SetActive(true);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        itemIconImage.color = new Color(itemIconImage.color.r, itemIconImage.color.g, itemIconImage.color.b, 0.5f);
        highlightObject.SetActive(false);
    }
    private void Update()
    {
        Physics2D.gravity = new Vector2(Input.acceleration.x * 100f, Input.acceleration.y * 100f);
    }
}