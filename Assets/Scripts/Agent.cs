using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
public class BirdAgent : Agent{
    [SerializeField] private Transform bird;
    [SerializeField] private Player player;
    [SerializeField] private Manager manager;
    [SerializeField] private CircleCollider2D circleCollider;
    [SerializeField] private Rigidbody2D rigidBody2D;
    public override void OnEpisodeBegin(){
        player.Restart();
        manager.Play();
    }
    public override void CollectObservations(VectorSensor sensor){
        sensor.AddObservation(bird.position.y);
    }
    private void OnActionReceived(float[] vectorAction){
        if (vectorAction[0] == 1){
            player.Flap();
        }
    }
    private void OnTriggerEnter2D(Collider2D obj){
        if (obj.gameObject.CompareTag("Obstacle")){
            SetReward(-1f);
            EndEpisode();
        }
        else if (obj.gameObject.CompareTag("Scoring")){
            SetReward(1f);
        }
    }
}