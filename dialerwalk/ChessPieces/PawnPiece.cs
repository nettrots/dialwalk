using System;
public  class PawnPiece : ChessPiece {
    public override string Name => "Pawn";
    public override bool PieceCanReach(LayoutPosition p1, LayoutPosition p2)
    {
        return p1.X + 1 == p2.X && p1.Y == p2.Y;
    }
}
