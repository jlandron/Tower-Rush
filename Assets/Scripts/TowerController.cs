using UnityEngine;

public class TowerController : MonoBehaviour {

    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;

    // Update is called once per frame
    void Update( ) {
        objectToPan.LookAt( targetEnemy );
    }
}
