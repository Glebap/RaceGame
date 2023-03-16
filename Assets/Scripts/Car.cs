using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _frontTireRigidbody;
    [SerializeField] private Rigidbody2D _backTireRigidbody;
    [SerializeField] private Rigidbody2D _carRigidbody;
    [SerializeField, Min(0)] private float _speed;
    [SerializeField, Min(0)] private float _rotationSpeed;

    private float _moveDirection;

    public void SetMoveDirection(float moveDirection)
    {
        _moveDirection = moveDirection;
    }

    private void FixedUpdate()
    {
        _frontTireRigidbody.AddTorque(-_moveDirection * _speed * Time.deltaTime);
        _backTireRigidbody.AddTorque(-_moveDirection * _speed * Time.deltaTime);
        _carRigidbody.AddTorque(_moveDirection * _rotationSpeed * Time.deltaTime);
    }
}
