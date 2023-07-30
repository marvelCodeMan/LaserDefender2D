using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Wave Config", fileName = "New Wave Config")] 
public class WayConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float timeBetweenEnemySpawn = 1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minSpawnTime = 0.2f;


    public int GetEnemyCount(){
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefabs(int index){
        return enemyPrefabs[index];
    }
    public Transform GetStartWayPoint(){
        return pathPrefab.GetChild(0);
    }
    public List<Transform> GetWayPoints(){
        List<Transform> waypoints = new List<Transform>();
        foreach(Transform child in pathPrefab){
            waypoints.Add(child);
        }
        return waypoints;
    }
    public float getMoveSpeed(){
        return moveSpeed;
    }
    public float GetSpawnTime(){
        
        float spawnTime = Random.Range(timeBetweenEnemySpawn- spawnTimeVariance, timeBetweenEnemySpawn + spawnTimeVariance);
        Mathf.Clamp(spawnTime, minSpawnTime, float.MaxValue);
        return spawnTime;
    }
}
