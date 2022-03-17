using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class PickupObject : MonoBehaviour
{
    public Transform destination;
    public Transform fatherNode;
    public Vector3 scaleOnPickup;
    private Vector3 scaleOnThrow;
    public TextMeshProUGUI textMsg;
    private MeshCollider meshCol;
    private Rigidbody rig;
    private Vector3 startPosition;

    private void Awake()
    {
        meshCol = GetComponent<MeshCollider>();
        rig = GetComponent<Rigidbody>();
        scaleOnThrow = this.transform.localScale;
        startPosition = this.transform.localPosition;
        //textMsg = GameObject.Find("MsgPickUp").GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
                PickupItem();
            if (Input.GetKeyDown(KeyCode.Q))
                ThrowItem();
        }
    }

    private void PickupItem()
    {
        rig.constraints = RigidbodyConstraints.FreezeAll;
        rig.useGravity = false;
        meshCol.enabled = false;
        this.transform.SetParent(destination);
        this.transform.position = destination.position;
        this.transform.eulerAngles = Vector3.zero;
        this.transform.localScale = scaleOnPickup;
        textMsg.text = "Presiona Q para botar";
    }

    public void OnActivateFourthChallenge()
    {
        PickupItem();
    }

    public void ThrowItem()
    {
        this.transform.parent = fatherNode;
        this.transform.localScale = scaleOnThrow;
        this.transform.localPosition = startPosition;
        meshCol.enabled = true;
        rig.useGravity = true;
        rig.constraints = RigidbodyConstraints.None;
        textMsg.text = "Presiona E para recoger";
    }
}
