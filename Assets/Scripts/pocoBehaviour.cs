﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pocoBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject corda;
    [SerializeField] private Sprite[] sprites;
    private SpriteRenderer cRenderer;
    private bool balde, bPoco = false;
    private float profundidade;
    private RaycastHit2D[] hit;
    private Animator cAnim;

    void Start()
    {
        cRenderer = corda.GetComponent<SpriteRenderer>();
        cAnim = corda.GetComponent<Animator>();
        cAnim.enabled = false;
        cRenderer.sprite = sprites[0];
    }
    
    void Update()
    {
        cRenderer.sprite = sprites[(profundidade <= 0 && bPoco)? 1 : 0 ];
        balde = player.GetComponent<controladorJogador>().balde;
        hit = Physics2D.CircleCastAll(transform.position, 1, -transform.up);        
        
        for (int i = 0; i < hit.Length; i++)
        {
            if(hit[i].collider != null)
            {
                var other = hit[i].collider.gameObject;
                if (other.tag == "Player")
                {
                    if(Input.GetKeyDown("e") && balde && !bPoco)
                    {
                        player.GetComponent<controladorJogador>().balde = false;
                        bPoco = true;
                    }
                    else if(Input.GetKeyDown("e") && !balde && bPoco && profundidade <= 0)
                    {
                        bPoco = false;
                        player.GetComponent<controladorJogador>().balde = true;
                    }
                    if(bPoco)
                    {
                        if(Input.GetAxisRaw("Vertical") > 0)
                        {
                            profundidade -= (profundidade < 0)? 0 : Time.deltaTime;
                            cAnim.enabled = (Input.GetAxisRaw("Vertical") != 0 && profundidade >= 0);
                        }
                        else if (Input.GetAxisRaw("Vertical") < 0)
                        {
                            profundidade += (profundidade > 1) ? 0 : Time.deltaTime;
                            cAnim.enabled = (Input.GetAxisRaw("Vertical") != 0 && profundidade <= 1);
                        }
                        else
                        {
                            profundidade = (Mathf.Abs(profundidade) < 0.05f)? 0 : profundidade;
                            cAnim.enabled = false;
                        }                      
                    }
                }
            }
            
        }
    }

}