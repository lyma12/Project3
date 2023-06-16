using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;

public static class AlgorithmDungeon
{
    public static HashSet<Vector3Int> SimpleRandomWalk(Vector3Int startPosition, int walkLength)
    {
        HashSet<Vector3Int> path = new HashSet<Vector3Int>();
        path.Add(startPosition);
        var previousPosition = startPosition;
        for(int i = 0; i< walkLength; i++)
        {
            var newPosition = previousPosition + Direction3D.GetRandomCardinalDirection();
            path.Add(newPosition);
            previousPosition = newPosition;
        }
        return path;
    }
    public static HashSet<Vector3Int> RandomWalkCorridor(Vector3Int startPosition, int corridorLength)
    {
        HashSet<Vector3Int> corridor = new HashSet<Vector3Int>();
        var direction = Direction3D.diagonalDirectionList[Random.Range(0, Direction3D.diagonalDirectionList.Count)];
        corridor.Add(startPosition);
        var previousCorridor = startPosition;
        for(int i = 0; i < corridorLength; i++)
        {
            var newPosition = previousCorridor + direction;
            corridor.Add(newPosition);
            previousCorridor = newPosition;
        }
        return corridor;
    }
}

public static class Direction3D
{
    public static List<Vector3Int> cardinalDiractionsList = new List<Vector3Int>
    {
        new Vector3Int(1, 0, 0),
        new Vector3Int(0, 0, 1),
        new Vector3Int(1, 0, 1),
        new Vector3Int(-1, 0, 0),
        new Vector3Int(0, 0 , -1),
        new Vector3Int(-1, 0, 1),
        new Vector3Int(1, 0, -1),
        new Vector3Int(-1, 0, -1)

    };
    public static List<Vector3Int> diagonalDirectionList = new List<Vector3Int>
    {
        new Vector3Int(0, -1, 1),
        new Vector3Int(1, -1, 0),
        new Vector3Int(1, -1, 1)
       
       
    };
    public static HashSet<Vector3Int> EndPositionList = new HashSet<Vector3Int>
    {
        new Vector3Int(0, 0, 1),
        new Vector3Int(1, 0, 1),
        new Vector3Int(1, 0, 0)
    };
    public static Vector3Int GetRandomCardinalDirection()
    {
        return cardinalDiractionsList[Random.Range(0, cardinalDiractionsList.Count)];
    }
}
