using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.NQueensProblem
{
    public class Figure
    {
        public Figure(int row, int column, int size, int id)
        {
            SetPosition(row, column);
            _id = id;
            _size = size;
        }

        public void SetPosition(int row, int column)
        {
            _row = row;
            _column = column;

            //diagonal 1
            if (column >= row)
            {
                _diagonal1 = (column - row);
            }
            else
            {
                _diagonal1 = (-row + column);
            }

            //diagonal 2
            int projectedRow = (_size - row + 1);
            int projectedColumn = column;
            if (projectedColumn >= projectedRow)
            {
                _diagonal2 = (projectedColumn - projectedRow);
            }
            else
            {
                _diagonal2 = (-projectedRow + projectedColumn);
            }
            
        }

        public int _size;

        private int _id;
        public int Id
        {
            get { return _id; }
        }

        private int _row;
        public int Row
        {
            get { return _row; }
        }

        private int _column;
        public int Column
        {
            get { return _column; }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            int hashcode = unchecked(Row * 314159 + Column);
            return hashcode;
        }

        public bool IsInCollision(Figure other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("figure");
            }

            if ((this.Row == other.Row)
                || (this.Column == other.Column)
                || (Math.Abs(this.Row - other.Row) == Math.Abs(this.Column - other.Column)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        int _diagonal1;
        public int Diagonal1
        {
            get
            {
                return _diagonal1;
            }
        }

        int _diagonal2;
        public int Diagonal2
        {
            get
            {
                return _diagonal2;
            }
        }

    }
}
