using UnityEngine;

public class EnemyStats : CharacterStats
{
    public GameObject prefab;
    public override void Die() {
        base.Die();

        // Add ragdoll effect  / death animation
        
        //Instantiate(prefab,gameObject.transform.position,gameObject.transform.rotation);
        Destroy(gameObject);
        
    }

}
