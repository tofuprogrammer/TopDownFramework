using UnityEngine;

public class EndManager : MonoBehaviour
{
    // References for text boxes
    public TMPro.TextMeshProUGUI m_endText;
    public TMPro.TextMeshProUGUI m_finalScore;

    void Start()
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
    }
}
