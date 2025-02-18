using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    // References for end panels
    [SerializeField] private GameObject m_endPanel;
    [SerializeField] private GameObject m_playAgainPanel;
    // References for text boxes
    [SerializeField] private TMPro.TextMeshProUGUI m_endText;
    [SerializeField] private TMPro.TextMeshProUGUI m_finalScore;
    // Controls visibility of play again panel

    private void Start()
    {
        // Tells the player if they won
        if (TopDownCharacterController.s_gameWon)
        {
            m_endText.text = "You survived!";
        }
        else
        {
            m_endText.text = "You died!";
        }
        
        // Shows final score
        m_finalScore.text = "Final score: " + ScoreSystem.s_finalScore;
        
        m_endPanel.SetActive(true);
        m_playAgainPanel.SetActive(false);

        // Switches panel after 5 seconds
        Invoke(nameof(EnablePlayAgainPanel), 5f);
    }
    
    private void EnablePlayAgainPanel()
    {
        m_endPanel.SetActive(false);
        m_playAgainPanel.SetActive(true);
    }

    private void LoadLevel()
    {
        // Loads level and UI
        SceneManager.LoadScene("GameScene");
        SceneManager.LoadScene("UIScene", LoadSceneMode.Additive);
    }
    
    private void QuitGame()
    {
        Application.Quit();
    }
}
