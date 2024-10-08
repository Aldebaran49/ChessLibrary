using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public class EnPassant : Move
    {
        public override MoveType Type => MoveType.EnPassant;
        public override Position FromPos { get; }
        public override Position ToPos { get; }
        private readonly Position capturPos;
        public EnPassant(Position from, Position to)
        {
            FromPos = from;
            ToPos = to;
            capturPos = new Position(from.Row, to.Column);
        }
        public override bool Execute(Board board)
        {
            new NormalMove(FromPos, ToPos).Execute(board);
            board[capturPos] = null;
            return true;
        }
    }
}
