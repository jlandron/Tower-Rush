using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

    [Header( "General" )]
    [Range( 0.5f, 10 )] [SerializeField] float secondsBetweenSpawns = 1f;
    [SerializeField] int numberOfEnemies = 10;
    [SerializeField] EnemyMover enemyPrefab;
    [SerializeField] int scoreMultiplier = 10;

    [Header( "External dependencies" )]
    [SerializeField] Transform parent;
    [SerializeField] Text scoreText;
    [SerializeField] AudioClip spawnSFX;

    void Start( ) {
        //start co-routine
        StartCoroutine( SpawnEnemies( ) );
    }
    IEnumerator<WaitForSeconds> SpawnEnemies( ) {
        for( int i = 0; i < numberOfEnemies; i++ ) {
            EnemyMover enemy = Instantiate( enemyPrefab, transform.position , Quaternion.identity);
            enemy.transform.parent = parent;
            scoreText.text = (scoreMultiplier * (i + 1)).ToString( );
            FindObjectOfType<AudioSource>( ).PlayOneShot( spawnSFX );
            yield return new WaitForSeconds( secondsBetweenSpawns );
        }
    }
}
