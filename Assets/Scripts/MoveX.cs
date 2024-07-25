using UnityEngine;

public class MoveX : MonoBehaviour
{
    [SerializeField] float move_speed;

    private void LateUpdate()
    {
        transform.position += new Vector3 (move_speed *Time.deltaTime, 0);
    }
}
