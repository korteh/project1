using UnityEngine;

public class CameraMov : MonoBehaviour {

    public Transform target;

    public float SmoothSpeed = 0.5f;
    public Vector3 offset;

    private void LateUpdate()
    {
        Vector3 desPos = target.position + offset;
        Vector3 SmPos = Vector3.Lerp(transform.position, desPos, SmoothSpeed * Time.deltaTime);
        transform.position =SmPos;
        transform.LookAt(target);
    }
}
