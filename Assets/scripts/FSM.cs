using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void stateTransitionDel();

public class FSM : MonoBehaviour
{
    public static FSM singleton;

    void Awake()
    {
        singleton = this;
    }

    public enum gameState
    {
        Draw, Select, Action, Confirm, BDraw, BSelect, BAction, BConfirm
    }

    public gameState currentState;

    public stateTransitionDel onDrawBegin;
    public stateTransitionDel onDrawEnd;
    public stateTransitionDel onSelectBegin;
    public stateTransitionDel onSelectEnd;
    public stateTransitionDel onActionBegin;
    public stateTransitionDel onActionEnd;
    public stateTransitionDel onConfirmBegin;
    public stateTransitionDel onConfirmEnd;
    public stateTransitionDel onBDrawBegin;
    public stateTransitionDel onBDrawEnd;
    public stateTransitionDel onBSelectBegin;
    public stateTransitionDel onBSelectEnd;
    public stateTransitionDel onBActionBegin;
    public stateTransitionDel onBActionEnd;
    public stateTransitionDel onBConfirmBegin;
    public stateTransitionDel onBConfirmEnd;

    public void drawToSelect()
    {
        if (onDrawEnd != null)
            onDrawEnd();
        //State Change Actions
        currentState = gameState.Select;
        Debug.Log("game state changed to select");
        if (onSelectBegin != null)
            onSelectBegin();
    }

    public void selectToAction()
    {
        if (onSelectEnd != null)
            onSelectEnd();
        //State Change Actions
        currentState = gameState.Action;
        if (onActionBegin != null)
            onActionBegin();
    }

    public void actionToAction()
    {
        if (onActionEnd != null)
            onActionEnd();
        //State Change Actions
        currentState = gameState.Action;
        if (onActionBegin != null)
            onActionBegin();
    }

    public void actionToConfirm()
    {
        if (onActionEnd != null)
            onActionEnd();
        //State Change Actions
        currentState = gameState.Confirm;
        if (onConfirmBegin != null)
            onConfirmBegin();
    }

    public void confirmToBDraw()
    {
        if (onConfirmEnd != null)
            onConfirmEnd();
        //State Change Actions
        currentState = gameState.BDraw;
        if (onBDrawBegin != null)
            onBDrawBegin();
    }

    public void bDrawToBSelect()
    {
        if (onBDrawEnd != null)
            onBDrawEnd();
        //State Change Actions
        currentState = gameState.BSelect;
        if (onBSelectBegin != null)
            onBSelectBegin();
    }

    public void bSelectToBAction()
    {
        if (onBSelectEnd != null)
            onBSelectEnd();
        //State Change Actions
        currentState = gameState.BAction;
        if (onBActionBegin != null)
            onBActionBegin();
    }

    public void bActionToDraw()
    {
        if (onBActionEnd != null)
            onBActionEnd();
        //State Change Actions
        currentState = gameState.Draw;
        if (onDrawBegin != null)
            onDrawBegin();
    }
}