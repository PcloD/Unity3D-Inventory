using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Image image;
    public Text countText;

    private Inventory inventory = null;

    public Inventory Inventory
    {
        get { return inventory; }
        set { inventory = value; }
    }
    public int count = 0;

    //拖动的图标
    private GameObject m_DraggingIcon;
    // 放下物品的位置
    private RectTransform m_DraggingPlane;
    public Canvas canvas;

    void Start()
    {
        canvas = transform.parent.parent.parent.parent.GetComponent<Canvas>();
        m_DraggingPlane = canvas.transform as RectTransform;
    }

    public void Init()
    {
        this.inventory = null;
        this.count = 0;

        image.sprite = Resources.Load("bg_道具", typeof(Sprite)) as Sprite;
        countText.text = "";
    }

    /// <summary>
    /// 设置道具
    /// </summary>
    /// <param name="id"></param>
    /// <param name="count"></param>
    public void SetInventory(Inventory inventory, int count = 1)
    {
        this.inventory = inventory;
        this.count = count;

        //设置图标
        image.sprite = Resources.Load(inventory.ICON, typeof(Sprite)) as Sprite;


        if (this.count == 1)
        {
            countText.text = "";
        }
        else
        {
            countText.text = this.count.ToString();
        }
    }

    public void AddCount(int count)
    {
        this.count += count;

        if (this.count == 1)
        {
            countText.text = "";
        }
        else
        {
            countText.text = this.count.ToString();
        }

        //Debug.Log(this.count);
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag: 拖动事件：" + eventData.position);
        m_DraggingIcon = new GameObject("Drag");
        m_DraggingIcon.transform.SetParent(this.transform.parent.parent, false);
        m_DraggingIcon.AddComponent<Image>().sprite = image.sprite;

    }
    public void OnDrag(PointerEventData eventDate)
    {
        //Debug.Log("OnDrag: 拖动中事件：" + eventDate.position);
        if (m_DraggingIcon != null)
        {
            Vector3 globalMousePos;
            //获取鼠标在当前物体的相对坐标
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(m_DraggingPlane,//
                    eventDate.position, eventDate.pressEventCamera, out globalMousePos))
            {
                m_DraggingIcon.transform.position = globalMousePos;
                m_DraggingIcon.transform.rotation = m_DraggingPlane.rotation;
            }

        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (m_DraggingIcon != null)
        {
            Destroy(m_DraggingIcon);
        }
    }
}
