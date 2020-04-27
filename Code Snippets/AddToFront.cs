public void AddToFront(T data)
{
	if (begin == null)
	{
		begin = new Node(data, null);
	}
	else
	{
		Node temp = new Node(data, null);

		temp.Next = begin;

		begin = temp;
	}
}