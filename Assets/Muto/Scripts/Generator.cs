using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] GameObject[] _fishs = default;
    [SerializeField] GameObject _fishGroup = default;
    [SerializeField] Transform[] _pos = default;
    [SerializeField, Tooltip("XがMin　YがMax")] Vector2 _instanceInterval = Vector2.zero;

    float _timer;
    float _setTime;

    private void Start()
    {
        _setTime = _instanceInterval.x;
    }
    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _setTime)
        {
            Debug.Log(Mathf.Floor(_setTime));
            Generate();
        }
    }
    void　Generate()
    {
        var pos = new Vector2(this.transform.position.x, Random.Range(_pos[0].position.y, _pos[1].position.y));
        var fish = Instantiate(_fishs[Random.Range(0, _fishs.Length)], pos, Quaternion.identity);

        _timer = 0;
        _setTime = Random.Range(_instanceInterval.x, _instanceInterval.y);

        if (_fishGroup)
        {
            fish.transform.SetParent(_fishGroup.transform);
        }
    }
}
