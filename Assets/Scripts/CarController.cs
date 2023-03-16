using UnityEngine;

public class CarController : MonoBehaviour
{
	[SerializeField] private Car _car;
	[SerializeField] private Pedal _gasPedal;
	[SerializeField] private Pedal _breakPedal;


	private void OnEnable()
	{
		_gasPedal.PedalPressed += OnGasPedalPressed;
		_gasPedal.PedalReleased += OnPedalReleased;
		_breakPedal.PedalPressed += OnBreakPedalPressed;
		_breakPedal.PedalReleased += OnPedalReleased;
	}

	private void OnDisable()
	{
		_gasPedal.PedalPressed -= OnGasPedalPressed;
		_gasPedal.PedalReleased -= OnPedalReleased;
		_breakPedal.PedalPressed -= OnBreakPedalPressed;
		_breakPedal.PedalReleased -= OnPedalReleased;
	}

	private void OnGasPedalPressed()
	{
		_car.SetMoveDirection(1.0f);
	}

	private void OnBreakPedalPressed()
	{
		_car.SetMoveDirection(-1.0f);
	}
    
	private void OnPedalReleased()
	{
		_car.SetMoveDirection(0.0f);
	}
}
