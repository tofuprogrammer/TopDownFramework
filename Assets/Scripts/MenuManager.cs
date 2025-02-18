using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // References for UI panels
    [SerializeField] private GameObject m_menuPanel;
    [SerializeField] private GameObject m_controlsPanel;
    // Controls visibility of controls panel
    private bool m_controlsPanelActive;

    public void LoadLevel()
    {
        // Loads level and UI
        SceneManager.LoadScene("GameScene");
        SceneManager.LoadScene("UIScene", LoadSceneMode.Additive);
    }
    
    public void ToggleControlsPanel()
    {
        if (m_controlsPanelActive)
        {
            // Hides control panel and shows main menu
            m_menuPanel.SetActive(true);
            m_controlsPanel.SetActive(false);
        }
        else
        {
            // Hides main menu and shows controls panel
            m_menuPanel.SetActive(false);
            m_controlsPanel.SetActive(true);
        }
        // Switches boolean to reflect panel state
        m_controlsPanelActive = !m_controlsPanelActive;
    }

    // Quits the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
