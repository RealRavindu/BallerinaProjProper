using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class PigIdlingAT : ActionTask {
		[SliderField(0,10)] public int chanceToDevour;
        public Material m_normal;
        private MeshRenderer[] renderers;
		public float timeBetweenWanders, timePassed, wanderRadius, wanderCircleDistance;
		private NavMeshAgent navAgent;
        protected override string OnInit() {
            renderers = agent.transform.GetComponentsInChildren<MeshRenderer>();
			navAgent = agent.GetComponent<NavMeshAgent>();
            return null;
		}

		protected override void OnExecute() {
			int randomNum = Random.Range(0, 10);
			if(randomNum< chanceToDevour) EndAction(true);

            foreach (MeshRenderer renderer in renderers)
            {
                renderer.material = m_normal;
            }
			timePassed = 0;
			Wander();
        }

		protected override void OnUpdate() {
			timePassed += Time.deltaTime;
			if (timePassed > timeBetweenWanders)
			{
				Wander();
			}
		}

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}

		private void Wander()
		{
            Vector3 circleCenter = (agent.transform.forward * wanderCircleDistance) + agent.transform.position;
            Vector3 randomPoint = Random.insideUnitCircle.normalized * wanderRadius;
            Vector3 destination = circleCenter + new Vector3(randomPoint.x, agent.transform.position.y, randomPoint.z);

            NavMeshHit hit;
            if (NavMesh.SamplePosition(destination, out hit, 10f, NavMesh.AllAreas))
            {
                navAgent.SetDestination(hit.position);
            }
        }
	}
}