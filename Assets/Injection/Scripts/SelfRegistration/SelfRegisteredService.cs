using HGrandry.Injection;
using UnityEngine;

namespace SelfRegistration
{
    // We don't need to extends Injectable<T>, we can register our service explicitly when it's ready to be used.
    public class SelfRegisteredService : MonoBehaviour, IInjectable
    {
        private void Awake()
        {
            this.Require<AnotherService>(otherService =>
            {
                // initialize this component
                // ...
                
                // the gameObject will get enabled right after this callback, making it visible to other components
            });
        }

        private void OnEnable()
        {
            Debug.Log("I'm ready");
            
            // Make the service visible to other components
            this.Register();
            
            // Alternatively, we could register as an interface or base-class as well, as long as we implement it:
            // this.Register<IMyService>();
        }

        private void OnDisable()
        {
            Debug.Log("Bye bye");
            
            // Remove the service, invalidating potential dependencies referencing that service.
            this.Unregister();
        }
    }

    public class AnotherService : IInjectable
    {
    }
}