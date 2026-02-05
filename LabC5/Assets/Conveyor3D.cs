using UnityEngine;

public class Conveyor3D : MonoBehaviour
{
    public float speed = 3.0f;
    public Vector3 direction = Vector3.forward; // Hướng đẩy (trục Z)

    // Khi Player đứng vào vùng này
    void OnTriggerStay(Collider other) {
        // Nếu là Player (có CharacterController)
        CharacterController player = other.GetComponent<CharacterController>();
        if (player != null) {
            player.Move(direction * speed * Time.deltaTime);
        }

        // Nếu là Vật thể (có Rigidbody)
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null) {
            rb.position += direction * speed * Time.deltaTime;
        }
    }
}