using Player;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy.Base
{
    public abstract class BaseEnemyMoveController : MonoBehaviour
    {
        public enum States { StartNewMove, RandomMove, MoveToPlayer, Stuck };
        public States state = new States();
        public Player.Player player;
        public Vector3 targetPosition;
        public NavMeshAgent agent;
        public int defaultSpeed;
        public int attackSpeed;
        public float viewDistance;
        public float time;
        
        private void OnEnable() 
        {
            state = States.StartNewMove;
            InvokeRepeating(nameof(CheckIfStuck), Consts.CheckStartSec, Consts.CheckRepeatRate);
        }
        void OnDrawGizmos() 
        {
            var actualObjectPosition = transform.position;
            Gizmos.DrawWireSphere(actualObjectPosition, viewDistance);
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(actualObjectPosition, Consts.WalkRadius);
        }
        private void Update() 
        {
            CheckIfPlayerInDistance();
            CheckTheState();
        }
        private void CheckIfStuck() 
        {
            if (agent.velocity.magnitude <= Consts.StuckSpeed)
                state = States.Stuck;
        }
        private void CheckIfPlayerInDistance() 
        {
            if (Vector3.Distance(transform.position, player.transform.position) < viewDistance)
                state = States.MoveToPlayer;
            else if (state == States.MoveToPlayer)
                state = States.StartNewMove;
        }
        private void CheckTheState() 
        {
            switch (state) {
                case States.RandomMove:
                    agent.destination = targetPosition;
                    break;
                case States.MoveToPlayer:
                    MoveToPlayer();
                    break;
                case States.StartNewMove or States.Stuck:
                    SetRandomPosition();
                    state = States.RandomMove;
                    break;
            }
        }
        private void SetRandomPosition() 
        {
            Vector3 randomPos = Random.insideUnitSphere * Consts.WalkRadius + transform.position;
            bool foundPosition = NavMesh.SamplePosition(randomPos, out NavMeshHit navHit, Consts.WalkRadius, NavMesh.AllAreas);
            if (!foundPosition)
                return;
            targetPosition = navHit.position;
        }
        private void MoveToPlayer() {
            agent.destination = player.transform.position;
            agent.speed = Mathf.Lerp(defaultSpeed, attackSpeed, time);
            time += Consts.Acceleration * Time.deltaTime;
        }
    }
}
