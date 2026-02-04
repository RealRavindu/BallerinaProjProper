using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class SeekAT : ActionTask {
		
		private NavMeshAgent navAgent;
		public Transform targetTransform;
		public float seekFrequency;
		private float timeSinceLastSeek = 0;

		protected override string OnInit() {
			navAgent = agent.GetComponent<NavMeshAgent>();
			return null;
		}

		protected override void OnExecute() {
			targetTransform = agent.GetComponent<Blackboard>().GetVariableValue<Transform>("targetTransform");
			navAgent.SetDestination(targetTransform.position);
		}

		protected override void OnUpdate() {
			timeSinceLastSeek += Time.deltaTime;
			
			if (timeSinceLastSeek > seekFrequency)
			{
				navAgent.SetDestination(targetTransform.position);
				timeSinceLastSeek = 0;
			}
			if((agent.transform.position - targetTransform.position).magnitude < 0.5f)
			{
				EndAction();
			}
		}

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}