using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandDropZone : DropZone {

    Hand hand;

    protected override void DroppedEvent(Draggable d)
    {
        if (this.transform.childCount < 6)
        {
            d.parentToReturnTo = this.transform;
        }
        else
        {
            RemovedEvent(d);
        }
    }

    protected override void EnteredEvent(Draggable d)
    {
        ;
    }

    protected override void RemovedEvent(Draggable d)
    {
        ;
    }
}