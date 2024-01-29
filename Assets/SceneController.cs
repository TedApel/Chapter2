using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{

    [SerializeField] GameObject enemyPrefab;
    private GameObject enemy;
    

    // Update is called once per frame
    void Update()
    {
        if (enemy == null) {
      enemy = Instantiate(enemyPrefab) as GameObject;
      enemy.transform.position = new Vector3(0, 1, 0);
      float angle = Random.Range(0, 360);
      enemy.transform.Rotate(0, angle, 0);
   enemy.transform.localScale = new Vector3(enemy.transform.localScale.x, Random.Range(0.5f, 8.5f), enemy.transform.localScale.z);
      
      // Change the color of the enemy to a random color
    Renderer renderer = enemy.GetComponent<Renderer>();
    if (renderer != null) {
        renderer.material.color = new Color(Random.value, Random.value, Random.value);
            }
        }
    }

    

} 

