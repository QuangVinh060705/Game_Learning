using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float flySpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
        {
        var newPosition = transform.position;
        newPosition.y += Time.deltaTime * flySpeed;
        transform.position = newPosition;
        }
}
