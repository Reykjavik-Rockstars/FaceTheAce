public class DodgeRoll : Effect
{
    public DodgeRoll() : base()
    {
        _name = "Dodge Roll";
    }

    public override void Activate()
    {
        base.Activate();

        //Checks if the card is targeting the boss.
        if (_targets[0] == GameInfo.singleton.Boss)
        {
            //If so, delegates will activate on the player's turn.
            FSM.singleton.onSelectEnd += CheckCards;
            //This card inactivates if unresolved at the end of the target's opponent's turn.
            FSM.singleton.onConfirmEnd += Inactivate;
        }
        else
        {
            //Otherwise, delegates will activate on the Ace's turn.
            FSM.singleton.onBSelectEnd += CheckCards;
            FSM.singleton.onBConfirmEnd += Inactivate;
        }
    }

    public override void Inactivate()
    {
        base.Inactivate();

        if (_targets[0] == GameInfo.singleton.Boss)
        {
            FSM.singleton.onSelectEnd -= CheckCards;
            FSM.singleton.onConfirmEnd -= Inactivate;
        }
        else
        {
            FSM.singleton.onBSelectEnd -= CheckCards;
            FSM.singleton.onBConfirmEnd -= Inactivate;
        }
    }

    void CheckCards()
    {
        //Called at the end of the target's opponent's selection step.
        //Check the unresolved cards list. If there is one called "Open Fire"
        //or "Sweeping Fire", remove it and inactivate this effect.
        foreach (Card card in GameInfo.singleton.unresolvedCards)
        {
            if (card.name == "Open Fire" || card.name == "Sweeping Fire")
            {
                if (card.GetEffect().Targets[0] == _targets[0])
                {
                    GameInfo.singleton.unresolvedCards.Remove(card);
                    Inactivate();
                }
            }
        }
    }
}