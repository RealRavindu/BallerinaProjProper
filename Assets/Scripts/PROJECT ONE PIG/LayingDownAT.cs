using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    public class LayingDownAT : ActionTask
    {

        private Transform bodyTransform, headTransform;
        public float sleepyHeadPosY, sleepyBodyPosY;

        protected override string OnInit()
        {
            //get the 2 children that consists of the body and the head of the pig which are it's children.
            bodyTransform = agent.transform.GetChild(0);
            headTransform = agent.transform.GetChild(1);
            
            return null;
        }

        protected override void OnExecute()
        {
            //adding the vertical displacement specified in the inspector
            bodyTransform.position += Vector3.up * sleepyBodyPosY;
            headTransform.position += Vector3.up * sleepyHeadPosY;
        }

        //Called once per frame while the action is active.
        protected override void OnUpdate()
        {

        }

        //Called when the task is disabled.
        protected override void OnStop()
        {
            //subtracting the vertical displacement from each transform
            bodyTransform.position += Vector3.up * -sleepyBodyPosY;
            headTransform.position += Vector3.up * -sleepyHeadPosY;
        }

        //Called when the task is paused.
        protected override void OnPause()
        {

        }
    }
}