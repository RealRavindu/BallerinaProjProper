using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class PigIdlingAT : ActionTask {
		[SliderField(0,10)] public int chanceToDevour;
        public Material m_normal;
        private MeshRenderer[] renderers;
        protected override string OnInit() {
            renderers = agent.transform.GetComponentsInChildren<MeshRenderer>();
            return null;
		}

		protected override void OnExecute() {
			int randomNum = Random.Range(0, 10);
			if(randomNum< chanceToDevour) EndAction(true);

            foreach (MeshRenderer renderer in renderers)
            {
                renderer.material = m_normal;
            }
        }

		protected override void OnUpdate() {
			
		}

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}