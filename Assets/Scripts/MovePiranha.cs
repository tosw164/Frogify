using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePiranha : MonoBehaviour
{
    Rigidbody2D enemyRigidBody2D;
    public float UnitsToMove = 25;
    public float EnemySpeed = 0.005f;
    public bool _isFacingUp;
    public float _startPos;
    public float _endPos;

    public bool _moveUp;


    // Use this for initialization
    public void Awake()
    {
        enemyRigidBody2D = GetComponent<Rigidbody2D>();
        _startPos = transform.position.y;
        _endPos = _startPos + UnitsToMove;
        _isFacingUp = transform.localScale.y > 0;
        if (_isFacingUp)
        {
            _moveUp = true;
        }
        else
        {
            _moveUp = false;
        }
    }


    // Update is called once per frame
    public void Update()
    {

        if (_moveUp)
        {
            if(!_isFacingUp)
                Flip();

            //enemyRigidBody2D.transform.localPosition = new Vector3(enemyRigidBody2D.transform.localPosition.x, enemyRigidBody2D.transform.localPosition.y + EnemySpeed);
            enemyRigidBody2D.velocity = new Vector2(enemyRigidBody2D.velocity.x, EnemySpeed);
            //enemyRigidBody2D.AddRelativeForce(Vector2.up * EnemySpeed * Time.deltaTime);

            if (enemyRigidBody2D.position.y >= _endPos)
                _moveUp = false;

        }
        else // if moving down
        {
            if (_isFacingUp)
                Flip();

            //enemyRigidBody2D.transform.localPosition = new Vector3(enemyRigidBody2D.transform.localPosition.x, enemyRigidBody2D.transform.localPosition.y - EnemySpeed);
            enemyRigidBody2D.velocity = new Vector2(enemyRigidBody2D.velocity.x, -EnemySpeed);
            //enemyRigidBody2D.AddRelativeForce(-Vector2.up * EnemySpeed * Time.deltaTime);

            if (enemyRigidBody2D.position.y <= _startPos)
                _moveUp = true;


        }
    }


    public void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
        _isFacingUp = transform.localScale.y > 0;
    }

}

