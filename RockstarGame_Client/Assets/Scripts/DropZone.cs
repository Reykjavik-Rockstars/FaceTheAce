﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Networking;

[System.Serializable]
public class CardEvent : UnityEvent { }


public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {
    // for possible future use!
    // public Draggable.Slot typeOfItem = Draggable.Slot.INVENTORY;
    public CardEvent sendCard;

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("OnPointerEnter");
        if (eventData.pointerDrag == null)
            return;

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            d.placeholderParent = this.transform;
        }
        //if (d != null)
        //{
        //    if(typeOfItem == d.typeOfItem || typeOfItem == Draggable.Slot.INVENTORY)
        //    {
        //        d.parentToReturnTo = this.transform;
        //    }
        //}

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("OnPointerExit");
        if (eventData.pointerDrag == null)
            return;

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null && d.placeholderParent == this.transform)
        {
            d.placeholderParent = d.parentToReturnTo;
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);
        UpdateMsg(eventData.pointerDrag.name);

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            d.parentToReturnTo = this.transform;
        }
        else
        {
            sendCard.Invoke();
        }
    }

    void UpdateMsg(string elementName)
    {
        GameObject sharedDisplay;
        sharedDisplay = GameObject.Find("MsgBoard");
        sharedDisplay.GetComponent<Text>().text = elementName + " was dropped on " + gameObject.name + "\n";

    }

}
