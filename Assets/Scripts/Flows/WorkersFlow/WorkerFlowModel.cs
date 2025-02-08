using FSM;
using System;
using UnityEngine;

namespace WorkersFlow
{
    class WorkerFlowModel : FlowModel
    {
        //Target and Current Info:
        internal Transform Target;
        internal Transform ResourceDepot; //Transform needs to be the ResourceDepot's MonoBehaviour

        //Refs:
        internal GameObject WorkerGameObject;

        //Current Values:
        internal float CurrentHunger;
        internal float CurrentCarrying;

        //Base Stats:
        internal float MoveSpeed;
        internal float SearchRange;
        internal float SeekFoodHungerFraction;
        //internal float SwingRate; 
        internal float StoneGatherRate; //resource unit per swing
        internal float WoodGatherRate; //resource unit per swing
        internal float CarryCapacity;

        internal float StomacheSize;
        internal float HungerRate;

        internal Transform BaseStation; //Transform needs to be the Station's MonoBehaviour

        //Calculated Answers:
        internal bool DoSeekFood => CurrentHunger / StomacheSize < SeekFoodHungerFraction;
        internal Vector3 CurrentWorkerPosition => WorkerGameObject.transform.position;
    }
}
