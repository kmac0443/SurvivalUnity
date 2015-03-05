using UnityEngine;
using System.Collections;

public class Test_ModelScript : MonoBehaviour
{
    Inventory inv;

    void Start()
    {
         inv = new Inventory();
    }

    void OnMouseDown()
    {
        print("Adding item to inventory");
        inv.AddItem(new Item());
    }

}
