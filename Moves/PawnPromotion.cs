using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public class PawnPromotion : Move
    {
        public override MoveType Type => MoveType.PawnPromotion;
        public override Position FromPos { get; }
        public override Position ToPos { get; }
        private readonly PieceType newType;
        public PawnPromotion(Position from,Position to, PieceType newType)
        {
            FromPos = from;
            ToPos = to;
            this.newType = newType;
        }
        private Piece CreatePromotionPiece(Player color)
        {
            Piece newPiece = null;

            switch ((PieceType)Type)
            {
                case PieceType.Knight:
                    newPiece = new Knight(color);
                    break;
                case PieceType.Bishop:
                    newPiece = new Bishop(color);
                    break;
                case PieceType.Rook:
                    newPiece = new Rook(color);
                    break;
                default:
                    newPiece = new Queen(color);
                    break;
            }
            return newPiece;
        }
        public override bool Execute(Board board)
        {
            Piece pawn = board[FromPos];
            board[FromPos] = null;
            Piece promotionPiece = CreatePromotionPiece(pawn.Color);
            promotionPiece.HasMoved = true;
            board[ToPos] = promotionPiece;
            return true;
        }

    }
}
