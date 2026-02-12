using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class EatingAT : ActionTask {
		public BBParameter<Transform> truffleTransform;
		public BBParameter<float> hunger;
		public float eatRate;
		public float distToTruffle;
		private Transform headTransform;
		public AnimationCurve animCurve;
		public float rotationSpeed;
		protected override string OnInit() {
			headTransform = agent.transform.GetChild(1);
			return null;
		}
		protected override void OnExecute() {
		}

		protected override void OnUpdate() {
			if((truffleTransform.value.position - agent.transform.position).magnitude < distToTruffle)
			{
				hunger.value += eatRate * Time.deltaTime;
				headTransform.Rotate(headTransform.forward, Mathf.Sin(Time.time * rotationSpeed));
			}
		}

		protected override void OnStop() {
			headTransform.rotation = new Quaternion(0,0,0,0);
		}

		protected override void OnPause() {
			
		}
	}
}