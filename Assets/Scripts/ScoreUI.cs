using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public ScoreSystem m_scoreSystem;
    public TMPro.TextMeshProUGUI m_scoreCounter;
    
    void Update()
    {
        // Outputs current score to the in-game UI
        m_scoreCounter.text = "Score: " + m_scoreSystem.m_score;
    }
}
