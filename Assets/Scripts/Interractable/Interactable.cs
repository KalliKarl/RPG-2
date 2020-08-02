using UnityEngine;
using UnityEngine.AI;


public class Interactable : MonoBehaviour {
    public float radius = 3f;
    public Transform interactionTransform;
    bool isFocus = false;
    Transform player;
    bool hasInteracted = false;    

    void Update() {
        if (isFocus && hasInteracted == false) {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (!hasInteracted && distance <= radius) {
                hasInteracted = true;
                Interact();
            }
        }
    }
    public void OnFocused(Transform playerTransform) {

        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
        
    }
    public void OnDefocused() {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }
    public virtual void Interact() {
        // this method is meant to be overwritten
        //Debug.Log("has interract with =" + transform.name);
        
    }
    void OnDrawGizmosSelected() {
        if (interactionTransform == null) {
            interactionTransform = transform;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
   
}
