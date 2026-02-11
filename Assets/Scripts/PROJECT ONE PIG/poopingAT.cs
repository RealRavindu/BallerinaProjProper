using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class poopingAT : ActionTask {
		private Blackboard blackboard;
		public BBParameter<float> poopness;

		protected override string OnInit() {
			blackboard = agent.GetComponent<Blackboard>();
			return null;
		}

		protected override void OnExecute() {
			if(poopness.value <=0)
			{
                GameObject spawnedTurd = GameObject.Instantiate(blackboard.GetVariableValue<GameObject>("turdPrefab"));
				spawnedTurd.transform.position =agent.transform.position;
				poopness.value = 100;
            }
			EndAction();
		}

		protected override void OnUpdate() {
			
		}

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}