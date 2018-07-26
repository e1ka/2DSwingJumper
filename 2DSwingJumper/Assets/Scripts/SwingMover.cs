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
    public float angle = 0f;

    public int turnsCounter = 1;

	void Update () {
        posX = centerPoint.position.x + Mathf.Cos(angle + 1.5f) * rotationRadius;
        posY = centerPoint.position.y + Mathf.Sin(angle + 1.5f) * rotationRadius;
        transform.position = new Vector2(posX, posY);
        angle += Time.deltaTime*angularSpeed;

        if (Mathf.Abs(angle) >= 6.3f)
        {
            if (turnsCounter % turnsInMode == 0)
            {
                ChangeSpeed();
                ChangeDirection();
                turnsCounter = 0;
            }
            turnsCounter++;
            angle = 0;
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
