﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Score")]
    public int scoreValue = 100;

    [Header("Movement")]
    [SerializeField] private float _verticalAmplitude = 2.5f;
    [SerializeField] private float _verticalFrequency = 2.5f;

    [Header("Physics")]
    [SerializeField] private Rigidbody _rigidBody = null;

    private Vector3 _startPosition = Vector3.zero;
    [HideInInspector]
    public EnemySpawner _parentSpawner;
    public System.Action OnDeath;
    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float positionOffset = Mathf.Sin( Time.timeSinceLevelLoad / _verticalFrequency ) * _verticalAmplitude;
        transform.position = new Vector3( _startPosition.x, _startPosition.y + positionOffset, _startPosition.z );
    }

    void Die()
    {
        _rigidBody.useGravity = true;
        Destroy(this);
        GameSession.Instance.AddScore();
        Destroy(gameObject, 5);
        OnDeath();
    }

    void OnCollisionEnter( Collision collision )
    {
        if( collision.gameObject.GetComponent<Cannonball>() )
        {
            _rigidBody.AddForceAtPosition(collision.transform.forward, collision.GetContact(0).point, ForceMode.Impulse);
            Die();
        }
    }
}
