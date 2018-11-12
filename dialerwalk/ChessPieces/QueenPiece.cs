using System;
public  class QueenPiece : RookPiece {
    public override string Name => "Queen";
    public override bool PieceCanReach(LayoutPosition p1, LayoutPosition p2)
    {
        return 
            // Queen
            // can reach as bishop 
            new BishopPiece().PieceCanReach(p1,p1)
            // or as Rook 
            || base.PieceCanReach(p1,p2);
    }
}