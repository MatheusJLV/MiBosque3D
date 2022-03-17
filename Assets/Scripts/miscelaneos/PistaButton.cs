using UnityEngine;
using UnityEngine.EventSystems;

public class PistaButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [HideInInspector]
    public bool Pressed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE
        GameObject.Find("PistaButton").SetActive(false);
#endif
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
    }

    public void setPressed()
    {
        Pressed = false;
    }
}

