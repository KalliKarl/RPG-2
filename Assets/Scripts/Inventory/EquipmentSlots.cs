using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlots : MonoBehaviour
{
    public GameObject menu;
    Text[] info;
    public Image icon;
    [SerializeField]
    Equipment item;
    
    public void AddItem(Equipment newItem) {

        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
       
    }

    public void Unequipment() {

        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }
   

    public void OnMouseEnter() {
        Debug.Log("Enter" + this.name.ToString()+ item.name.ToString());
        menu.SetActive(true);
        info = menu.GetComponentsInChildren<Text>();

        info[0].text = "Name :" +item.name.ToString();
        info[1].text = "Type :" +item.name.ToString();
        info[2].text = "Level :" +item.level.ToString();
        info[3].text = "Degree :" + item.degree.ToString();
        info[4].text = "Armor " + item.armorModifier.ToString();
        info[5].text = "Damage " + item.damageModifier.ToString();
        //info[1].text = item.armorModifier.toString();

        //Transform parent = menu.GetComponent<Transform>();
        //Vector3 trans = new Vector3();
        //trans = parent.position;
        //trans.y += 1f;
        //parent.position = trans;
        //GameObject name = Instantiate( menuName, parent);
        //name.AddComponent<Text>();
        //name.GetComponent<Text>().text = "Eklendi!";
    }
    public void OnMouseExit() {
        Debug.Log("Exit" + this.name.ToString());
        menu.SetActive(false);
        
    }

}
