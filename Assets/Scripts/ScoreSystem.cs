using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    // Stores player's score and final score
    public int m_score;
    public static int s_finalScore;

    // Increases player's score when called
    public void AddScore(int scoreIncrease)
    {
        m_score += scoreIncrease;
    }

    // Saves player's score at the end of the session
    public void SaveScore()
    {
        s_finalScore = m_score;
    }
}
