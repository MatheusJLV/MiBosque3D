using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragNDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Inventory inventory;
    public Transform inventoryPanel;
    public Slot mySlot;
    public Slot destinationSlot;
    private Image myImage;
    public Database database;
    private GameObject[] farmeables;
    Ray ray;
    RaycastHit hit;
    public static int basura = 0;
    public static int plantado = 0;

    public GameObject panel;
    private Image mochila;
    public static bool isAccesory = false;
    public GameObject LogroSist;

    //private GameObject puntero;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        inventoryPanel = transform.parent.parent;
        myImage = this.GetComponent<Image>();
        farmeables = GameObject.FindGameObjectsWithTag("Farm");
        panel = GameObject.Find("FBTrash");
        mochila=GameObject.FindGameObjectWithTag("Mochila").GetComponent<Image>();
        LogroSist = GameObject.Find("SistemaLogros");
        //puntero = GameObject.Find("Crosshair/Image");
    }

    /*private void OnMouseEnter()
    {
        puntero.GetComponent<Puntero>().agarrar();
    }
    private void OnMouseExit()
    {
        puntero.GetComponent<Puntero>().mira();
    }*/


    public void OnBeginDrag(PointerEventData eventData)
    {
        mySlot = transform.parent.GetComponent<Slot>();
        transform.SetParent(inventoryPanel);
        transform.position = eventData.position;

        myImage.raycastTarget = false;
        Color color=mochila.color;
        color.a=0.6f;
        mochila.color=color;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;

    }


    public void OnEndDrag(PointerEventData eventData)
    {
        Color color=mochila.color;
        color.a=1f;
        mochila.color=color;
        if (destinationSlot != null)
        {
            if (destinationSlot.slotInfo.id != mySlot.slotInfo.id)
            {
                inventory.SwapSlotsWrapper(mySlot.slotInfo.id, destinationSlot.slotInfo.id, this.transform, destinationSlot.itemImage.transform, isAccesory);
                destinationSlot.itemImage.transform.localPosition = Vector3.zero;
            }
            else
            {
                inventory.SwapSlotsWrapper(mySlot.slotInfo.id, mySlot.slotInfo.id, this.transform, mySlot.itemImage.transform, isAccesory);
            }
        }
        else
        {

            inventory.SwapSlotsWrapper(mySlot.slotInfo.id, mySlot.slotInfo.id, this.transform, mySlot.itemImage.transform, isAccesory);
            if (true)
            {
                Item planta = database.FindItemInDatabase(mySlot.slotInfo.itemId);
                if (planta.itemType == Item.ItemType.SEMILLAS)
                {
                    Debug.Log(planta.id);
                    if (planta.id == 3)
                    {

                        foreach (GameObject g in farmeables)
                        {
                            if (g.name == "Teca_planta")
                            {
                                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                                if (Physics.Raycast(ray, out hit))
                                {
                                    Debug.Log(hit.collider.name);
                                    if (hit.collider.name == "Teca_Semilla")
                                    {
                                        plantado++;
                                        inventory.RemoveItem(mySlot.slotInfo.itemId, mySlot.slotInfo, false);
                                        inventory.TimeFarmM(g);
                                        LogroSist.GetComponent<LogrosGlobales>().ProgresarMision(5, "Semilla2");
                                        LogroSist.GetComponent<LogrosGlobales>().ProgresarLogro(5);
                                    }
                                }
                            }


                        }
                    }
                    if (planta.id == 4)
                    {

                        foreach (GameObject g in farmeables)
                        {
                            if (g.name == "Ceibo_planta")
                            {
                                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                                if (Physics.Raycast(ray, out hit))
                                {
                                    Debug.LogWarning(hit.collider.name);
                                    if (hit.collider.name == "Ceibo_Semilla")
                                    {
                                        plantado++;
                                        
                                        inventory.RemoveItem(mySlot.slotInfo.itemId, mySlot.slotInfo, false);
                                        inventory.TimeFarmM(g);
                                        LogroSist.GetComponent<LogrosGlobales>().ProgresarMision(5, "Semilla1");
                                        LogroSist.GetComponent<LogrosGlobales>().ProgresarLogro(5);
                                    }
                                }
                            }
                        }
                    }
                }

                if (planta.itemType == Item.ItemType.BASURA)
                {
                    Debug.Log(planta.id);
                    if (planta.id == 5)
                    {

                        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        if (Physics.Raycast(ray, out hit))
                        {
                            if (hit.collider.name == "BotePapelCarton")
                            {
                                inventory.RemoveItem(mySlot.slotInfo.itemId, mySlot.slotInfo, true);
                                basura += 1;
                                inventory.ShowMessageM("Papel en papel");

                            }
                            else
                            {
                                inventory.ShowMessageM("Esto no va ahí");
                                
                            }
                        }

                    }
                    if (planta.id == 6)
                    {
                        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        if (Physics.Raycast(ray, out hit))
                        {
                            Debug.Log(hit.collider.name);
                            if (hit.collider.name == "BoteVidrio")
                            {
                                inventory.RemoveItem(mySlot.slotInfo.itemId, mySlot.slotInfo, true);
                                basura += 1;
                                inventory.ShowMessageM("Vidrio con vidrio");

                            }
                            else
                            {
                                inventory.ShowMessageM("Eso no va ahi! ");
                            }
                        }


                    }
                }


            }


        }
        myImage.raycastTarget = true;
        destinationSlot = null;
    }

}
