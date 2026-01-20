using UnityEngine;

public class LifecycleLogger : MonoBehaviour
{
    void Awake()        => Debug.Log("Awake");
    void OnEnable()     => Debug.Log("OnEnable");
    void Start()        => Debug.Log("Start");

    void Update()
    {
        Debug.Log("Update");

        // Nhấn phím D để Destroy object
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Destroy(gameObject) called");
            Destroy(gameObject);
        }
    }

    void FixedUpdate()  => Debug.Log("FixedUpdate");
    void LateUpdate()   => Debug.Log("LateUpdate");

    void OnDisable()    => Debug.Log("OnDisable");
    void OnDestroy()    => Debug.Log("OnDestroy");
}
