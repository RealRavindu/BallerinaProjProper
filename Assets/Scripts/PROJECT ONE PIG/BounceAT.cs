using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{

    public class BounceAT : ActionTask
    {
        public float frequency, amplitude;
        private Vector3 originalPosition;
        public bool bounceInWaterOnly = false;
        private bool buoyancy = false;
        public LayerMask pondLayer;
        protected override string OnInit()
        {
            originalPosition = agent.transform.position;
            return null;
        }

        protected override void OnExecute()
        {
        }

        protected override void OnUpdate()
        {
            buoyancy = (Physics.Raycast(agent.transform.position, -agent.transform.up, 10, pondLayer));

            if (bounceInWaterOnly)
            {
                if (buoyancy) Bounce();

            }
            else
            {
                Bounce();
            }

        }

        protected override void OnStop()
        {
            agent.transform.position = originalPosition;
        }

        protected override void OnPause()
        {

        }

        private void Bounce()
        {
            agent.transform.position = new Vector3(agent.transform.position.x, Mathf.Sin(Time.time * frequency) * amplitude + agent.transform.position.y, agent.transform.position.z);
        }
    }
}