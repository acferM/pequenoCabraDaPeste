﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sons : MonoBehaviour
{
    public AudioSource[] musicas;
    public AudioSource[] sons;
    private int proxMusica = 0;
    private AudioSource musicaAtual;

    void Start()
    {
        musicaAtual = musicas[0];
    }

    void Update()
    {
        //print(Random.Range(1, 4));
        //print(musicaAtual.clip.length - musicaAtual.time);
        if (musicaAtual.clip.length - musicaAtual.time <= 0.2f)
        {
           musicas[proxMusica].Play();
           musicaAtual = musicas[proxMusica];
           proxMusica = 0;
        }
    }
    public void PlaySound(string som){
        switch (som){
            case "hit":
                sons[0].Play();
                break;
            case "pulo":
                sons[Random.Range(0, 4)].Play();
                break;
            case "broto":
                sons[5].Play();
                break;
            case "pá":
                proxMusica = 1;
                break;
            
        }
    }
}
