using UnityEngine;
using UnityEngine.EventSystems;

public class BagButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [HideInInspector]
    public bool Pressed;
    [HideInInspector]
    public ShowMochila showMochila;

    public GameObject mochila;

    // Start is called before the first frame update
    void Start()
    {
        showMochila = GameObject.Find("FirstPersonCharacter").GetComponent<ShowMochila>();
        mochila.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Pressed && showMochila.isActiveAndEnabled)
        {
            showMochila.ShowWindow(mochila);
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
