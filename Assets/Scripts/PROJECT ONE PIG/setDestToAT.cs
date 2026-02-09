using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class setDestToAT : ActionTask {

		public BBParameter<Transform> destination;
		private NavMeshAgent navAgent;
		protected override string OnInit() {
			navAgent = agent.GetComponent<NavMeshAgent>();
			return null;
		}
		protected override void OnExecute() {
			navAgent.SetDestination(destination.value.position);
		}
		protected override void OnUpdate() {
			
		}
		protected override void OnStop() {
			
		}
		protected override void OnPause() {
			
		}
	}
}