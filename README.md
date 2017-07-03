Haneke - Xamarin iOS binding library
------

Haneke resizes images and caches the result on memory and disk. Everything is done in background, allowing for fast, responsive scrolling. Asking Haneke to load, resize, cache and display an *appropriately sized image* is as simple as:

```c#
image.Hnk_setImageFromURL(new Foundation.NSUrl(""));
```

##Features

* First-level memory cache using `NSCache`.
* Second-level LRU disk cache using the file system.
* Zero-config `UIImageView` category to use the cache, optimized for `UITableView` and `UICollectionView` cell reuse.
* Asynchronous and synchronous image retrieval.
* Background image resizing and file reading.
* Image decompression.
* Custom image transformations before and after resizing.
* Thread-safe.
* Automatic cache eviction on memory warnings or disk capacity reached.
* Preloading images from the disk cache into memory on startup.

##Installation
```
Install-Package Naxam.Haneke.iOS
```