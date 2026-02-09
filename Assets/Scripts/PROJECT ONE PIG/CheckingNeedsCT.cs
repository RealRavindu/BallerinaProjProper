using NodeCanvas.Framework;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization.FullSerializer;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{

    public class CheckingNeedsCT : ConditionTask
    {

        public BBParameter<float> hunger;
        public BBParameter<float> heat;
        public BBParameter<float> tiredness;
        public BBParameter<float> poopness;
        public float hungerThreshold;
        public float heatThreshold;
        public float tirednessThreshold;
        public float poopnessThreshold;

        protected override string OnInit()
        {
            return null;
        }

        protected override void OnEnable()
        {
        }

        protected override void OnDisable()
        {

        }

        protected override bool OnCheck()
        {
            if (hunger.value < hungerThreshold) return true;
            else if (heat.value < heatThreshold) return true;
            else if (tiredness.value < tirednessThreshold) return true;
            else if (poopness.value < poopnessThreshold) return true;
            return false;

        }
    }
}