using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DifferentScenes
{
    public class DifferentSceneSample : MonoBehaviour
    {
        [SerializeField] private Button _loadUnloadSceneButton;
        [SerializeField] private Text _buttonText;
        [SerializeField] private string _sceneWithService;

        private bool _isLoaded;
        
        private void Awake()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.sceneUnloaded += OnSceneUnloaded;
            RefreshButton();
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode arg1)
        {
            if(scene.name!= _sceneWithService)
                return;

            _isLoaded = true;
            RefreshButton();
        }

        private void OnSceneUnloaded(Scene scene)
        {
            if(scene.name!= _sceneWithService)
                return;

            _isLoaded = false;
            RefreshButton();
        }

        private void RefreshButton()
        {
            if (_buttonText == null)
                return;
            
            _buttonText.text = _isLoaded ? "Unload service": "Load service";
            _loadUnloadSceneButton.onClick.AddListener(ToggleScene);
        }

        private void ToggleScene()
        {
            _loadUnloadSceneButton.onClick.RemoveAllListeners();

            if (!_isLoaded)
            {
                SceneManager.LoadSceneAsync(_sceneWithService, LoadSceneMode.Additive);
            }
            else
            {
                SceneManager.UnloadSceneAsync(_sceneWithService);
            }
        }
    }
}