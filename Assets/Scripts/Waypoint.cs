﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Color exploredColor;
    // public okay as it is a data class
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlaceable = true;


    Vector2Int gridPos;

    const int gridSize = 10;

    private void Start()
    {
        Physics.queriesHitTriggers = true;
    }

    public int GetGridSize()
    {
        return gridSize;
    }


    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) //left click
        {
            if (isPlaceable)
            {
                FindObjectOfType<TowerFactory>().AddTower(this); // this, meaning the Waypoint (we are in Waypoint class)
            }
            else
            {
                print("can't place here.");
            }   
        }
        
    }

}
