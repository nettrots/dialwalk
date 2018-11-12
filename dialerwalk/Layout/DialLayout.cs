using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class DialLayout {
    public readonly string[, ] Matrix;
    public int LayoutWidth => Matrix.GetLength (0);
    public int LayoutHeigth => Matrix.GetLength (1);
    public int ElementsCount => LayoutWidth * LayoutHeigth;

    public DialLayout () {
        Matrix = new string[0, 0];
    }
    public DialLayout (string fileName) {
        if (!File.Exists (fileName)) {
            throw new FileNotFoundException ("Layout file does not exists. Halting application",fileName);
        }
        var lLines = File.ReadLines (fileName).Select (l => l.Split (',').ToList ()).ToList ();
        this.Matrix = new string[lLines.Count, lLines.Max (l => l.Count)];
        for (var i = 0; i < lLines.Count; i++) {
            for (var j = 0; j < lLines[i].Count; j++) {
                this.Matrix[i, j] = lLines[i][j];
            }
        }
    }

    public LayoutPosition GetPosition (string element) {
        return GetAllPositions (element).FirstOrDefault ();
    }

    public List<LayoutPosition> GetAllPositions (string element) {
        var positions = new List<LayoutPosition> ();
        for (var i = 0; i < LayoutWidth; i++) {
            for (var j = 0; j < LayoutHeigth; j++) {
                if (this.Matrix[i, j] == element) { positions.Add (new LayoutPosition (this, i, j)); }
            }
        }
        return positions;
    }

}