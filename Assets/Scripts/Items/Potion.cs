using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Potion")]
public class Potion : Item
{
    public bool potion = false;
    public int Hp;
    InventorySlot[] slots = null;
    public override void Use()
    {
        base.Use();

        GameObject player = GameObject.Find("Player");

        int can = player.GetComponent<PlayerStats>().currentHealth;
        int maxcan = player.GetComponent<PlayerStats>().maxHealth;
        if (can > 0 || can < maxcan)
        {
            player.GetComponent<PlayerStats>().Healthmodifer(Hp);
            GameObject itemsParent = GameObject.Find("ItemsParent");
            slots = itemsParent.GetComponentsInChildren<InventorySlot>();
            if (Inventory.instance.items.Count > 0)
            {
                for (int i = 0; i < Inventory.instance.items.Count; i++)
                {

                    if (Inventory.instance.items[i].name == this.name)
                    {
                        slots[i].stack -= 1;
                        Text yazi = slots[i].txtStack;
                        yazi.text = slots[i].stack.ToString();
                        slots[i].txtStack.text = yazi.text;

                        if (slots[i].stack < 1 && slots[i].stack == 0)
                        {
                           
                            removeFromInventory();
                            slots[i].txtStack.enabled = false;
                        }

                    }
                }
            }
           
        }


    }

}
