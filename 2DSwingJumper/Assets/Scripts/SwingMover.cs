using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingMover : MonoBehaviour {
    [Header ("Circle movement")]
    public float rotationRadius = 3f;
    public float angle = 0f;
    public bool rightDir = false;
    [SerializeField]
    Transform centerPoint;
    [SerializeField]
    float angularSpeed;

    [Header ("Mode info")]
    public int turnsCounter = 1;
    public int cyclesCounter = 1;
    public int turnsLeft, turnsRight, cyclesInMode;
    public float leftSpeed, rightSpeed;

    float posX, posY = 0f;

    void Start()
    {
        leftSpeed = RandomSpeed();
        rightSpeed = -RandomSpeed();
        angularSpeed = leftSpeed;
    }

	void Update () {
        posX = centerPoint.position.x + Mathf.Cos(angle + 1.5f) * rotationRadius;
        posY = centerPoint.position.y + Mathf.Sin(angle + 1.5f) * rotationRadius;
        transform.position = new Vector2(posX, posY);
        angle += Time.deltaTime*angularSpeed;

            if (Mathf.Abs(angle) >= 6.3f)
            {
                if (rightDir && turnsCounter % turnsRight == 0)
                {
                    ChangeDirection();
                    cyclesCounter++;
                }
                else if (!rightDir && turnsCounter % turnsLeft == 0)
                {
                    ChangeDirection();
                }
                angle = 0;
                if (cyclesCounter % (cyclesInMode + 1) == 0)
                    NewMode();
                turnsCounter++;
            }
    }
    void NewMode()
    {
        cyclesCounter = 1;
        turnsLeft = RandomTurns();
        turnsRight = RandomTurns();
        leftSpeed = RandomSpeed();
        rightSpeed = -RandomSpeed();
    }
    int RandomTurns()
    {
        return Random.Range(1, 5);
    }
    float RandomSpeed()
    {
        return Random.Range(1.5f, 4.9f);
    }
    void ChangeDirection()
    {
        if (!rightDir)
        {
            angularSpeed = rightSpeed;
            rightDir = true;
        }
        else
        {
            angularSpeed = leftSpeed;
            rightDir = false;
        }
        turnsCounter = 0;
    }
}
