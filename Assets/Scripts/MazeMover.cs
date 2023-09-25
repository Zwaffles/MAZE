using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MazeMover : MonoBehaviour
{
    private InputKeybinds _inputKeybinds;


    private void Awake()
    {
        _inputKeybinds = new InputKeybinds();

        _inputKeybinds.Player.Mouse.performed += MoveMaze;

    }

    private void MoveMaze(InputAction.CallbackContext ctx)
    {
        
    }
    
    
}
