using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class LOSAT : ActionTask {

		public BBParameter<float> LOSAngle;
		public BBParameter<float> LOSDist;
        public BBParameter<float> LOSRez;
        private Blackboard blackboard;

		protected override string OnInit() {
			blackboard = agent.GetComponent<Blackboard>();
			LOSAngle = blackboard.GetVariableValue<float>("LOSAngle");
			LOSDist = blackboard.GetVariableValue<float>("LOSDist");
            LOSRez = blackboard.GetVariableValue<float>("LOSRez");
            return null;
		}

		
		protected override void OnExecute() {

		}

		
		protected override void OnUpdate() {
			for (int i = 0; i < LOSRez.value; i++)
			{
				float minAngle = -LOSAngle.value;
				Vector2 direction = new Vector2(Mathf.Cos(LOSAngle.value), Mathf.Sin(LOSAngle.value));
				
			}
		}

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}