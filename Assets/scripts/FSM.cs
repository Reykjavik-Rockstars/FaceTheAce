using UnityEngine;
using UnityEngine.UI;

public delegate void stateTransitionDel();

public class FSM : MonoBehaviour
{
    public static FSM singleton;

    public Button nextTurnButton;

    void Awake()
    {
        singleton = this;
    }

    private void Start()
    {
        enterFSM();
    }

    public enum gameState
    {
        Draw, Select, Action, Confirm, BDraw, BSelect, BAction, BConfirm
    }

    public void activateCard()
    {
        Card thisCard = GameInfo.singleton.unresolvedCards[0];
        GameInfo.singleton.unresolvedCards.RemoveAt(0);
        thisCard.m_effect.Activate();
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

    public void enterFSM()
    {
        nextTurnButton.onClick.RemoveAllListeners();
        nextTurnButton.onClick.AddListener(drawToSelect);
        //TODO: Set the button to be non-interactable here, tell card draw action to re-activate
        //nextTurnButton.interactable = false;
        currentState = gameState.Draw;
        if (onDrawBegin != null)
            onDrawBegin();
    }

    public void drawToSelect()
    {
        if (onDrawEnd != null)
            onDrawEnd();
        //State Change Actions

        //Set the Next Turn button non-interactable, change its listener to the next transition
        nextTurnButton.onClick.RemoveAllListeners();
        nextTurnButton.onClick.AddListener(selectToAction);
        //TODO: Set the button to be non-interactable here, tell card drag action when to re-activate
        //nextTurnButton.interactable = false;
        currentState = gameState.Select;
        if (onSelectBegin != null)
            onSelectBegin();
    }

    public void selectToAction()
    {
        if (onSelectEnd != null)
            onSelectEnd();
        //State Change Actions
        nextTurnButton.onClick.RemoveAllListeners();
        if (GameInfo.singleton.unresolvedCards.Count <= 1)
        {
            nextTurnButton.onClick.AddListener(actionToConfirm);
        }
        else
        {
            nextTurnButton.onClick.AddListener(actionToAction);
        }
        currentState = gameState.Action;
        if (onActionBegin != null)
            onActionBegin();
        if (GameInfo.singleton.unresolvedCards.Count >= 1)
            activateCard();
    }

    public void actionToAction()
    {
        if (onActionEnd != null)
            onActionEnd();
        //State Change Actions
        nextTurnButton.onClick.RemoveAllListeners();
        if (GameInfo.singleton.unresolvedCards.Count <= 1)
        {
            nextTurnButton.onClick.AddListener(actionToConfirm);
        }
        else
        {
            nextTurnButton.onClick.AddListener(actionToAction);
        }
        currentState = gameState.Action;
        if (onActionBegin != null)
            onActionBegin();
        if (GameInfo.singleton.unresolvedCards.Count >= 1)
            activateCard();
    }

    public void actionToConfirm()
    {
        if (onActionEnd != null)
            onActionEnd();
        //State Change Actions
        nextTurnButton.onClick.RemoveAllListeners();
        nextTurnButton.onClick.AddListener(confirmToBDraw);
        currentState = gameState.Confirm;
        if (onConfirmBegin != null)
            onConfirmBegin();
    }

    public void confirmToBDraw()
    {
        if (onConfirmEnd != null)
            onConfirmEnd();
        //State Change Actions
        nextTurnButton.onClick.RemoveAllListeners();
        nextTurnButton.onClick.AddListener(bDrawToBSelect);
        currentState = gameState.BDraw;
        if (onBDrawBegin != null)
            onBDrawBegin();
    }

    public void bDrawToBSelect()
    {
        if (onBDrawEnd != null)
            onBDrawEnd();
        //State Change Actions
        nextTurnButton.onClick.RemoveAllListeners();
        nextTurnButton.onClick.AddListener(bSelectToBAction);
        currentState = gameState.BSelect;
        if (onBSelectBegin != null)
            onBSelectBegin();
    }

    public void bSelectToBAction()
    {
        if (onBSelectEnd != null)
            onBSelectEnd();
        //State Change Actions
        nextTurnButton.onClick.RemoveAllListeners();
        if (GameInfo.singleton.unresolvedCards.Count <= 1)
        {
            nextTurnButton.onClick.AddListener(bActionToBConfirm);
        }
        else
        {
            nextTurnButton.onClick.AddListener(bActionToBAction);
        }
        currentState = gameState.BAction;
        if (onBActionBegin != null)
            onBActionBegin();
        if (GameInfo.singleton.unresolvedCards.Count >= 1)
            activateCard();
    }

    public void bActionToBAction()
    {
        if (onBActionEnd != null)
            onBActionEnd();
        //State Change Actions
        nextTurnButton.onClick.RemoveAllListeners();
        if (GameInfo.singleton.unresolvedCards.Count <= 1)
        {
            nextTurnButton.onClick.AddListener(bActionToBConfirm);
        }
        else
        {
            nextTurnButton.onClick.AddListener(bActionToBAction);
        }
        if (onBActionBegin != null)
            onBActionBegin();
        if (GameInfo.singleton.unresolvedCards.Count >= 1)
            activateCard();
    }

    public void bActionToBConfirm()
    {
        if (onBActionEnd != null)
            onBActionEnd();
        //State Change Actions
        nextTurnButton.onClick.RemoveAllListeners();
        nextTurnButton.onClick.AddListener(bConfirmToDraw);
        currentState = gameState.BConfirm;
        if (onBConfirmBegin != null)
            onBConfirmBegin();
    }

    public void bConfirmToDraw()
    {
        if (onBActionEnd != null)
            onBConfirmBegin();
        //State Change Actions
        nextTurnButton.onClick.RemoveAllListeners();
        nextTurnButton.onClick.AddListener(drawToSelect);
        currentState = gameState.Draw;
        if (onDrawBegin != null)
            onDrawBegin();
    }
}