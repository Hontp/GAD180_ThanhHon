public class DecisionTree<T>
{
    class Node
    {
        public T Data;
        public Node left;
        public Node right;
    }

    private Node root = null;
    private int nodeCount = 0;

    public delegate void compute(ref T Data);
    public delegate int comparator(ref T left, ref T right);

    private Node findNode(Node node, Node parent, comparator func)
    {
       if (parent == null)
        {
            return null;
        }
       else if ( func( ref node.Data, ref parent.Data) == -1)
        {
            return findNode( node, parent.left, func);
        }
       else if ( func( ref node.Data, ref parent.Data) == 1 )
        {
            return findNode( node, parent.right, func);
        }

        return parent;
    }

    
    public void Insert(T Data, comparator func)
    {
        Node node = new Node
        {
            Data = Data
        };

        if (root == null)
        {
            root = node;
        }
        else
        {
            newNode(node, root, func);
        }
    }

    public T Search( T Data, comparator func)
    {
        T result;
        Node temp = new Node();
        temp.Data = Data;

        if (findNode(temp, root, func) != null)
        {
            result = findNode(temp, root ,func).Data;
        }
        else
        {
            result = default;
        }

        return result;
    }

    public void ComputeData(compute func)
    {
        InOrder(root, func);
    }

    private void InOrder(Node node, compute func)
    {
        if ( node != null)
        {
            InOrder(node.left, func);
            func(ref node.Data);
            InOrder(node.right, func);
        }
    }

    private void newNode(Node node, Node parent, comparator func)
    {
        if (func(ref node.Data, ref parent.Data) == -1)
        {
            if (parent.left == null)
            {
                parent.left = node;
            }
            else
            {
                newNode(node, parent.left, func);
            }
        }
        else
        {
            if (parent.right == null)
            {
                parent.right = node;
            }
            else
            {
                newNode(node, parent.right, func);
            }
        }
    }
    
   
}
