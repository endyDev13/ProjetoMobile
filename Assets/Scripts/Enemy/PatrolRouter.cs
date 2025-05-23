using System.Collections.Generic;
using UnityEngine;

public class PatrolRoute : MonoBehaviour
{
    [Tooltip("Arraste aqui os pontos de patrulha (GameObjects vazios)")]
    public List<Transform> patrolPoints = new List<Transform>();

    public List<Vector3> GetWorldPositions()
    {
        List<Vector3> positions = new List<Vector3>();
        foreach (var point in patrolPoints)
        {
            Vector3 pos = point.position;
            pos.z = 0f; // Força plano 2D
            positions.Add(pos);
        }
        return positions;
    }
}
