using System;
using HGrandry.Injection;
using UnityEngine;

namespace DifferentScenes
{
    public class DifferentsScenesComponent : MonoBehaviour
    {
        private void Awake()
        {
            Debug.Log("Waiting for the service from a different scene.");
            
            this.Require((DifferentScenesService service) =>
            {
                Debug.Log("The service is loaded.");

                return () => Debug.Log("The service is not available anymore.");
            });
        }
    }
}