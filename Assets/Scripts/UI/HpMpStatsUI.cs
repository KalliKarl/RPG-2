using UnityEngine;
using UnityEngine.UI;
public class HpMpStatsUI : MonoBehaviour
{
    public GameObject uiPrefab,player;
    public Transform target;

    Transform ui;
    Image healthSlider;
    // Start is called before the first frame update
    void Start()
    {
        ui = Instantiate(uiPrefab, target).transform;
        
        ui.transform.localScale = new Vector3(100f, 100f, 1f);
        healthSlider = ui.GetChild(0).GetComponent<Image>();
        healthSlider.fillOrigin = 2;


        player.GetComponent<CharacterStats>().OnHealthChanged += OnHealthChaned;
    }
    void OnHealthChaned(int maxHealth, int currentHealth) {
        if (ui != null) {
            float healthPercent = currentHealth / (float)maxHealth;
            healthSlider.fillAmount = healthPercent;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
