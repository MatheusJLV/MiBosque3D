using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class tab_Button : MonoBehaviour , IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    private int tabIndex;
    private Image image;
    private tab_control_panel controller;
    private bool isActive = false;

   

    private void Awake()
    {
        controller = FindObjectOfType<tab_control_panel>();
        image = GetComponent<Image>();
    }

    public void SetIndex(int _index) {
        tabIndex = _index;
    }

    public void ToggleActive() {
        isActive = !isActive;

        if (isActive)
        {
            image.color = controller.mouseClickColor;
        }
        else {
            image.color = controller.normalColor;
        }
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        controller.ButtonMouseClick(tabIndex);
        image.color = controller.mouseClickColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isActive)
        {
            image.color = controller.mouseEnterColor;
        }

        controller.ButtonMouseEnter(tabIndex);
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        if (!isActive) {
            image.color = controller.normalColor;
        }

        controller.ButtonMouseExit(tabIndex);

    }

}
