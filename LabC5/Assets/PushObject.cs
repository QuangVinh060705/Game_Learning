using UnityEngine;

public class PushObject : MonoBehaviour
{
   void Update() {
    if(Input.GetKeyDown(KeyCode.Space))
        GetComponent<Rigidbody>().AddForce(Vector3.up * 500f); // Nhảy
    if(Input.GetKey(KeyCode.W))
        GetComponent<Rigidbody>().AddForce(Vector3.forward * 20f);
    }
}
