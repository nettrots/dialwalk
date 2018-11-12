        public class LayoutPosition {
            private int multiplier;
            public LayoutPosition (DialLayout layout, int x, int y) {
                multiplier = layout.LayoutHeigth;
                this.X = x;
                this.Y = y;
            }
            public int X { get; private set; }
            public int Y { get; private set; }
            public int Ordinal => X * multiplier + Y;

        }