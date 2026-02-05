using UnityEngine;
public class Bullet : MonoBehaviour
{
    public float flySpeed;
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}