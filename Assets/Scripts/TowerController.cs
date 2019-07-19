using UnityEngine;

public class TowerController : MonoBehaviour {

    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] float attackRange = 20f;
    [SerializeField] ParticleSystem gun;

    void Start( ) {
        gun = gameObject.GetComponentInChildren<ParticleSystem>( );
    }
    // Update is called once per frame
    void Update( ) {
        FireAtEnemy( );
    }

    private void FireAtEnemy( ) {
        if( targetEnemy ) {
            objectToPan.LookAt( targetEnemy );
            float distanceToEnemy = Vector3.Distance( targetEnemy.transform.position, gameObject.transform.position );
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
