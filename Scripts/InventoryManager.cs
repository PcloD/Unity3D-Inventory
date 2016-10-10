using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager _Instance;

    public TextAsset InventoryText;
    public Dictionary<int, Inventory> InventoryDict = new Dictionary<int, Inventory>();

    void Awake()
    {
        _Instance = this;
        ReadInventoryText();

        //Debug.Log(InventoryDict.Count);
    }

    void ReadInventoryText()
    {
        string[] Inventorys = InventoryText.ToString().Split('\n');
        for (int i = 0; i < Inventorys.Length; i++)
        {
            Inventory inventory = new Inventory();
            string[] itemInfos = Inventorys[i].Split('|');
            inventory.ID = int.Parse(itemInfos[0]);
            inventory.NAME = itemInfos[1];
            inventory.ICON = itemInfos[2];

            switch (itemInfos[3])
            {
                case "Drug":
                    inventory.TYPE = InventoryType.Drug;
                    break;

                case "Equip":
                    inventory.TYPE = InventoryType.Equip;
                    break;

                case "Box":
                    inventory.TYPE = InventoryType.Box;
                    break;

                case "Other":
                    inventory.TYPE = InventoryType.Other;
                    break;
               
            }

            InventoryDict.Add(inventory.ID, inventory);
            //Debug.Log("ID:" + inventory.ID + "Name:" + inventory.NAME + "Type:" + inventory.TYPE);
        }
    }

    public Inventory GetInventoryById(int _id)
    {
        Inventory inventory=null;
        InventoryDict.TryGetValue(_id, out inventory);

        //Debug.Log(inventory);
        return inventory;
    }

}
