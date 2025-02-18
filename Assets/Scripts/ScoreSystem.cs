using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public int m_score;
    public static int m_finalScore;

    public void AddScore(int ScoreIncrease)
    {
        m_score += ScoreIncrease;
    }

    public void SaveScore()
    {
        m_finalScore = m_score;
    }
}
