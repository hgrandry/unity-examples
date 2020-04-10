using HGrandry.Injection;
using UnityEngine;

namespace Observable
{
    public class MyObserverComponent : MonoBehaviour
    {
        [SerializeField] private bool _hasResolvedOnce; 
        
        private void Awake()
        {
            void MyCallback()
            {
                Debug.Log("An event was fired.");
            }
            
            this.Require((MyObservableService service) =>
            {
                Debug.Log("Observing event.");

                if (!_hasResolvedOnce)
                {
                    Debug.Log("Try disabling/enabling the service.");
                    _hasResolvedOnce = true;
                }
                
                service.EventFired += MyCallback;
                
                // Since we attached to an event, we need to detach to get garbage collected.
                
                // The Require method can return a cleanup method that is called when the consumer component is destroyed
                // or when one of its dependencies get invalidated. 
                return () =>
                {
                    Debug.Log("Detaching from event.");
                    service.EventFired -= MyCallback;
                };
            });
        }
    }
}