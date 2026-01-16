using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class OnStageCT : ConditionTask {

		public Transform stage;
		protected override string OnInit(){
			return null;
		}

		protected override void OnEnable() {
			
		}

		protected override void OnDisable() {
			
		}

		protected override bool OnCheck() {
			if (agent.transform.position.x > stage.position.x - stage.localScale.x / 2 && 
				agent.transform.position.x < stage.position.x + stage.localScale.x / 2) 
				return true;
                return false;
		}
	}
}