using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] GameObject[] _fishs = default;
    [SerializeField] int _rarityFish = 3;
    [SerializeField] GameObject _fishGroup = default;
    [SerializeField] Transform[] _pos = default;
    [SerializeField, Tooltip("XがMin　YがMax")] Vector2 _instanceInterval = Vector2.zero;
    [SerializeField] bool _flip;

    float _timer;
    float _setTime;
    int _charmNum;

    private void Start()
    {
        _setTime = _instanceInterval.x;
    }
    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _setTime)
        {
            Generate();
        }

        _charmNum = Item.IsCharm ? 0 : _rarityFish;//charmがtrueの時にNumを０にする
    }
    void　Generate()
    {
        var pos = new Vector2(this.transform.position.x, Random.Range(_pos[0].position.y, _pos[1].position.y));
        var fish = Instantiate(_fishs[Random.Range(0, _fishs.Length - _charmNum + 1)], pos, Quaternion.identity);//charmがfalseの時はRangeの最大を少なくする

        if(_flip)
        {
            fish.transform.Rotate(0, 180, 0);
        }

        _timer = 0;
        _setTime = Random.Range(_instanceInterval.x, _instanceInterval.y);

        if (_fishGroup)
        {
            fish.transform.SetParent(_fishGroup.transform);
        }
    }
}
