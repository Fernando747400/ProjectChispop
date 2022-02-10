//Diana 9/02/22
using System.Collections;
using System.Collections.Generic;
using com.LazyGames.Chispop;
using UnityEngine;
using UnityEditor;
//If you want to test change the typeof to the name of the class you what to test
[CustomEditor(typeof(EnemyController))]
public class TestEditor : Editor
{
   //This Script is only for testing usages 
   public override void OnInspectorGUI()
   {
      DrawDefaultInspector();
      // PlayerController playerController = target as PlayerController;
      //Change the next line 
      EnemyController enemyController = target as EnemyController;
      

      if (GUILayout.Button("Create Health or Get health"))
      {
         if (Application.isPlaying)
         {
            enemyController.InitializeOrGetHealth();
            
         }
      }
      
      
      if (GUILayout.Button("Get health Percent"))
      {
         if (Application.isPlaying)
         {
            enemyController.GetHealthPercent();
            
         }
      }
      
      if (GUILayout.Button("Make Damage to Enemy"))
      {
         if (Application.isPlaying)
         {
           enemyController.PlayerReceiveDamage();
            
         }
      }
      
       if (GUILayout.Button("Heal Enemy"))
      {
         if (Application.isPlaying)
         {
            enemyController.PlayerReceiveHeal();
            
         }
         
      }
      
   }
}
