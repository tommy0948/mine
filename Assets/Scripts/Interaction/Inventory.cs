using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryPanel;
    private bool isOpen = false;
    private int[] inventory = new int[10]; // 0~9 슬롯

    void Start()
    {
        if (inventoryPanel != null)
        {
            inventoryPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    void ToggleInventory()
    {
        isOpen = !isOpen;
        
        if (inventoryPanel != null)
        {
            inventoryPanel.SetActive(isOpen);
            Time.timeScale = isOpen ? 0f : 1f; // 일시정지
        }
    }

    public void AddItem(int itemId, int quantity = 1)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == 0)
            {
                inventory[i] = itemId;
                Debug.Log("아이템이 인벤토리에 추가되었습니다. (슬롯 " + i + ")");
                return;
            }
        }
        Debug.Log("인벤토리가 가득 찼습니다!");
    }
}
