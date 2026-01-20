using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    // MỚI: Biến để chỉnh tốc độ bắn (số giây giữa 2 viên đạn)
    // 0.2f nghĩa là 1 giây bắn được 5 viên
    public float fireRate = 0.2f; 
    private float nextFireTime = 0f; // Biến đếm thời gian

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + transform.up * 2);
    }

    void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleShooting();
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(moveX, moveY);
        transform.Translate(movement.normalized * moveSpeed * Time.deltaTime, Space.World);
    }

    void HandleRotation()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector2 direction = mousePos - transform.position;
        float angle = Vector2.SignedAngle(Vector2.up, direction);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void HandleShooting()
    {
        // MỚI: Đổi GetButtonDown -> GetButton (để giữ chuột)
        // MỚI: Thêm điều kiện Time.time >= nextFireTime (kiểm soát tốc độ bắn)
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime) 
        {
            Shoot();
            // Cập nhật thời điểm được bắn viên tiếp theo
            nextFireTime = Time.time + fireRate; 
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}