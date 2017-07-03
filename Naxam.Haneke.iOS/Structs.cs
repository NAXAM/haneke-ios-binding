﻿using System;
using ObjCRuntime;
using UIKit;

namespace Haneke
{
	[Native]
	public enum HNKScaleMode : long
	{
		Fill = UIViewContentMode.ScaleToFill,
		AspectFit = UIViewContentMode.ScaleAspectFit,
		AspectFill = UIViewContentMode.ScaleAspectFill,
		None
	}

	[Native]
	public enum HNKPreloadPolicy : long
	{
		None,
		LastSession,
		All
	}

	public enum HNKErrorCode
	{
		ImageNotFound = -100,
		FetcherMustReturnImage = -200,
		DiskCacheCannotReadImageFromData = -300,
		DiskFetcherInvalidData = -500,
		InvalidData = -400,
		MissingData = -401,
		InvalidStatusCode = -402
	}
}
