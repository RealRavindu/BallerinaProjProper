using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
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
				StartCoroutine(CamControl(spawnedTurd.transform));
            }
			EndAction();
		}

		protected override void OnUpdate() {
			
		}

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}

		private IEnumerator CamControl(Transform turdTransform)
		{
			Camera.main.transform.parent = turdTransform;
			Camera.main.transform.position = turdTransform.position +new Vector3(Random.Range(1,3), Random.Range(1, 3), Random.Range(1, 3));
			Camera.main.transform.LookAt(turdTransform.position);
			yield return new WaitForSeconds(3);
			Camera.main.transform.parent = null;
			Camera.main.transform.position = blackboard.GetVariableValue<Vector3>("originalCamPos");
            Camera.main.transform.rotation = Quaternion.Euler(blackboard.GetVariableValue<Vector3>("originalCamRotation"));
            yield return null;
		}
	}
}