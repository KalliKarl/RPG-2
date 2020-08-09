using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : Interactable {

	public Item item;   // Item to put in the inventory if picked up
	InventorySlot[] slots;
	public GameObject itemsParent;
	bool isFound = false;
	// When the player interacts with the item
	public override void Interact() {
		base.Interact();
		PickUp();
	}

	// Pick up the item
	void PickUp() {
		Debug.Log("Picking up " + item.name);

		
		slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        
		
		if(Inventory.instance.items.Count > 0){
			for (int i = 0; i < Inventory.instance.items.Count; i++) {
				
				if (Inventory.instance.items[i].name == item.name) {

					slots[i].stack += item.stack;
					Text yazi = slots[i].txtStack;
					yazi.text = slots[i].stack.ToString();
					slots[i].txtStack.enabled = true;
					isFound = true;
				}

			}
		}
		
		if(!isFound)
			Inventory.instance.Add(item);   // Add to inventory

		Destroy(gameObject);    // Destroy item from scene
		isFound = false;
	}

}
