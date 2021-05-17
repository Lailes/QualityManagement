using System.Collections.Generic;
using System.Linq;

namespace TreeBalance.Shared {
    
    public static class BalanceExample{
        
        public static Node Balance(Node node) {
            static Node Bal(Node node) {
                static Node RotateRight(Node p) {
                    var q = p.Left;
                    p.Left = q.Right;
                    q.Right = p;
                    return q;
                }
            
                static Node RotateLeft(Node q) {
                    var p = q.Right;
                    q.Right = p.Left;
                    p.Left = q;
                    return p;    
                }
                
                switch (node.BalanceFactor) {
                    case 2: {
                        if (node.Right.BalanceFactor < 0) {
                            node.Right = RotateRight(node.Right);
                        }

                        return RotateLeft(node);
                    }
                    case -2: {
                        if (node.Left.BalanceFactor > 0) {
                            node.Left = RotateLeft(node.Left);
                        }

                        return RotateRight(node);
                    }
                    default:
                        return node;
                }
            }
            
            static Node Ins(Node p, int k) {
                if (p == null) return new Node(k);
                if (k < p.Key) {
                    p.Left = Ins(p.Left, k);
                }
                else {
                    p.Right = Ins(p.Right, k);
                }

                return Bal(p);
            }

            return GetNodeList(node).Aggregate<Node, Node>(null, (current, nd) => Ins(current, nd.Key));
        }

        public static Node Insert(Node p, int k) {
            if (p == null) return new Node(k);
            if (k < p.Key) {
                p.Left = Insert(p.Left, k);
            }
            else {
                p.Right = Insert(p.Right, k);
            }

            return p;
        }
        

        public static bool IsAvl(Node node) {
            var list = GetNodeList(node);
           return list.All(n => n.BalanceFactor <= 1 && n.BalanceFactor >= -1);
        }

        public static Node CreateNode(string line) =>
            line
                .Trim()
                .Split(' ')
                .Select(int.Parse)
                .Aggregate<int, Node>(null, Insert);

        private static IEnumerable<Node> GetNodeList(Node node) {
            var list = new List<Node>();

            void Step(Node n) {
                list.Add(n);
                if (n.Left != null) Step(n.Left);
                if (n.Right != null) Step(n.Right);
            }

            Step(node);
            return list;
        }

        public static bool VerifyTreeString(string line) => line.Trim().Split(' ').All(l => int.TryParse(l, out _));
    }
}