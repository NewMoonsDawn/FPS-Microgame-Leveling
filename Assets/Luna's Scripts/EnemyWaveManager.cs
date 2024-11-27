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

    IEnumerator SpawnWave(int enemies)
    {
        counter++;
        if(counter % 2 == 0)
        {
            enemies++;
        }
        for(int i =0;i< enemies; i++)
        {
            Transform spawnLocation = spawnLocations[Random.Range(0, spawnLocations.Count)];
            Instantiate(enemyPrefab, spawnLocation.position, spawnLocation.rotation, spawnLocation);
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(4f + enemies);
        Debug.Log("next wave");
        StartCoroutine(SpawnWave(enemies));
    }
}
