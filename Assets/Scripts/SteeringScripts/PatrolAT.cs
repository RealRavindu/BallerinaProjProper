using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.AI;
using UnityEngine;
using System.Collections.Generic;

namespace NodeCanvas.Tasks.Actions {

	public class PatrolAT : ActionTask {

		private NavMeshAgent navAgent;
		public List<Transform> patrolPoints;
		private int currentPatrolPointIndex = 0;
		protected override string OnInit() {
			navAgent = agent.GetComponent<NavMeshAgent>();
			return null;
		}

		protected override void OnExecute() {
			navAgent.SetDestination(patrolPoints[currentPatrolPointIndex].position);
		}

		protected override void OnUpdate() {
			if(navAgent.remainingDistance < 0.25f && !navAgent.pathPending)
			{
				navAgent.SetDestination(patrolPoints[currentPatrolPointIndex].position);
				currentPatrolPointIndex %= patrolPoints.Count;
            }
		}

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}