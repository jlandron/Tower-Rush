using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] float secondsBetweenSpawns = 2;
    [SerializeField] float numberOfEnemies = 10;
    [SerializeField] EnemyMover enemyPrefab;
    // Start is called before the first frame update
    void Start( ) {
        //start co-routine
        StartCoroutine( SpawnEnemies( ) );
    }
    IEnumerator<WaitForSeconds> SpawnEnemies( ) {
        for( int i = 0; i < numberOfEnemies; i++ ) {
            print( "Spawn enamies" );
            
            yield return new WaitForSeconds( secondsBetweenSpawns );
        }

    }
}
