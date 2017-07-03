using System;
using ObjCRuntime;

namespace Haneke
{
	[Native]
	public enum HNKScaleMode : nint
	{
		Fill = UIViewContentModeScaleToFill,
		AspectFit = UIViewContentModeScaleAspectFit,
		AspectFill = UIViewContentModeScaleAspectFill,
		None
	}

	[Native]
	public enum HNKPreloadPolicy : nint
	{
		None,
		LastSession,
		All
	}

	[Verify (InferredFromMemberPrefix)]
	public enum HNKError
	{
		ImageNotFound = -100,
		FetcherMustReturnImage = -200,
		DiskCacheCannotReadImageFromData = -300
	}

	public enum 
	{
		HNKErrorDiskFetcherInvalidData = -500
	}

	[Verify (InferredFromMemberPrefix)]
	public enum HNKErrorNetworkFetcher
	{
		InvalidData = -400,
		MissingData = -401,
		InvalidStatusCode = -402
	}
}
