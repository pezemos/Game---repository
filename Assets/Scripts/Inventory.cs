using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    #region variables
    private RectTransform _inventoryRect;

    private float _inventoryWidth, _inventoryHeight;
    public int slots;
    public int rows;
    public float slotPaddingLeft, slotPaddingTop;
    public float slotSize;
    public GameObject slotPrefab;

    private List<GameObject> allSlots;
    #endregion

    // Use this for initialization
    void Start ()
    {
	    CreateLayout();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void CreateLayout()
    {
        allSlots = new List<GameObject>();

        // Setting inventory width and height
        _inventoryWidth = (slots/rows)*(slotSize*slotPaddingLeft) + slotPaddingLeft;
        _inventoryHeight = rows*(slotSize*slotPaddingTop) + slotPaddingTop;

        _inventoryRect = GetComponent<RectTransform>();
        _inventoryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _inventoryWidth);
        _inventoryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _inventoryHeight);

        int columns = slots / rows;
        // Creating slots in inventory
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                GameObject newSlot = (GameObject)Instantiate(slotPrefab);
                RectTransform slotRect = newSlot.GetComponent<RectTransform>();

                newSlot.name = "Slot";
                newSlot.transform.SetParent(this.transform.parent);

                // Setting the position
                slotRect.localPosition = _inventoryRect.localPosition +
                                         new Vector3(slotPaddingLeft*(x + 1) + (slotSize*x),
                                             -slotPaddingTop*(y + 1) - (slotSize*y));

                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotSize);
                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotSize);

                allSlots.Add(newSlot);
            }
        }
    }
}
