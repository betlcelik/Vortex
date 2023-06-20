using System;
using SpotifyClone.Core.Utilities.Results.Abstract;

namespace SpotifyClone.Core.Utilities.Results.Concretes
{
	public class Result : IResult
	{
		public Result(bool success, string message):this(success)
		{
			Message = message;
		}

		public Result(bool success)
		{
			Success = success;
		}

		public bool Success { get; }

		public string Message { get; }
    }
}

