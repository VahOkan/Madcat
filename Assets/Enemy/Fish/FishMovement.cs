using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FishMovement : EnemyMoveBaseClass
{
    public override void Start()
    {
        player = Player.Instance;
        viewDistance = 8;
    }
    public override void MoveToPlayer()
    {
        agent.destination = player.transform.position;
        agent.speed = Mathf.Lerp(1, 4, time);
        time += 0.33f * Time.deltaTime;
    }
    public override void MoveAroundRandomly()
    {
        if (Vector3.Distance(transform.position, targetPosition) < 2 || targetPosition == null)
        {
            targetPosition = RandomPlaceInArea(transform.position, 10, 6);
            agent.speed = 2;
        }

        agent.destination = targetPosition;
    }
    public override Vector3 RandomPlaceInArea(Vector3 origin, float dist, int layermask)
    {
        Vector3 randomDirection = Random.insideUnitCircle * dist;
        randomDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, dist, layermask);
        return navHit.position;
    }
}
