using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] enemies;  
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;
    int randEnemy;
    public float range;
    public int enemyCount,limit;
    public Dictionary<string,int> enemyDic= new Dictionary<string,int>();   
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitSpawner());
        spawnValues = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        spawnWait = Random.Range(spawnMostWait, spawnMostWait);
    }
    IEnumerator waitSpawner() {
        yield return new WaitForSeconds(startWait);

        while (!stop) {
            randEnemy = Random.Range(0, 5);
            spawnValues = new Vector3(Random.Range(transform.position.x + range, transform.position.x - range), transform.position.y, Random.Range(transform.position.z + range, transform.position.z - range)) ;
            Debug.Log("---------------------------------");
            for (int i = 7; i < UnityEditorInternal.InternalEditorUtility.tags.Length; i++) {

                string _tag = UnityEditorInternal.InternalEditorUtility.tags[i];
                int _lvl = GameObject.FindGameObjectsWithTag(_tag).Length;
                if (enemyDic.ContainsKey(_tag)) {
                    enemyDic[_tag] = _lvl;
                    Debug.Log("Key = :" + _tag +"\t value :" + _lvl);
                }
                else {
                    enemyDic.Add(_tag,_lvl);
                }
                

            }
           
            if (enemyCount <= limit) {
                Instantiate(enemies[randEnemy], spawnValues, gameObject.transform.rotation);
                enemyCount++;
            }
           

            yield return new WaitForSeconds(spawnWait);


        }
    }
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
