using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Manager : MonoBehaviour{
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private MeshRenderer backgroundMeshRenderer;
    [SerializeField] private Text scoreText;
    private float spawnRate = 1f;
    private float minHeight = -1f;
    private float maxHeight = 2f;
    public int score { get; private set; }
    public void Start(){
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }
    void Update(){
        backgroundMeshRenderer.material.mainTextureOffset += new Vector2(1f * Time.deltaTime, 0);
    }
    private void Awake(){
        Application.targetFrameRate = 60;
    }
    private void Spawn(){
        GameObject pipes = Instantiate(pipePrefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
    public void IncreaseScore(){
        score++;
        scoreText.text = score.ToString();
    }
    public void Play(){
        score = 0;
        scoreText.text = score.ToString();
        Time.timeScale = 1f;
        Pipe[] pipes = FindObjectsOfType<Pipe>();
        for (int i = 0; i < pipes.Length; i++){
            Destroy(pipes[i].gameObject);
        }
    }
}