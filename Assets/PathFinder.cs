using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>( );
    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };
    [SerializeField] Waypoint start;
    [SerializeField] Waypoint end;
    // Start is called before the first frame update
    void Start( ) {
        LoadBlocks( );
        ExploreNeighbors( start );
    }

    private void ExploreNeighbors(Waypoint waypoint) {
        foreach( Vector2Int direction in directions ) {
            print( "Exploring " + (waypoint.GetGridPosition( ) + direction) );

            if( grid.ContainsKey( waypoint.GetGridPosition( ) + direction ) ) {
                grid[waypoint.GetGridPosition( ) + direction].SetTopColor( Color.blue );
            }
        }
    }

    private void LoadBlocks( ) {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>( );
        foreach( Waypoint waypoint in waypoints ) {

            var gridPos = waypoint.GetGridPosition( );
            //check or overlapping blocks
            if( grid.ContainsKey( gridPos ) ) {
                Debug.LogWarning( "Overlapping block at " + gridPos.ToString( ) );
            }
            else {
                //put in dictionary
                grid.Add( gridPos, waypoint );
                waypoint.SetTopColor( Color.yellow );
            }
        }
        start.SetTopColor( Color.green );
        end.SetTopColor( Color.red );
    }
}
