using System;
using System.Runtime.InteropServices;
using CoreGraphics;
using CoreLocation;
using Foundation;

public enum EnPermissionStatus
{
	Ok = 0,
	ServerError = -200,
	NetworkError = -300
}

public enum BMKMapModule : uint
{
	BMKMapModuleTile = 0
}

public enum BmkCoordType : uint
{
	Gps = 0,
	Common
}

[Verify (InferredFromMemberPrefix)]
public enum BMKMapType : uint
{
	None = 0,
	Standard = 1,
	Satellite = 2
}

public enum BMKErrorCode : uint
{
	Ok = 0,
	Connect = 2,
	Data = 3,
	RouteAddr = 4,
	ResultNotFound = 100,
	LocationFailed = 200,
	PermissionCheckFailure = 300,
	Parse = 310
}

public enum BMKPermissionCheckResultCode
{
	ConnectError = -300,
	DataError = -200,
	Ok = 0,
	KeyError = 101,
	McodeError = 102,
	UidKeyError = 200,
	KeyForbiden = 201
}

public enum BMKSearchErrorCode : uint
{
	NoError = 0,
	AmbiguousKeyword,
	AmbiguousRoureAddr,
	NotSupportBus,
	NotSupportBus2city,
	ResultNotFound,
	StEnTooNear,
	KeyError,
	NetwokrError,
	NetwokrTimeout,
	PermissionUnfinished,
	IndoorIdError,
	FloorError
}

public enum BMKOpenErrorCode : uint
{
	NoError = 0,
	WebMap,
	OptionNull,
	NotSupport,
	PoiDetailUidNull,
	PoiNearbyKeywordNull,
	RouteStartError,
	RouteEndError,
	PanoramaUidError,
	PanoramaAbsent,
	PermissionUnfinished,
	KeyError,
	NetwokrError
}

[StructLayout (LayoutKind.Sequential)]
public struct BMKCoordinateSpan
{
	public double latitudeDelta;

	public double longitudeDelta;
}

[StructLayout (LayoutKind.Sequential)]
public struct BMKCoordinateBounds
{
	public CLLocationCoordinate2D northEast;

	public CLLocationCoordinate2D southWest;
}

[StructLayout (LayoutKind.Sequential)]
public struct BMKCoordinateRegion
{
	public CLLocationCoordinate2D center;

	public BMKCoordinateSpan span;
}

[StructLayout (LayoutKind.Sequential)]
public struct BMKGeoPoint
{
	public int latitudeE6;

	public int longitudeE6;
}

[StructLayout (LayoutKind.Sequential)]
public struct BMKMapPoint
{
	public double x;

	public double y;
}

[StructLayout (LayoutKind.Sequential)]
public struct BMKMapSize
{
	public double width;

	public double height;
}

[StructLayout (LayoutKind.Sequential)]
public struct BMKMapRect
{
	public BMKMapPoint origin;

	public BMKMapSize size;
}

static class CFunctions
{
	// NSString * BMKGetMapApiVersion ();
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern NSString BMKGetMapApiVersion ();

	// extern NSString * BMKGetMapApiBaseComponentVersion () __attribute__((visibility("default")));
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern NSString BMKGetMapApiBaseComponentVersion ();

	// extern NSString * BMKGetMapApiLocationComponentVersion () __attribute__((visibility("default")));
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern NSString BMKGetMapApiLocationComponentVersion ();

	// extern BOOL BMKCheckLocationComponentIsLegal () __attribute__((visibility("default")));
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern bool BMKCheckLocationComponentIsLegal ();

	// BMKCoordinateSpan BMKCoordinateSpanMake (CLLocationDegrees latitudeDelta, CLLocationDegrees longitudeDelta);
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern BMKCoordinateSpan BMKCoordinateSpanMake (double latitudeDelta, double longitudeDelta);

	// BMKCoordinateRegion BMKCoordinateRegionMake (CLLocationCoordinate2D centerCoordinate, BMKCoordinateSpan span);
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern BMKCoordinateRegion BMKCoordinateRegionMake (CLLocationCoordinate2D centerCoordinate, BMKCoordinateSpan span);

	// extern BMKCoordinateRegion BMKCoordinateRegionMakeWithDistance (CLLocationCoordinate2D centerCoordinate, CLLocationDistance latitudinalMeters, CLLocationDistance longitudinalMeters) __attribute__((visibility("default")));
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern BMKCoordinateRegion BMKCoordinateRegionMakeWithDistance (CLLocationCoordinate2D centerCoordinate, double latitudinalMeters, double longitudinalMeters);

	// extern BMKMapPoint BMKMapPointForCoordinate (CLLocationCoordinate2D coordinate) __attribute__((visibility("default")));
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern BMKMapPoint BMKMapPointForCoordinate (CLLocationCoordinate2D coordinate);

	// extern CLLocationCoordinate2D BMKCoordinateForMapPoint (BMKMapPoint mapPoint) __attribute__((visibility("default")));
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern CLLocationCoordinate2D BMKCoordinateForMapPoint (BMKMapPoint mapPoint);

	// extern CLLocationDistance BMKMetersPerMapPointAtLatitude (CLLocationDegrees latitude) __attribute__((visibility("default")));
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern double BMKMetersPerMapPointAtLatitude (double latitude);

	// extern double BMKMapPointsPerMeterAtLatitude (CLLocationDegrees latitude) __attribute__((visibility("default")));
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern double BMKMapPointsPerMeterAtLatitude (double latitude);

	// extern CLLocationDistance BMKMetersBetweenMapPoints (BMKMapPoint a, BMKMapPoint b) __attribute__((visibility("default")));
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern double BMKMetersBetweenMapPoints (BMKMapPoint a, BMKMapPoint b);

	// BMKMapPoint BMKMapPointMake (double x, double y);
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern BMKMapPoint BMKMapPointMake (double x, double y);

	// BMKMapSize BMKMapSizeMake (double width, double height);
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern BMKMapSize BMKMapSizeMake (double width, double height);

	// BMKMapRect BMKMapRectMake (double x, double y, double width, double height);
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern BMKMapRect BMKMapRectMake (double x, double y, double width, double height);

	// double BMKMapRectGetMinX (BMKMapRect rect);
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern double BMKMapRectGetMinX (BMKMapRect rect);

	// double BMKMapRectGetMinY (BMKMapRect rect);
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern double BMKMapRectGetMinY (BMKMapRect rect);

	// double BMKMapRectGetMidX (BMKMapRect rect);
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern double BMKMapRectGetMidX (BMKMapRect rect);

	// double BMKMapRectGetMidY (BMKMapRect rect);
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern double BMKMapRectGetMidY (BMKMapRect rect);

	// double BMKMapRectGetMaxX (BMKMapRect rect);
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern double BMKMapRectGetMaxX (BMKMapRect rect);

	// double BMKMapRectGetMaxY (BMKMapRect rect);
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern double BMKMapRectGetMaxY (BMKMapRect rect);

	// double BMKMapRectGetWidth (BMKMapRect rect);
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern double BMKMapRectGetWidth (BMKMapRect rect);

	// double BMKMapRectGetHeight (BMKMapRect rect);
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern double BMKMapRectGetHeight (BMKMapRect rect);

	// BOOL BMKMapPointEqualToPoint (BMKMapPoint point1, BMKMapPoint point2);
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern bool BMKMapPointEqualToPoint (BMKMapPoint point1, BMKMapPoint point2);

	// BOOL BMKMapSizeEqualToSize (BMKMapSize size1, BMKMapSize size2);
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern bool BMKMapSizeEqualToSize (BMKMapSize size1, BMKMapSize size2);

	// BOOL BMKMapRectEqualToRect (BMKMapRect rect1, BMKMapRect rect2);
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern bool BMKMapRectEqualToRect (BMKMapRect rect1, BMKMapRect rect2);

	// BOOL BMKMapRectIsNull (BMKMapRect rect);
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern bool BMKMapRectIsNull (BMKMapRect rect);

	// BOOL BMKMapRectIsEmpty (BMKMapRect rect);
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern bool BMKMapRectIsEmpty (BMKMapRect rect);

	// NSString * BMKStringFromMapPoint (BMKMapPoint point);
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern NSString BMKStringFromMapPoint (BMKMapPoint point);

	// NSString * BMKStringFromMapSize (BMKMapSize size);
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern NSString BMKStringFromMapSize (BMKMapSize size);

	// NSString * BMKStringFromMapRect (BMKMapRect rect);
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern NSString BMKStringFromMapRect (BMKMapRect rect);

	// extern BMKMapRect BMKMapRectUnion (BMKMapRect rect1, BMKMapRect rect2) __attribute__((visibility("default")));
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern BMKMapRect BMKMapRectUnion (BMKMapRect rect1, BMKMapRect rect2);

	// extern BMKMapRect BMKMapRectIntersection (BMKMapRect rect1, BMKMapRect rect2) __attribute__((visibility("default")));
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern BMKMapRect BMKMapRectIntersection (BMKMapRect rect1, BMKMapRect rect2);

	// extern BMKMapRect BMKMapRectInset (BMKMapRect rect, double dx, double dy) __attribute__((visibility("default")));
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern BMKMapRect BMKMapRectInset (BMKMapRect rect, double dx, double dy);

	// extern BMKMapRect BMKMapRectOffset (BMKMapRect rect, double dx, double dy) __attribute__((visibility("default")));
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern BMKMapRect BMKMapRectOffset (BMKMapRect rect, double dx, double dy);

	// extern void BMKMapRectDivide (BMKMapRect rect, BMKMapRect *slice, BMKMapRect *remainder, double amount, CGRectEdge edge) __attribute__((visibility("default")));
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern unsafe void BMKMapRectDivide (BMKMapRect rect, BMKMapRect* slice, BMKMapRect* remainder, double amount, CGRectEdge edge);

	// extern BOOL BMKMapRectContainsPoint (BMKMapRect rect, BMKMapPoint point) __attribute__((visibility("default")));
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern bool BMKMapRectContainsPoint (BMKMapRect rect, BMKMapPoint point);

	// extern BOOL BMKMapRectContainsRect (BMKMapRect rect1, BMKMapRect rect2) __attribute__((visibility("default")));
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern bool BMKMapRectContainsRect (BMKMapRect rect1, BMKMapRect rect2);

	// extern BOOL BMKMapRectIntersectsRect (BMKMapRect rect1, BMKMapRect rect2) __attribute__((visibility("default")));
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern bool BMKMapRectIntersectsRect (BMKMapRect rect1, BMKMapRect rect2);

	// extern BMKCoordinateRegion BMKCoordinateRegionForMapRect (BMKMapRect rect) __attribute__((visibility("default")));
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern BMKCoordinateRegion BMKCoordinateRegionForMapRect (BMKMapRect rect);

	// extern BOOL BMKMapRectSpans180thMeridian (BMKMapRect rect) __attribute__((visibility("default")));
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern bool BMKMapRectSpans180thMeridian (BMKMapRect rect);

	// extern BMKMapRect BMKMapRectRemainder (BMKMapRect rect) __attribute__((visibility("default")));
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern BMKMapRect BMKMapRectRemainder (BMKMapRect rect);

	// extern BOOL BMKCircleContainsPoint (BMKMapPoint point, BMKMapPoint center, double radius) __attribute__((visibility("default")));
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern bool BMKCircleContainsPoint (BMKMapPoint point, BMKMapPoint center, double radius);

	// extern BOOL BMKCircleContainsCoordinate (CLLocationCoordinate2D point, CLLocationCoordinate2D center, double radius) __attribute__((visibility("default")));
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern bool BMKCircleContainsCoordinate (CLLocationCoordinate2D point, CLLocationCoordinate2D center, double radius);

	// extern BOOL BMKPolygonContainsPoint (BMKMapPoint point, BMKMapPoint *polygon, NSUInteger count) __attribute__((visibility("default")));
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern unsafe bool BMKPolygonContainsPoint (BMKMapPoint point, BMKMapPoint* polygon, nuint count);

	// extern BOOL BMKPolygonContainsCoordinate (CLLocationCoordinate2D point, CLLocationCoordinate2D *polygon, NSUInteger count) __attribute__((visibility("default")));
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern unsafe bool BMKPolygonContainsCoordinate (CLLocationCoordinate2D point, CLLocationCoordinate2D* polygon, nuint count);

	// extern BMKMapPoint BMKGetNearestMapPointFromPolyline (BMKMapPoint point, BMKMapPoint *polyline, NSUInteger count) __attribute__((visibility("default")));
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern unsafe BMKMapPoint BMKGetNearestMapPointFromPolyline (BMKMapPoint point, BMKMapPoint* polyline, nuint count);

	// extern double BMKAreaBetweenCoordinates (CLLocationCoordinate2D leftTop, CLLocationCoordinate2D rightBottom) __attribute__((visibility("default")));
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern double BMKAreaBetweenCoordinates (CLLocationCoordinate2D leftTop, CLLocationCoordinate2D rightBottom);

	// extern NSDictionary * BMKConvertBaiduCoorFrom (CLLocationCoordinate2D coordinate, BMK_COORD_TYPE type) __attribute__((visibility("default")));
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern NSDictionary BMKConvertBaiduCoorFrom (CLLocationCoordinate2D coordinate, BmkCoordType type);

	// extern CLLocationCoordinate2D BMKCoorDictionaryDecode (NSDictionary *dictionary) __attribute__((visibility("default")));
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern CLLocationCoordinate2D BMKCoorDictionaryDecode (NSDictionary dictionary);

	// extern NSString * BMKGetMapApiUtilsComponentVersion () __attribute__((visibility("default")));
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern NSString BMKGetMapApiUtilsComponentVersion ();

	// extern BOOL BMKCheckUtilsComponentIsLegal () __attribute__((visibility("default")));
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern bool BMKCheckUtilsComponentIsLegal ();
}

public enum BmkNaviType : uint
{
	Native = 0,
	Web
}

public enum BMKOpenTransitPolicy : uint
{
	Recommand = 3,
	TransferFirst,
	WalkFirst,
	NoSubway,
	TimeFirst
}
