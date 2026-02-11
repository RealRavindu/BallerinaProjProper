using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.AI;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class WanderAT : ActionTask {

		private NavMeshAgent navAgent;
		public float wanderRadius, wanderCircleDistance;
		protected override string OnInit() {
			navAgent = agent.GetComponent<NavMeshAgent>();
			return null;
		}

		protected override void OnExecute() {
            Wander();
		}


		protected override void OnUpdate() {
            if (navAgent.remainingDistance < 0.25f && !navAgent.pathPending) Wander();
		}


		protected override void OnStop() {
			
		}


		protected override void OnPause() {
			
		}

        private void VisualizeWander(Vector3 currentCircleCenter, Vector3 currentDestination, float pathUpdateFrequency)
        {
            Debug.DrawLine(agent.transform.position, currentCircleCenter, Color.red, pathUpdateFrequency);
            for (int i = 0; i < 360; i += 12)
            {
                Vector3 p1 = new Vector3(Mathf.Cos(i * Mathf.Deg2Rad), 0f, Mathf.Sin(i * Mathf.Deg2Rad)) * wanderRadius;
                Vector3 p2 = new Vector3(Mathf.Cos((i + 12) * Mathf.Deg2Rad), 0f, Mathf.Sin((i + 12) * Mathf.Deg2Rad)) * wanderRadius;

                Debug.DrawLine(currentCircleCenter + p1, currentCircleCenter + p2, Color.cyan, pathUpdateFrequency);
            }

            Debug.DrawLine(agent.transform.position, currentDestination, Color.magenta, pathUpdateFrequency);
        }

		private void Wander()
		{
            Vector3 circleCenter = (agent.transform.forward * wanderCircleDistance) + agent.transform.position;
            Vector3 randomPoint = Random.insideUnitCircle.normalized * wanderRadius;
            Vector3 destination = circleCenter + new Vector3(randomPoint.x, agent.transform.position.y, randomPoint.z);

            VisualizeWander(circleCenter, destination, 5);

            NavMeshHit hit;
            if (NavMesh.SamplePosition(destination, out hit, 10f, NavMesh.AllAreas))
            {
                navAgent.SetDestination(hit.position);
            }
        }
    }
}