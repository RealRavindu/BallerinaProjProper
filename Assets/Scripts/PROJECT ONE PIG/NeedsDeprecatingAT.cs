using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class NeedsDeprecatingAT : ActionTask {

		public BBParameter<float> hunger;
		public float hungerRate;
		public BBParameter<float> heat;
        public float heatRate;
        public BBParameter<float> tiredness;
        public float tirednessRate;
        public BBParameter<float> poopness;
        public float poopnessRate;
        protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
		}

		
		protected override void OnUpdate() {
			hunger.value -= hungerRate*Time.deltaTime;
			heat.value -= heatRate * Time.deltaTime; ;
			tiredness.value -= tirednessRate * Time.deltaTime; ;
			poopness.value -= poopnessRate * Time.deltaTime; ;
		}

		
		protected override void OnStop() {
			
		}

		
		protected override void OnPause() {
			
		}
	}
}