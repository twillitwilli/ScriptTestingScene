using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class PWTradeSystem : MonoBehaviour
{
    public bool[] playerAcceptsTrade;
    public bool runTradeSimulation;
    public bool destroyCompletedTrades;

    public PWMessage[] originalMessages;

    public PWMessage senderMessage, recieverMessage, resultMessage1, resultMessage2;

    private Dictionary<int, PWMessage> _currentTradesInProgress = new Dictionary<int, PWMessage>();

    private void Update()
    {
        if (runTradeSimulation)
        {
            TradeSimulationTest();

            runTradeSimulation = false;
        }
    }

    private void TradeSimulationTest()
    {
        Debug.Log("Trade Sim Started");

        System.Random randomizer = new System.Random();

        int tradeID = randomizer.Next();
        int itemID = randomizer.Next();
        int senderPlayerID = randomizer.Next();
        int recieverPlayerID = randomizer.Next();

        for (int i = 0; i < 2; i++)
        {
            originalMessages[i].messageType = PWMessage.MessageType.StartTrade;
            originalMessages[i].tradeID = tradeID;
            originalMessages[i].itemID = itemID;
            originalMessages[i].senderPlayerID = senderPlayerID;
            originalMessages[i].recieverPlayerID = recieverPlayerID;
        }

        /// Instead of the network sending the message to 2 players, here i will just simulate that
        /// by running 2 different methods that would normally just be the same method on each player.
        /// 

        SenderPlayerRecievedMessage(originalMessages[0]);
        RecieverPlayerRecievedMessage(originalMessages[1]);
    }

    /// Fake Network To Players ///

    private void SenderPlayerRecievedMessage(PWMessage tradeMessage)
    {
        PWMessage replyMessage = new PWMessage();
        replyMessage = tradeMessage;
        replyMessage.differentiator = true;

        if (playerAcceptsTrade[0])
        {
            replyMessage.messageType = PWMessage.MessageType.AcceptedTrade;

            AcceptTrade(replyMessage);
        }
        else
        {
            replyMessage.messageType = PWMessage.MessageType.CancelledTrade;

            CancelTrade(replyMessage);
        }

        senderMessage = replyMessage;
    }

    private void RecieverPlayerRecievedMessage(PWMessage tradeMessage)
    {
        PWMessage replyMessage = new PWMessage();
        replyMessage = tradeMessage;
        replyMessage.differentiator = false;

        if (playerAcceptsTrade[1])
        {
            replyMessage.messageType = PWMessage.MessageType.AcceptedTrade;

            AcceptTrade(replyMessage);
        }
        else
        {
            replyMessage.messageType = PWMessage.MessageType.CancelledTrade;

            CancelTrade(replyMessage);
        }

        recieverMessage = replyMessage;
    }

    /// -----------------------------------------

    private void AcceptTrade(PWMessage replyMessage)
    {
        var currentTrade = _currentTradesInProgress.ContainsKey(replyMessage.tradeID);

        if (currentTrade)
        {
            Debug.Log("Found Current Trade In Progress");

            PWMessage currentTradeMessage = CurrentMessage(replyMessage.tradeID).GetAwaiter().GetResult();

            switch (currentTradeMessage.messageType)
            {
                case PWMessage.MessageType.AcceptedTrade:

                    Debug.Log("trade accepted");
                    TradeCompleted(true, replyMessage, currentTradeMessage, replyMessage.tradeID);
                    break;

                case PWMessage.MessageType.CancelledTrade:

                    Debug.Log("trade cancelled");
                    TradeCompleted(false, replyMessage, currentTradeMessage, replyMessage.tradeID);

                    break;
            }
        }
        else
        {
            Debug.Log("No Current Trade In Progress, Creating New Trade");

            _currentTradesInProgress.Add(replyMessage.tradeID, replyMessage);
        }
    }

    private void CancelTrade(PWMessage replyMessage)
    {
        var currentTrade = _currentTradesInProgress.ContainsKey(replyMessage.tradeID);

        if (currentTrade)
        {
            Debug.Log("Found Current Trade In Progress");

            PWMessage currentTradeMessage = CurrentMessage(replyMessage.tradeID).GetAwaiter().GetResult();

            TradeCompleted(false, replyMessage, currentTradeMessage, replyMessage.tradeID);
        }
        else
        {
            Debug.Log("No Current Trade In Progress, Creating New Trade");

            _currentTradesInProgress.Add(replyMessage.tradeID, replyMessage);
        }
    }

    private async Task<PWMessage> CurrentMessage(int tradeID)
    {
        foreach (PWMessage tradeMessage in _currentTradesInProgress.Values)
        {
            if (tradeMessage.tradeID == tradeID)
            {
                return tradeMessage;
            }
        }
        return null;
    }

    private void TradeCompleted(bool success, PWMessage message1, PWMessage message2, int tradeKey)
    {
        Debug.Log("Total Count Of Trades = " + _currentTradesInProgress.Count);

        if (success)
        {
            Debug.Log("Trade Accepted By Both Players");
        }
        else Debug.Log("Trade Canceled");

        resultMessage1 = message1;
        resultMessage2 = message2;

        if (destroyCompletedTrades)
        {
            _currentTradesInProgress.Remove(tradeKey);
        }
    }
}

[System.Serializable]
public class PWMessage
{
    public MessageType messageType;
    public int tradeID;
    public int itemID;
    public int senderPlayerID, recieverPlayerID;
    public bool differentiator;

    public enum MessageType 
    { 
        StartTrade, 
        AcceptedTrade, 
        CancelledTrade,
        CompletedTrade
    }
}
