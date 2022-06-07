using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private float _length;
    private float _startPosition;
    private GameObject _camera;

    [SerializeField] private float _parallaxEffect;

    void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("Camera");
        _startPosition = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float temp = (_camera.transform.position.x * (1 - _parallaxEffect));
        float distance = (_camera.transform.position.x * _parallaxEffect);
        transform.position = new Vector3(_startPosition + distance, transform.position.y, transform.position.z);

        if (temp > _startPosition + _length)
        {
            _startPosition += _length;
        }
        else if (temp < _startPosition - _length)
        {
            _startPosition -= _length;
        }
    }
}
