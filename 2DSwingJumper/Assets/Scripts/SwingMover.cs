using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingMover : MonoBehaviour {
    [SerializeField]
    Transform centerPoint;
    public float rotationRadius = 3f, angularSpeed = 2f;
    float posX, posY = 0f;
    float angle = 1.6f;

	void Update () {
        posX = centerPoint.position.x + Mathf.Cos(angle) * rotationRadius;
        posY = centerPoint.position.y + Mathf.Sin(angle) * rotationRadius;
        transform.position = new Vector2(posX, posY);
        angle += Time.deltaTime*angularSpeed;

        if (Mathf.Abs(angle) >= 6.3f)
            angle = 0f;
    }
    public void ChangeSpeed()
    {
        angularSpeed = Random.Range(1.5f, 5f);
    }
}
