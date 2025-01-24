using FSM;
using System;
using UnityEngine;

namespace WorkersFlow
{
    class WorkerFlowModel : FlowModel
    {
        //Target and Current Info:
        internal Transform Target;
        //internal float CurrentCarryWeight;

        internal float CurrentHunger;

        //Base Stats:
        internal float MoveSpeed;
        internal float SearchRange;
        //internal float SwingRate; 
        internal float StoneGatherRate; //resource unit per swing
        internal float WoodGatherRate; //resource unit per swing
        internal float CarryCapacity;

        internal float StomacheSize;
        internal float HungerRate;

        internal Transform BaseStation; //Transform needs to be the Station's MonoBehaviour
    }
}
