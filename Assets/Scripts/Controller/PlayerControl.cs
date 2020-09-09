using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    public Interactable focus;
    public LayerMask movementMask;


    Camera cam;
    PlayerMotor motor;

    void Start() {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
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
        }

        newFocus.OnFocused(transform);

    }
    void RemoveFocus() {
        if (focus != null)
            focus.OnDefocused();
        focus = null;
        motor.StopFollowingTarget();
    }
}
