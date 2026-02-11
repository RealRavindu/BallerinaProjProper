using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class RestingAT : ActionTask {

		public BBParameter<float> tiredness;
		public float restRate;
		public BBParameter<Transform> pondTransform;
        public float distFromPond;
		private NavMeshAgent navAgent;
        protected override string OnInit() {
			navAgent = agent.GetComponent<NavMeshAgent>();
			return null;
		}

		protected override void OnExecute() {

            Vector3 displacement = (agent.transform.position - pondTransform.value.position);
            if (displacement.magnitude < distFromPond)
            {

				float distanceToMove = (distFromPond - displacement.magnitude);

                Vector3 directionToMove = displacement.normalized * distanceToMove;

                Vector3 targetPoint = directionToMove + agent.transform.position;
                navAgent.SetDestination(targetPoint);
            }
        }

		protected override void OnUpdate() {

			if((agent.transform.position - pondTransform.value.position).magnitude > distFromPond)
			{
				tiredness.value += restRate;
			}

		}
		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}