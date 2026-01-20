using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public float speed = 2f;
    public float rotateSpeed = 200f; // Tốc độ xoay (độ/giây)

    // LAB 1: Component Lifecycle Debugger
    void Awake() => Debug.Log("Enemy: Awake");
    void Start() 
    {
        Debug.Log("Enemy: Start");
        // Tự tìm Player nếu chưa gán
        if (target == null) target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void OnDisable() => Debug.Log("Enemy: OnDisable");
    void OnDestroy() => Debug.Log("Enemy: OnDestroy");

    void Update()
    {
        if (target == null) return;

        // 1. Di chuyển về phía Player
        // LAB 2 ứng dụng: Vector hướng về mục tiêu = (Đích - Đầu).normalized
        Vector2 direction = (target.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        // 2. Xoay mặt về phía Player (LAB 3: Quaternion Rotation)
        RotateTowardsTarget();
    }

    // LAB 3: So sánh xoay mượt (RotateTowards)
    void RotateTowardsTarget()
    {
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f; // -90 vì sprite mặc định hướng lên
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Dùng RotateTowards thay vì gán trực tiếp để xoay mượt mà
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
    }
    
    // Xử lý va chạm với Player
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Trừ máu Player
            other.GetComponent<HealthSystem>().TakeDamage(1);
            // Tự hủy
            Destroy(gameObject);
        }
    }
}