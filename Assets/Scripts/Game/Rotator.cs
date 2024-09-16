using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] float rotation_speed = 100;

    private void LateUpdate()
    {
        transform.Rotate(0, 0, rotation_speed* Time.deltaTime);
    }
}
