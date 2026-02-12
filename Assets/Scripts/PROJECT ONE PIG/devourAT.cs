using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.Universal;

namespace NodeCanvas.Tasks.Actions {

	public class devourAT : ActionTask {
		public Material m_angry;
		private MeshRenderer[] renderers;
		private float timeTillScan, timePassed;
		private NavMeshAgent navAgent;
		public BBParameter<Transform> humanTransform;

		protected override string OnInit() {
			renderers = agent.transform.GetComponentsInChildren<MeshRenderer>();
			navAgent = agent.GetComponent<NavMeshAgent>();
			return null;
		}

		protected override void OnExecute() {
			foreach (MeshRenderer renderer in renderers)
			{
				renderer.material = m_angry;
			}
			timePassed = 0;
            navAgent.SetDestination(humanTransform.value.position);
			
			Camera.main.transform.parent = null;
			Camera.main.transform.position = blackboard.GetVariableValue<Vector3>("originalCamPos");
            Camera.main.transform.rotation = Quaternion.Euler(blackboard.GetVariableValue<Vector3>("originalCamRotation"));
        }

		protected override void OnUpdate() {
			timePassed += Time.deltaTime;
			if (timePassed > timeTillScan)
			{
				navAgent.SetDestination(humanTransform.value.position);
				timePassed = 0;
			}
		}

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}