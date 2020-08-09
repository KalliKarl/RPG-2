using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{

    public int level;
    public int skillPoint;
    public int Experience;
    public float[] position;
    public string[] items;
    //public GameObject gameManager;
    //public Inventory playerInventory;
    //List <Item> item = new List<Item>();
    public PlayerData(Player player) {
        //GameObject manager = GameObject.Find("GameManager");
        //item = manager.GetComponent<Inventory>().items;

        level = player.level;
        skillPoint = player.skillPoint;
        Experience = player.experience;
        items = new string[player.items.Length];
        for (int i = 0; i < player.items.Length; i++) {
            items[i] = player.items[i];
        }

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

    }
}
