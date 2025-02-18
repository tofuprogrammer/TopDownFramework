using UnityEngine;

public class EndManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI m_FinalScore;

    void Start()
    {
        m_FinalScore.text = "Final score: " + ScoreSystem.m_finalScore;
    }
}
