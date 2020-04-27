public void Add(T data)
{
	if (begin == null)
	{
		begin = new Node(data, null);

		end = begin;
	}
	else
	{
		Node temp = new Node(data, null);

		end.Next = temp;
		end = temp;

	}
}