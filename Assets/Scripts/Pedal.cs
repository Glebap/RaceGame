using System;
using UnityEngine;
using UnityEngine.EventSystems;


public class Pedal : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public event Action PedalPressed;
    public event Action PedalReleased;
    
    
    public void OnPointerDown(PointerEventData eventData)
    {
        OnPedalPressed();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnPedalReleased();
    }

    private void OnPedalPressed()
    {
        PedalPressed?.Invoke();
    }

    private void OnPedalReleased()
    {
        PedalReleased?.Invoke();
    }
}
