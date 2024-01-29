using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
   public float speed = 10.0f;
  public int damage = 1;
  void Update() {
    transform.Translate(0, 0, speed * Time.deltaTime);
}

 // Change the color of the enemy to a random color
// important comment

        
void OnTriggerEnter(Collider other) {
  PlayerCharacter player = other.GetComponent<PlayerCharacter>();
    if (player != null) {
      Debug.Log("Player hit");
      player.Hurt(damage);
}
    Destroy(this.gameObject);
  }


}
