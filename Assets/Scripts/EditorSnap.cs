using UnityEngine;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{
    [Range(1, 20)][SerializeField] int gridSize = 10;
    void Update( ) {
        Vector3 snapPosition;
        snapPosition.x = Mathf.RoundToInt( transform.position.x / gridSize ) * gridSize;
        snapPosition.y = Mathf.RoundToInt( transform.position.y / gridSize ) * gridSize;
        snapPosition.z = Mathf.RoundToInt( transform.position.z / gridSize ) * gridSize;
        transform.position = snapPosition;

    }

}
