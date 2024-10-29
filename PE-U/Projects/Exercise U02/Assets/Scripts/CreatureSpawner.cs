using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject creaturePrefab;
    [SerializeField]
    private List<Vector3> spawnPos = new List<Vector3>(3);

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate creature prefab with assigned location
        //and default rotation.
        for (int i = 0; i < spawnPos.Count; i++)
        {
            GameObject.Instantiate(
                creaturePrefab,
                spawnPos[i],
                Quaternion.identity);

            //Print a message if instantiated successfully.
            Debug.Log($"Creature spawned at {spawnPos[i]}!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
