using UnityEngine;

public class ResetXPosition : MonoBehaviour
{
    [SerializeField] float trap_leagth ;
    [SerializeField] float out_of_camera_x = -30f;
    [SerializeField] Transform next_trap;

    private void Update()
    {
        //if trap out of camera
        if (gameObject.transform.position.x < out_of_camera_x)
        {
            //transport it to the end of the trap array
            transform.position = new Vector3 (next_trap.position.x + trap_leagth, gameObject.transform.position.y);    
        }
    }
}
