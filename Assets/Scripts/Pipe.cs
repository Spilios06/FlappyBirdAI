﻿using UnityEngine;
public class Pipe : MonoBehaviour{
    [SerializeField] private Transform top;
    [SerializeField] private Transform bottom;
    private float speed = 5f;
    private float leftEdge;
    private void Start(){
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }
    private void Update(){
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < leftEdge) {
            Destroy(gameObject);
        }
    }
}