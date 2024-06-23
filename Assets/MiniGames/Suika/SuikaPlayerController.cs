using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuikaPlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Transform _leftPoint;  // Sol kenar için GameObject
    [SerializeField] private Transform _rightPoint; // Sað kenar için GameObject
    [SerializeField] private Transform _fruitThrowTransform;

    private float _leftBound;
    private float _rightBound;

    private bool _movingRight = true; // Baþlangýç yönü

    // Unity Message | 0 references
    private void Awake()
    {
        // Sýnýrlarý doðrudan Transform nesnelerinden al
        _leftBound = _leftPoint.position.x;
        _rightBound = _rightPoint.position.x;
    }

    // Unity Message | 0 references
    private void Update()
    {
        // Eðer sað sýnýrý geçtiyse veya sol sýnýrýn altýna düþtüyse yön deðiþtir
        if (_movingRight && transform.position.x >= _rightBound)
        {
            _movingRight = false;
        }
        else if (!_movingRight && transform.position.x <= _leftBound)
        {
            _movingRight = true;
        }

        // Yön bilgisine göre yeni pozisyonu hesapla
        float direction = _movingRight ? 1 : -1;
        Vector3 moveDelta = new Vector3(direction * _moveSpeed * Time.deltaTime, 0, 0);
        transform.position += moveDelta;
    }
/*
    public void ChangeBoundary(float extraWidth)
    {
        // Sýnýrlarý geniþletmek veya daraltmak için mevcut noktalarýn x pozisyonlarýný güncelle
        _leftPoint.position = new Vector3(
            _leftPoint.position.x - SuikaThrowFruitController.instance.Bounds.extents.x - extraWidth,
            _leftPoint.position.y,
            _leftPoint.position.z
        );

        _rightPoint.position = new Vector3(
            _rightPoint.position.x + SuikaThrowFruitController.instance.Bounds.extents.x + extraWidth,
            _rightPoint.position.y,
            _rightPoint.position.z
        );

        // Sýnýrlarý yeni transform pozisyonlarýndan güncelle
        _leftBound = _leftPoint.position.x;
        _rightBound = _rightPoint.position.x;
    }

    */
}
