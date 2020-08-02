using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlots : MonoBehaviour
{
    public GameObject menu;
    public GameObject menuName;
    public Image icon;
    Item item;
    public void AddItem(Item newItem) {

        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
            
    }
    public void OnMouseEnter() {
        Debug.Log("Enter" + this.name.ToString()+ item.name.ToString());
        menu.SetActive(true);
        
        Transform parent = menu.GetComponent<Transform>();
        Vector3 trans = new Vector3();
        trans = parent.position;
        trans.y += 1f;
        parent.position = trans;
        GameObject name = Instantiate( menuName, parent);
        //name.AddComponent<Text>();
        name.GetComponent<Text>().text = "Eklendi!";
    }
    public void OnMouseExit() {
        
        Debug.Log("Exit" + this.name.ToString());
        menu.SetActive(false);
        
    }

}
