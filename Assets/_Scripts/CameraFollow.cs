using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 cameraOffset;
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.position + cameraOffset;
    }
}
