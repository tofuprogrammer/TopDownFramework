using UnityEngine;

public class EndManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI m_endText;
    
    public TMPro.TextMeshProUGUI m_finalScore;

    void Start()
    {
        if (TopDownCharacterController.gameWon)
        {
            m_endText.text = "You survived!";
        }
        else
        {
            m_endText.text = "You died!";
        }
        m_finalScore.text = "Final score: " + ScoreSystem.m_finalScore;
    }
}
