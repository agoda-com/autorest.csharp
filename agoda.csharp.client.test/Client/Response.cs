using System;
using System.Collections.Generic;
namespace Agoda.Csharp.Client.Test
{
    using System.Collections;
	public class Response
	{
		public bool IsSuccessful { get; set; } = false;
		public int HttpCode { get; set; } = 0;
		public byte[] RawResult { get; set; }
	}
	public class Response<T> : Response
	{
		public T Result { get; set; }
	}
}
