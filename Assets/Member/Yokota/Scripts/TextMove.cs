using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMove : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text _titleText;

    private Vector3 _initialPosition = Vector3.zero;

    private float _timeLine = 0;

    private void Start()
    {
        _initialPosition = _titleText.rectTransform.position;
        _titleText = GetComponent<TMPro.TMP_Text>();
    }

    private void Update()
    {
        _timeLine += Time.deltaTime;
        _titleText.rectTransform.position 
            = new Vector3(_initialPosition.x, 
            _initialPosition.y + Mathf.Sin(_timeLine) / 2, 
            _initialPosition.z);
    }
}
