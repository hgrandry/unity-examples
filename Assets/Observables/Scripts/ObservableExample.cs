using HGrandry.Observables;
using UnityEngine;
using UnityEngine.UI;

public class ObservableExample : MonoBehaviour
{
    [SerializeField] private InputField _input;
    [SerializeField] private Text _text;
    private Observable<string> _model;

    void Awake()
    {
        _model = new Observable<string>(_input.text);
        _model.Subscribe(SetText);
        
        _input.onValueChanged.AddListener(_model.Set);        
    }

    private void OnDestroy()
    {
        _input.onValueChanged.RemoveListener(_model.Set);
        _model.Unsubscribe(SetText);
    }

    private void SetText(string value)
    {
        _text.text = value;
    }
}
