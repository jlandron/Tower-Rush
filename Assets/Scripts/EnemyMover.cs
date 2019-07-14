using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour {

    [SerializeField] List<Waypoint> blocks;
    // Start is called before the first frame update
    void Start( ) {
        
    }

    // Update is called once per frame
    void Update( ) {
        foreach( Waypoint block in blocks ) {
            print( block.name );
        }
    }
}
