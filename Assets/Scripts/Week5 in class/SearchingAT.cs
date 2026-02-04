using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class SearchingAT : ActionTask {

		public LayerMask detectionLayerMask;
		public float detectionRadius;
		public BBParameter<Transform> targetTransform;
        public BBParameter<Vector3> LKPTransform;
		private bool foundTarget;
        protected override string OnInit() {
			return null;
		}
		protected override void OnExecute() {
		}

		protected override void OnUpdate() {
			Collider[] detectedColliders = Physics.OverlapSphere(agent.transform.position, detectionRadius, detectionLayerMask);
			if (detectedColliders.Length > 0)
			{
				targetTransform.value = detectedColliders[0].transform;
				LKPTransform.value = agent.transform.position;
				foundTarget = true;
			} else
            {
				if (foundTarget)
                {
					Vector3 transformPos = targetTransform.value.position;
                    LKPTransform.value = transformPos;
                    foundTarget = false;

                }
                targetTransform.value = agent.transform;
			}

		}

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}