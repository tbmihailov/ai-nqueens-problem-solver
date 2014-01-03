﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.NQueensProblem
{
    public class Solver
    {
        int _size;
        public Solver(int boardSize)
        {
            _size = boardSize;
            _stepsLog = new List<FigureMove>();
        }

        private List<FigureMove> _stepsLog;
        public List<FigureMove> StepsLog
        {
            get { return _stepsLog; }
        }

        public void Solve(int boardSize)
        {
            Board board = new Board(boardSize);
            board.InitFigurePositions();
            Console.WriteLine("{0} queens", boardSize);
            Console.WriteLine("Initial board:");
            Console.WriteLine(board.ToString());

            int stepCount = 0;
            int queenIndex = 0;
            while (board.CollisionsCnt > 0)
            {
                Figure queen = board.Collisions.Select(kv=>kv.Key).ToArray()[queenIndex];

                int previousRow = queen.Row;
                int previousColumn = queen.Column;

                int queenRow = queen.Row;
                int queenColumn = queen.Column;

                //move queen in column;
                int actualCollisions = board.CollisionsCnt;
                int bestCollisions = actualCollisions;

                int newColumn = 0;
                while (newColumn<boardSize)
                {
                    board.TryMove(queen, queenRow, newColumn);
                    int currentCollisions = board.CollisionsCnt;
                    if (currentCollisions <= bestCollisions)
                    {
                        bestCollisions = currentCollisions;
                        queenColumn = newColumn;
                    }
                    newColumn++;
                }

                board.TryMove(queen, queenRow, queenColumn);

                if (previousColumn == queenColumn && previousRow == queenRow)
                {
                    queenIndex++;
                }
                else
                {
                    stepCount++;
                    AddStepLog(stepCount, queen.Id, queen.Row, queen.Column, queen.Row, newColumn, board);
                    queenIndex = 0;
                }
            }

            Console.WriteLine("=========================");
            Console.WriteLine("Solution in {0} steps", stepCount);
        }

        private void AddStepLog(int stepNumber,int queenId, int fromRow, int fromColumn, int toRow, int toColumn, Board board)
        {
            var figureMove = new FigureMove(stepNumber,queenId, fromRow, fromColumn, toRow, toColumn);
            StepsLog.Add(figureMove);

            Console.WriteLine("Step:{0}", figureMove.StepNumber);
            Console.WriteLine(board);
            Console.WriteLine("Collisions {0}", board.CollisionsCnt);
        }

        internal void Solve()
        {
            Solve(_size);
        }
    }
}
