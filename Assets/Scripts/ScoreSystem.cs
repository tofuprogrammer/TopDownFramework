using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public int m_score;

    public void AddScore(int ScoreIncrease)
    {
        m_score += ScoreIncrease;
    }
}
