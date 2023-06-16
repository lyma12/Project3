using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net.Mime;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlaneDungeon : MonoBehaviour
{
    public int sizePlaneMin = 70;
    public int sizePlaneMax = 100;
    public int corridorLengthMin = 4;
    public int corridorLengthMax = 10;
    
    public GameObject gameObject;

    private Queue<int> numberOfPlane = new Queue<int>();
    private Player player;

    public void Start()
    {
        GameObject gamer = GameObject.FindGameObjectWithTag("Player");
        if (gamer != null)
        {
            player = gamer.GetComponent<Player>();
        }
        if (player != null)
            CreatePlaneDungeon();
        else UnityEngine.Debug.Log("Don't find the player");
    }

    private void CreatePlaneDungeon()
    {
        int tmp = 0;
        var startPositionPlane = Vector3Int.zero;
        int corridorLength;
        Vector3Int startPositionCorridor;
    //    while (player.getOverGame())
    for(int i = 0; i< 5; i++)
        {
            var sizePlane = Random.Range(sizePlaneMin, sizePlaneMax);
            HashSet<Vector3Int> plane = AlgorithmDungeon.SimpleRandomWalk(startPositionPlane, sizePlane);
            foreach (var position in plane)
            {
                GameObject pla = Instantiate(gameObject, position, Quaternion.identity);
                PlaneObject planeObject = pla.GetComponent<PlaneObject>();
                planeObject.setNumber(tmp);
            }
            startPositionCorridor = FindEndPosition(plane, startPositionPlane);
            corridorLength = Random.Range(corridorLengthMin, corridorLengthMax);
            HashSet<Vector3Int> corridor = AlgorithmDungeon.RandomWalkCorridor(startPositionCorridor, corridorLength);
            foreach (var position in corridor)
            {
                GameObject pla = Instantiate(gameObject, position, Quaternion.identity);
                PlaneObject planeObject = pla.GetComponent<PlaneObject>();
                planeObject.setNumber(tmp);
            }
            startPositionPlane = corridor.ElementAt(corridor.Count - 1);
            numberOfPlane.Enqueue(tmp);
            tmp++;
        }
        
    }
    private Vector3Int FindEndPosition(HashSet<Vector3Int> plane, Vector3Int differentPosition)
    {
        Vector3Int result = new Vector3Int();
        HashSet<Vector3Int> endPosition = new HashSet<Vector3Int>();
        foreach(var position in plane)
        {
            if(differentPosition != position)
            {
                bool isEndPosition = true;
                foreach(var direction in Direction3D.EndPositionList)
                {
                    var neightbour = position + direction;
                    if (plane.Contains(neightbour))
                    {
                        isEndPosition = false;
                        break;
                    }
                }
                if (isEndPosition) endPosition.Add(position);
            }

        }
        var list = endPosition.OrderBy(position => position.z).ToList();
        result = list[list.Count - 1];
        return result;
    }
}
