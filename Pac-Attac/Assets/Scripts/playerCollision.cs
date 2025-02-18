using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour
{
    public bool isIt = false; // is the player it?
    private SpriteRenderer spriteRenderer; // sprite renderer component

    public Sprite itSprite; //Sprite for when the player is IT
    public Sprite notItSprite; // Sprite when the player is NOT IT 
    private bool canTag = true; // can the player tag another player?;; need this for our cooldown.

    float cooldown = 2f; // cooldown for tagging another player
    float tagTimer = 0f; // timer for the cooldown

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // get the sprite renderer component
        ChangeSprite();
    }

    void Update()
    {
        TagCooldown();
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Only will tag if this player is "It" and collides with another player
        if (isIt && collision.gameObject.CompareTag("Player"))
        {
            playerCollision otherPlayer = collision.gameObject.GetComponent<playerCollision>();

            if (otherPlayer != null && otherPlayer.canTag)
            {
                SwapRoles(otherPlayer);
            }
        }
    }

    void SwapRoles (playerCollision otherPlayer)
    {
        isIt = false;
        otherPlayer.isIt = true;

        ChangeSprite();
        otherPlayer.ChangeSprite();

        canTag = false;
    }

    private void TagCooldown()
    {
        if (tagTimer >= cooldown && !canTag)
        {
            canTag = true;
            tagTimer = 0f;
        }
        else
        {
            tagTimer += Time.deltaTime;
        }
    }

    public void ChangeSprite()
    {
        spriteRenderer.sprite = isIt ? itSprite : notItSprite;
    }
}
