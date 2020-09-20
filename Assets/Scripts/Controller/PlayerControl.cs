using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {
    public Interactable focus;
    public LayerMask movementMask;
    Camera cam;
    PlayerMotor motor;
    GameObject mobUI;
    Image healthSlider;

    void Start() {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
        mobUI = FindInActiveObjectByName("MobUI");
        healthSlider = FindInActiveObjectByName("MobHpTop").GetComponent<Image>();
    }

    void Update() {


        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.GetMouseButtonDown(0)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, movementMask)) {
                motor.MoveToPoint(hit.point);
                // Debug.Log("we hit" + hit.collider.name + hit.point);
                // move our player to what we hit

                // stop focusing any objects
                RemoveFocus();
            }
        }
        if (Input.GetMouseButtonDown(1)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100)) {
                
                Interactable interactable = hit.collider.GetComponentInParent<Interactable>();
                if (interactable != null) {
                    SetFocus(interactable);
                }
                //Check if we hit an itreccatable

                // stop focusing any objects
            }
        }
    }
    void SetFocus(Interactable newFocus) {
        if (newFocus != focus) {
            if (focus != null)
                focus.OnDefocused();
            focus = newFocus;
            motor.FollowTarget(newFocus);
            string foc = newFocus.name.ToString();
            foc = foc.Substring(0, 7);
            if(foc != "itemBox") {
                mobUI = FindInActiveObjectByName("MobUI");
                mobUI.SetActive(true);
                GameObject.Find("MobName").GetComponent<Text>().text = newFocus.GetComponent<EnemyStats>().mobName;
                GameObject.Find("MobLvl").GetComponent<Text>().text = newFocus.GetComponent<EnemyStats>().Level.ToString();
                GameObject.Find("MobMHp").GetComponent<Text>().text = " /" + newFocus.GetComponent<EnemyStats>().maxHealth.ToString();
                GameObject.Find("MobCHp").GetComponent<Text>().text = newFocus.GetComponent<EnemyStats>().currentHealth.ToString();
            }
           


            if (healthSlider != null && gameObject.name != "Player") {
                float healthPercent = transform.GetComponent<EnemyStats>().currentHealth / (float)transform.GetComponent<EnemyStats>().maxHealth;
                healthSlider.fillAmount = healthPercent;
            }
        }
    
        newFocus.OnFocused(transform);

    }
    void RemoveFocus() {
        if (focus != null)
            focus.OnDefocused();
        mobUI.SetActive(false);
        focus = null;
        motor.StopFollowingTarget();
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
