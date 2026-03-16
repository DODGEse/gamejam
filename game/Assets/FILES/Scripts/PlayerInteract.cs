using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [Tooltip("Радиус")]
    public float interactRadius = 1.5f;

    [Tooltip("Слой")]
    public LayerMask interactableLayer;

    public Transform interactPoint; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    void TryInteract()
    {
        Vector2 point = interactPoint != null ? interactPoint.position : transform.position;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(point, interactRadius, interactableLayer);

        foreach (Collider2D collider in colliders)
        {
            IInteractable interactableObject = collider.GetComponent<IInteractable>();

            if (interactableObject != null)
            {
                interactableObject.Interact();
                
                break; 
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector2 point = interactPoint != null ? interactPoint.position : transform.position;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(point, interactRadius);
    }
}