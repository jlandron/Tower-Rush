using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    [SerializeField] int playerHealth = 5;
    [SerializeField] int healthDecrease = 1;

    [SerializeField] Text healthText;


    void OnTriggerEnter( Collider collider ) {
        playerHealth = playerHealth - healthDecrease;

    }

    void Update( ) {
        healthText.text = playerHealth.ToString( );
    }
}
