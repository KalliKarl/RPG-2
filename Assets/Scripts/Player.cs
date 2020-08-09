using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class Player : MonoBehaviour{
    
    public int level = 1;
    public int skillPoint = 0;
    public int experience;
    public string[] items;
    
    GameObject gameManager;
    Inventory playerInventory;
    Item item;
    itemManager itManager;

    public void Start() {
    }

    public void SavePlayer() {

        GameObject itemler = GameObject.Find("ItemManager");
        itManager = itemler.GetComponent<itemManager>();
        gameManager = GameObject.Find("GameManager");
        playerInventory = gameManager.GetComponent<Inventory>();

        items = new string[playerInventory.items.Count];
        for (int i = 0; i < items.Length; i++) {
            items[i] = playerInventory.items[i].name;
        }
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer() {
        GameObject itemler = GameObject.Find("ItemManager");
        itManager = itemler.GetComponent<itemManager>();

        PlayerData data = SaveSystem.LoadPlayer();

        level = data.level;
        skillPoint = data.skillPoint;
        experience = data.Experience;

        for (int i =0; i<itManager.items.Count;i++) {
            for(int j = 0; j < data.items.Length;j++) {
                
                string a = itManager.items[i].name;
                string b = data.items[j].ToString();
                if ( a == b ) {
                    item = itManager.items[i];
                    Inventory.instance.Add(item);
                }
            }
           
            #region comment
            /*
            if(items[i] != null) {
                // Debug.Log(items[i]);
                int index = items[i].IndexOf("(Equipment)");
                if (index > 0) {
                    objName = items[i].Substring(0, index - 1);
                    Debug.Log(objName);
                }
                var guid = AssetDatabase.FindAssets(objName, new[] { "Assets/Items" });
                foreach (var x in guid) {
                    var path = AssetDatabase.GUIDToAssetPath(x);
                    Debug.Log(path);
                    Equipment pathObj = Resources.Load<ScriptableObject>(path) as Equipment;
                }

            }
            */
            #endregion
        }
        GameObject itemManager = GameObject.Find("itemManager");
        
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
}