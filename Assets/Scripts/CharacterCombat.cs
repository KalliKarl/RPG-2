using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour{

    public float attackSpeed = 1f;
    private float attackCooldown = 0f;
    public float attackDelay = .6f;
    public event System.Action OnAttack;
    CharacterStats myStats;
    Image healthSlider;
    public GameObject player;
    private Animator anim;
    private void Start() {
        myStats = GetComponent<CharacterStats>();
        anim = GameObject.Find("AxeAnimator").GetComponent<Animator>();
        healthSlider = FindInActiveObjectByName("MobHpTop").GetComponent<Image>();
        player = GameObject.Find("Player");
    }

    private void Update() {
        attackCooldown -= Time.deltaTime;
    }
    public void Attack(CharacterStats targetStats) {
        //Debug.Log(attackCooldown);
        if(attackCooldown <= 0) {
            StartCoroutine(DoDamage(targetStats,attackDelay));
           // targetStats.TakeDamage(myStats.damage.GetValue());
            attackCooldown = 2.6f / attackSpeed;
            if (OnAttack != null)
                OnAttack();
            if (anim != null && gameObject.name == "Player") {
                anim.Play("Base Layer.aXe",0);
            }            
           
        }
    }

    IEnumerator DoDamage (CharacterStats stats , float delay) {
        yield return new WaitForSeconds(delay);
        stats.TakeDamage(myStats.damage.GetValue());
        int rand = (int)Random.Range(0f, 5f);
        //Debug.Log(rand +"DoDamage" + myStats.damage.GetValue());
        
        if (healthSlider != null && player.GetComponent<PlayerControl>().focus != null) {
                    Interactable enemy =    player.GetComponent<PlayerControl>().focus;
                    float healthPercent =(float) enemy.GetComponent<EnemyStats>().currentHealth / (float)enemy.GetComponent<EnemyStats>().maxHealth;
                    GameObject.Find("MobCHp").GetComponent<Text>().text = enemy.GetComponent<EnemyStats>().currentHealth.ToString();
                    GameObject.Find("MobMHp").GetComponent<Text>().text = " /" + enemy.GetComponent<EnemyStats>().maxHealth.ToString();
            healthSlider.fillAmount = healthPercent;
            }
        FindObjectOfType<AudioManager>().Play("hit"+rand);
    }
    GameObject FindInActiveObjectByName(string name) {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++) {
            if (objs[i].hideFlags == HideFlags.None) {
                if (objs[i].name == name) {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }
}
