using UnityEngine;

public class TakeDamage : MonoBehaviour {

    [SerializeField] int hitPoints = 5;
    void OnParticleCollision( GameObject other ) {
        hitPoints--;
        if( hitPoints <= 0 ) {
            Destroy( this.gameObject );
        }
    }
}
