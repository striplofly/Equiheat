using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class VirtualJoyStick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public Vector3 inputVector;

    private Image bgJoyStick;
    private Image joyStick;

    void Start()
    {
        bgJoyStick = GetComponent<Image>();
        joyStick = transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(bgJoyStick.rectTransform, ped.position, ped.pressEventCamera, out pos);
        {
            // ratio mouse pointer with bgJoyStick -> Quad4
            pos.x = pos.x / bgJoyStick.rectTransform.sizeDelta.x;
            pos.y = pos.y / bgJoyStick.rectTransform.sizeDelta.y;

            // Quad 4 -> Quad1
            float x = (bgJoyStick.rectTransform.pivot.x == 1f) ? pos.x * 2 + 1 : pos.x * 2 - 1;
            float y = (bgJoyStick.rectTransform.pivot.y == 1f) ? pos.y * 2 + 1 : pos.y * 2 - 1;

            inputVector = new Vector3(x, y, 0);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            // update joyStick pos + define area joystick
            joyStick.rectTransform.anchoredPosition = new Vector3(inputVector.x * (bgJoyStick.rectTransform.sizeDelta.x/3), inputVector.y * (bgJoyStick.rectTransform.sizeDelta.y/3));
        }

    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector3.zero;
        joyStick.rectTransform.anchoredPosition = Vector3.zero;
    }
}
