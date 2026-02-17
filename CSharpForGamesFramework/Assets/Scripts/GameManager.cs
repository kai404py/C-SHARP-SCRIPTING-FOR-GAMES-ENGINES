using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject deadMenu;
    
    public static bool isPaused = false;
    private InputAction m_Pause;

    private void Awake()
    {
        m_Pause = InputSystem.actions.FindAction("Pause");
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseMenu.SetActive(false);
        deadMenu.SetActive(false);
        isPaused = false;   
    }
    
    void Update()
    {
        // Pauses game when pause is pressed
        if (m_Pause.WasPressedThisFrame()) 
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }
    
    private void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    
    public void ShowDeadMenu()
    {
        pauseMenu.SetActive(false);
        deadMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void MainMenu()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadSceneAsync("MainMenu");
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
