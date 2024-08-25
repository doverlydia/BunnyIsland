using EasyButtons;
using UnityEngine;

namespace WorkersFlow
{
    public class WorkerFlowCreator : MonoBehaviour
    {
        WorkerFlowModel Model;
        WorkerFlow Flow;

        [Button]
        void CreateFlowModel()
        {
            Model = new();
        }

        [Button]
        void CreateFlow()
        {
            Flow = new WorkerFlow(Model);

            Flow.Create();
        }

        [Button]
        void SetTarget()
        {
            Model.Target = transform;
        }

        [Button]
        void RemoveTarget()
        {
            Model.Target = null;
        }

        [Button]
        void CancelFlow()
        {
            Flow.Dispose();
        }
    }
}
