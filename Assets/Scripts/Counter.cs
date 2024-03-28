using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private float _delay = 0.5f;
    private Coroutine _coroutine;
    private int _number = 0;    

    private void Start()
    {
        _text.text = "0";       
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(Countdown());
            }
            else
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }            
    }

    private IEnumerator Countdown()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);
        
        while (true)
        {
            yield return wait;
            _number = _number + 1;
            DisplayCountdown(_number);                     
        }
    }

    private void DisplayCountdown(int number)
    {
        _text.text = number.ToString("");
    }
}