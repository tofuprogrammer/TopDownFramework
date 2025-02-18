using UnityEngine;

public class SwitchSprite : MonoBehaviour
{
    // Checks 
    private static readonly int s_IsBoosting = Animator.StringToHash("isBoosting");
    private Animator m_animator;

    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Switches sprite depending on keys being pressed.
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            m_animator.SetBool(s_IsBoosting, true);
        }
        else
        {
            m_animator.SetBool(s_IsBoosting, false);
        }
    }
}
