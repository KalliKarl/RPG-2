using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour {

    public int maxHealth = 200,maxMana = 200;

    public int currentHealth { get; private set; }
    public Stat damage;
    public Stat armor;
    public GameObject txtDamage;
    public Transform transDmg;
    

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
        int randDmg = (int)Random.Range(0f, 15f);
        damage  += damage * (randDmg / 100);
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 1, int.MaxValue);

        currentHealth -= damage;        //Debug.Log(transform.name + "Takes " + damage + "Damage");

        foreach (Canvas c in FindObjectsOfType<Canvas>()) {
            if (c.renderMode != RenderMode.WorldSpace) {
                GameObject txtDmgUI = Instantiate(txtDamage,transform.position,Quaternion.identity,c.transform) as GameObject;
                txtDmgUI.GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(transform.position);
                txtDmgUI.GetComponent<RectTransform>().position += new Vector3(0f,300f,0f);
                txtDmgUI.AddComponent<DamageUI>();
                txtDmgUI.GetComponent<Text>().text = damage.ToString();
                if (transform.name == "Player")
                    txtDmgUI.GetComponent<Text>().color = Color.red;
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
