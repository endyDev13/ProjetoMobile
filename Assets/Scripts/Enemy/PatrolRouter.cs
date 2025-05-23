using System.Collections.Generic;
using UnityEngine;

public class PatrolRoute : MonoBehaviour
{
    [System.Serializable]
    public struct PatrolLevelRange
    {
        public int startIndex;
        public int endIndex; // exclusivo, ou seja, n�o inclui esse �ndice
    }


    [Tooltip("Pontos de patrulha divididos por n�vel")]
    public List<Transform> allPatrolPoints;

    [Tooltip("Faixas de pontos para cada n�vel da IA")]
    public PatrolLevelRange[] patrolLevels;


    public List<Vector3> GetPatrolPointsForLevel(int level)
    {
        List<Vector3> selected = new List<Vector3>();

        if (level < 0 || level >= patrolLevels.Length)
        {
            Debug.LogWarning("IA_Lvl fora do intervalo. Usando pontos do n�vel 0 como fallback.");
            level = 0;
        }

        int start = patrolLevels[level].startIndex;
        int end = patrolLevels[level].endIndex;

        for (int i = start; i < end && i < allPatrolPoints.Count; i++)
        {
            selected.Add(allPatrolPoints[i].position);
        }

        return selected;
    }

}
