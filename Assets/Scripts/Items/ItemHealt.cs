using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHealt : Item
{
    protected override void UseItem(GameObject col, int Size)
    {
        col.SendMessage("HealtUp", Size);
    }
}
