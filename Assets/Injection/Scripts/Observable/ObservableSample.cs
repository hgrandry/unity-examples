using HGrandry.Injection;
using UnityEngine;
using UnityEngine.UI;

namespace Observable
{
    public class ObservableSample : MonoBehaviour
    {
        [SerializeField] private Button _fireEventButton;
        
        private void Awake()
        {
            this.Require((MyObservableService service) =>
            {
                _fireEventButton.onClick.AddListener(service.FireEvent);

                return () => _fireEventButton.onClick.RemoveListener(service.FireEvent);
            });
        }
    }
}