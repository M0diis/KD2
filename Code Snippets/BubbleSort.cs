public void BubbleSort()
{
	if (begin == null)
	{
		return;
	}

	bool done = true;

	while (done)
	{
		done = false;

		for (Node d = begin; d != null && d.Next != null; d = d.Next)
		{
			if (d.Data.CompareTo(d.Next.Data) > 0)
			{
				T temp = d.Data;

				d.Data = d.Next.Data;

				d.Next.Data = temp;

				done = true;
			}
		}
	}
}