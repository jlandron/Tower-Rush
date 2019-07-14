using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour {

    [SerializeField] List<Waypoint> waypoints;
    // Start is called before the first frame update
    void Start( ) {
        StartCoroutine( MoveAlongAllWaypoints( ) );
    }

    // Update is called once per frame
    void Update( ) {
        
    }

    IEnumerator<WaitForSeconds> MoveAlongAllWaypoints( ) {
        foreach( Waypoint waypoint in waypoints ) {
            Vector3 snapPosition = new Vector3();
            snapPosition.x = waypoint.transform.position.x;
            snapPosition.y = 5f;
            snapPosition.z = waypoint.transform.position.z;
            transform.position = snapPosition;
            yield return new WaitForSeconds( 1f );
        }
    }
}
