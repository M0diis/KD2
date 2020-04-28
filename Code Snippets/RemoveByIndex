public object RemoveByIndex(int index)
{
    if (this.Empty) return null;

    if (index < 0 || index > Count) return null;

        Node<type> current = this.HeadNode;

        object result = null;

        if (index == 0)
        {
            result = current.Data;

            this.HeadNode = current.Next;
        }
        else
        {
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }

            result = current.Next.Data;

            current.Next = current.Next.Next;
        }

        Count--;

        return result;
}
