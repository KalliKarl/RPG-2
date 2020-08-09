using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Potion")]
public class Potion : Item{
    public bool potion = false;
    public int Hp;

    public override void Use()
    {
        base.Use();

        GameObject player = GameObject.Find("Player");

       int can = player.GetComponent<PlayerStats>().currentHealth;
        int maxcan = player.GetComponent<PlayerStats>().maxHealth;
        if (can > 0 && can < maxcan)
        {
            player.GetComponent<PlayerStats>().Healthmodifer(Hp);
        }


    }

}
