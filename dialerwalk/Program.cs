using System;
using System.Linq;

namespace dialwallk {
    class Program {
        static void Main (string[] args) {

            DialLayout layout;
            try {
                layout = new DialLayout ("layout.txt");
            } catch (System.Exception ex) {
                Console.WriteLine ("Error occured:");
                Console.WriteLine (ex.Message);
                Console.ReadLine ();
                return;
            }
            //layout.Matrix.PrintMatrix();

            string choice = null;

            while (true) {
                Console.WriteLine ("Type chess piece name (queen, king , bishop, rook, knight, pawn) or 'exit' to quit :");
                choice = Console.ReadLine ();

                if (choice.Equals ("Exit", StringComparison.OrdinalIgnoreCase)) {
                    Console.WriteLine ("Quiting...");

                    return;
                }

                try {
                    var walker = new Walker (choice, layout);
                    walker.ApplyRulesFromFile ("rules.txt");
                    var walkResult = walker.Walk ();
                    //walkResult.PrintMatrix();

                    Console.WriteLine ($"Number of possible phone numbers for {choice}: {walkResult.SumOfElements():N0}");
                } catch (System.Exception ex) {
                    Console.WriteLine ("Error occured:");
                    Console.WriteLine (ex.Message);
                }

                Console.WriteLine ("-----------------------------");
                Console.WriteLine ();
            }

        }
    }
}