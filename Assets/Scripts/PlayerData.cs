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
    public GameObject gameManager;
    public Inventory playerInventory;

    public PlayerData(Player player) {
        level = player.level;
        skillPoint = player.skillPoint;
        Experience = player.experience;
        gameManager = GameObject.Find("GameManager");
        playerInventory = gameManager.GetComponent<Inventory>();

        items = new string[playerInventory.items.Count];
        for (int i =0; i < items.Length; i++) {
            items[i] = playerInventory.items[i].ToString();
        }
        
        

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

    }
}
