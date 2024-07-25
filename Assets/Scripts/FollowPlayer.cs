using UnityEngine;

public class FollowPlayer : MonoBehaviour
{   
    [SerializeField] Transform player;

    private void Update()
    {
        //if player position is higher then (this gameobject Y) follow it
        if (player.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
        }
    }
}
