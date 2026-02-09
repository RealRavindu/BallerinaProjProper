using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class BathingAT : ActionTask {
        public BBParameter<Transform> pondTransform;
        public BBParameter<float> heat;
        public float batheRate;
        public float distToPond;
        protected override string OnInit()
        {
            return null;
        }
        protected override void OnExecute()
        {
        }

        protected override void OnUpdate()
        {
            if ((pondTransform.value.position - agent.transform.position).magnitude < distToPond)
            {
                heat.value += batheRate * Time.deltaTime;
            }
        }

        protected override void OnStop()
        {

        }

        protected override void OnPause()
        {

        }
    }
}