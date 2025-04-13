using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private readonly float smoothSpeed = 0.125f;
    public Vector3 offset = new(0, 0, -10);

    public bool useBounds = false;
    public float minX = 0f;
    public float maxX = 10f;
    public float minY = 0f;
    public float maxY = 5f;

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {

        Vector3 desiredPosition = target.position + offset;

        if (useBounds)
        {
            desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX, maxX);
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, minY, maxY);
        }

        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        transform.position = smoothedPosition;
    }

    private void OnDrawGizmosSelected()
    {
        if (useBounds)
        {
            Gizmos.color = Color.yellow;
            Vector3 bottomLeft = new Vector3(minX, minY, transform.position.z);
            Vector3 topRight = new Vector3(maxX, maxY, transform.position.z);

            Gizmos.DrawLine(bottomLeft, new Vector3(topRight.x, bottomLeft.y, bottomLeft.z));
            Gizmos.DrawLine(new Vector3(topRight.x, bottomLeft.y, bottomLeft.z), topRight);
            Gizmos.DrawLine(topRight, new Vector3(bottomLeft.x, topRight.y, bottomLeft.z));
            Gizmos.DrawLine(new Vector3(bottomLeft.x, topRight.y, bottomLeft.z), bottomLeft);
        }
    }
}
