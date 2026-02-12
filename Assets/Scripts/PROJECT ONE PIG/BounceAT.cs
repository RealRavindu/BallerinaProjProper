using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class BounceAT : ActionTask {
		public float frequency, amplitude;
		private Vector3 originalPosition;
		protected override string OnInit() {
			originalPosition = agent.transform.position;
			return null;
		}

		protected override void OnExecute() {
		}

		protected override void OnUpdate() {
				agent.transform.position = new Vector3(agent.transform.position.x, Mathf.Sin(Time.time * frequency) * amplitude + agent.transform.position.y, agent.transform.position.z);
		}

		protected override void OnStop() {
			agent.transform.position = originalPosition;
		}

		protected override void OnPause() {
			
		}
	}
}