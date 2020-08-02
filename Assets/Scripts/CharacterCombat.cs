using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{

    public float attackSpeed = 1f;
    private float attackCooldown = 0f;
    public float attackDelay = .6f;


    public event System.Action OnAttack;


    CharacterStats myStats;

    private void Start() {
        myStats = GetComponent<CharacterStats>();
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

        }
        
        
    }

    IEnumerator DoDamage (CharacterStats stats , float delay) {
        yield return new WaitForSeconds(delay);
        stats.TakeDamage(myStats.damage.GetValue());
        int rand = (int)Random.Range(0f, 5f);
        Debug.Log(rand +"DoDamage" + myStats.damage.GetValue());
        
        FindObjectOfType<AudioManager>().Play("hit"+rand);
    }
}
