using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{
    PlayerManager playerManager;
    CharacterStats myStats;

    private void Start() {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<CharacterStats>();
    }
    public override void Interact() {
        base.Interact();
         CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
        GameObject.Find("MobName").GetComponent<Text>().text = transform.GetComponent<EnemyStats>().mobName;
        GameObject.Find("MobLvl").GetComponent<Text>().text = transform.GetComponent<EnemyStats>().Level.ToString();
        GameObject.Find("MobMHp").GetComponent<Text>().text = transform.GetComponent<EnemyStats>().maxHealth.ToString();
        GameObject.Find("MobCHp").GetComponent<Text>().text = transform.GetComponent<EnemyStats>().currentHealth.ToString();
        //Attack Enemy
        if (playerCombat != null) {
            playerCombat.Attack(myStats);

        }
    }
}
