public object Get(int index)
{
    if (index >= 0 && index < this.Count)
    {
        if (this.Empty)
        {
            return null;
        }

        Node<type> current = this.HeadNode;

        for (int i = 0; i < index; i++)
        {
            current = current.Next;
        }

        return current.Data;
    }

    return null;
}
