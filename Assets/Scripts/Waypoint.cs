using UnityEngine;

public class Waypoint : MonoBehaviour {

    const int gridSize = 10;

    Vector2Int gridPosition;
    // Start is called before the first frame update
    void Start( ) {

    }

    // Update is called once per frame
    void Update( ) {

    }

    public int getGridSize( ) {
        return gridSize;
    }
    public Vector2Int GetGridPosition( ) {
        gridPosition = new Vector2Int(
        Mathf.RoundToInt( transform.position.x / gridSize ),
        Mathf.RoundToInt( transform.position.z / gridSize ));
        return gridPosition;
    }
    public void SetTopColor( Color color ) {
        MeshRenderer topRenderer = transform.Find( "Top" ).GetComponent<MeshRenderer>( );
        topRenderer.material.color = color;
    }
}
