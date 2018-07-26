using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingMover : MonoBehaviour {
    [SerializeField]
    Transform centerPoint;
    [SerializeField]
    float angularSpeed = 2f;
    public float rotationRadius = 3f;
    public int turnsInMode;
    float posX, posY = 0f;
    float angle = 1.7f;

    public int turnsCounter = 0;

	void Update () {
        posX = centerPoint.position.x + Mathf.Cos(angle) * rotationRadius;
        posY = centerPoint.position.y + Mathf.Sin(angle) * rotationRadius;
        transform.position = new Vector2(posX, posY);
        angle += Time.deltaTime*angularSpeed;

        if (angle >= 1.8 && angularSpeed > 0 || angle <= -5)
        {
            ChangeDirection();
            turnsCounter++;
            if (turnsCounter % turnsInMode == 0)
            {
                ChangeSpeed();
                turnsCounter = 0;
            }
        }
    }
    public void ChangeSpeed()
    {
        if(angularSpeed>0)
            angularSpeed = Random.Range(1.5f, 5f);
        else
            angularSpeed = Random.Range(-4.9f, -1.5f);
    }
    public void ChangeDirection()
    {
        angularSpeed = -angularSpeed;
    }
}
