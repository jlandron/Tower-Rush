using UnityEngine;

[ExecuteInEditMode]
public class CubeController : MonoBehaviour {
    [Range( 1, 20 )] [SerializeField] int gridSize = 10;

    TextMesh textMesh;

    void Start( ) {
        textMesh = GetComponentInChildren<TextMesh>( );
        textMesh.text = ("0,0");
    }
    void Update( ) {
        Vector3 snapPosition;
        snapPosition.x = Mathf.RoundToInt( transform.position.x / gridSize ) * gridSize;
        //snapPosition.y = Mathf.RoundToInt( transform.position.y / gridSize ) * gridSize;
        snapPosition.y = 0;
        snapPosition.z = Mathf.RoundToInt( transform.position.z / gridSize ) * gridSize;
        transform.position = snapPosition;
        textMesh.text = ("(" + (snapPosition.x / gridSize) + "," + (snapPosition.z / gridSize) + ")");
    }

}
