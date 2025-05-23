using System.Collections.Generic;
using UnityEngine;

public class StatePatrol : IState
{
    private StateMachine stateMachine;
    private EnemyAI enemy;
    private List<Vector3> patrolPoints;

    private Vector3 currentTarget;
    private float reachThreshold = 0.2f;

    private bool waiting = false;
    private float waitTimer = 0f;
    private float waitDuration = 3f;

    private int lastTargetIndex = -1; // �ndice do �ltimo ponto patrulhado, inicializado com -1

    public StatePatrol(StateMachine sm, EnemyAI enemyAI, List<Vector3> points)
    {
        stateMachine = sm;
        enemy = enemyAI;
        patrolPoints = points;
    }

    public void Enter()
    {
        PickNewTarget();
    }

    public void Update()
    {
        if (waiting)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= waitDuration)
            {
                waiting = false;
                waitTimer = 0f;
                PickNewTarget();
            }
            return;
        }

        if (enemy.currentPath == null || enemy.currentPath.Count == 0)
        {
            waiting = true;
            return;
        }

        if (enemy.seguindo)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null && Vector3.Distance(enemy.transform.position, player.transform.position) < 5f)
            {
                stateMachine.ChangeState(new StateChase(stateMachine, enemy, player.transform));
            }
        }
    }

    public void Exit()
    {
        enemy.SetPath(null);
    }

    private void PickNewTarget()
    {
        if (patrolPoints == null || patrolPoints.Count == 0)
        {
            Debug.LogWarning("PickNewTarget: Lista de pontos vazia ou nula.");
            return;
        }

        int newIndex = lastTargetIndex;

        // Enquanto o novo �ndice for igual ao anterior e houver mais de 1 ponto, tenta outro �ndice
        while (newIndex == lastTargetIndex && patrolPoints.Count > 1)
        {
            newIndex = Random.Range(0, patrolPoints.Count);
        }

        lastTargetIndex = newIndex;
        currentTarget = patrolPoints[newIndex];

        Debug.Log($"Novo destino de patrulha: {currentTarget} (�ndice {newIndex})");

        List<Node> path = enemy.pathfinder.FindPath(enemy.transform.position, currentTarget);
        enemy.SetPath(path);
    }
}
