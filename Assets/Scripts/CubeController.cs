using UnityEngine;

[ExecuteInEditMode]
public class CubeController : MonoBehaviour {

    int gridSize;

    Waypoint waypoint;

    void Awake( ) {
        waypoint = GetComponent<Waypoint>( );
        gridSize = waypoint.getGridSize( );
    }

    void Start( ) {

    }
    void Update( ) {
        SnapToGrid( );
        UpdateLabel( );
    }

    private void UpdateLabel( ) {
        TextMesh textMesh = GetComponentInChildren<TextMesh>( );
        string posText = ("(" + (waypoint.GetGridPosition( ).x) + "," + (waypoint.GetGridPosition( ).y) + ")");
        textMesh.text = posText;
        gameObject.name = "Cube " + posText;
    }

    private void SnapToGrid( ) {
        transform.position = new Vector3Int(
            waypoint.GetGridPosition( ).x * gridSize,
            0,
            waypoint.GetGridPosition( ).y * gridSize
            );
    }
}
