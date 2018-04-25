public class Suppression : Effect
{
    int countdown = 4;
    int turnCount = 2;
    protected override void Awake()
    {
        base.Awake();
        _description = "Target takes 4 damage for each of their next 4 actions. Expires in 2 turns.";
        _name = "Suppression";
        _rarity = (int)Rarity.rare;
    }
    public override void Activate()
    {
        base.Activate();
        //Checks if the card is targeting the boss.
        if (_targets[0] == GameInfo.singleton.Boss)
        {
            //If so, delegates will activate on the player's turn.
            FSM.singleton.onSelectEnd += CheckCards;
            //This card counts down if unresolved at the end of the target's opponent's turn.
            FSM.singleton.onConfirmEnd += countTurn;
        }
        else
        {
            //Otherwise, delegates will activate on the Ace's turn.
            FSM.singleton.onBSelectEnd += CheckCards;
            FSM.singleton.onBConfirmEnd += countTurn;
        }
    }

    public override void Inactivate()
    {
        base.Inactivate();
        if (_targets[0] == GameInfo.singleton.Boss)
        {
            FSM.singleton.onSelectEnd -= CheckCards;
            FSM.singleton.onConfirmEnd -= countTurn;
        }
        else
        {
            FSM.singleton.onBSelectEnd -= CheckCards;
            FSM.singleton.onBConfirmEnd -= countTurn;
        }
    }

    bool Countdown()
    {
        countdown--;
        if (countdown <= 0)
        {
            Inactivate();
            return false;
        }
        return true;
    }

    void countTurn()
    {
        turnCount--;
        if (turnCount <= 0)
        {
            Inactivate();
        }
    }

    void CheckCards()
    {
        //Called at the end of the target's opponent's selection step.
        //Check the unresolved cards list. For each one owned by the target, target takes
        //2 damage.
        foreach (CardDisplay card in GameInfo.singleton.unresolvedCards)
        {
            if (card.GetEffect().Targets[0] == _targets[0])
            {
                if (Countdown())
                    _targets[0].CmdReceiveDamage(4);
            }
        }
    }
}