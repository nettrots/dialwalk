using System;
public abstract class ChessPiece
{
    public abstract string Name {get;} 
    public abstract bool PieceCanReach(LayoutPosition p1, LayoutPosition p2);
    public int[,] GenerateAdjacencyMatrix(DialLayout layout) {
        var width = layout.LayoutWidth;
        var height = layout.LayoutHeigth;
        var adjacency = new int[layout.ElementsCount, layout.ElementsCount];

        for (var i1 = 0; i1 < width; i1++) {
            for (var j1 = 0; j1 < height; j1++) {

                for (var i2 = 0; i2 < width; i2++) {
                    for (var j2 = 0; j2 < height; j2++) {
                        
                        var p1 = new LayoutPosition(layout,i1,j1);
                        var p2 = new LayoutPosition(layout,i2,j2);

                        if (p1.Ordinal == p2.Ordinal) continue;
        
                        adjacency[p1.Ordinal,p2.Ordinal] = this.PieceCanReach(p1,p2) ? 1 : 0;
                    }
                }
            }
        }
        return adjacency;
    }
}