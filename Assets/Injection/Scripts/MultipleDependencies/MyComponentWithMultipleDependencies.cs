using DifferentScenes;
using HGrandry.Injection;
using UnityEngine;

namespace MultipleDependencies
{
    public class MyComponentWithMultipleDependencies : MonoBehaviour
    {
        private void Awake()
        {
            Debug.Log("Waiting for all the services to become available.");
            
            // A component can depends on up to 15 services, and will be callback/enabled when all dependencies are resolved.
            this.Require((ServiceA a, ServiceB b, DifferentScenesService c) =>
            {
                Debug.Log("All services are ready.");

                return () => Debug.Log("Oops, a service is missing.");
            });
        }
    }

}