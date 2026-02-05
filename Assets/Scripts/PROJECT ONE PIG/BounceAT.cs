using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class BounceAT : ActionTask {
		public float frequency, amplitude, angle;
		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
		}

		protected override void OnUpdate() {
				agent.transform.position = new Vector2(agent.transform.position.x, Mathf.Sin(agent.transform.position.y * frequency - (angle*Time.deltaTime)) * amplitude);
		}

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}