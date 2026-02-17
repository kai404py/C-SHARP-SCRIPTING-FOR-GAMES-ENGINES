using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevel : MonoBehaviour
{
    [SerializeField] private string sceneName;
    private TopDownCharacterController m_PlayerController;
    
    //A simple on trigger to send the player to the next level when the trigger the box
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadSceneAsync(sceneName);
        }
    }
}
