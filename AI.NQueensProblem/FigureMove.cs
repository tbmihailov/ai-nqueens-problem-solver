using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.NQueensProblem
{
    public class FigureMove
    {
        private int stepNumber;
        public int StepNumber
        {
            get { return stepNumber; }
        }

        private int queenId;
        public int QueenId
        {
            get { return queenId; }
        }

        private int fromRow;
        public int FromRow
        {
            get { return fromRow; }
        }

        private int fromColumn;
        public int FromColumn
        {
            get { return fromColumn; }
        }

        private int toRow;
        public int ToRow
        {
            get { return toRow; }
        }

        private int toColumn;
        public int ToColumn
        {
            get { return toColumn; }
        }

        public FigureMove(int stepNumber, int queenId, int fromRow, int fromColumn, int toRow, int toColumn)
        {
            this.stepNumber = stepNumber;
            this.queenId = queenId;
            this.fromRow = fromRow;
            this.fromColumn = fromColumn;
            this.toRow = toRow;
            this.toColumn = toColumn;
        }
    }
}
