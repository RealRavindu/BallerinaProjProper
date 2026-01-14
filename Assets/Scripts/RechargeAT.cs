using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.UI;


namespace NodeCanvas.Tasks.Actions {

	public class RechargeAT : ActionTask {
		public Transform chargerTransform;
		public Image chargeBar;
		public BBParameter<float> currentCharge, maxCharge, speed, chargeDepreciationRate;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

			//charges 3 times faster than depreciates when at charger
				currentCharge.value -= chargeDepreciationRate.value * 3 * Time.deltaTime;

			//update UI charge bar
            chargeBar.fillAmount = currentCharge.value / maxCharge.value;

            //if charge is full end the function
            if (currentCharge.value>=maxCharge.value) EndAction();
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}