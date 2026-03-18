using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerID : MonoBehaviour, IInteractable

{
    public string sceneID;
    public SpriteRenderer KeyE;

    void Start()
    {
        KeyE.enabled = false;
    }

    public void Interact()
    {
        SceneManager.LoadScene(sceneID);
        Debug.Log("Interact");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
        KeyE.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            KeyE.enabled = false;
        }
    }
}
