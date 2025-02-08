using FSM;
using UnityEngine;

namespace WorkersFlow
{
    class SetTargetState : State<WorkerFlowModel>
    {
        internal const string GoToEndStateKey = "GoToEndStateKey";

        public override void Enter()
        {
            //Check hunger?
            if (FlowModel.DoSeekFood)
            {
                Vector3 halfExtents_Food = new Vector3(1, 0, 1) * FlowModel.SearchRange;
                //Seek food
                Collider[] cols = Physics.OverlapBox(FlowModel.WorkerGameObject.transform.position, halfExtents_Food, Quaternion.identity, 128); //128 is temp, but it is just the 8th bit on 

                if (cols != null && cols.Length > 0)
                {
                    float _shortestDistance = float.PositiveInfinity;
                    Collider _closestFoodCollider = null; //Should be FoodComponent instead of Collider
                    foreach (var foodCollider in cols)
                    {
                        //Get FoodComponent
                        //Check food applicability
                        //if not applicable, continue. Otherwise:

                        float _distance = Vector3.Distance(foodCollider.transform.position, FlowModel.CurrentWorkerPosition);
                        if (_distance < _shortestDistance)
                        {
                            _shortestDistance = _distance;
                            _closestFoodCollider = foodCollider;
                        }
                    }

                    //Go to next state(???) to eat at _closestFoodCollider 
                    //return?
                }
                else
                {
                    //Go to No-food-found state
                    //return
                }
            }
            //Check resource state, just in case some resource gathering was interrupted?
            if(FlowModel.CurrentCarrying >= FlowModel.CarryCapacity/2f) //not sure about this
            {
                //Go to next state: Return to base station
                //return
            }

            //Find ResourceDepot
            Vector3 halfExtents_Resource = new Vector3(1, 0, 1) * FlowModel.SearchRange;
            Collider[] resourceDepots = Physics.OverlapBox(FlowModel.CurrentWorkerPosition, halfExtents_Resource, Quaternion.identity, 1024);//Temp to set the Resource layer 10th layer

            if (resourceDepots != null && resourceDepots.Length > 0)
            {
                float _shortestDistance = float.PositiveInfinity;
                Collider _closestResourceCollider = null; //Should be FoodComponent instead of Collider
                foreach (var resourceCollider in resourceDepots)
                {
                    //Get FoodComponent
                    //Check food applicability
                    //if not applicable, continue. Otherwise:

                    float _distance = Vector3.Distance(resourceCollider.transform.position, FlowModel.CurrentWorkerPosition);
                    if (_distance < _shortestDistance)
                    {
                        _shortestDistance = _distance;
                        _closestResourceCollider = resourceCollider;
                    }
                }
                //Go to next state, targeting the resource depot?
                //return?
            }


                if (FlowModel.Target == null)
                    GoToNextState(GoToEndStateKey);
                else
                    GoToNextState();
        }
        protected override void Exit()
        {
        }

        public override void Dispose()
        {
            FlowModel.Target = null;
        }
    }
}
