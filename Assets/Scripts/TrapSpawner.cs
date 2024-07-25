using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] traps_pref;
    [SerializeField] float spawn_distance;
    [SerializeField] int number_traps = 5;
    [SerializeField] Camera main_camera;
    float y_offset = 25;
    GameObject last_trap;
    private List<GameObject> activeTraps = new List<GameObject>();  // List to store active traps


    private void Start()
    {
        SpawnRandomTrap(number_traps);
    }

    private void Update()
    {
        DestroyLowestTrap();
    }

    private void SpawnRandomTrap(int repeatNumber)
    {
        for (int i = 0; i < repeatNumber; i++)
        {
            int index = Random.Range(0, traps_pref.Length);
            GameObject trap = traps_pref[index];

            //if this is the first trap, generate it on y=0
            if (last_trap == null)
            {
                last_trap = Instantiate(trap, new Vector3(trap.transform.position.x, 0, trap.transform.position.z), trap.transform.rotation);
                activeTraps.Add(last_trap);
            }
            else
            {
                Trap trap_script = last_trap.GetComponent<Trap>();

                //determine were the trap will spawn
                float position_y = last_trap.transform.position.y + spawn_distance + trap_script.trap_offset;

                //Instanciate a new trap based on the position of the last one
                last_trap = Instantiate(trap, new Vector3(trap.transform.position.x, position_y, trap.transform.position.z), trap.transform.rotation);
                activeTraps.Add(last_trap);
            }
        }
    }

    private void DestroyLowestTrap()
    {
        // Ensure the list is not empty
        if (activeTraps.Count > 0)
        {
            GameObject lowestTrap = activeTraps[0];

            // Check if the lowest trap is below the specified y value
            if (lowestTrap.transform.position.y < main_camera.transform.position.y - y_offset)
            {
                activeTraps.RemoveAt(0);  // Remove the trap from the list
                Destroy(lowestTrap);      // Destroy the trap
                SpawnRandomTrap(1);       // Spawn a new trap
            }
        }
    }
}
