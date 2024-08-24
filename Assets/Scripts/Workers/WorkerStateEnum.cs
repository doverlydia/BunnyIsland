
namespace Workers
{
    public enum WorkerStateEnum 
    {
        None, 
        Searching, //Resource or Food 
        Walking, //Station, Resource, Food
        Gathering, //Resourced, Food
        Sleeping //Idle, Starving
    }
}
