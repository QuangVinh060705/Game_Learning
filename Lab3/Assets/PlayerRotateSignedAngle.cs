using UnityEngine;
using TMPro;

public class PlayerRotateSignedAngle : MonoBehaviour
{
    public TMP_Text angleText;

    void Update()
    {
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = 0f;

        Vector2 direction = mouseWorld - transform.position;

        float angle = Vector2.SignedAngle(Vector2.up, direction);

        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        angleText.text = $"Angle: {angle:F2}°";
    }
}
