using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// A class to control the top-down character.
/// Implements the player controls for moving and shooting.
/// Updates the player animator so the character animates based on input.
/// </summary>
public class TopDownCharacterController : MonoBehaviour
{
    #region Framework Variables

    //The inputs that we need to retrieve from the input system.
    private InputAction m_moveAction;
    private InputAction m_attackAction;

    //The components that we need to edit to make the player move smoothly.
    private Animator m_animator;
    private Rigidbody2D m_rigidbody;
    
    //The direction that the player is moving in.
    private Vector2 m_playerDirection;
    
    //The minimum time between shots.
    private float m_fireTimeout = 0.3f;

    //Vectors to calculate the position of the mouse and the direction from the player.
    private Vector2 mousePosition;
    private Vector3 mousePointOnScreen;
    private Vector3 mouseDirection;
    [Header("Movement parameters")]
    //The speed at which the player moves
    [SerializeField] private float m_playerSpeed = 200f;
    //The maximum speed the player can move
    [SerializeField] private float m_playerMaxSpeed = 1000f;
    
    [Header("Projectile parameters")]
    // References the projectile object
    [SerializeField] GameObject m_projectilePrefab;
    // Projectile spawn point
    [SerializeField] Transform m_firePoint;
    // Projectile velocity
    [SerializeField] float m_projectileSpeed;
    [SerializeField] private float m_fireRate;
    #endregion
    
    /// <summary>
    /// Awake is called when the script is initialised.
    /// It is used to get components from GameObjects that will be needed later.
    /// </summary>
    private void Awake()
    {
        //bind movement inputs to variables
        m_moveAction = InputSystem.actions.FindAction("Move");
        m_attackAction = InputSystem.actions.FindAction("Attack");
        
        //get components from Character game object so that we can use them later.
        m_animator = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Start is called immediately after Awake().
    /// It is used to initialize variables e.g. set values on the player.
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// A fixed update loop runs at a constant rate, regardless of performance.
    /// This ensures that physics are calculated properly.
    /// </summary>
    private void FixedUpdate()
    {
        //clamp the speed to the maximum speed for if the speed has been changed in code.
        float speed = m_playerSpeed > m_playerMaxSpeed ? m_playerMaxSpeed : m_playerSpeed;
        
        //apply the movement to the character using the clamped speed value.
        m_rigidbody.linearVelocity = m_playerDirection * (speed * Time.fixedDeltaTime);
    }

    /// <summary>
    /// This is a basic function to spawn a projectle
    /// </summary>
    void Fire()
    {
        GameObject projectileToSpawn = Instantiate(m_projectilePrefab, m_firePoint.position, Quaternion.identity);
        if (projectileToSpawn.GetComponent<Rigidbody2D>() != null)
        {
            projectileToSpawn.GetComponent<Rigidbody2D>().AddForce(mouseDirection.normalized * m_projectileSpeed, ForceMode2D.Impulse);
        }
    }

    /// <summary>
    /// When the update loop is called, it runs every frame.
    /// Therefore, this will run more or less frequently depending on performance.
    /// Used to catch changes in variables or input.
    /// </summary>
    
    void Update()
    {
        /*
        Gets the mouse's position on the screen.
        Converts the position of the mouse on the screen to its position in the game world.
        Subtracts the position of the player from the position of the mouse to get a vector pointing to the mouse cursor from the player's position.
        */
        mousePosition = Input.mousePosition;
        mousePointOnScreen = Camera.main.ScreenToWorldPoint(mousePosition);
        mouseDirection = mousePointOnScreen - transform.position;
        
        // store any movement inputs into m_playerDirection - this will be used in FixedUpdate to move the player.
        m_playerDirection = m_moveAction.ReadValue<Vector2>();
        
        // ~~ handle animator ~~
        // Update the animator speed to ensure that we revert to idle if the player doesn't move.
        m_animator.SetFloat("Speed", m_playerDirection.magnitude);
        
        // If there is movement, set the directional values to ensure the character is facing the way they are moving.
        if (m_playerDirection.magnitude > 0)
        {
            m_animator.SetFloat("Horizontal", m_playerDirection.x);
            m_animator.SetFloat("Vertical", m_playerDirection.y);
        }

        // check if an attack has been triggered.
        if (m_attackAction.IsPressed() && Time.time > m_fireTimeout)
        {
            m_fireTimeout = Time.time + m_fireRate;
            Fire();
        }
    }
}
