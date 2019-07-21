using System;
using UnityEngine;

public class TakeDamage : MonoBehaviour {

    [SerializeField] int hitPoints = 5;
    [SerializeField] ParticleSystem hit;
    [SerializeField] ParticleSystem death;
    [SerializeField] AudioClip hitSound;
    [SerializeField] AudioClip deathSound;

    AudioSource audioSource;
    void Start( ) {
        audioSource = GetComponent<AudioSource>( );
    }
    void OnParticleCollision( GameObject other ) {
        Vector3 pos = new Vector3( transform.position.x, transform.position.y + 5, transform.position.z );
        Instantiate( hit, pos, Quaternion.identity );
        audioSource.Stop( );
        audioSource.volume = 0.5f;
        audioSource.PlayOneShot(hitSound);
        hitPoints--;
        if( hitPoints <= 0 ) {
            kill( pos );
        }
    }

    private void kill( Vector3 pos ) {
    
        Instantiate( death, pos, Quaternion.identity );
        AudioSource.PlayClipAtPoint( deathSound, transform.position );
        Destroy( this.gameObject);
    }
}
