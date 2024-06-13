
namespace JogoGourmet.Model
{
    public class GameStore
    {
        private static string MESSAGE_INVALID_NAME = "Nome Inválido. Informe um novo prato!";
        private static string MESSAGE_COMPLETE_INVALID_ANSWER = "Resposta Inválida! Digite S para Sim ou N para Não.";
        private static string MESSAGE_INVALID_ANSWER = "Resposta Inválida!";
        private static string MESSAGE_IF_CORRECT = "Acertei!";
        private static string TEXT_QUESTION_PLATE = "Qual prato você pensou?:";
        private static string VALUE_ENTER = "ENTER";
        
        private static string VALUE_YES = "S";
        private static string VALUE_NO = "N";

        public Node<Plate> StartGame()
        {
            var root = new Node<Plate>(new Plate("massa"));
            var nodeLeft = new Node<Plate>(new Plate("Bolo de Chocolate"));
            var nodeRight = new Node<Plate>(new Plate("Lasanha"));

            InicializeNode(root, nodeRight, nodeLeft);
           
            return root;
        }

        private void InicializeNode(Node<Plate> root, Node<Plate> nodeRight, Node<Plate> nodeLeft)
        {
            root.UpdateLeftNode(nodeLeft);
            root.UpdateRightNode(nodeRight);
            nodeLeft.UpdateParentNode(root);
            nodeRight.UpdateParentNode(root);
        }

        private Node<Plate> AddNewRoot(Node<Plate> root, string message)
        {
            var newNode = GetNewPlate(message);
            return newNode;
        }

        private static Node<Plate> GetNewPlate(string message)
        {
            Console.WriteLine(message);
            
            var name = string.Empty;

            while (true)
            {
                name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine(MESSAGE_INVALID_NAME);
                }
                else
                {
                    break;
                }
            }

            return new Node<Plate>(new Plate(name));
        }

        public void LookUp(Node<Plate> node)
        {
            string answer;
            while (true)
            {
                Console.Clear();
                answer = GetAnswer($"O prato que você escolheu é {node.Data} ? (Responda S ou N)");
                if ((!answer.Contains(VALUE_YES) && !answer.Contains(VALUE_NO)) || answer.Equals(VALUE_ENTER))
                {
                    Console.WriteLine(MESSAGE_COMPLETE_INVALID_ANSWER);
                }
                else
                {
                    break;
                }
            }
            if (node.HasChildrens())
            {
                this.LookUp(answer.Equals(VALUE_YES)
                    ? node.Right
                    : node.Left);
            }
            else
            {
                if (answer.Equals(VALUE_YES))
                {
                    if (!node.HasChildrens())
                    {
                        Console.WriteLine(MESSAGE_IF_CORRECT);
                        Console.WriteLine();
                    }
                }
                else
                {
                    var newChild = AddNewRoot(node, TEXT_QUESTION_PLATE);
                    var lastChild = AddNewRoot(newChild, $"{newChild.Data} é __________ mas {node.Data} não.");

                    RebalanceTree(node, newChild, lastChild);
                }
            }
        }

        static void RebalanceTree(Node<Plate> root, Node<Plate> newChild, Node<Plate> lastChild)
        {
            var nodeParent = root.Parent;
            if (nodeParent.Right == root)
            {
                nodeParent.UpdateRightNode(lastChild);
                root.UpdateParentNode(newChild);
                newChild.UpdateParentNode(lastChild);
                lastChild.UpdateParentNode(nodeParent);
                lastChild.UpdateRightNode(newChild);
                lastChild.UpdateLeftNode(root);
            }
            else if (nodeParent.Right == null)
            {
                var newParent = nodeParent.Parent;
                newParent.UpdateLeftNode(lastChild);
                root.UpdateParentNode(newChild);
                newChild.UpdateParentNode(lastChild);
                lastChild.UpdateParentNode(newParent);
                lastChild.UpdateRightNode(newChild);
                lastChild.UpdateLeftNode(root);
            }
            else if (nodeParent.Left == root)
            {
                nodeParent.UpdateLeftNode(lastChild);
                root.UpdateParentNode(newChild);
                newChild.UpdateParentNode(lastChild);
                lastChild.UpdateParentNode(nodeParent);
                lastChild.UpdateRightNode(newChild);
                lastChild.UpdateLeftNode(root);
            }
            else if (nodeParent.Left == null)
            {
                var newParent = nodeParent.Parent;
                newParent.UpdateLeftNode(lastChild);
                root.UpdateParentNode(newChild);
                newChild.UpdateParentNode(lastChild);
                lastChild.UpdateParentNode(newParent);
                lastChild.UpdateRightNode(newChild);
                lastChild.UpdateLeftNode(root);
            }
        }

        public string GetAnswer(string message)
        {
            var answer = string.Empty;
            
            Console.WriteLine(message);

            try
            {
                answer = Console.ReadKey().Key.ToString().ToUpper();
                
                Console.WriteLine(string.Empty);
                Console.WriteLine(string.Empty);
            }
            catch (Exception)
            {
                Console.WriteLine(MESSAGE_INVALID_ANSWER);
            }

            return answer;
        }
    }
}
