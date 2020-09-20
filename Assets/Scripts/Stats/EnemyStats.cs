using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnemyStats : CharacterStats
{
    public GameObject prefab,Kasa,itemsParent;
    public string mobName;
    itemManager itManager;
    public int Exp, Sp, Level;
    [HideInInspector]
    public int ratio,ratio1,rand;
    public GameObject lvlParti;

    private void Start() {
        itemsParent = FindInActiveObjectByName("ItemsParent");
    }

    public override void Die() {
        base.Die();

        // Add ragdoll effect  / death animation       
        GameObject player = GameObject.Find("Player");
        player.GetComponent<Player>().experience += Exp;
        player.GetComponent<Player>().skillPoint  += Sp;
        GameObject logViewer = GameObject.Find("logContent");
        Color renk = Color.green;
        Color renk2 = Color.yellow;
        logViewer.GetComponent<logViewer>().entryLog(Exp + "\t Experience gained.",renk);
        logViewer.GetComponent<logViewer>().entryLog(Sp + "\t Skill Point gained.",renk2);


        #region Level UP
        int check = player.GetComponent<Player>().experience;
        int lvl = check / 100;
        lvl++;

        // if level up
        if (player.GetComponent<Player>().level != lvl) {
            player.GetComponent<Player>().level = lvl;
            player.GetComponent<PlayerStats>().maxHealth = 100 + lvl * 10;
            player.GetComponent<PlayerStats>().Healthmodifer(player.GetComponent<PlayerStats>().maxHealth);
            GameObject.Find("HpBarRight").GetComponent<Image>().fillAmount = 1;
            GameObject _stats = GameObject.Find("Stats");
            _stats.GetComponent<HpMpStatsUI>().MaxHp.text = player.GetComponent<PlayerStats>().maxHealth.ToString();
            _stats.GetComponent<HpMpStatsUI>().CurHp.text = player.GetComponent<PlayerStats>().currentHealth.ToString();
            Instantiate(lvlParti,new Vector3(transform.position.x,transform.position.y + 1,transform.position.z), Quaternion.Euler(-90,0,0) ,player.transform);
        }
        #endregion

        #region Update UI
        GameObject stats = GameObject.Find("Stats");
        stats.GetComponent<HpMpStatsUI>().Level.text = "Level : " + lvl.ToString();
        stats.GetComponent<HpMpStatsUI>().Exp.text = "Expereince : " + check.ToString();
        stats.GetComponent<HpMpStatsUI>().Sp.text = "SkillPoint : " + player.GetComponent<Player>().skillPoint.ToString();
        #endregion

        #region Item Drop
        Transform trans = this.transform;
        trans.position = new Vector3(trans.position.x,trans.position.y + 0.42f,trans.position.z);
        GameObject itemler = GameObject.Find("ItemManager");
        itManager = itemler.GetComponent<itemManager>();
        ratio = (int)Random.Range(0f,1f);
        ratio1 = (int)Random.Range(0f,1f);
        rand = (int)Random.Range(0f, itManager.items.Count);
        Debug.Log(ratio + " \t"+ ratio1 + " \t" + rand);
        if(ratio == ratio1) {
            GameObject itemKasa = Instantiate(Kasa, trans.transform.position,Quaternion.identity) as GameObject;
            itemKasa.GetComponent<ItemPickup>().item = itManager.items[rand];
            itemKasa.GetComponent<ItemPickup>().itemsParent = itemsParent;
        }
        #endregion

        Destroy(gameObject);
        player.GetComponent<PlayerControl>().focus = null;
        GameObject.Find("MobUI").SetActive(false);

        #region Spawner Reset
        string _deadMob = gameObject.transform.tag;
        GameObject spawner = GameObject.Find("Spawner1Lvl");
        spawner.GetComponent<spawner>().stop = false;
        int j = 0;
        for (int i = 7; i < UnityEditorInternal.InternalEditorUtility.tags.Length; i++) {
            if (_deadMob == UnityEditorInternal.InternalEditorUtility.tags[i]) {
                spawner.GetComponent<spawner>().enemyCount[j] -=1;
                spawner.GetComponent<spawner>().startCorotine();
            }
            j++;
        }
        #endregion
    }
    GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }

}
