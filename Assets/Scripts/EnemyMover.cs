using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour {

    [SerializeField] List<Waypoint> waypoints;
    // Start is called before the first frame update
    void Start( ) {
        PathFinder pathFinder = FindObjectOfType<PathFinder>( );
        waypoints = pathFinder.getPath( );
        StartCoroutine( MoveAlongAllWaypoints( ) );
    }

    // Update is called once per frame
    void Update( ) {
        
    }

    IEnumerator<WaitForSeconds> MoveAlongAllWaypoints( ) {
        foreach( Waypoint waypoint in waypoints ) {
            Vector3 snapPosition = new Vector3(
                waypoint.transform.position.x,
                10f,
                waypoint.transform.position.z );
            transform.position = snapPosition;
            yield return new WaitForSeconds( 1f );
        }
    }
}
