using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class LastKnownAT : ActionTask {
		public GameObject LKPSignifierTransformPrefab, spawnedSignifier;
		private Vector3 lastKnownPos;
		public float timeTillSignDisappears;
		private float time;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			time = 0;
			lastKnownPos = blackboard.GetVariableValue<Vector3>("lastKnownPos");
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			time += Time.deltaTime;
			if (time < timeTillSignDisappears && lastKnownPos != agent.transform.position && spawnedSignifier == null)
			{
				spawnedSignifier = GameObject.Instantiate(LKPSignifierTransformPrefab);
				spawnedSignifier.transform.position = lastKnownPos;
            } else
			{
				GameObject.Destroy(spawnedSignifier);
			}
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}