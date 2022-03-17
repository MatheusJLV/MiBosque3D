using UnityEngine;
using UnityEngine.EventSystems;

public class ViewButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [HideInInspector]
    public bool Pressed;
    [HideInInspector]
    public ShowBook showBook;

    // Start is called before the first frame update
    void Start()
    {
        showBook = GameObject.Find("FPSController").GetComponent<ShowBook>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Pressed && !showBook.isCanvasActive)
        {
            showBook.displayBook();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
    }

    public void setPress()
    {
        Pressed = false;
    }
}
