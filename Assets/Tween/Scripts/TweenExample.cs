using HGrandry.Tweens;
using UnityEngine;

public class TweenExample : MonoBehaviour
{
    void Start()
    {
        transform.TweenPosition(transform.position + new Vector3(500, 0, 0), 1)
            .SetEase(Ease.CubicInOut)
            .OnComplete(() => Debug.Log("Tween completed!"));
    }

}
