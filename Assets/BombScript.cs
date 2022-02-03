using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    [SerializeField] private LayerMask destroyableObjects;

     void Start()
     {
         StartCoroutine(nameof(BadaBum));
     }

     IEnumerator BadaBum()
     {
         yield return new WaitForSeconds(3);
         var colliders = Physics2D.OverlapCircleAll(transform.position, 1f, destroyableObjects);
         
         foreach (var cldr in colliders) 
         {
             Destroy(cldr.gameObject);
         }
         Destroy(this.gameObject);
         
         
     }
}

