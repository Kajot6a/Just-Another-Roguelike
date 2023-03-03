using System.Diagnostics;
using System;
using System.Security.AccessControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;
using Debug = UnityEngine.Debug;

public class SimpleRandomWalkMapGenerator : AbstractDungeonGenerator
{
    [SerializeField]
    protected SimpleRandomWalkData randomWalkParameters;
    
    protected override void RunProceduralGeneration(){
        HashSet<Vector2Int> floorPositions = RunRandomWalk(randomWalkParameters, startPosition);

        tilemapVisualizer.Clear();
        tilemapVisualizer.PaintFloorTiles(floorPositions);
        WallGenerator.CreateWalls(floorPositions, tilemapVisualizer);
        
    }

    public void test(){
        Debug.Log("test");
    }

    protected HashSet<Vector2Int> RunRandomWalk(SimpleRandomWalkData parameters, Vector2Int position){

        var currentPosition = position;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        for(int i = 0; i < parameters.iterations; i++) {
            var path = ProceduralGenerationAlg.SimpleRandomWalk(currentPosition, parameters.walkLength);
            floorPositions.UnionWith(path);
            if (parameters.startRandomlyEachIteration) {
                currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
            }
        }
        return floorPositions;
    }  

}
