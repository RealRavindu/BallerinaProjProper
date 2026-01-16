using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.InputSystem.Android;


namespace NodeCanvas.Tasks.Conditions {

	public class RechargeCT : ConditionTask {

		Blackboard agentBlackboard;
		public string varName;
		public BBParameter<float> threshold;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			agentBlackboard = agent.GetComponent<Blackboard>();
			threshold = agentBlackboard.GetVariableValue<float>(varName);
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
			if (agentBlackboard.GetVariableValue<float>("currentCharge") < threshold.value) return true;
			return false;
		}
	}
}