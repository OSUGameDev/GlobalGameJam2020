﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    //Make sure to attach these Buttons in the Inspector
    [Header("Stat Buttons")]
    [SerializeField] private Button eyesButton;
    [SerializeField] private Button cableBoxButton;
    [SerializeField] private Button armButton;
    [SerializeField] private Button circuitBoardButton;
    [SerializeField] private Button legButton;
    [SerializeField] private Button coolantButton;
    //Any buttoons that will open a menu
    [Header("Menu Buttons")]
    [SerializeField] private Button fightButton;
    private GameController GameController;

    void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        //adding event listeners cause we javascript now boys
        eyesButton.onClick.AddListener(EyesButton);
        armButton.onClick.AddListener(ArmButton);
        cableBoxButton.onClick.AddListener(CableBoxButton);
        circuitBoardButton.onClick.AddListener(CircuitBoardButton);
        legButton.onClick.AddListener(LegButton);
        coolantButton.onClick.AddListener(CoolantButton);
        fightButton.onClick.AddListener(FightButton);
    }

    void Update(){
        //if timer reaches 0... start fight
        if(GameController.timer <= 0)
            FightButton();
    }

    /*
        Each button has it's own function because it's easier and we might have certain buttons do more than one thing and other such things I guess, probably
        could have had a listener function that took a parameter and put it in a case statement, but I want to keep it like this for now.
    */
    void EyesButton()
    {
        SceneManager.LoadScene("EyeRepair", LoadSceneMode.Single);
    }
    void ArmButton()
    {
        //SceneManager.LoadScene("", LoadSceneMode.Single);
        SceneManager.LoadScene("ArmSpring", LoadSceneMode.Single);
        GameController.player.ModifyArm(1);
    }
    void CableBoxButton()
    {
        SceneManager.LoadScene("WireRepair", LoadSceneMode.Single);
        //GameController.player.ModifyCableBox(1);
    }
    void CircuitBoardButton()
    {
        SceneManager.LoadScene("HeadRepair", LoadSceneMode.Single);
        //GameController.player.ModifyCircuitBoard(1);
    }
    void LegButton()
    {

        GameController.player.ModifyLeg(1);
    }
    void CoolantButton()
    {
        SceneManager.LoadScene("PressureRepair", LoadSceneMode.Single);
        GameController.player.ModifyCoolant(1);
    }
    void FightButton(){
        //Load the fight
        GameController.LoadFightScene();
    }

}