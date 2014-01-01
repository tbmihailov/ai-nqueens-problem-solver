using System;
using System.Collections.Generic;
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
        
        private void Solve(int boardSize)
        {
            Board board = new Board(boardSize);
            board.InitFigurePositions();

            int stepCount = 0;
            while (board.Collisions() > 0)
            {
                Figure queen = board.GetQueenWithMaxCollisions();

                //move queen in column;
                int newColumn = 0;

                int actualCollisions = board.Collisions();
                while (board.TestCollisionsForMove(queen, queen.Row, newColumn) >= actualCollisions && newColumn<boardSize)
                {
                    newColumn++;
                }

                if (newColumn != boardSize)//max column - no better position for this queen
                {
                    stepCount++;

                    AddStepLog(stepCount,queen.Id, queen.Row, queen.Column, queen.Row, newColumn);
                    board.Move(queen, queen.Row, newColumn);
                }
            }
        }

        private void AddStepLog(int stepNumber,int queenId, int fromRow, int fromColumn, int toRow, int toColumn)
        {
            var figureMove = new FigureMove(stepNumber,queenId, fromRow, fromColumn, toRow, toColumn);
            StepsLog.Add(figureMove);
        }

        internal void Solve()
        {
            Solve(_size);
        }
    }
}
