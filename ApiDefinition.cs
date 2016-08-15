using System;
using CoreLocation;
using Foundation;
using ObjCRuntime;

namespace BaiduMapSDK
{
	// @protocol BMKGeneralDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface BMKGeneralDelegate
	{
		// @optional -(void)onGetNetworkState:(int)iError;
		[Export ("onGetNetworkState:")]
		void OnGetNetworkState (int iError);

		// @optional -(void)onGetPermissionState:(int)iError;
		[Export ("onGetPermissionState:")]
		void OnGetPermissionState (int iError);
	}

	// @interface BMKMapManager : NSObject
	[BaseType (typeof (NSObject))]
	interface BMKMapManager
	{
		// +(void)logEnable:(BOOL)enable module:(BMKMapModule)mapModule;
		[Static]
		[Export ("logEnable:module:")]
		void LogEnable (bool enable, BMKMapModule mapModule);

		// -(BOOL)start:(NSString *)key generalDelegate:(id<BMKGeneralDelegate>)delegate;
		[Export ("start:generalDelegate:")]
		bool Start (string key, BMKGeneralDelegate @delegate);

		// -(int)getTotalSendFlaxLength;
		[Export ("getTotalSendFlaxLength")]
		//[Verify (MethodToProperty)]
		int TotalSendFlaxLength { get; }

		// -(int)getTotalRecvFlaxLength;
		[Export ("getTotalRecvFlaxLength")]
		//[Verify (MethodToProperty)]
		int TotalRecvFlaxLength { get; }

		// -(BOOL)stop;
		[Export ("stop")]
		//[Verify (MethodToProperty)]
		bool Stop { get; }
	}

	//[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern const BMKMapSize BMKMapSizeWorld __attribute__((visibility("default")));
		[Field ("BMKMapSizeWorld", "__Internal")]
		BMKMapSize BMKMapSizeWorld { get; }

		// extern const BMKMapRect BMKMapRectWorld __attribute__((visibility("default")));
		[Field ("BMKMapRectWorld", "__Internal")]
		BMKMapRect BMKMapRectWorld { get; }

		// extern const BMKMapRect BMKMapRectNull __attribute__((visibility("default")));
		[Field ("BMKMapRectNull", "__Internal")]
		BMKMapRect BMKMapRectNull { get; }
	}

	// @interface BMKPlanNode : NSObject
	[BaseType (typeof (NSObject))]
	interface BMKPlanNode
	{
		// @property (nonatomic, strong) NSString * cityName;
		[Export ("cityName", ArgumentSemantic.Strong)]
		string CityName { get; set; }

		// @property (assign, nonatomic) NSInteger cityID;
		[Export ("cityID")]
		nint CityID { get; set; }

		// @property (nonatomic, strong) NSString * name;
		[Export ("name", ArgumentSemantic.Strong)]
		string Name { get; set; }

		// @property (nonatomic) CLLocationCoordinate2D pt;
		[Export ("pt", ArgumentSemantic.Assign)]
		CLLocationCoordinate2D Pt { get; set; }
	}

	// @interface BMKUserLocation : NSObject
	[BaseType (typeof (NSObject))]
	interface BMKUserLocation
	{
		// @property (readonly, getter = isUpdating, nonatomic) BOOL updating;
		[Export ("updating")]
		bool Updating { [Bind ("isUpdating")] get; }

		// @property (readonly, nonatomic, strong) CLLocation * location;
		[Export ("location", ArgumentSemantic.Strong)]
		CLLocation Location { get; }

		// @property (readonly, nonatomic, strong) CLHeading * heading;
		[Export ("heading", ArgumentSemantic.Strong)]
		CLHeading Heading { get; }

		// @property (nonatomic, strong) NSString * title;
		[Export ("title", ArgumentSemantic.Strong)]
		string Title { get; set; }

		// @property (nonatomic, strong) NSString * subtitle;
		[Export ("subtitle", ArgumentSemantic.Strong)]
		string Subtitle { get; set; }
	}

	// @protocol BMKLocationServiceDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface BMKLocationServiceDelegate
	{
		// @optional -(void)willStartLocatingUser;
		[Export ("willStartLocatingUser")]
		void WillStartLocatingUser ();

		// @optional -(void)didStopLocatingUser;
		[Export ("didStopLocatingUser")]
		void DidStopLocatingUser ();

		// @optional -(void)didUpdateUserHeading:(BMKUserLocation *)userLocation;
		[Export ("didUpdateUserHeading:")]
		void DidUpdateUserHeading (BMKUserLocation userLocation);

		// @optional -(void)didUpdateBMKUserLocation:(BMKUserLocation *)userLocation;
		[Export ("didUpdateBMKUserLocation:")]
		void DidUpdateBMKUserLocation (BMKUserLocation userLocation);

		// @optional -(void)didFailToLocateUserWithError:(NSError *)error;
		[Export ("didFailToLocateUserWithError:")]
		void DidFailToLocateUserWithError (NSError error);
	}

	// @interface BMKLocationService : NSObject
	[BaseType (typeof (NSObject))]
	interface BMKLocationService
	{
		// @property (readonly, nonatomic) BMKUserLocation * userLocation;
		[Export ("userLocation")]
		BMKUserLocation UserLocation { get; }

		[Wrap ("WeakDelegate")]
		BMKLocationServiceDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<BMKLocationServiceDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// -(void)startUserLocationService;
		[Export ("startUserLocationService")]
		void StartUserLocationService ();

		// -(void)stopUserLocationService;
		[Export ("stopUserLocationService")]
		void StopUserLocationService ();

		// @property (assign, nonatomic) CLLocationDistance distanceFilter;
		[Export ("distanceFilter")]
		double DistanceFilter { get; set; }

		// @property (assign, nonatomic) CLLocationAccuracy desiredAccuracy;
		[Export ("desiredAccuracy")]
		double DesiredAccuracy { get; set; }

		// @property (assign, nonatomic) CLLocationDegrees headingFilter;
		[Export ("headingFilter")]
		double HeadingFilter { get; set; }

		// @property (assign, nonatomic) BOOL pausesLocationUpdatesAutomatically;
		[Export ("pausesLocationUpdatesAutomatically")]
		bool PausesLocationUpdatesAutomatically { get; set; }

		// @property (assign, nonatomic) BOOL allowsBackgroundLocationUpdates;
		[Export ("allowsBackgroundLocationUpdates")]
		bool AllowsBackgroundLocationUpdates { get; set; }

		// +(void)setLocationDistanceFilter:(CLLocationDistance)distanceFilter __attribute__((deprecated("废弃方法（空实现），使用distanceFilter属性替换")));
		[Static]
		[Export ("setLocationDistanceFilter:")]
		void SetLocationDistanceFilter (double distanceFilter);

		// +(CLLocationDistance)getCurrentLocationDistanceFilter __attribute__((deprecated("废弃方法（空实现），使用distanceFilter属性替换")));
		[Static]
		[Export ("getCurrentLocationDistanceFilter")]
		//[Verify (MethodToProperty)]
		double CurrentLocationDistanceFilter { get; }

		// +(void)setLocationDesiredAccuracy:(CLLocationAccuracy)desiredAccuracy __attribute__((deprecated("废弃方法（空实现），使用desiredAccuracy属性替换")));
		[Static]
		[Export ("setLocationDesiredAccuracy:")]
		void SetLocationDesiredAccuracy (double desiredAccuracy);

		// +(CLLocationAccuracy)getCurrentLocationDesiredAccuracy __attribute__((deprecated("废弃方法（空实现），使用desiredAccuracy属性替换")));
		[Static]
		[Export ("getCurrentLocationDesiredAccuracy")]
		//[Verify (MethodToProperty)]
		double CurrentLocationDesiredAccuracy { get; }
	}

	// @interface BMKFavPoiInfo : NSObject
	[BaseType (typeof (NSObject))]
	interface BMKFavPoiInfo
	{
		// @property (nonatomic, strong) NSString * favId;
		[Export ("favId", ArgumentSemantic.Strong)]
		string FavId { get; set; }

		// @property (nonatomic, strong) NSString * poiName;
		[Export ("poiName", ArgumentSemantic.Strong)]
		string PoiName { get; set; }

		// @property (nonatomic, strong) NSString * poiUid;
		[Export ("poiUid", ArgumentSemantic.Strong)]
		string PoiUid { get; set; }

		// @property (assign, nonatomic) CLLocationCoordinate2D pt;
		[Export ("pt", ArgumentSemantic.Assign)]
		CLLocationCoordinate2D Pt { get; set; }

		// @property (nonatomic, strong) NSString * address;
		[Export ("address", ArgumentSemantic.Strong)]
		string Address { get; set; }

		// @property (nonatomic, strong) NSString * cityName;
		[Export ("cityName", ArgumentSemantic.Strong)]
		string CityName { get; set; }

		// @property (assign, nonatomic) NSUInteger timeStamp;
		[Export ("timeStamp")]
		nuint TimeStamp { get; set; }
	}

	// @interface BMKFavPoiManager : NSObject
	[BaseType (typeof (NSObject))]
	interface BMKFavPoiManager
	{
		// -(NSInteger)addFavPoi:(BMKFavPoiInfo *)favPoiInfo;
		[Export ("addFavPoi:")]
		nint AddFavPoi (BMKFavPoiInfo favPoiInfo);

		// -(BMKFavPoiInfo *)getFavPoi:(NSString *)favId;
		[Export ("getFavPoi:")]
		BMKFavPoiInfo GetFavPoi (string favId);

		// -(NSArray *)getAllFavPois;
		[Export ("getAllFavPois")]
		//[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject [] AllFavPois { get; }

		// -(BOOL)updateFavPoi:(NSString *)favId favPoiInfo:(BMKFavPoiInfo *)favPoiInfo;
		[Export ("updateFavPoi:favPoiInfo:")]
		bool UpdateFavPoi (string favId, BMKFavPoiInfo favPoiInfo);

		// -(BOOL)deleteFavPoi:(NSString *)favId;
		[Export ("deleteFavPoi:")]
		bool DeleteFavPoi (string favId);

		// -(BOOL)clearAllFavPois;
		[Export ("clearAllFavPois")]
		//[Verify (MethodToProperty)]
		bool ClearAllFavPois { get; }
	}

	// @interface BMKNaviPara : NSObject
	[BaseType (typeof (NSObject))]
	interface BMKNaviPara
	{
		// @property (nonatomic, strong) BMKPlanNode * startPoint;
		[Export ("startPoint", ArgumentSemantic.Strong)]
		BMKPlanNode StartPoint { get; set; }

		// @property (nonatomic, strong) BMKPlanNode * endPoint;
		[Export ("endPoint", ArgumentSemantic.Strong)]
		BMKPlanNode EndPoint { get; set; }

		// @property (assign, nonatomic) BMK_NAVI_TYPE naviType __attribute__((deprecated("自2.8.0开始废弃")));
		[Export ("naviType", ArgumentSemantic.Assign)]
		BmkNaviType NaviType { get; set; }

		// @property (nonatomic, strong) NSString * appScheme;
		[Export ("appScheme", ArgumentSemantic.Strong)]
		string AppScheme { get; set; }

		// @property (nonatomic, strong) NSString * appName;
		[Export ("appName", ArgumentSemantic.Strong)]
		string AppName { get; set; }

		// @property (assign, nonatomic) BOOL isSupportWeb;
		[Export ("isSupportWeb")]
		bool IsSupportWeb { get; set; }
	}

	// @interface BMKNavigation : NSObject
	[BaseType (typeof (NSObject))]
	interface BMKNavigation
	{
		// +(BMKOpenErrorCode)openBaiduMapNavigation:(BMKNaviPara *)para;
		[Static]
		[Export ("openBaiduMapNavigation:")]
		BMKOpenErrorCode OpenBaiduMapNavigation (BMKNaviPara para);

		// +(BMKOpenErrorCode)openBaiduMapWalkNavigation:(BMKNaviPara *)para;
		[Static]
		[Export ("openBaiduMapWalkNavigation:")]
		BMKOpenErrorCode OpenBaiduMapWalkNavigation (BMKNaviPara para);

		// +(BMKOpenErrorCode)openBaiduMapRideNavigation:(BMKNaviPara *)para;
		[Static]
		[Export ("openBaiduMapRideNavigation:")]
		BMKOpenErrorCode OpenBaiduMapRideNavigation (BMKNaviPara para);
	}

	// @interface BMKOpenOption : NSObject
	[BaseType (typeof (NSObject))]
	interface BMKOpenOption
	{
		// @property (nonatomic, strong) NSString * appScheme;
		[Export ("appScheme", ArgumentSemantic.Strong)]
		string AppScheme { get; set; }

		// @property (assign, nonatomic) BOOL isSupportWeb;
		[Export ("isSupportWeb")]
		bool IsSupportWeb { get; set; }
	}

	// @interface BMKOpenPanoramaOption : BMKOpenOption
	[BaseType (typeof (BMKOpenOption))]
	interface BMKOpenPanoramaOption
	{
		// @property (nonatomic, strong) NSString * poiUid;
		[Export ("poiUid", ArgumentSemantic.Strong)]
		string PoiUid { get; set; }
	}

	// @interface BMKOpenPanorama : NSObject
	[BaseType (typeof (NSObject))]
	interface BMKOpenPanorama
	{
		[Wrap ("WeakDelegate")]
		BMKOpenPanoramaDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<BMKOpenPanoramaDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// -(void)openBaiduMapPanorama:(BMKOpenPanoramaOption *)option;
		[Export ("openBaiduMapPanorama:")]
		void OpenBaiduMapPanorama (BMKOpenPanoramaOption option);
	}

	// @protocol BMKOpenPanoramaDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface BMKOpenPanoramaDelegate
	{
		// @required -(void)onGetOpenPanoramaStatus:(BMKOpenErrorCode)ecode;
		[Abstract]
		[Export ("onGetOpenPanoramaStatus:")]
		void OnGetOpenPanoramaStatus (BMKOpenErrorCode ecode);
	}

	// @interface BMKOpenPoiDetailOption : BMKOpenOption
	[BaseType (typeof (BMKOpenOption))]
	interface BMKOpenPoiDetailOption
	{
		// @property (nonatomic, strong) NSString * poiUid;
		[Export ("poiUid", ArgumentSemantic.Strong)]
		string PoiUid { get; set; }
	}

	// @interface BMKOpenPoiNearbyOption : BMKOpenOption
	[BaseType (typeof (BMKOpenOption))]
	interface BMKOpenPoiNearbyOption
	{
		// @property (assign, nonatomic) CLLocationCoordinate2D location;
		[Export ("location", ArgumentSemantic.Assign)]
		CLLocationCoordinate2D Location { get; set; }

		// @property (assign, nonatomic) NSUInteger radius;
		[Export ("radius")]
		nuint Radius { get; set; }

		// @property (nonatomic, strong) NSString * keyword;
		[Export ("keyword", ArgumentSemantic.Strong)]
		string Keyword { get; set; }
	}

	// @interface BMKOpenPoi : NSObject
	[BaseType (typeof (NSObject))]
	interface BMKOpenPoi
	{
		// +(BMKOpenErrorCode)openBaiduMapPoiDetailPage:(BMKOpenPoiDetailOption *)option;
		[Static]
		[Export ("openBaiduMapPoiDetailPage:")]
		BMKOpenErrorCode OpenBaiduMapPoiDetailPage (BMKOpenPoiDetailOption option);

		// +(BMKOpenErrorCode)openBaiduMapPoiNearbySearch:(BMKOpenPoiNearbyOption *)option;
		[Static]
		[Export ("openBaiduMapPoiNearbySearch:")]
		BMKOpenErrorCode OpenBaiduMapPoiNearbySearch (BMKOpenPoiNearbyOption option);
	}

	// @interface BMKOpenRouteOption : BMKOpenOption
	[BaseType (typeof (BMKOpenOption))]
	interface BMKOpenRouteOption
	{
		// @property (nonatomic, strong) BMKPlanNode * startPoint;
		[Export ("startPoint", ArgumentSemantic.Strong)]
		BMKPlanNode StartPoint { get; set; }

		// @property (nonatomic, strong) BMKPlanNode * endPoint;
		[Export ("endPoint", ArgumentSemantic.Strong)]
		BMKPlanNode EndPoint { get; set; }
	}

	// @interface BMKOpenWalkingRouteOption : BMKOpenRouteOption
	[BaseType (typeof (BMKOpenRouteOption))]
	interface BMKOpenWalkingRouteOption
	{
	}

	// @interface BMKOpenDrivingRouteOption : BMKOpenRouteOption
	[BaseType (typeof (BMKOpenRouteOption))]
	interface BMKOpenDrivingRouteOption
	{
	}

	// @interface BMKOpenTransitRouteOption : BMKOpenRouteOption
	[BaseType (typeof (BMKOpenRouteOption))]
	interface BMKOpenTransitRouteOption
	{
		// @property (assign, nonatomic) BMKOpenTransitPolicy openTransitPolicy;
		[Export ("openTransitPolicy", ArgumentSemantic.Assign)]
		BMKOpenTransitPolicy OpenTransitPolicy { get; set; }
	}

	// @interface BMKOpenRoute : NSObject
	[BaseType (typeof (NSObject))]
	interface BMKOpenRoute
	{
		// +(BMKOpenErrorCode)openBaiduMapWalkingRoute:(BMKOpenWalkingRouteOption *)option;
		[Static]
		[Export ("openBaiduMapWalkingRoute:")]
		BMKOpenErrorCode OpenBaiduMapWalkingRoute (BMKOpenWalkingRouteOption option);

		// +(BMKOpenErrorCode)openBaiduMapTransitRoute:(BMKOpenTransitRouteOption *)option;
		[Static]
		[Export ("openBaiduMapTransitRoute:")]
		BMKOpenErrorCode OpenBaiduMapTransitRoute (BMKOpenTransitRouteOption option);

		// +(BMKOpenErrorCode)openBaiduMapDrivingRoute:(BMKOpenDrivingRouteOption *)option;
		[Static]
		[Export ("openBaiduMapDrivingRoute:")]
		BMKOpenErrorCode OpenBaiduMapDrivingRoute (BMKOpenDrivingRouteOption option);
	}
}
