using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class PerformingAT : ActionTask {

		public AudioSource Jukebox;
		public Transform MainCam, TheaterCamPos;
		private Vector3 originalCamPos;
		public float rotateRate, growRate, timeToMoveCam;
		private float t;
        protected override string OnInit() {
			return null;
		}

		protected override void OnExecute()
        {
            originalCamPos = MainCam.transform.position;
            t = 0;
			Jukebox.volume = 0.7f;
		}

		protected override void OnUpdate() {
			//rotate and grow ballerina
            agent.transform.Rotate(new Vector3(0, rotateRate * Time.deltaTime, 0));
            if (agent.transform.localScale.x < 38) agent.transform.localScale += Vector3.one * growRate * Time.deltaTime;

			//move camera
			t += Time.deltaTime;
			MainCam.position = Vector3.Lerp(originalCamPos, TheaterCamPos.position, t/timeToMoveCam);
        }

		//Called when the task is disabled.
		protected override void OnStop() {
            Jukebox.volume = 0.3f;
			MainCam.position =originalCamPos;
        }

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}