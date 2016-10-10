using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GirdManager : MonoBehaviour
{

    public GameObject InventoryItemPrefeb;
    public Scrollbar ScrollBar;

    private List<InventoryItem> InventoryGirdList = new List<InventoryItem>();

    //最大格子数量
    public int MAXNUM = 28;

    void Start()
    {
        InitInventoryGird();

        for (int a = 0; a < MAXNUM; a++)
        {
            Inventory i = InventoryManager._Instance.GetInventoryById(Random.Range(1011, 1020));
            //Debug.Log(i.ICON);
            AddItemToInventory(i);
        }

    }

    void InitInventoryGird()
    {
        for (int i = 0; i < MAXNUM; i++)
        {
            //创建所有空格子
            CreateEmptyGirdItem();

        }
        ScrollBar.value = 1f;
    }

    /// <summary>
    /// 创建一个空格子
    /// </summary>
    void CreateEmptyGirdItem()
    {
        GameObject newItem = GameObject.Instantiate(InventoryItemPrefeb, Vector3.zero, Quaternion.identity) as GameObject;
        newItem.transform.parent = this.transform;

        InventoryItem item = newItem.GetComponent<InventoryItem>();
        item.Init();
        InventoryGirdList.Add(item);
    }

    /// <summary>
    /// 往背包中添加物品
    /// </summary>
    void AddItemToInventory(Inventory inventory, int count = 1)
    {
        //不可堆叠
        if (inventory.TYPE == InventoryType.Equip)
        {
            //判断格子数量是否足够
            int temp = 0;
            for (int i = 0; i < InventoryGirdList.Count; i++)
            {
                if (InventoryGirdList[i].Inventory != null)//寻找空格子
                {
                    temp++;//第一个空格子所处的编号
                    //Debug.Log(temp);
                }
            }

            if (temp == MAXNUM)//
            {
                Debug.Log("FULL");
                return;
            }
            else
            {
                //有空格子
                //往空格子填充数据
                InventoryGirdList[temp].SetInventory(inventory);
                //Debug.Log(temp);
                //Debug.Log(InventoryGirdList[temp].inventory);
            }

        }
        else
        {
            //可堆叠物品
            //1.判断是否有相同的物品
            //有 数量加
            //没有
            //是否有空格子
            //有 添加
            //没有
            for (int i = 0; i < InventoryGirdList.Count; i++)
            {
                if (InventoryGirdList[i].Inventory == inventory)
                {
                    InventoryGirdList[i].AddCount(count);
                    return;
                }

            }

            int temp = 0;
            for (int i = 0; i < InventoryGirdList.Count; i++)
            {
                if (InventoryGirdList[i].Inventory != null)//寻找空格子
                {

                    temp++;//第一个空格子所处的编号
                    //Debug.Log(temp);
                }
            }

            if (temp == MAXNUM)//
            {
                Debug.Log("FULL");
                return;
            }
            else
            {
                //有空格子
                //往空格子填充数据
                InventoryGirdList[temp].SetInventory(inventory);
            }
        }
    }

}
