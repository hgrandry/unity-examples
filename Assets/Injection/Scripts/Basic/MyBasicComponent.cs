using HGrandry.Injection;
using UnityEngine;

namespace Basic
{
    public class MyBasicComponent : MonoBehaviour
    {
        void Start()
        {
            // Require the service before continuing.
            // We don't need to know where the service is located (which scene, which game object)
            // or is the service is already loaded and initialized: we'll get a callback when the service is ready.
            this.Require((MyBasicService service) =>
            {
                Debug.Log("Doing stuff with the service.");
                service.DoStuff();
            });
        }
    }
}
