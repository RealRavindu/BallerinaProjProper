using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class NeedCheckCT : ConditionTask {

        public BBParameter<float> need;
		public float threshold;
        protected override string OnInit(){
			return null;
		}

		protected override void OnEnable() {
			
		}
		protected override void OnDisable() {
			
		}

		protected override bool OnCheck() {
			return need.value >= threshold;
			
		}
	}
}