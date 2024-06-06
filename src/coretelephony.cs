using Foundation;
using ObjCRuntime;
using System;

namespace CoreTelephony {
	/// <summary>Encapsulates a unique identifier for a call and it's state.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/NetworkingInternet/Reference/CTCall/index.html">Apple documentation for <c>CTCall</c></related>
	[MacCatalyst (14, 0)]
	[Deprecated (PlatformName.MacCatalyst, 14, 0, message: Constants.UseCallKitInstead)]
	[Deprecated (PlatformName.iOS, 10, 0, message: Constants.UseCallKitInstead)]
	[BaseType (typeof (NSObject))]
	interface CTCall {
		[Export ("callID")]
		string CallID { get; }

		[Export ("callState")]
		string CallState { get; }

	}

	/// <related type="externalDocumentation" href="https://developer.apple.com/reference/CoreTelephony/CTCellularData">Apple documentation for <c>CTCellularData</c></related>
	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface CTCellularData {
		[NullAllowed, Export ("cellularDataRestrictionDidUpdateNotifier", ArgumentSemantic.Copy)]
		Action<CTCellularDataRestrictedState> RestrictionDidUpdateNotifier { get; set; }

		[Export ("restrictedState")]
		CTCellularDataRestrictedState RestrictedState { get; }
	}

	/// <summary>Defines constants describing various telephone radio technogies.</summary>
	[MacCatalyst (14, 0)]
	[Static]
	interface CTRadioAccessTechnology {
		[Field ("CTRadioAccessTechnologyGPRS")]
		NSString GPRS { get; }

		[Field ("CTRadioAccessTechnologyEdge")]
		NSString Edge { get; }

		[Field ("CTRadioAccessTechnologyWCDMA")]
		NSString WCDMA { get; }

		[Field ("CTRadioAccessTechnologyHSDPA")]
		NSString HSDPA { get; }

		[Field ("CTRadioAccessTechnologyHSUPA")]
		NSString HSUPA { get; }

		[Field ("CTRadioAccessTechnologyCDMA1x")]
		NSString CDMA1x { get; }

		[Field ("CTRadioAccessTechnologyCDMAEVDORev0")]
		NSString CDMAEVDORev0 { get; }

		[Field ("CTRadioAccessTechnologyCDMAEVDORevA")]
		NSString CDMAEVDORevA { get; }

		[Field ("CTRadioAccessTechnologyCDMAEVDORevB")]
		NSString CDMAEVDORevB { get; }

		[Field ("CTRadioAccessTechnologyeHRPD")]
		NSString EHRPD { get; }

		[Field ("CTRadioAccessTechnologyLTE")]
		NSString LTE { get; }

		[iOS (14, 1)]
		[MacCatalyst (14, 1)]
		[Field ("CTRadioAccessTechnologyNRNSA")]
		NSString NRNsa { get; }

		[iOS (14, 1)]
		[MacCatalyst (14, 1)]
		[Field ("CTRadioAccessTechnologyNR")]
		NSString NR { get; }
	}

	interface ICTTelephonyNetworkInfoDelegate { }

	[MacCatalyst (14, 0)]
	[iOS (13, 0)]
#if NET
	[Protocol, Model]
#else
	[Protocol, Model (AutoGeneratedName = true)]
#endif
	[BaseType (typeof (NSObject))]
	interface CTTelephonyNetworkInfoDelegate {

		[Export ("dataServiceIdentifierDidChange:")]
		void DataServiceIdentifierDidChange (string identifier);
	}

	/// <summary>A class that holds information on the application user's cellular service provider.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/NetworkingInternet/Reference/CTTelephonyNetworkInfo/index.html">Apple documentation for <c>CTTelephonyNetworkInfo</c></related>
	[MacCatalyst (14, 0)]
	[BaseType (typeof (NSObject))]
	interface CTTelephonyNetworkInfo {
		[Deprecated (PlatformName.iOS, 12, 0, message: "Use 'ServiceSubscriberCellularProviders' instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'ServiceSubscriberCellularProviders' instead.")]
		[Export ("subscriberCellularProvider", ArgumentSemantic.Retain)]
		[NullAllowed]
		CTCarrier SubscriberCellularProvider { get; }

		[Deprecated (PlatformName.iOS, 12, 0, message: "Use 'ServiceSubscriberCellularProvidersDidUpdateNotifier' instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'ServiceSubscriberCellularProvidersDidUpdateNotifier' instead.")]
		[NullAllowed] // by default this property is null
		[Export ("subscriberCellularProviderDidUpdateNotifier")]
		Action<CTCarrier> CellularProviderUpdatedEventHandler { get; set; }

		[Deprecated (PlatformName.iOS, 12, 0, message: "Use 'ServiceCurrentRadioAccessTechnology' instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'ServiceCurrentRadioAccessTechnology' instead.")]
		[Export ("currentRadioAccessTechnology")]
		[NullAllowed]
		NSString CurrentRadioAccessTechnology { get; }

		[iOS (12, 0)]
		[MacCatalyst (14, 0)]
		[Deprecated (PlatformName.iOS, 16, 0)]
		[Deprecated (PlatformName.MacCatalyst, 16, 0)]
		[NullAllowed]
		[Export ("serviceSubscriberCellularProviders", ArgumentSemantic.Retain)]
		NSDictionary<NSString, CTCarrier> ServiceSubscriberCellularProviders { get; }

		[iOS (12, 0)]
		[MacCatalyst (14, 0)]
		[NullAllowed]
		[Export ("serviceCurrentRadioAccessTechnology", ArgumentSemantic.Retain)]
		NSDictionary<NSString, NSString> ServiceCurrentRadioAccessTechnology { get; }

		[iOS (12, 0)]
		[MacCatalyst (14, 0)]
		[Deprecated (PlatformName.iOS, 16, 0)]
		[Deprecated (PlatformName.MacCatalyst, 16, 0)]
		[NullAllowed]
		[Export ("serviceSubscriberCellularProvidersDidUpdateNotifier", ArgumentSemantic.Copy)]
		Action<NSString> ServiceSubscriberCellularProvidersDidUpdateNotifier { get; set; }

		[iOS (12, 0)]
		[MacCatalyst (14, 0)]
		[Notification]
		[Field ("CTServiceRadioAccessTechnologyDidChangeNotification")]
		NSString ServiceRadioAccessTechnologyDidChangeNotification { get; }

		[iOS (13, 0)]
		[MacCatalyst (14, 0)]
		[NullAllowed, Export ("dataServiceIdentifier")]
		string DataServiceIdentifier { get; }

		[iOS (13, 0)]
		[MacCatalyst (14, 0)]
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ICTTelephonyNetworkInfoDelegate Delegate { get; set; }

		[iOS (13, 0)]
		[MacCatalyst (14, 0)]
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }
	}

	/// <summary>Holds a list of current calls and triggers events when their states change.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/NetworkingInternet/Reference/CTCallCenter/index.html">Apple documentation for <c>CTCallCenter</c></related>
	[MacCatalyst (14, 0)]
	[Deprecated (PlatformName.MacCatalyst, 14, 0, message: Constants.UseCallKitInstead)]
	[Deprecated (PlatformName.iOS, 10, 0, message: Constants.UseCallKitInstead)]
	[BaseType (typeof (NSObject))]
	interface CTCallCenter {
		[NullAllowed] // by default this property is null
		[Export ("callEventHandler")]
		Action<CTCall> CallEventHandler { get; set; }

		[Export ("currentCalls")]
		[NullAllowed]
		NSSet CurrentCalls { get; }

	}

	/// <summary>Contains information about the application user's home cellular service provider.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/NetworkingInternet/Reference/CTCarrier/index.html">Apple documentation for <c>CTCarrier</c></related>
	[Deprecated (PlatformName.MacCatalyst, 16, 0, message: Constants.UseCallKitInstead)]
	[Deprecated (PlatformName.iOS, 16, 0, message: Constants.UseCallKitInstead)]
	[MacCatalyst (14, 0)]
	[BaseType (typeof (NSObject))]
	interface CTCarrier {
		[NullAllowed]
		[Export ("mobileCountryCode")]
		string MobileCountryCode { get; }

		[NullAllowed]
		[Export ("mobileNetworkCode")]
		string MobileNetworkCode { get; }

		[NullAllowed]
		[Export ("isoCountryCode")]
		string IsoCountryCode { get; }

		[Export ("allowsVOIP")]
		bool AllowsVoip { get; }

		[NullAllowed]
		[Export ("carrierName")]
		string CarrierName { get; }
	}

	interface ICTSubscriberDelegate { }

	[NoMacCatalyst]
	[Protocol]
	[iOS (12, 1)]
	interface CTSubscriberDelegate {
		[Abstract]
		[Export ("subscriberTokenRefreshed:")]
		void SubscriberTokenRefreshed (CTSubscriber subscriber);
	}

	/// <summary>Carrier information for a subscriber.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/CoreTelephony/Reference/CTSubscriber/index.html">Apple documentation for <c>CTSubscriber</c></related>
	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	partial interface CTSubscriber {
		[Export ("carrierToken")]
		[NullAllowed]
		[Deprecated (PlatformName.iOS, 11, 0)]
		[Deprecated (PlatformName.MacCatalyst, 13, 1)]
		NSData CarrierToken { get; }

		[iOS (12, 1)]
		[Export ("identifier")]
		string Identifier { get; }

		[iOS (12, 1)]
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		[iOS (12, 1)]
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ICTSubscriberDelegate Delegate { get; set; }
	}

	/// <summary>Information on a subscriber to a telephone service.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/reference/CoreTelephony/CTSubscriberInfo">Apple documentation for <c>CTSubscriberInfo</c></related>
	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	partial interface CTSubscriberInfo {
		[Deprecated (PlatformName.iOS, 12, 1, message: "Use 'Subscribers' instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'Subscribers' instead.")]
		[Static]
		[Export ("subscriber")]
		CTSubscriber Subscriber { get; }

		[iOS (12, 1)]
		[Static]
		[Export ("subscribers")]
		CTSubscriber [] Subscribers { get; }
	}

	[NoMacCatalyst]
	[iOS (12, 0)]
	[BaseType (typeof (NSObject))]
	interface CTCellularPlanProvisioningRequest : NSSecureCoding {
		[Export ("address")]
		string Address { get; set; }

		[NullAllowed, Export ("matchingID")]
		string MatchingId { get; set; }

		[NullAllowed, Export ("OID")]
		string Oid { get; set; }

		[NullAllowed, Export ("confirmationCode")]
		string ConfirmationCode { get; set; }

		[NullAllowed, Export ("ICCID")]
		string Iccid { get; set; }

		[NullAllowed, Export ("EID")]
		string Eid { get; set; }
	}

	[NoMacCatalyst]
	[iOS (12, 0)]
	[BaseType (typeof (NSObject))]
	interface CTCellularPlanProvisioning {
		[Export ("supportsCellularPlan")]
		bool SupportsCellularPlan { get; }

		[Async]
		[Export ("addPlanWith:completionHandler:")]
		void AddPlan (CTCellularPlanProvisioningRequest request, Action<CTCellularPlanProvisioningAddPlanResult> completionHandler);

		[iOS (16, 0)]
		[Export ("supportsEmbeddedSIM")]
		bool SupportsEmbeddedSim { get; }
	}
}
