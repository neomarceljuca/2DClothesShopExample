using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FloatLoop : MonoBehaviour
{
    public float floatHeight = 1f;
    public float floatDuration = 1f;

    private void Start()
    {
        Vector3 initialPosition = transform.position;

        // Calculate the target position for floating up and down
        Vector3 targetPositionUp = initialPosition + Vector3.up * floatHeight;
        Vector3 targetPositionDown = initialPosition;

        // Create a sequence for the float animation
        Sequence floatSequence = DOTween.Sequence();
        floatSequence.Append(transform.DOMove(targetPositionUp, floatDuration).SetEase(Ease.InOutSine));
        floatSequence.Append(transform.DOMove(targetPositionDown, floatDuration).SetEase(Ease.InOutSine));
        floatSequence.SetLoops(-1); // Loop infinitely
    }

}
