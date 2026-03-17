using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerID : MonoBehaviour, IInteractable

{
    public string sceneID;

    // void OnTriggerStay2D(Collider2D collision)
    // {
    //     if(Input.GetKey(KeyCode.E) && CompareTag("Player"))
    //     {
    //         SceneManager.LoadScene(sceneID);
    //     }
    // }

    public void Interact()
    {
        SceneManager.LoadScene(sceneID);
    }
}
