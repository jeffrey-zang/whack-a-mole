using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class mole : MonoBehaviour
{
    public Transform block;
    public int thing;
    private bool up = false;
    public TMP_Text scoretext;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (block.position.y == 0) {
            up = true;
        }
        else {
            up = false;
        }
    }
    void Update()
    {
        System.Random random = new System.Random();
        int num = random.Next(150);
        if (!up && num == thing) {
            block.position = new Vector3(block.position.x, 0, block.position.z);
            return;
        }
        num = random.Next(200);
        if (up && num == thing+1) {
            block.position = new Vector3(block.position.x, -2f, block.position.z);
            return;
        }
    }
    void OnMouseOver(){
        if (!up) {return;}
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.JoystickButton9)) {
            //block.localScale = new Vector3(block.scale.x,0.25,block.scale.z);
            block.position = new Vector3(block.position.x, -2f, block.position.z);
            int prevscore = Int32.Parse(scoretext.text.Split(' ')[1]);
            scoretext.text = $"SCORE: {prevscore+1}";
            // scoretext.text = '';
        } 
    }
}
