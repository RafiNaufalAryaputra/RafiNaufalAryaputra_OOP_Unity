using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HitboxComponent : MonoBehaviour
{
    [SerializeField] private HealthComponent healthComponent;

    private void Awake()
    {
        if (healthComponent == null)
        {
            healthComponent = GetComponent<HealthComponent>();
        }
    }

    public void Damage(int damage)
    {
        healthComponent.Subtract(damage);
    }

    public void Damage(Bullet bullet)
    {
        Damage(bullet.damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.GetComponent<Bullet>();
        if (bullet != null)
        {
            Damage(bullet);
            // Setelah mengurangi health, kita bisa menghapus atau me-*recycle* bullet
            bullet.gameObject.SetActive(false);
        }
    }
}
