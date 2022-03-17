using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class tab_control_panel : MonoBehaviour
{
    [Header("Panels")]
    public Transform buttonsPanel;
    public Transform panelsPanel;


    [Header("Button State Color")]
    public Color normalColor;
    public Color mouseEnterColor;
    public Color mouseClickColor;

    [Header("Events")]
    public UnityEvent TabSelectionChangedEvent;

    private int selectedIndex;
    private tab_Button selectedButton;

    private List<tab_Button> buttons = new List<tab_Button>();
    private List<Transform> panels = new List<Transform>();

    private void Start()
    {
        for (int i= 0; i < buttonsPanel.transform.childCount; i++)
        {
            GameObject buttonGo = buttonsPanel.transform.GetChild(i).gameObject;
            tab_Button button = buttonGo.GetComponent<tab_Button>();
               // GameObject.Find("tab_Button").GetComponent<tab_Button>();

            //buttonGo.GetComponent<tab_Button>();
            button.SetIndex(i);
            buttons.Add(button);

        }

        foreach ( Transform item in panelsPanel.transform)
        {
            panels.Add(item);
        }

        //ButtonMouseClick(0);

    }

    public void ButtonMouseClick(int _id) {
        if (selectedButton != null)
        {
            selectedButton.ToggleActive();

        }
        selectedIndex = _id;
        selectedButton = buttons[selectedIndex];

        selectedButton.ToggleActive();
        HideAllPanels();

    }

    public void ButtonMouseEnter(int id) {
        Debug.Log("Button Mouse Enter");
    }

    public void ButtonMouseExit(int id) {
        Debug.Log("Button Mouse Exit");

    }
    private void HideAllPanels() {

        for (int i= 0; i < panels.Count; i++)
        {
            if (i == selectedIndex) {
                panels[i].gameObject.SetActive(true);
            }
            else
            {
                panels[i].gameObject.SetActive(false);
            }
            

        }


        if (TabSelectionChangedEvent != null)
        {
            TabSelectionChangedEvent.Invoke();
        }



    }


}
