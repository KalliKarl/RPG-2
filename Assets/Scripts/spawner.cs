using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] enemies,spots;  
    public Vector3 spawnValues;
    public float spawnWait,range;
    public int startWait,summaryEnemy,maxLimit,limit; 
    private int randEnemy,count;
    public bool stop,spot;
    public List<string> enemie = new List<string>();
    public List<int> enemyCount = new List<int>();
    void Start()
    {
        StartCoroutine(waitSpawner());
        spawnValues = this.transform.position;
        int j = 0;
        for (int i = 7; i < UnityEditorInternal.InternalEditorUtility.tags.Length; i++) {
            
            tag = UnityEditorInternal.InternalEditorUtility.tags[i];
            count = GameObject.FindGameObjectsWithTag(tag).Length;
            enemie.Add(enemies[j].name);
            enemyCount.Add(0);
            j++;
        }
    }
    public void startCorotine() {
        StartCoroutine(waitSpawner());
    }
    IEnumerator waitSpawner() {
        yield return new WaitForSeconds(startWait);

        while (!stop) {

            randEnemy = (int)Random.Range(0, enemies.Length);
            int randSpot = Random.Range(0,8);
            if (spot) {
                spawnValues = spots[randSpot].transform.position;
            }
            else {

                spawnValues = new Vector3(Random.Range(transform.position.x + range, transform.position.x - range), transform.position.y, Random.Range(transform.position.z + range, transform.position.z - range));

            }
            maxLimit = limit * enemies.Length;
            summaryEnemy = enemyCount.Sum();

            if (enemyCount[randEnemy] < limit) {
                enemyCount[randEnemy] += 1;
                Debug.Log("Spawned :" + enemie[randEnemy] + "\t Count :" + enemyCount[randEnemy]);
                GameObject enemyAI = Instantiate(enemies[randEnemy], spawnValues, gameObject.transform.rotation) as GameObject;
            }

            if (maxLimit == summaryEnemy)
                stop = true;
            yield return new WaitForSeconds(spawnWait);
        } 
        
    }
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    private void OnTriggerEnter(Collider other) {
        Debug.Log(other.name);
        Destroy(this.gameObject.GetComponent<Rigidbody>()); 


    }
}
