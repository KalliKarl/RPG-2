using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour {

    public int maxHealth = 100;
    public int currentHealth { get; private set; }
    public Stat damage;
    public Stat armor;
    public GameObject txtDamage;
    public Transform transDmg;
    Camera camera1;

    public int arm , dmg ;
    public event System.Action<int, int> OnHealthChanged;

    private void Awake() {
        currentHealth = maxHealth;
        camera1 = Camera.main;
    }
    
    public void Update() {
       // Vector3 screenPos = camera1.WorldToScreenPoint(transform.position);
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
        //Debug.Log(transform.name + "Takes " + damage + "Damage");

        foreach (Canvas c in FindObjectsOfType<Canvas>()) {
            if (c.renderMode != RenderMode.WorldSpace) {
                Vector3 screenPos = camera1.WorldToScreenPoint(transform.position);
                
                GameObject txtDmgUI = Instantiate(txtDamage) as GameObject;
                txtDmgUI.transform.SetParent(c.transform);
                RectTransform brt = txtDmgUI.GetComponent<RectTransform>();
                txtDmgUI.AddComponent<DamageUI>();
                txtDmgUI.GetComponent<Text>().text = damage.ToString();

            }
        }

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
