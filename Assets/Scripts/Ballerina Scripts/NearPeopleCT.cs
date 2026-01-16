using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class NearPeopleCT : ConditionTask {

		protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		protected override bool OnCheck() {
			Collider[] colliders = Physics.OverlapSphere(agent.transform.position, 3);
			foreach (Collider collider in colliders)
			{
				if (collider.gameObject.tag == "People") return true;
			}
			return false;
		}
	}
}