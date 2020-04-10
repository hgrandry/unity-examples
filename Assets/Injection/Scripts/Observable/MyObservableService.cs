using System;
using HGrandry.Injection;

namespace Observable
{
    // A service with an event that can be attached to.
    public class MyObservableService : Injectable<MyObservableService>
    {
        public event Action EventFired;

        public void FireEvent()
        {
            EventFired?.Invoke();
        }
    }
}