using UnityEngine;
using UnityEngine.U2D;


public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private Transform _startObstacleTransform;
    [SerializeField] private Transform _finishObstacleTransform;
    
    [Header("Ground Settings")]
    [SerializeField] private SpriteShapeController _spriteShapeController;
    [SerializeField, Range(3, 100)] private int _length = 42;
    [SerializeField, Range(1.0f, 50.0f)] private float _xMultiplier = 2.0f;
    [SerializeField, Range(1.0f, 50.0f)] private float _yMultiplier = 2.0f;
    [SerializeField, Range(0.0f, 1.0f)] private float _curveSmoothness = 0.5f;
    [SerializeField, Min(0)] private float _height = 10.0f;

    private float _noiseStep;
    private Vector3 _lastPosition;

    private void Start()
    {
        GenerateGround();
        SpawnObstacles();
    }

    private void GenerateGround()
    {
        _spriteShapeController.spline.Clear();
        var position = transform.position;
        _noiseStep = Random.Range(0, 100) / 10.0f;

        for (var i = 0; i < _length; i++)
        {
            _lastPosition = position + new Vector3(i * _xMultiplier, Mathf.PerlinNoise(0.0f, i * _noiseStep) * _yMultiplier);
            _spriteShapeController.spline.InsertPointAt(i, _lastPosition);

            if (i == 0 || i == _length - 1) continue;
            
            _spriteShapeController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
            _spriteShapeController.spline.SetRightTangent(i, Vector3.right * _xMultiplier * _curveSmoothness); 
            _spriteShapeController.spline.SetLeftTangent(i, Vector3.left * _xMultiplier * _curveSmoothness);
        }
        
        var point = new Vector3(_lastPosition.x, position.y - _height);
        _spriteShapeController.spline.InsertPointAt(_length, point);
            
        point = new Vector3(position.x, position.y - _height);
        _spriteShapeController.spline.InsertPointAt(_length + 1, point);
    }
    
    private void SpawnObstacles()
    {
        var spline = _spriteShapeController.spline;
        var position = _spriteShapeController.transform.position;
        _startObstacleTransform.position = spline.GetPosition(0) + position;
        _finishObstacleTransform.position = spline.GetPosition(_length - 1) + position;
    }
}
