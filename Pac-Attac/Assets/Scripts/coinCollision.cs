using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinCollision : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerCollision playerColl = other.GetComponent<playerCollision>();

        // Check if the player is NOT "IT"
        if (playerColl != null && !playerColl.isIt)
        {
            playerScore playerScore = other.GetComponent<playerScore>();
            if (playerScore != null)
            {
                AnimationManager();
                playerScore.AddScore(1);
                Destroy(gameObject);
            }
        }

        public void AnimationManager();
        {
            Instantiante("collect1", Spawn.Position(0), Spawn.Rotation(0));
            anim.Play("coinCollect");
            Yeild WaitForSeconds(1f);
            Destroy(gameObject);
        }
    }
}
