using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        // Bay thẳng theo hướng local (Lab 2)
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        
        // Tự hủy sau 3s để tránh đầy bộ nhớ (Lab 1)
        Destroy(gameObject, 3f); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Trừ 1 máu Enemy
            other.GetComponent<HealthSystem>().TakeDamage(1);
            Destroy(gameObject); // Đạn biến mất
        }
    }
}