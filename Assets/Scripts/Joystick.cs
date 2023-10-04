using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour
{
    public GameObject joystick;
    public Vector2 joystickVec;
    private Vector2 _joystickTouchPos;
    private Vector2 _joystickOriginalPos;
    private const float JoystickRadius = 50f;

    // Start is called before the first frame update
    private void Start()
    {
        _joystickOriginalPos = joystick.transform.position;
    }

    public void PointerDown()
    {
        joystick.transform.position = Input.mousePosition;
        _joystickTouchPos = Input.mousePosition;
    }

    public void Drag(BaseEventData baseEventData)
    {
        var pointerEventData = baseEventData as PointerEventData;
        var dragPos = pointerEventData.position;
        joystickVec = (dragPos - _joystickTouchPos).normalized;

        var joystickDist = Vector2.Distance(dragPos, _joystickTouchPos);

        if (joystickDist < JoystickRadius)
        {
            joystick.transform.position = _joystickTouchPos + joystickVec * joystickDist;
        }
        else
        {
            joystick.transform.position = _joystickTouchPos + joystickVec * JoystickRadius;
        }
    }

    public void PointerUp()
    {
        joystickVec = Vector2.zero;
        joystick.transform.position = _joystickOriginalPos;
    }
}