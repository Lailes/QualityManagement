using System.Text.Json;

namespace TreeBalance.Shared {
    public static class NodeSerializer {
        
        public static string Serialize(Node node) => 
            JsonSerializer.Serialize(node, new JsonSerializerOptions{
                WriteIndented = true
            });

        public static Node Deserialize(string json) =>
            JsonSerializer.Deserialize<Node>(json);

    }
}