using System;
public  class RookPiece : ChessPiece {
    public override string Name => "Rook";
    public override bool PieceCanReach(LayoutPosition p1, LayoutPosition p2)
    {
        return p1.X == p2.X || p1.Y == p2.Y;
    }
}