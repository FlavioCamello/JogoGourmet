namespace JogoGourmet.Model
{
    public class Node<T>
    {
        public Node(T value) => Data = value;
        public T Data { get; private set; }
        public Node<T> Parent { get; private set; }
        public Node<T> Left { get; private set; }
        public Node<T> Right { get; private set; }

        public void UpdateParentNode(Node<T> node)
        {
            this.Parent = node;
        }

        public void UpdateLeftNode(Node<T> node)
        {
            this.Left = node;
        }

        public void UpdateRightNode(Node<T> node)
        {
            this.Right = node;
        }

        public bool HasChildrens()
        {
            return this.Right != null || this.Left != null;
        }
    }
}
