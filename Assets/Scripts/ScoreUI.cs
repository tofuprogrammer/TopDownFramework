using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public ScoreSystem m_scoreSystem;
    
    public TMPro.TextMeshProUGUI m_scoreCounter;

    // Update is called once per frame
    void Update()
    {
        m_scoreCounter.text = "Score: " + m_scoreSystem.m_score;
    }
}
