using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class EatingAT : ActionTask {
		public BBParameter<Transform> truffleTransform;
		public BBParameter<float> hunger;
		public float eatRate;
		public float distToTruffle;
		protected override string OnInit() {
			return null;
		}
		protected override void OnExecute() {
		}

		protected override void OnUpdate() {
			if((truffleTransform.value.position - agent.transform.position).magnitude < distToTruffle)
			{
				hunger.value += eatRate * Time.deltaTime;
			}
		}

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}