using System;
namespace SpotifyClone.Core.Utilities.Results.Abstract
{
	public interface IResult
	{
		bool Success { get; }
		string Message { get; }
	}
}

