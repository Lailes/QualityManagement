namespace TreeBalance.Shared {
    public sealed class Node {
        
        public Node(int key) {
            Key = key;
            Left = Right = null;
        }
        
        public int Key { get; }

        public int Height {
            get {
                var h1 = Left?.Height ?? 0;
                var h2 = Right?.Height ?? 0;
                return (h1 > h2 ? h1 : h2) + 1;
            }
        }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int BalanceFactor => (Right?.Height ?? 0) - (Left?.Height ?? 0);
    }
}