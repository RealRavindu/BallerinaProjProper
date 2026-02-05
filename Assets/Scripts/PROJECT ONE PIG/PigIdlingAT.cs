using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class PigIdlingAT : ActionTask {

		public int chanceToDevour;
		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			int randomNum = Random.Range(0, 10);
			if(randomNum< chanceToDevour) EndAction(true);
		}

		protected override void OnUpdate() {
			
		}

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}