using HGrandry.Injection;
using UnityEngine;


namespace RegisterAs
{
    // A service can register itself as an interface or baseclass
    public class MyService : Injectable<IService>, IService
    {
        void IService.DoStuff()
        {
            Debug.Log("MyService DoStuff");
        }
    }
    
    // A different implementation of the interface can be provided depending on the scenario
    public class MyServiceMock : Injectable<IService>, IService
    {
        void IService.DoStuff()
        {
            Debug.Log("MyMock is just pretending to DoStuff");
        }
    }
    
    // The interface must be flagged as Injectable
    public interface IService: IInjectable
    {
        void DoStuff();
    }
}