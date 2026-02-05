using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    CharacterController controller;
    void Start() { controller = GetComponent<CharacterController>(); }
    void Update() {
    Vector3 move = new Vector3(Input.GetAxis("Horizontal"), -1, Input.GetAxis("Vertical")); 
    controller.Move(move * Time.deltaTime * 5f);
    }
}
