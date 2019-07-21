using System;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

    private Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>( );
    private Queue<Waypoint> queue = new Queue<Waypoint>( );
    private List<Waypoint> path = new List<Waypoint>( );

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    [SerializeField] Waypoint start;
    [SerializeField] Waypoint end;

    Waypoint searchPoint;
    // Start is called before the first frame update
    void Awake( ) {
        LoadBlocks( );
        PathFind( );
        MakePath( );
    }
    public List<Waypoint> getPath( ) {
        return path;
    }
    private void PathFind( ) {
        queue.Enqueue( this.start );
        while( queue.Count > 0 ) {
            searchPoint = queue.Dequeue( );
            //check if at end
            if( searchPoint == this.end ) {
                break;
            }
            else {
                ExploreNeighbors();
            }
        }
    }
    private void MakePath( ) {
        Waypoint current = end;
        end.isPlaceable = false;
        while( current != start ) {
            AddToPath( current );
            current = current.exploredFrom;
        }
        AddToPath( start );
        path.Reverse( );
    }

    private void AddToPath( Waypoint waypoint ) {
        path.Add( waypoint );
        waypoint.isPlaceable = false;
    }

    private void ExploreNeighbors() {
        foreach( Vector2Int direction in directions ) {
            if( grid.ContainsKey( searchPoint.GetGridPosition( ) + direction ) ) {
                QueueNewNeighbor( direction );
            }
        }
    }

    private void QueueNewNeighbor( Vector2Int direction ) {
        Waypoint next = grid[searchPoint.GetGridPosition( ) + direction];
        if( !next.isExplored || queue.Contains( next ) ) {
            next.isExplored = true;
            queue.Enqueue( next );
            next.exploredFrom = searchPoint;
        }
    }

    private void LoadBlocks( ) {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>( );
        foreach( Waypoint waypoint in waypoints ) {
            if( waypoint.CheckIsNeutral()) {
                continue;
            }
            var gridPos = waypoint.GetGridPosition( );
            //check or overlapping blocks
            if( grid.ContainsKey( gridPos ) ) {
                Debug.LogWarning( "Overlapping block at " + gridPos.ToString( ) );
            }
            else {
                //put in dictionary
                grid.Add( gridPos, waypoint );
            }
        }
    }
}
