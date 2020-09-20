using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : Interactable {

	public GameObject itemsParent;
	public Item item;   // Item to put in the inventory if picked up
	InventorySlot[] slots;
	bool isFound = false;
	
	public override void Interact() {
		base.Interact();
		PickUp();
	}

	// Pick up the item
	void PickUp() {
		Debug.Log("Picking up " + item.name);
		GameObject logContent = GameObject.Find("logContent");
		Color renk = new Color();
		renk = Color.red;	
		logContent.GetComponent<logViewer>().entryLog("Picking Up" + item.name , renk);


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

        if (!isFound){
			Inventory.instance.Add(item);   // Add to inventory
			if (item.stackable){
				for (int i = 0; i < Inventory.instance.items.Count; i++){
					if (Inventory.instance.items[i].name == item.name){
						slots[i].stack = item.stack;
						Text yazi = slots[i].txtStack;
						yazi.text = slots[i].stack.ToString();
						slots[i].txtStack.enabled = true;
					}
				}
			}
		}
		Destroy(gameObject);    // Destroy item from scene
		isFound = false;
	}

}
