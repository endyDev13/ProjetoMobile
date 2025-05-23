using System.Collections.Generic;
using UnityEngine;

public class StateChase : IState
{
    private StateMachine stateMachine;

    private EnemyAI enemy;
    private Transform player;

    private float updatePathTimer = 0f;
    private float updatePathInterval = 0.5f;

    public StateChase(StateMachine sm, EnemyAI enemyAI, Transform playerTransform)
    {
        stateMachine = sm;
        enemy = enemyAI;
        player = playerTransform;
    }

    public void Enter()
    {
        RequestPathToPlayer();
        Debug.Log("Iniciando perseguição ao jogador: ");
    }

    public void Update()
    {
        updatePathTimer += Time.deltaTime;

        if (updatePathTimer >= updatePathInterval)
        {
            updatePathTimer = 0f;
            RequestPathToPlayer();
        }

        // Se perdeu o jogador ou bool seguindo desligou, volta pra patrulha
        if (Vector3.Distance(enemy.transform.position, player.position) > 8f || !enemy.seguindo)
        {
            Debug.Log("Jogador perdido ou bool desligada, voltando pra patrulha.");
            stateMachine.ChangeState(new StatePatrol(stateMachine, enemy, enemy.GetPatrolPoints()));


            return;
        }
    }


    public void Exit()
    {
        enemy.SetPath(null);
    }

    private void RequestPathToPlayer()
    {
        List<Node> path = enemy.pathfinder.FindPath(enemy.transform.position, player.position);
        enemy.SetPath(path);
    }
}
