using System.Collections;
using TMPro;
using UnityEngine;

public class CounterEffector :  MonoBehaviour
{
    private const float SecondWathingValue = .5f;
   
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Color _defaultColor;

    private WaitForSeconds _waitEffect;
    private Coroutine _showing = null;

    private void OnEnable()
    {
        _waitEffect = new WaitForSeconds(SecondWathingValue);
    }

    public void ShowPositiveEffect()
    {
        _text.color = Color.green;

        if (_showing == null)
            _showing = StartCoroutine(Showing());
    }

    public void ShowNegativeEffect()
    {
        _text.color = Color.red;

        if (_showing == null)
            _showing = StartCoroutine(Showing());
    }

    private IEnumerator Showing()
    {
        yield return _waitEffect;

        _text.color = _defaultColor;
        _showing = null;
    }
}
