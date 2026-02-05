
using UnityEngine;

public class lab6 : MonoBehaviour
{
   void OnCollisionEnter(Collision col) { Debug.Log("Đụng tường!"); }
void OnTriggerEnter(Collider other) { Debug.Log("Đi xuyên vùng xanh!"); }
}
