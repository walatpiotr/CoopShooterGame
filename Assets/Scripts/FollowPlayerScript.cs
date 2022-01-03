using UnityEngine;

public class FollowPlayerScript : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset = 1f;

    private Camera assignedCamera;

    private void Start()
    {
        assignedCamera = GetComponent<PlayerMovement>().cam;
    }

    private void Update()
    {
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y, -10f);
        assignedCamera.transform.position = Vector3.Slerp(assignedCamera.transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}
