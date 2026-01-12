using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class RotatingCT : ConditionTask {

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		SphereCollider ballerinaCollider;
		protected override string OnInit() {

			ballerinaCollider = GameObject.FindWithTag("Player").GetComponent<SphereCollider>();
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {

		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {

		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			//if (ballerinaCollider.)
				return true;
		}

		
	}
	
}