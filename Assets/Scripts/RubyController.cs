using System;
using UnityEngine;

public class RubyController : MonoBehaviour
{

   public int maxHealth = 5; 
   int currentHealth;
   Rigidbody2D rigidbody2d;

   void Start()
   {
      currentHealth = maxHealth;
      rigidbody2d = GetComponent<Rigidbody2D>();
      QualitySettings.vSyncCount = 0; 
      Application.targetFrameRate = 60;
   }

   void Update()
   {	
      float horizontal = Input.GetAxis("Horizontal"); 
      float vertical = Input.GetAxis("Vertical"); 
      Vector2 position = rigidbody2d.position;  
      position.x += 5.0f * horizontal * Time.deltaTime; 
      position.y += 5.0f * vertical * Time.deltaTime;
      transform.position = position;

      rigidbody2d.MovePosition(position);
   }

   void changeHealth(int amount) {
      currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
   }
}
