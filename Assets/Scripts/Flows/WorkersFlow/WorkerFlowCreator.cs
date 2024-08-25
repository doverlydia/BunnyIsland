using EasyButtons;
using UnityEngine;

namespace WorkersFlow
{
    public class WorkerFlowCreator : MonoBehaviour
    {
        [Button]
        public void CreateFlow()
        {
            var model = new WorkerFlowModel();
            var flow = new WorkerFlow(model);

            flow.CreateFlow();
        }
    }
}
