using UnityEngine;
public class DeathCanvasHolder : MonoBehaviour
{
    private void OnEnable()
    {
        gameObject.transform.localScale = Vector3.zero;
        LeanTween.scale(gameObject, new Vector3(24,20,20), 1);
        LeanTween.alpha(gameObject.GetComponent<RectTransform>(),1,1);
        LeanTween.color(gameObject,Color.black,1);
    }
}