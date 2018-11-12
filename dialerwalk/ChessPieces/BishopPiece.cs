using System;
public  class BishopPiece : ChessPiece {
    public override string Name => "Bishop";
    public override bool PieceCanReach(LayoutPosition p1, LayoutPosition p2)
    {
        // on diagonal
        return Math.Abs(p1.X-p2.X)==Math.Abs(p1.Y-p2.Y);
    }
}