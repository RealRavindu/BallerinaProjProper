using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class IsDetectedCT : ConditionTask {
		protected override string OnInit(){
			return null;
		}

		protected override void OnEnable() {
			
		}

		protected override void OnDisable() {
			
		}
		protected override bool OnCheck() {
			if (blackboard.GetVariableValue<Transform>("targetTransform") != agent.transform)
			{
				return true;
			}
			return false;
		}
	}
}