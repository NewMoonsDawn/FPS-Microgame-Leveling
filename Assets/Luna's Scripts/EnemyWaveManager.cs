using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public GameObject enemyPrefab;

    private int counter = 0;
    private List<Transform> spawnLocations = new List<Transform>();

    void Start()
    {
        foreach(Transform child in gameObject.transform)
        {
            spawnLocations.Add(child);
        }
        StartCoroutine(SpawnWave(1));
    }

    // Update is called once per frame
/*    void Update()
    {
        
    }*/

    IEnumerator SpawnWave(int enemies)
    {
        Debug.Log(enemies);
        counter++;
        if(counter % 2 == 0)
        {
            enemies++;
        }
        for(int i =0;i< enemies; i++)
        {
            Transform spawnLocation = spawnLocations[Random.Range(0, spawnLocations.Count)];
            Instantiate(enemyPrefab, spawnLocation.position, spawnLocation.rotation, spawnLocation);
            Debug.Log("spawned");
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(4f + enemies);
        Debug.Log("next wave");
        StartCoroutine(SpawnWave(enemies));
    }
}
