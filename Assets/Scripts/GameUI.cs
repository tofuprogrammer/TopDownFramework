using UnityEngine;

public class GameUI : MonoBehaviour
{
    public ScoreSystem m_scoreSystem;
    public TMPro.TextMeshProUGUI m_scoreCounter;
    public TMPro.TextMeshProUGUI m_timerText;
    TopDownCharacterController m_characterController;

    private void Start()
    {
        if (!m_characterController)
        {
            m_characterController = FindFirstObjectByType<TopDownCharacterController>();
        }
    }
    
    private void Update()
    {
        float currentTime = m_characterController.m_playerTimer;
        // Outputs current score to the in-game UI
        m_scoreCounter.text = "Score: " + m_scoreSystem.m_score;
        // Outputs time elapsed to the in-game UI
        int minutes = Mathf.FloorToInt(currentTime / 60); // Calculates minutes passed
        int seconds = Mathf.FloorToInt(currentTime % 60); // Calculates seconds passed
        m_timerText.text = "Time: " + $"{minutes:00}:{seconds:00}"; // Outputs timer
        // Outputs in mm:ss format
    }
}
