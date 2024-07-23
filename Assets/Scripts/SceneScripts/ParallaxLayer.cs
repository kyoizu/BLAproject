using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    [SerializeField] private float horizontalParallaxFactor;
    [SerializeField] private float verticalParallaxFactor;

    public void Move(float delta, Vector3 deltaPlayerPosition)
    {
        Vector3 newPos = transform.localPosition;
        newPos.x -= delta * horizontalParallaxFactor;
        newPos.y -= deltaPlayerPosition.y * verticalParallaxFactor;

        transform.localPosition = newPos;
    }
}