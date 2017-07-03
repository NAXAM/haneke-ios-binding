using System;
using CoreFoundation;
using CoreGraphics;
using Foundation;
using Haneke;
using ObjCRuntime;
using UIKit;

namespace Haneke
{
	// @interface HNKCache : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface HNKCache
	{
		// -(instancetype)initWithName:(NSString *)name __attribute__((objc_designated_initializer));
		[Export ("initWithName:")]
		[DesignatedInitializer]
		IntPtr Constructor (string name);

		// +(HNKCache *)sharedCache;
		[Static]
		[Export ("sharedCache")]
		HNKCache SharedCache { get; }

		// -(void)registerFormat:(HNKCacheFormat *)format;
		[Export ("registerFormat:")]
		void RegisterFormat (HNKCacheFormat format);

		// @property (readonly, nonatomic) NSDictionary * formats;
		[Export ("formats")]
		NSDictionary Formats { get; }

		// -(BOOL)fetchImageForFetcher:(id<HNKFetcher>)fetcher formatName:(NSString *)formatName success:(void (^)(UIImage *))successBlock failure:(void (^)(NSError *))failureBlock;
		[Export ("fetchImageForFetcher:formatName:success:failure:")]
		bool FetchImageForFetcher (HNKFetcher fetcher, string formatName, Action<UIImage> successBlock, Action<NSError> failureBlock);

		// -(BOOL)fetchImageForKey:(NSString *)key formatName:(NSString *)formatName success:(void (^)(UIImage *))successBlock failure:(void (^)(NSError *))failureBlock;
		[Export ("fetchImageForKey:formatName:success:failure:")]
		bool FetchImageForKey (string key, string formatName, Action<UIImage> successBlock, Action<NSError> failureBlock);

		// -(void)setImage:(UIImage *)image forKey:(NSString *)key formatName:(NSString *)formatName;
		[Export ("setImage:forKey:formatName:")]
		void SetImage (UIImage image, string key, string formatName);

		// -(void)removeAllImages;
		[Export ("removeAllImages")]
		void RemoveAllImages ();

		// -(void)removeImagesOfFormatNamed:(NSString *)formatName;
		[Export ("removeImagesOfFormatNamed:")]
		void RemoveImagesOfFormatNamed (string formatName);

		// -(void)removeImagesForKey:(NSString *)key;
		[Export ("removeImagesForKey:")]
		void RemoveImagesForKey (string key);
	}

    partial interface IHNKFetcher {}

	// @protocol HNKFetcher <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface HNKFetcher
	{
		// @required @property (readonly, nonatomic) NSString * key;
		[Abstract]
		[Export ("key")]
		string Key { get; }

		// @required -(void)fetchImageWithSuccess:(void (^)(UIImage *))successBlock failure:(void (^)(NSError *))failureBlock;
		[Abstract]
		[Export ("fetchImageWithSuccess:failure:")]
		void FetchImageWithSuccess (Action<UIImage> successBlock, Action<NSError> failureBlock);

		// @optional -(void)cancelFetch;
		[Export ("cancelFetch")]
		void CancelFetch ();
	}

	// @interface HNKCacheFormat : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface HNKCacheFormat
	{
		// @property (assign, nonatomic) BOOL allowUpscaling;
		[Export ("allowUpscaling")]
		bool AllowUpscaling { get; set; }

		// @property (assign, nonatomic) CGFloat compressionQuality;
		[Export ("compressionQuality")]
		nfloat CompressionQuality { get; set; }

		// @property (readonly, nonatomic) NSString * name;
		[Export ("name")]
		string Name { get; }

		// @property (assign, nonatomic) CGSize size;
		[Export ("size", ArgumentSemantic.Assign)]
		CGSize Size { get; set; }

		// @property (assign, nonatomic) HNKScaleMode scaleMode;
		[Export ("scaleMode", ArgumentSemantic.Assign)]
		HNKScaleMode ScaleMode { get; set; }

		// @property (assign, nonatomic) unsigned long long diskCapacity;
		[Export ("diskCapacity")]
		ulong DiskCapacity { get; set; }

		// @property (readonly, nonatomic) unsigned long long diskSize;
		[Export ("diskSize")]
		ulong DiskSize { get; }

		// @property (assign, nonatomic) HNKPreloadPolicy preloadPolicy;
		[Export ("preloadPolicy", ArgumentSemantic.Assign)]
		HNKPreloadPolicy PreloadPolicy { get; set; }

		// @property (copy, nonatomic) UIImage * (^preResizeBlock)(NSString *, UIImage *);
		[Export ("preResizeBlock", ArgumentSemantic.Copy)]
		Func<NSString, UIImage, UIImage> PreResizeBlock { get; set; }

		// @property (copy, nonatomic) UIImage * (^postResizeBlock)(NSString *, UIImage *);
		[Export ("postResizeBlock", ArgumentSemantic.Copy)]
		Func<NSString, UIImage, UIImage> PostResizeBlock { get; set; }

		// -(instancetype)initWithName:(NSString *)name __attribute__((objc_designated_initializer));
		[Export ("initWithName:")]
		[DesignatedInitializer]
		IntPtr Constructor (string name);

		// -(UIImage *)resizedImageFromImage:(UIImage *)image;
		[Export ("resizedImageFromImage:")]
		UIImage ResizedImageFromImage (UIImage image);
	}

	[Static]
	partial interface HNKErrorConstants
	{
		// extern NSString *const HNKErrorDomain;
		[Field ("HNKErrorDomain", "__Internal")]
		NSString Domain { get; }

		// extern NSString *const HNKExtendedFileAttributeKey;
		[Field ("HNKExtendedFileAttributeKey", "__Internal")]
		NSString HNKExtendedFileAttributeKey { get; }
	}

	// @interface HNKDiskCache : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface HNKDiskCache
	{
		// -(instancetype)initWithDirectory:(NSString *)directory capacity:(unsigned long long)capacity __attribute__((objc_designated_initializer));
		[Export ("initWithDirectory:capacity:")]
		[DesignatedInitializer]
		IntPtr Constructor (string directory, ulong capacity);

		// @property (assign, nonatomic) unsigned long long capacity;
		[Export ("capacity")]
		ulong Capacity { get; set; }

		// @property (readonly, nonatomic) unsigned long long size;
		[Export ("size")]
		ulong Size { get; }

		// @property (readonly, nonatomic) dispatch_queue_t queue;
		[Export ("queue")]
		DispatchQueue Queue { get; }

		// -(void)setData:(NSData *)data forKey:(NSString *)key;
		[Export ("setData:forKey:")]
		void SetData (NSData data, string key);

		// -(void)fetchDataForKey:(NSString *)key success:(void (^)(NSData *))successBlock failure:(void (^)(NSError *))failureBlock;
		[Export ("fetchDataForKey:success:failure:")]
		void FetchDataForKey (string key, Action<NSData> successBlock, Action<NSError> failureBlock);

		// -(void)removeDataForKey:(NSString *)key;
		[Export ("removeDataForKey:")]
		void RemoveDataForKey (string key);

		// -(void)removeAllData;
		[Export ("removeAllData")]
		void RemoveAllData ();

		// -(void)enumerateDataByAccessDateUsingBlock:(void (^)(NSString *, NSData *, NSDate *, BOOL *))block;
		[Export ("enumerateDataByAccessDateUsingBlock:")]
		unsafe void EnumerateDataByAccessDateUsingBlock (EnumerateDataByAccessDateUsingBlock block);

		// -(void)updateAccessDateForKey:(NSString *)key data:(NSData *(^)())lazyData;
		[Export ("updateAccessDateForKey:data:")]
		void UpdateAccessDateForKey (string key, Func<NSData> lazyData);
	}

    delegate void EnumerateDataByAccessDateUsingBlock(NSString p0, NSData p1, NSDate p2, out bool p3);

	// @interface HNKDiskFetcher : NSObject <HNKFetcher>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface HNKDiskFetcher : IHNKFetcher
	{
		// -(instancetype)initWithPath:(NSString *)path __attribute__((objc_designated_initializer));
		[Export ("initWithPath:")]
		[DesignatedInitializer]
		IntPtr Constructor (string path);

		// -(void)cancelFetch;
		[Export ("cancelFetch")]
		void CancelFetch ();
	}

	// @interface HNKNetworkFetcher : NSObject <HNKFetcher>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface HNKNetworkFetcher : IHNKFetcher
	{
		// -(instancetype)initWithURL:(NSURL *)URL __attribute__((objc_designated_initializer));
		[Export ("initWithURL:")]
		[DesignatedInitializer]
		IntPtr Constructor (NSUrl URL);

		// @property (readonly, nonatomic) NSURL * URL;
		[Export ("URL")]
		NSUrl URL { get; }

		// -(void)cancelFetch;
		[Export ("cancelFetch")]
		void CancelFetch ();
	}

	// @interface Subclassing (HNKNetworkFetcher)
	[Category]
	[BaseType (typeof(HNKNetworkFetcher))]
	interface HNKNetworkFetcher_Subclassing
	{
        // @property (readonly, nonatomic) NSURLSession * URLSession;
        [Export("URLSession")]
        NSUrlSession URLSession();
	}

	// @interface HNKSimpleFetcher : NSObject <HNKFetcher>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface HNKSimpleFetcher : IHNKFetcher
	{
		// -(instancetype)initWithKey:(NSString *)key image:(UIImage *)image __attribute__((objc_designated_initializer));
		[Export ("initWithKey:image:")]
		[DesignatedInitializer]
		IntPtr Constructor (string key, UIImage image);
	}

	// @interface Haneke (UIImageView)
	[Category]
	[BaseType (typeof(UIImageView))]
	interface UIImageView_Haneke
	{
		// -(void)hnk_setImageFromFile:(NSString *)path;
		[Export ("hnk_setImageFromFile:")]
		void Hnk_setImageFromFile (string path);

		// -(void)hnk_setImageFromFile:(NSString *)path placeholder:(UIImage *)placeholder;
		[Export ("hnk_setImageFromFile:placeholder:")]
		void Hnk_setImageFromFile (string path, UIImage placeholder);

		// -(void)hnk_setImageFromFile:(NSString *)path placeholder:(UIImage *)placeholder success:(void (^)(UIImage *))successBlock failure:(void (^)(NSError *))failureBlock;
		[Export ("hnk_setImageFromFile:placeholder:success:failure:")]
		void Hnk_setImageFromFile (string path, UIImage placeholder, Action<UIImage> successBlock, Action<NSError> failureBlock);

		// -(void)hnk_setImageFromURL:(NSURL *)url;
		[Export ("hnk_setImageFromURL:")]
		void Hnk_setImageFromURL (NSUrl url);

		// -(void)hnk_setImageFromURL:(NSURL *)url placeholder:(UIImage *)placeholder;
		[Export ("hnk_setImageFromURL:placeholder:")]
		void Hnk_setImageFromURL (NSUrl url, UIImage placeholder);

		// -(void)hnk_setImageFromURL:(NSURL *)url placeholder:(UIImage *)placeholder success:(void (^)(UIImage *))successBlock failure:(void (^)(NSError *))failureBlock;
		[Export ("hnk_setImageFromURL:placeholder:success:failure:")]
		void Hnk_setImageFromURL (NSUrl url, UIImage placeholder, Action<UIImage> successBlock, Action<NSError> failureBlock);

		// -(void)hnk_setImage:(UIImage *)image withKey:(NSString *)key;
		[Export ("hnk_setImage:withKey:")]
		void Hnk_setImage (UIImage image, string key);

		// -(void)hnk_setImage:(UIImage *)image withKey:(NSString *)key placeholder:(UIImage *)placeholder;
		[Export ("hnk_setImage:withKey:placeholder:")]
		void Hnk_setImage (UIImage image, string key, UIImage placeholder);

		// -(void)hnk_setImage:(UIImage *)image withKey:(NSString *)key placeholder:(UIImage *)placeholder success:(void (^)(UIImage *))successBlock failure:(void (^)(NSError *))failureBlock;
		[Export ("hnk_setImage:withKey:placeholder:success:failure:")]
		void Hnk_setImage (UIImage image, string key, UIImage placeholder, Action<UIImage> successBlock, Action<NSError> failureBlock);

		// -(void)hnk_setImageFromFetcher:(id<HNKFetcher>)fetcher;
		[Export ("hnk_setImageFromFetcher:")]
		void Hnk_setImageFromFetcher (HNKFetcher fetcher);

		// -(void)hnk_setImageFromFetcher:(id<HNKFetcher>)fetcher placeholder:(UIImage *)placeholder;
		[Export ("hnk_setImageFromFetcher:placeholder:")]
		void Hnk_setImageFromFetcher (HNKFetcher fetcher, UIImage placeholder);

		// -(void)hnk_setImageFromFetcher:(id<HNKFetcher>)fetcher placeholder:(UIImage *)placeholder success:(void (^)(UIImage *))successBlock failure:(void (^)(NSError *))failureBlock;
		[Export ("hnk_setImageFromFetcher:placeholder:success:failure:")]
		void Hnk_setImageFromFetcher (HNKFetcher fetcher, UIImage placeholder, Action<UIImage> successBlock, Action<NSError> failureBlock);

		// -(void)hnk_cancelSetImage;
		[Export ("hnk_cancelSetImage")]
		void Hnk_cancelSetImage ();

        // @property (nonatomic, strong) HNKCacheFormat * hnk_cacheFormat;
        [Export("hnk_cacheFormat", ArgumentSemantic.Strong)]
		HNKCacheFormat Hnk_cacheFormat();
		[Export("setHnk_cacheFormat:", ArgumentSemantic.Strong)]
		void SetHnk_cacheFormat(HNKCacheFormat format);
	}

	// @interface Haneke (UIButton)
	[Category]
	[BaseType (typeof(UIButton))]
	interface UIButton_Haneke
	{
		// -(void)hnk_setImageFromURL:(NSURL *)URL forState:(UIControlState)state;
		[Export ("hnk_setImageFromURL:forState:")]
		void Hnk_setImageFromURL (NSUrl URL, UIControlState state);

		// -(void)hnk_setImageFromURL:(NSURL *)URL forState:(UIControlState)state placeholder:(UIImage *)placeholder;
		[Export ("hnk_setImageFromURL:forState:placeholder:")]
		void Hnk_setImageFromURL (NSUrl URL, UIControlState state, UIImage placeholder);

		// -(void)hnk_setImageFromURL:(NSURL *)URL forState:(UIControlState)state placeholder:(UIImage *)placeholder success:(void (^)(UIImage *))successBlock failure:(void (^)(NSError *))failureBlock;
		[Export ("hnk_setImageFromURL:forState:placeholder:success:failure:")]
		void Hnk_setImageFromURL (NSUrl URL, UIControlState state, UIImage placeholder, Action<UIImage> successBlock, Action<NSError> failureBlock);

		// -(void)hnk_setImageFromFile:(NSString *)path forState:(UIControlState)state;
		[Export ("hnk_setImageFromFile:forState:")]
		void Hnk_setImageFromFile (string path, UIControlState state);

		// -(void)hnk_setImageFromFile:(NSString *)path forState:(UIControlState)state placeholder:(UIImage *)placeholder;
		[Export ("hnk_setImageFromFile:forState:placeholder:")]
		void Hnk_setImageFromFile (string path, UIControlState state, UIImage placeholder);

		// -(void)hnk_setImageFromFile:(NSString *)path forState:(UIControlState)state placeholder:(UIImage *)placeholder success:(void (^)(UIImage *))successBlock failure:(void (^)(NSError *))failureBlock;
		[Export ("hnk_setImageFromFile:forState:placeholder:success:failure:")]
		void Hnk_setImageFromFile (string path, UIControlState state, UIImage placeholder, Action<UIImage> successBlock, Action<NSError> failureBlock);

		// -(void)hnk_setImage:(UIImage *)image withKey:(NSString *)key forState:(UIControlState)state;
		[Export ("hnk_setImage:withKey:forState:")]
		void Hnk_setImage (UIImage image, string key, UIControlState state);

		// -(void)hnk_setImage:(UIImage *)image withKey:(NSString *)key forState:(UIControlState)state placeholder:(UIImage *)placeholder;
		[Export ("hnk_setImage:withKey:forState:placeholder:")]
		void Hnk_setImage (UIImage image, string key, UIControlState state, UIImage placeholder);

		// -(void)hnk_setImage:(UIImage *)image withKey:(NSString *)key forState:(UIControlState)state placeholder:(UIImage *)placeholder success:(void (^)(UIImage *))successBlock failure:(void (^)(NSError *))failureBlock;
		[Export ("hnk_setImage:withKey:forState:placeholder:success:failure:")]
		void Hnk_setImage (UIImage image, string key, UIControlState state, UIImage placeholder, Action<UIImage> successBlock, Action<NSError> failureBlock);

		// -(void)hnk_setImageFromFetcher:(id<HNKFetcher>)fetcher forState:(UIControlState)state;
		[Export ("hnk_setImageFromFetcher:forState:")]
		void Hnk_setImageFromFetcher (HNKFetcher fetcher, UIControlState state);

		// -(void)hnk_setImageFromFetcher:(id<HNKFetcher>)fetcher forState:(UIControlState)state placeholder:(UIImage *)placeholder;
		[Export ("hnk_setImageFromFetcher:forState:placeholder:")]
		void Hnk_setImageFromFetcher (HNKFetcher fetcher, UIControlState state, UIImage placeholder);

		// -(void)hnk_setImageFromFetcher:(id<HNKFetcher>)fetcher forState:(UIControlState)state placeholder:(UIImage *)placeholder success:(void (^)(UIImage *))successBlock failure:(void (^)(NSError *))failureBlock;
		[Export ("hnk_setImageFromFetcher:forState:placeholder:success:failure:")]
		void Hnk_setImageFromFetcher (HNKFetcher fetcher, UIControlState state, UIImage placeholder, Action<UIImage> successBlock, Action<NSError> failureBlock);

		// -(void)hnk_cancelSetImage;
		[Export ("hnk_cancelSetImage")]
		void Hnk_cancelSetImage ();

        // @property (nonatomic, strong) HNKCacheFormat * hnk_imageFormat;
        [Export("hnk_imageFormat", ArgumentSemantic.Strong)]
		HNKCacheFormat Hnk_imageFormat();
		[Export("setHnk_imageFormat:", ArgumentSemantic.Strong)]
		void SetHnk_imageFormat(HNKCacheFormat format);

		// -(void)hnk_setBackgroundImageFromURL:(NSURL *)URL forState:(UIControlState)state;
		[Export ("hnk_setBackgroundImageFromURL:forState:")]
		void Hnk_setBackgroundImageFromURL (NSUrl URL, UIControlState state);

		// -(void)hnk_setBackgroundImageFromURL:(NSURL *)URL forState:(UIControlState)state placeholder:(UIImage *)placeholder;
		[Export ("hnk_setBackgroundImageFromURL:forState:placeholder:")]
		void Hnk_setBackgroundImageFromURL (NSUrl URL, UIControlState state, UIImage placeholder);

		// -(void)hnk_setBackgroundImageFromURL:(NSURL *)URL forState:(UIControlState)state placeholder:(UIImage *)placeholder success:(void (^)(UIImage *))successBlock failure:(void (^)(NSError *))failureBlock;
		[Export ("hnk_setBackgroundImageFromURL:forState:placeholder:success:failure:")]
		void Hnk_setBackgroundImageFromURL (NSUrl URL, UIControlState state, UIImage placeholder, Action<UIImage> successBlock, Action<NSError> failureBlock);

		// -(void)hnk_setBackgroundImageFromFile:(NSString *)path forState:(UIControlState)state;
		[Export ("hnk_setBackgroundImageFromFile:forState:")]
		void Hnk_setBackgroundImageFromFile (string path, UIControlState state);

		// -(void)hnk_setBackgroundImageFromFile:(NSString *)path forState:(UIControlState)state placeholder:(UIImage *)placeholder;
		[Export ("hnk_setBackgroundImageFromFile:forState:placeholder:")]
		void Hnk_setBackgroundImageFromFile (string path, UIControlState state, UIImage placeholder);

		// -(void)hnk_setBackgroundImageFromFile:(NSString *)path forState:(UIControlState)state placeholder:(UIImage *)placeholder success:(void (^)(UIImage *))successBlock failure:(void (^)(NSError *))failureBlock;
		[Export ("hnk_setBackgroundImageFromFile:forState:placeholder:success:failure:")]
		void Hnk_setBackgroundImageFromFile (string path, UIControlState state, UIImage placeholder, Action<UIImage> successBlock, Action<NSError> failureBlock);

		// -(void)hnk_setBackgroundImage:(UIImage *)image withKey:(NSString *)key forState:(UIControlState)state;
		[Export ("hnk_setBackgroundImage:withKey:forState:")]
		void Hnk_setBackgroundImage (UIImage image, string key, UIControlState state);

		// -(void)hnk_setBackgroundImage:(UIImage *)image withKey:(NSString *)key forState:(UIControlState)state placeholder:(UIImage *)placeholder;
		[Export ("hnk_setBackgroundImage:withKey:forState:placeholder:")]
		void Hnk_setBackgroundImage (UIImage image, string key, UIControlState state, UIImage placeholder);

		// -(void)hnk_setBackgroundImage:(UIImage *)image withKey:(NSString *)key forState:(UIControlState)state placeholder:(UIImage *)placeholder success:(void (^)(UIImage *))successBlock failure:(void (^)(NSError *))failureBlock;
		[Export ("hnk_setBackgroundImage:withKey:forState:placeholder:success:failure:")]
		void Hnk_setBackgroundImage (UIImage image, string key, UIControlState state, UIImage placeholder, Action<UIImage> successBlock, Action<NSError> failureBlock);

		// -(void)hnk_setBackgroundImageFromFetcher:(id<HNKFetcher>)fetcher forState:(UIControlState)state;
		[Export ("hnk_setBackgroundImageFromFetcher:forState:")]
		void Hnk_setBackgroundImageFromFetcher (HNKFetcher fetcher, UIControlState state);

		// -(void)hnk_setBackgroundImageFromFetcher:(id<HNKFetcher>)fetcher forState:(UIControlState)state placeholder:(UIImage *)placeholder;
		[Export ("hnk_setBackgroundImageFromFetcher:forState:placeholder:")]
		void Hnk_setBackgroundImageFromFetcher (HNKFetcher fetcher, UIControlState state, UIImage placeholder);

		// -(void)hnk_setBackgroundImageFromFetcher:(id<HNKFetcher>)fetcher forState:(UIControlState)state placeholder:(UIImage *)placeholder success:(void (^)(UIImage *))successBlock failure:(void (^)(NSError *))failureBlock;
		[Export ("hnk_setBackgroundImageFromFetcher:forState:placeholder:success:failure:")]
		void Hnk_setBackgroundImageFromFetcher (HNKFetcher fetcher, UIControlState state, UIImage placeholder, Action<UIImage> successBlock, Action<NSError> failureBlock);

		// -(void)hnk_cancelSetBackgroundImage;
		[Export ("hnk_cancelSetBackgroundImage")]
		void Hnk_cancelSetBackgroundImage ();

        // @property (nonatomic, strong) HNKCacheFormat * hnk_backgroundImageFormat;
        [Export("hnk_backgroundImageFormat", ArgumentSemantic.Strong)]
		HNKCacheFormat Hnk_backgroundImageFormat();
		[Export("setHnk_backgroundImageFormat:", ArgumentSemantic.Strong)]
		void SetHnk_backgroundImageFormat(HNKCacheFormat format);
	}

	[Static]
	partial interface HNKViewFormatConstants
	{
		// extern const CGFloat HNKViewFormatCompressionQuality;
		[Field ("HNKViewFormatCompressionQuality", "__Internal")]
		nfloat HNKViewFormatCompressionQuality { get; }

		// extern const unsigned long long HNKViewFormatDiskCapacity;
		[Field ("HNKViewFormatDiskCapacity", "__Internal")]
        nuint HNKViewFormatDiskCapacity { get; }

		// extern const NSTimeInterval HNKViewSetImageAnimationDuration;
		[Field ("HNKViewSetImageAnimationDuration", "__Internal")]
		double HNKViewSetImageAnimationDuration { get; }
	}

	// @interface Haneke (UIView)
	[Category]
	[BaseType (typeof(UIView))]
	interface UIView_Haneke
	{
        // @property (readonly, nonatomic) HNKScaleMode hnk_scaleMode;
        [Export("hnk_scaleMode")]
        HNKScaleMode Hnk_scaleMode();
	}

	//[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	//partial interface Constants
	//{
	//	// extern double HanekeVersionNumber;
	//	[Field ("HanekeVersionNumber", "__Internal")]
	//	double HanekeVersionNumber { get; }

	//	// extern const unsigned char [] HanekeVersionString;
	//	[Field ("HanekeVersionString", "__Internal")]
	//	byte[] HanekeVersionString { get; }
	//}
}
