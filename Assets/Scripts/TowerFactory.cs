using System;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {
    [Header( "General" )]
    [SerializeField] int towerLimit = 5;
    [SerializeField] TowerController towerPrefab;

    [Header( "External dependencies" )]
    [SerializeField] Transform parent;

    private Queue<TowerController> towers = new Queue<TowerController>( );
    private Queue<Waypoint> waypoints = new Queue<Waypoint>( );
    // Start is called before the first frame update
    int towercount = 0;
    public void AddTower( Waypoint waypoint ) {
        if( towers.Count < towerLimit ) {
            MakeNewTower( waypoint );
        }
        else {
            moveOldestTower( waypoint );
        }

    }

    private void moveOldestTower( Waypoint waypoint ) {
        TowerController tower = towers.Dequeue( );
        Waypoint prevWaypoint = waypoints.Dequeue( );

        prevWaypoint.hasTower = false;
        Vector3 towerPos = new Vector3( waypoint.transform.position.x, waypoint.transform.position.y + 10, waypoint.transform.position.z );
        tower.transform.position = towerPos;
        tower.transform.parent = parent;

        towers.Enqueue( tower );
        waypoint.hasTower = true;
        waypoints.Enqueue( waypoint );
    }

    private void MakeNewTower( Waypoint waypoint ) {
        Vector3 towerPos = new Vector3( waypoint.transform.position.x, waypoint.transform.position.y + 10, waypoint.transform.position.z );
        TowerController tower = Instantiate( towerPrefab, towerPos, Quaternion.identity );
        tower.transform.parent = parent;
        towers.Enqueue( tower );

        waypoint.hasTower = true;
        waypoints.Enqueue( waypoint );
    }

}
