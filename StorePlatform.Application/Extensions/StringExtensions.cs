using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePlatform.Application.Extensions
{
	public static class StringExtensions
	{
		public static bool IsNotNullOrEmpty(this string? str)
		{
			return !string.IsNullOrEmpty(str);
		}
	}
}
