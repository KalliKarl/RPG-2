
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    
    public Image icon;
    public Button removeButton;
    public Text txtStack;
    public int stack= 1;
    Item item;

    public void SetStack(int a) {

        stack = a;
    }
    public int GetStack() {

        return stack;
    }
    public  void AddItem(Item newItem) {

        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        if (newItem.stackable) {

            txtStack.enabled = true;
            txtStack.text = stack.ToString();
        }
        removeButton.interactable = true;
        //activeButton.interactable = true;


    }
    public void ClearSlot() {

        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
        //activeButton.interactable = false;

    }

    public void OnRemoveButton() {
        
        Inventory.instance.Remove(item);
    }

    public void UseItem() {
        if (item != null) {
            item.Use();
        }
    }
}
