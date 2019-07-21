﻿using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    const int gridSize = 10;
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlaceable = true;
    public bool hasTower = false;

    [SerializeField] TowerController towerPrefab;
    [SerializeField] bool isNautral = false;

    Vector2Int gridPosition;
    void OnMouseOver( ) {
        if( isPlaceable ) {
            if( Input.GetMouseButtonDown( 0 ) ) {
                SpawnTower( );
            }
        }
    }

    private void SpawnTower( ) {
        if( !hasTower ) {
            Vector3 towerPos = new Vector3( transform.position.x, transform.position.y + 10, transform.position.z );
            TowerController tower = Instantiate( towerPrefab, towerPos, Quaternion.identity );
            hasTower = true;
        }
    }

    public int getGridSize( ) {
        return gridSize;
    }
    public Vector2Int GetGridPosition( ) {
        gridPosition = new Vector2Int(
        Mathf.RoundToInt( transform.position.x / gridSize ),
        Mathf.RoundToInt( transform.position.z / gridSize ) );
        return gridPosition;
    }
    public void SetTopColor( Color color ) {
        MeshRenderer topRenderer = transform.Find( "Top" ).GetComponent<MeshRenderer>( );
        topRenderer.material.color = color;
    }
    public bool CheckIsNeutral( ) {
        return isNautral;
    }
}
