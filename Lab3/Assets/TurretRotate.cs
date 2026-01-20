using UnityEngine;

public class TurretRotate : MonoBehaviour
{
    public Transform target;
    public float rotateSpeed = 90f;

    public RotationMode rotationMode;

    public enum RotationMode
    {
        LookAt_Direct,      // xoay trực tiếp
        RotateTowards_Smooth // xoay mượt
        // hoặc có thể đổi thành Slerp_Smooth
    }

    void Update()
    {
        if (target == null) return;

        Vector3 dir = target.position - transform.position;
        Quaternion targetRot = Quaternion.LookRotation(dir);

        switch (rotationMode)
        {
            case RotationMode.LookAt_Direct:
                // Xoay ngay lập tức
                transform.LookAt(target);
                break;

            case RotationMode.RotateTowards_Smooth:
                // Xoay mượt theo tốc độ
                transform.rotation = Quaternion.RotateTowards(
                    transform.rotation,
                    targetRot,
                    rotateSpeed * Time.deltaTime
                );
                break;
        }
    }
}
