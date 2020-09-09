using UnityEngine;

public class CharacterStats : MonoBehaviour {

    public int maxHealth = 100;
    public int currentHealth { get; private set; }
    public Stat damage;
    public Stat armor;

    public int arm , dmg ;
    public event System.Action<int, int> OnHealthChanged;

    private void Awake() {
        currentHealth = maxHealth;
    }
    
    public void Update() {

        if(Input.GetButton("Stats")) {
            Stats();
        }
    }
    public void Healthmodifer(int hp) {
        int kontrol = currentHealth + hp;
        if (kontrol >= maxHealth) {
            currentHealth = maxHealth;
        }
        else {
            currentHealth += hp;
        }
        
    }

    public void Stats() {
        arm = armor.GetValue();
        dmg = damage.GetValue();
        //Debug.Log("armor = " + arm + " Damage = " + dmg);
    }
    public void TakeDamage(int damage) {

        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + "Takes " + damage + "Damage");

        OnHealthChanged?.Invoke(maxHealth, currentHealth);


        if (currentHealth <= 0) {
            Die();
        }
    }
    public virtual void Die() {
        // Die in some way
        //This method  is meant to be overwritten

        Debug.Log(transform.name + " died.");
        int rand = (int)Random.Range(1f, 5f);
        FindObjectOfType<AudioManager>().Play("dead" + rand);
    }
}
