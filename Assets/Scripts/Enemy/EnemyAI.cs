using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyAI : MonoBehaviour
{
    [Header("Referências")]
    public Pathfinder pathfinder;
    public PatrolRoute patrolRoute;

    [Header("Movimento")]
    public float moveSpeed = 3f;

    [Header("Controle de perseguição")]
    public bool seguindo = false;

    // FSM e controle de estado
    private StateMachine stateMachine;
    private List<Vector3> patrolPoints;


    // Caminho atual
    public List<Node> currentPath;
    private int targetNodeIndex;
    private Vector3 currentTargetPosition;


    public List<Vector3> GetPatrolPoints()
    {
        return patrolPoints;
    }
    private void Awake()
    {
        stateMachine = new StateMachine(this);

        patrolPoints = patrolRoute.GetWorldPositions(); 

        // Verifica se o PatrolRoute está atribuído
        if (patrolRoute == null)
        {
            Debug.LogError("EnemyAI: 'patrolRoute' não foi atribuído no Inspector.");
            return;
        }

        
        if (patrolPoints == null || patrolPoints.Count == 0)
        {
            Debug.LogError("EnemyAI: Nenhum ponto de patrulha encontrado no PatrolRoute.");
            return;
        }

        stateMachine.ChangeState(new StatePatrol(stateMachine, this, patrolPoints));
    }

    private void Update()
    {
        stateMachine.Update();
        MoveAlongPath();
    }

    public void SetPath(List<Node> path)
    {
        currentPath = path;
        targetNodeIndex = 0;

        if (currentPath != null && currentPath.Count > 0)
        {
            currentTargetPosition = GridManager.Instance.groundTilemap
                .CellToWorld((Vector3Int)currentPath[0].gridPosition) + new Vector3(0.5f, 0.5f, 0);
        }
    }

    public void MoveAlongPath()
    {
        if (currentPath == null || currentPath.Count == 0)
            return;

        Vector3 pos = transform.position;
        Vector3 direction = (currentTargetPosition - pos).normalized;

        transform.position += direction * moveSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, currentTargetPosition) < 0.1f)
        {
            targetNodeIndex++;
            if (targetNodeIndex >= currentPath.Count)
            {
                currentPath = null;
            }
            else
            {
                currentTargetPosition = GridManager.Instance.groundTilemap
                    .CellToWorld((Vector3Int)currentPath[targetNodeIndex].gridPosition) + new Vector3(0.5f, 0.5f, 0);
            }
        }
    }
}
