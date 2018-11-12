using System;
public class KingPiece : ChessPiece {
    public override string Name => "King";
    public override bool PieceCanReach(LayoutPosition p1, LayoutPosition p2)
    {
        return Math.Abs (p1.X - p2.X) < 2 && Math.Abs (p1.Y - p2.Y) < 2;
    }
}
