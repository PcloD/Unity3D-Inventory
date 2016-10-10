using UnityEngine;
using System.Collections;

public enum InventoryType
{
    Equip,
    Drug,
    Box,
    Other

}

//一定不能继承MonoBehaviour  否则范围为null
public class Inventory //: MonoBehaviour
{
    private int _ID=0;

    public int ID
    {
        get { return _ID; }
        set { _ID = value; }
    }
    private string _NAME;

    public string NAME
    {
        get { return _NAME; }
        set { _NAME = value; }
    }
    private string _ICON;

    public string ICON
    {
        get { return _ICON; }
        set { _ICON = value; }
    }
    private InventoryType _TYPE;

    public InventoryType TYPE
    {
        get { return _TYPE; }
        set { _TYPE = value; }
    }


}
