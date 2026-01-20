using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float speed = 5f;

    private Vector3 moveDirection;

    void Update()
    {
        // Lấy input WASD
        float horizontal = Input.GetAxisRaw("Horizontal"); // A D
        float vertical   = Input.GetAxisRaw("Vertical");   // W S

        // Vector hướng di chuyển trên mặt phẳng XZ
        moveDirection = new Vector3(horizontal, vertical, 0f);

        // Normalize để tránh chạy chéo nhanh hơn
        if (moveDirection.magnitude > 1f)
        {
            moveDirection = moveDirection.normalized;
        }

        // Di chuyển object
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    // Vẽ hướng di chuyển trong Scene View
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(
            transform.position,
            transform.position + moveDirection * 2f
        );
    }
}
