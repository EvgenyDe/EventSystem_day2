using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private LayerMask raycastMask;

    private int enemyDirection = 1;
    // Update is called once per frame
    void Update()
    {
        
        
    }
    
    private int MovePlayerTo(Vector2 dir)
    {

        //var isMovement = true;

        var pos = (Vector2)transform.position + dir;
        transform.DOMove(pos, 0.5f).OnComplete(() =>
        {
           // isMovement = false;
        });
        
        if (Raycast(dir))
        {
            enemyDirection=Random.Range(1, 5);
            StartCoroutine("ChangeDirection");
            Debug.Log(enemyDirection);
        }
        
        return enemyDirection;
    }

    private bool Raycast(Vector2 dir)
    {
        var hit = Physics2D.Raycast(transform.position, dir, 1f, raycastMask);
        return hit.collider ;
    }

    IEnumerator ChangeDirection()
    {
        yield return new WaitForSeconds(2);
        while (true)
        {

            switch (enemyDirection)
            {
                case 1:
                    MovePlayerTo(Vector2.up);
                    break;
                case 2:
                    MovePlayerTo(Vector2.left);
                    break;
                case 3:
                    MovePlayerTo(Vector2.right);
                    break;
                case 4:
                    MovePlayerTo(Vector2.down);
                    break;
            }
        }
    }
}
