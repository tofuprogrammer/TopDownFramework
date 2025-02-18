using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject m_menuPanel;
    [SerializeField] private GameObject m_controlsPanel;
    private bool m_controlsPanelActive;

    public void LoadLevel()
    {
        SceneManager.LoadScene("GameScene");
        SceneManager.LoadScene("UIScene", LoadSceneMode.Additive);
    }
    
    public void ToggleControlsPanel()
    {
        if (m_controlsPanelActive)
        {
            m_menuPanel.SetActive(true);
            m_controlsPanel.SetActive(false);
        }
        else
        {
            m_menuPanel.SetActive(false);
            m_controlsPanel.SetActive(true);
        }
        m_controlsPanelActive = !m_controlsPanelActive;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
