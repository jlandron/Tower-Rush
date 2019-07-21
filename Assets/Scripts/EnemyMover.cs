using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour {

    private List<Waypoint> waypoints;

    [Range(0.1f,2)][SerializeField] float moveSpeed = 1f;

    [SerializeField] ParticleSystem explosion;
    [SerializeField] AudioClip explosionSound;

    AudioSource audioSource;
    void Start( ) {
        audioSource = GetComponent<AudioSource>( );
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
            yield return new WaitForSeconds( moveSpeed );
        }
        Blowup( waypoints[waypoints.Count - 1].transform.position );
    }

    private void Blowup( Vector3 pos ) {
        Vector3 fixedPos = new Vector3( pos.x, pos.y + 10, pos.z );
        Instantiate( explosion, fixedPos, Quaternion.identity );
        audioSource.Stop( );
        audioSource.volume = 0.5f;
        audioSource.PlayOneShot( explosionSound );
        Destroy( this.gameObject, 0.5f);
    }
}
