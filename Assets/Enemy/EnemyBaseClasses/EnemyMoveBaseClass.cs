using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyMoveBaseClass : MonoBehaviour
{
    public enum States { RandomMove, MoveToPlayer, Stuck };
    public States state = new States();
    public Player player;
    public Vector3 targetPosition;
    public NavMeshAgent agent;
    public float viewDistance;
    public float time;

    float repeatRate = 5;

    private void OnEnable()
    {
        InvokeRepeating(nameof(IsStuck), 0, 1);
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, viewDistance);
    }
    void Update()
    {
        CheckIfPlayerInDistance();

        switch (state)
        {
            case States.RandomMove:
                MoveAroundRandomly();
                break;
            case States.MoveToPlayer:
                MoveToPlayer();
                break;
            case States.Stuck:
                state = States.RandomMove;
                break;
        }
    }
    void IsStuck()
    {
        if (agent.speed <= 0.5f)
            state = States.Stuck;
    }
    public abstract void Start(); //insert values in viewDistance
    public abstract void MoveToPlayer();
    public abstract void MoveAroundRandomly();
    public void CheckIfPlayerInDistance()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < viewDistance)
            state = States.MoveToPlayer;
        else
            state = States.RandomMove;
    }
    public abstract Vector3 RandomPlaceInArea(Vector3 origin, float dist, int layermask);
}
