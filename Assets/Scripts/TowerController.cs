using System;
using UnityEngine;

public class TowerController : MonoBehaviour {

    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 20f;
    [SerializeField] ParticleSystem gun;

    Transform targetEnemy;
    float distanceToEnemy;

    void Start( ) {
        gun = gameObject.GetComponentInChildren<ParticleSystem>( );
    }
    // Update is called once per frame
    void Update( ) {
        FireAtEnemy( );
        SetTargetEnemy( );
    }

    private void SetTargetEnemy( ) {
        EnemyMover[] enemies = FindObjectsOfType<EnemyMover>( );
        if( enemies.Length == 0 ) {
            return;
        }
        targetEnemy = enemies[0].transform;
        distanceToEnemy = Vector3.Distance( targetEnemy.transform.position, gameObject.transform.position );
        foreach( EnemyMover enemy in enemies ) {
            if( Vector3.Distance( enemy.transform.position, gameObject.transform.position ) < distanceToEnemy ) {
                targetEnemy = enemy.transform;
                distanceToEnemy = Vector3.Distance( targetEnemy.transform.position, gameObject.transform.position );
            }
        }
    }

    private void FireAtEnemy( ) {
        if( targetEnemy ) {
            objectToPan.LookAt( targetEnemy );
            
            if( distanceToEnemy <= attackRange ) {
                Shoot( true );
            }
            else {
                Shoot( false );
            }
        }
        else {
            Shoot( false );
        }
    }

    private void Shoot( bool shoot) {
        ParticleSystem.EmissionModule emisionModule = gun.emission;
        emisionModule.enabled = shoot;
    }
}
