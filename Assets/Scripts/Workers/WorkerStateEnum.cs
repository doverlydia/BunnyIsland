
namespace Workers
{
    public enum WorkerStateEnum 
    {
        None,
        SetObjectiveState, //Resource or Food 
        Walking, //Station, Resource, Food
        Gathering, //Resourced, Food
        Sleeping //Idle, Starving
    }
}
