using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WayConfigSO> wayConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    WayConfigSO currentWave;
    [SerializeField] bool isLooping = false;
    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    IEnumerator SpawnEnemyWaves(){

        do{
            foreach(WayConfigSO child in wayConfigs){

                currentWave = child;
                for(int i = 0;i<currentWave.GetEnemyCount(); i++){
                    Instantiate(currentWave.GetEnemyPrefabs(i),
                    currentWave.GetStartWayPoint().position,
                    Quaternion.Euler(0, 0, 180), transform); // identity is for no rotation. 
                    yield return new WaitForSeconds(currentWave.GetSpawnTime());
                    Debug.Log(currentWave.GetSpawnTime());
                }

                yield return new WaitForSeconds(timeBetweenWaves);

            }

        }while(isLooping);
        // Coroutines are special methods that return a countable value. This value is counted untill the time is elapsed and then the current execution is resumed.
    }

    public WayConfigSO GetCurrentWave(){
        return currentWave;
    }
    void Update()
    {
        
    }
}
