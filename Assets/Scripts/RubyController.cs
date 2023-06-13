using System;
using UnityEngine;

public class RubyController : MonoBehaviour
{
   public float speed = 3.0f; 
   public int maxHealth = 5; 
   int currentHealth;
   Rigidbody2D rigidbody2d;

   bool isInvincible;
   float invincibleTimer;

   float horizontal, vertical;

   Animator animator;
   Vector2 lookDir = new Vector2(1, 0); 

   void Start()
   {
      currentHealth = maxHealth;
      rigidbody2d = GetComponent<Rigidbody2D>();
      animator = GetComponent<Animator>();

      QualitySettings.vSyncCount = 0; 
      Application.targetFrameRate = 60;
   }

   void Update()
   {	
      horizontal = Input.GetAxis("Horizontal"); 
      vertical = Input.GetAxis("Vertical");

      Vector2 move = new Vector2(horizontal, vertical);

      if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
      {
         lookDir.Set(move.x, move.y);
         lookDir.Normalize();
      } 

      animator.SetFloat("Horizontal", lookDir.x); 
      animator.SetFloat("Vertical", lookDir.y);
      animator.SetFloat("Speed", move.magnitude);

      if (isInvincible)
      {
         invincibleTimer -= Time.deltaTime;
         if (invincibleTimer < 0) isInvincible = false;
      }  
   }

   void FixedUpdate() {
      Vector2 position = rigidbody2d.position;
      position.x = position.x + speed * horizontal * Time.deltaTime;
      position.y = position.y + speed * vertical * Time.deltaTime;

      rigidbody2d.MovePosition(position);
   }

   void changeHealth(int amount) {
      currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
   }
}
