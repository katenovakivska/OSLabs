using System.Threading;

namespace OS6
{
	class Program
	{
		//static int func1(int a, int b)
		//{
		//	int res = 0;

		//	for (int i = 0; i < 10; i++)
		//	{
		//		Thread.Sleep(1);
		//		if (i > 8)
		//			res = resultOfSum(a, b);
		//		if (res > 0)
		//			return res;
		//	}
		//	return res;
		//}
		static int func2(int a, int b, int c)
		{
			int res = 0;

			for (int i = 0; i < 10; i++)
			{
				c++;
				if (c > b)
				{
					Thread.Sleep(1);
					if (i > 8)
					{
						res = resultOfSum(a, b);
						return res;
					}
						
				}
					
				else
					res = func2(a, b, c);
			}

			return res;
		}


		static int resultOfSum(int a, int b)
		{
			 return a + b;
		}

		static void Main(string[] args)
		{
			func2(51, 110, 12);
		}
	}
}
