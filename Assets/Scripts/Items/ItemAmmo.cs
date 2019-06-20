using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAmmo : Item
{

    protected override void UseItem(GameObject col,int Size)
    {
        Size = Random.Range(15, 27);

        col.gameObject.transform.Find("Gun").gameObject.SendMessage("AmmoUp",Size);
    }
}
