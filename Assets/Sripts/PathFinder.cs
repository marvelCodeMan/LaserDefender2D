using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    // This script will find the first wayPoint and then move the enemy towards next unvisited wayPoint, once it reaches the end of the path, it will be destroyed.
    EnemySpawner enemySpawner;
    WayConfigSO wayConfig;
    List<Transform> wayPoints;
    int wayPointIndex = 0;

    private void Awake() {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }
    private void Start() {
        wayConfig = enemySpawner.GetCurrentWave();
        wayPoints = wayConfig.GetWayPoints();
        transform.position = wayPoints[wayPointIndex].position;
    }

    private void Update(){
        FollowPath();
    }

    void FollowPath(){
        if(wayPointIndex < wayPoints.Count){
            Vector3 targetPosition = wayPoints[wayPointIndex].position;
            float delta = wayConfig.getMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if(transform.position == targetPosition){
                wayPointIndex ++;
            }
        }
        else {
            Destroy(gameObject);
        }
    }
}
