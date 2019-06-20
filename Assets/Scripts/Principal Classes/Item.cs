using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    
    protected int size;

    public int Size {

        get { return Random.Range(1,5); }
        set { size = value; }
    }

    protected virtual void UseItem(GameObject col,int Size) {}

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UseItem(collision.gameObject, Size);
            Destroy(gameObject);
        }
    }
}
