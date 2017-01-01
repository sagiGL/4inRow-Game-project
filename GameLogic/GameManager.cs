using System.Diagnostics;
using System;

namespace GameLogic
{
    public class GameManager
    {
        private Board.ePlayer m_CurrentPlayer;
        private Board m_GameBoard;
        private eGameMode m_GameMode;
        private int m_PlayerOneLastMove;
        private int m_PlayerOneOlderMove;
    
        public GameManager(int i_NumberOfPlayers, int i_BoardRow, int i_BoardColumn)
        {
            this.m_GameBoard = new Board(i_BoardRow, i_BoardColumn);
            this.m_GameMode = i_NumberOfPlayers == 1 ? eGameMode.SinglePlayer : eGameMode.MultyPlayer;
            this.m_CurrentPlayer = Board.ePlayer.PlayerOne;
        }

        public eGameMode GameMode
        {
            get { return m_GameMode; }
        }

        public Board.ePlayer CurrentPlayer
        {
            get { return m_CurrentPlayer; }
        }

        public Board Board
        {
            get { return m_GameBoard; }
        }

        // Full move include picking and checking sign insert
        public void move(int i_ColToInsert, Board.ePlayer i_CurrentPlayer)
        {
            bool isComputerValidChoise = false;
            m_GameBoard.EnterMove(i_ColToInsert, m_CurrentPlayer);

            if (i_CurrentPlayer == Board.ePlayer.PlayerOne)
            {
                m_PlayerOneOlderMove = m_PlayerOneLastMove;
                m_PlayerOneLastMove = i_ColToInsert;
            }
          
            m_CurrentPlayer = m_CurrentPlayer == Board.ePlayer.PlayerOne ? Board.ePlayer.PlayerTwo : Board.ePlayer.PlayerOne;

            if (m_GameMode == eGameMode.SinglePlayer && m_CurrentPlayer == Board.ePlayer.PlayerTwo)
            {
                int computerChoice = PcBlock(Board, m_PlayerOneLastMove, m_PlayerOneOlderMove);
                isComputerValidChoise = m_GameBoard.EnterMove(computerChoice, m_CurrentPlayer);
                while (!isComputerValidChoise)
                {
                    isComputerValidChoise = m_GameBoard.EnterMove(computerChoice, m_CurrentPlayer);
                }

                m_CurrentPlayer = Board.ePlayer.PlayerOne;
            }
        }
      
        // PC Smart Block move
        public int PcBlock(Board i_GameBoard, int i_PlayerLastMove, int i_PlayerOlderMove)
        {
            int ColumnsRange = i_GameBoard.BoardColumn - 1;
            int ColumnPick = GuessNumber(ColumnsRange);
            if (i_PlayerLastMove == i_PlayerOlderMove)
            {
                ColumnPick = i_PlayerLastMove;
            }
            else if (Math.Abs(i_PlayerLastMove - i_PlayerOlderMove) == 1)
            {
                if (Math.Max(i_PlayerLastMove, i_PlayerOlderMove) + 1 < ColumnsRange + 1)       
                {
                    ColumnPick = Math.Max(i_PlayerLastMove, i_PlayerOlderMove) + 1;
                }

                if (Math.Min(i_PlayerLastMove, i_PlayerOlderMove) - 1 > 1)                 
                {
                    ColumnPick = Math.Min(i_PlayerLastMove, i_PlayerOlderMove) - 1;
                }
            }

            while (i_GameBoard.IsColumnFull(ColumnPick - 1))
            {
                if (ColumnPick == ColumnsRange)
                {
                    ColumnPick = -1;
                }

                ColumnPick++;
            }

            return ColumnPick;
        }

        // Get Random number
        public int GuessNumber(int i_Columns)
        {
            Random rndNum = new Random();
            int guessresult = rndNum.Next(0, i_Columns);
            return guessresult;
        }
    }

    public enum eGameMode
    {
        MultyPlayer,
        SinglePlayer,
    }
}
