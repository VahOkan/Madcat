using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyMoveBaseClass : MonoBehaviour
{
    public enum States { StartNewMove, RandomMove, MoveToPlayer, Stuck };
    public States state = new States();
    public Player player;
    public Vector3 targetPosition;
    public NavMeshAgent agent;
    public int defaultSpeed;
    public int attackSpeed;
    public float viewDistance;
    public float time;
    private const int checkStartSec = 0;
    private const int checkRepeatRate = 1;
    private const float stuckSpeed = 0.5f;
    private const float acceleration = 0.33f;
    private const float walkRadius = 5;
    private const int layermask = 6;

    void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, viewDistance);
    }

    private void OnEnable() {
        state = States.StartNewMove;
        InvokeRepeating(nameof(CheckIfStuck), checkStartSec, checkRepeatRate);
    }

    void Update() {
        CheckIfPlayerInDistance();
        CheckTheState();
    }

    void CheckIfStuck() {
        if (agent.velocity.magnitude <= stuckSpeed)
            state = States.Stuck;
    }

    public void CheckIfPlayerInDistance() {
        if (Vector3.Distance(transform.position, player.transform.position) < viewDistance)
            state = States.MoveToPlayer;
        else if (state == States.MoveToPlayer)
            state = States.StartNewMove;
    }

    public void CheckTheState() {
        switch (state) {
            case States.RandomMove:
                agent.destination = targetPosition;
                break;
            case States.MoveToPlayer:
                MoveToPlayer();
                break;
            default:
                SetRandomPosition();
                state = States.RandomMove;
                break;
        }
    }

    public void SetRandomPosition() {
        Vector3 randomPos = Random.insideUnitSphere * walkRadius + transform.position;
        NavMeshHit navHit;
        bool foundPosition = NavMesh.SamplePosition(randomPos, out navHit, walkRadius, NavMesh.AllAreas);
        if (!foundPosition)
            return;
        targetPosition = navHit.position;
        Debug.Log(targetPosition);
    }

    public void MoveToPlayer() {
        agent.destination = player.transform.position;
        agent.speed = Mathf.Lerp(defaultSpeed, attackSpeed, time);
        time += acceleration * Time.deltaTime;
    }
}
