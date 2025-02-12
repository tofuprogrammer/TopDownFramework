using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") && !collision.CompareTag("Fire Point") && !collision.CompareTag("Background") && !collision.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
    }
}
