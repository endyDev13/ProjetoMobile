using System.Collections.Generic;
using UnityEngine;

public class StatePatrol : IState
{
    private StateMachine stateMachine;
    private EnemyAI enemy;
    private List<Vector3> patrolPoints;

    private Vector3 currentTarget;
    private float reachThreshold = 0.2f;

    private bool isMoving = false;

    private bool waiting = false;
    private float waitTimer = 0f;
    private float waitDuration = 3f; // tempo parado em segundos


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
            // Espera antes de ir para o próximo ponto
            waiting = true;
            return;
        }

        // Verifica perseguição
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
        int index = Random.Range(0, patrolPoints.Count);
        currentTarget = patrolPoints[index];
        Debug.Log("Novo destino de patrulha: " + currentTarget);
        List<Node> path = enemy.pathfinder.FindPath(enemy.transform.position, currentTarget);
        enemy.SetPath(path);
    }
}
