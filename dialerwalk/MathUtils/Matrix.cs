using System;

public static class MatrixExt {

    public static void PrintMatrix<T> (this T[, ] matrix) {
        Console.WriteLine ("Printing matrix:");
        for (var i = 0; i < matrix.GetLength (0); i++) {
            for (var j = 0; j < matrix.GetLength (1); j++) {
                Console.Write (matrix[i, j]);
                Console.Write (",");
            }
            Console.WriteLine ();
        }
    }

    public static int SumOfElements (this int[, ] matrix) {
        int result = 0;
        for (var i = 0; i < matrix.GetLength (0); i++) {
            for (var j = 0; j < matrix.GetLength (1); j++) {
                result += matrix[i, j];
            }
        }
        return result;
    }

    public static int[,] IdentityMatrix(int width){
        var result = new int[width,width];
          for (var i = 0; i < width; i++) {
                result[i,i] = 1;
            }
        return result;
    }

    public static void RemoveGraphVertex (this int[, ] adjacency, int elemNumber) {
        if (elemNumber > adjacency.GetLength (0) - 1) return;

        for (var i = 0; i < adjacency.GetLength (0); i++) {
            adjacency[elemNumber, i] = 0;
            adjacency[i, elemNumber] = 0;
        }
    }

    public static int[, ] Pow (this int[, ] matrix, int pow) {
        var matrixCopy = (int[, ]) matrix.Clone ();
        for (var i = 0; i < pow; i++) {
            matrix = matrix.MultiplyBy (matrixCopy);
        }
        return matrix;
    }

    public static int[, ] MultiplyBy (this int[, ] matrixA, int[, ] matrixB) {
        return MatrixProduct (matrixA, matrixB);
    }
    public static int[, ] MatrixProduct (int[, ] matrixA, int[, ] matrixB) {
        int aRows = matrixA.GetLength (0);
        int aCols = matrixA.GetLength (1);
        int bRows = matrixB.GetLength (0);
        int bCols = matrixB.GetLength (1);
        if (aCols != bRows)
            throw new Exception ("Non-conformable matrices in MatrixProduct");
        var result = new int[aRows, bCols];

        for (int i = 0; i < aRows; ++i) // each row of A
            for (int j = 0; j < bCols; ++j) // each col of B
                for (int k = 0; k < aCols; ++k)
                    result[i, j] += matrixA[i, k] * matrixB[k, j];
        return result;
    }

}