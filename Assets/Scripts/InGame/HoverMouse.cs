using UnityEngine;
using UnityEngine.EventSystems;

public class HoverMouse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject hover;
    public GameObject left;
    public GameObject right;
    private bool rotating = false;
    public float rotationSpeed = 100f;

    public void OnPointerEnter(PointerEventData eventData)
    {
        hover.SetActive(true);
        rotating = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hover.SetActive(false);
        rotating = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        hover.SetActive(false);
        rotating = false;
    }

    void Update()
    {
        if (rotating)
        {
            RotateImages();
        }
    }

    private void RotateImages()
    {
        left.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        right.transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
    }


}
