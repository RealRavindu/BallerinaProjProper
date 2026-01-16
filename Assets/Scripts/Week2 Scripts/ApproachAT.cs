using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions {

	public class ApproachAT : ActionTask {
		public Transform targetTransform;
		public BBParameter<float> speed;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            speed = agent.GetComponent<Blackboard>().GetVariableValue<float>("speed");
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			Vector3 directionToMove = targetTransform.position - agent.transform.position;
			agent.transform.position += directionToMove.normalized * speed.value * Time.deltaTime;

			float distToTarg = directionToMove.magnitude;
			if (distToTarg < 0.5f) EndAction();
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}