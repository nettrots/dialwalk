using System;
public  class KnightPiece : ChessPiece {
    public override string Name => "Knight";
    public override bool PieceCanReach(LayoutPosition p1, LayoutPosition p2)
    {
        return Math.Abs(p1.X - p2.X) == 2 &&  Math.Abs(p1.Y - p2.Y) == 1
            || Math.Abs(p1.X - p2.X) == 1 &&  Math.Abs(p1.Y - p2.Y) == 2;
    }
}