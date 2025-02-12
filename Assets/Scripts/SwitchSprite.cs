using UnityEngine;

public class SwitchSprite : MonoBehaviour

{
    private static readonly int IsBoosting = Animator.StringToHash("isBoosting");
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
            m_animator.SetBool(IsBoosting, true);
        }
        else
        {
            m_animator.SetBool(IsBoosting, false);
        }
    }
}
