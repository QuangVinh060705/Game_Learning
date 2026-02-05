using UnityEngine;

public class PlayerFinal : MonoBehaviour
{
    public float speed = 6.0f;
    public float pushPower = 2.0f; // Lực đẩy hộp
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    void Start() {
        controller = GetComponent<CharacterController>();
    }

    void Update() {
        // 1. Xử lý di chuyển
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Di chuyển theo hướng nhìn
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        
        // Giả lập trọng lực đơn giản (luôn kéo xuống)
        move.y = -5.0f; 

        controller.Move(move * speed * Time.deltaTime);
    }

    // 2. Xử lý đẩy vật thể Rigidbody (Code Lab 5 tích hợp)
    void OnControllerColliderHit(ControllerColliderHit hit) {
        Rigidbody body = hit.collider.attachedRigidbody;

        // Nếu vật không có Rigidbody hoặc đang bị khóa (Kinematic) thì bỏ qua
        if (body == null || body.isKinematic) return;

        // Tính hướng đẩy (chỉ đẩy ngang, không đẩy xuống đất)
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // Tác động lực
        body.linearVelocity = pushDir * pushPower;
    }
}