using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject menuUI;
    public PlayerMotor playerMotor;
    public PlayerLook playerLook;
    public InputManager inputManager;
    public PlayerInteract playerInteract;
    private bool gameStarted = false;
    private bool isPaused = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        playerMotor.enabled = false;
        playerLook.enabled = false;
        inputManager.enabled = false;
        playerInteract.enabled = false;
    }

    void Update()
    {
        if (gameStarted && Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void StartGame()
    {
        menuUI.SetActive(false);
        playerMotor.enabled = true;
        playerLook.enabled = true;
        inputManager.enabled = true;
        playerInteract.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameStarted = true;
    }

    public void PauseGame()
    {
        menuUI.SetActive(true);
        playerMotor.enabled = false;
        playerLook.enabled = false;
        inputManager.enabled = false;
        playerInteract.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isPaused = true;
    }

    public void ResumeGame()
    {
        menuUI.SetActive(false);
        playerMotor.enabled = true;
        playerLook.enabled = true;
        inputManager.enabled = true;
        playerInteract.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Called by HealthBar when health reaches 0
    public void RestartGame()
    {
        // Reset cursor and time before reloading
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}