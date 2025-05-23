using System.Collections.Generic;
using UnityEngine;

public class PatrolRoute : MonoBehaviour
{
    [Tooltip("Pontos de patrulha divididos por nível")]
    public List<Transform> allPatrolPoints;

    [Tooltip("Intervalos de pontos por nível")]
    public List<int> levelRanges; 

    public List<Vector3> GetPatrolPointsForLevel(int level)
    {
        List<Vector3> selected = new List<Vector3>();

        int start = levelRanges[level];
        int end = (level + 1 < levelRanges.Count) ? levelRanges[level + 1] : allPatrolPoints.Count;

        for (int i = start; i < end; i++)
        {
            selected.Add(allPatrolPoints[i].position);
        }

        return selected;
    }
}
