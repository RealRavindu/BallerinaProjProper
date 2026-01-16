using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class ShrinkAT : ActionTask {

		public float shrinkRate;
		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			if(agent.transform.localScale.x > 9) agent.transform.localScale -= Vector3.one * shrinkRate * Time.deltaTime;

        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}