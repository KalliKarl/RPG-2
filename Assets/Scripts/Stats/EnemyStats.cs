using UnityEngine;

public class EnemyStats : CharacterStats
{
    public GameObject prefab;
    public GameObject Kasa;
    GameObject ItemsParent;
    itemManager itManager;
    public int Exp, Sp, Level;
    [HideInInspector]
    public int ratio,ratio1,rand;

    public override void Die() {
        base.Die();

        // Add ragdoll effect  / death animation
        
        //Instantiate(prefab,gameObject.transform.position,gameObject.transform.rotation);
       
        GameObject player = GameObject.Find("Player");
        player.GetComponent<Player>().experience += Exp;
        player.GetComponent<Player>().skillPoint  += Sp;


        int check = player.GetComponent<Player>().experience;
        int lvl = check / 100;
        lvl++;
        player.GetComponent<Player>().level = lvl;


        GameObject stats = GameObject.Find("Stats");
        stats.GetComponent<HpMpStatsUI>().Level.text = "Level : " + lvl.ToString();
        stats.GetComponent<HpMpStatsUI>().Exp.text = "Expereince : " + check.ToString();
        stats.GetComponent<HpMpStatsUI>().Sp.text = "SkillPoint : " + player.GetComponent<Player>().skillPoint.ToString();


        Transform trans = this.transform;
        trans.position = new Vector3(trans.position.x,trans.position.y + 0.42f,trans.position.z);
        
        GameObject itemler = GameObject.Find("ItemManager");
        itManager = itemler.GetComponent<itemManager>();
        
        ratio = (int)Random.Range(0f,3f);
        ratio1 = (int)Random.Range(0f,3f);
        rand = (int)Random.Range(0f, itManager.items.Count);
        Debug.Log(ratio + " \t"+ ratio1 + " \t" + rand);
        Kasa.GetComponent<ItemPickup>().item = itManager.items[rand];
        Kasa.GetComponent<ItemPickup>().itemsParent = ItemsParent;
        if(ratio == ratio1)
        Instantiate(Kasa,trans.position ,Quaternion.identity);

        Destroy(gameObject);

    }

}
