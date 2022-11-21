#!/bin/bash -ex

# Go to the top level directory
cd "$(git rev-parse --show-toplevel)"
SRC_DIR=$(pwd)

# Go one directory up, to avoid any global.json in xamarin-macios
cd ..

# Start formatting!
dotnet format "$SRC_DIR/tools/xibuild/xibuild.csproj"
dotnet format whitespace "$SRC_DIR/tests/cecil-tests/cecil-tests.csproj"
dotnet format whitespace "$SRC_DIR/tests/dotnet/UnitTests/DotNetUnitTests.csproj"
dotnet format whitespace "$SRC_DIR/msbuild/Messaging/Xamarin.Messaging.Build/Xamarin.Messaging.Build.csproj"
dotnet format whitespace "$SRC_DIR/msbuild/Xamarin.Localization.MSBuild/Xamarin.Localization.MSBuild.csproj"
dotnet format whitespace "$SRC_DIR/msbuild/Xamarin.Mac.Tasks/Xamarin.Mac.Tasks.csproj"
dotnet format whitespace "$SRC_DIR/msbuild/Xamarin.MacDev.Tasks/Xamarin.MacDev.Tasks.csproj"
dotnet format whitespace "$SRC_DIR/msbuild/Xamarin.iOS.Tasks.Windows/Xamarin.iOS.Tasks.Windows.csproj"
dotnet format whitespace "$SRC_DIR/msbuild/Xamarin.iOS.Tasks/Xamarin.iOS.Tasks.csproj"
dotnet format whitespace "$SRC_DIR/src/bgen/bgen.csproj"
dotnet format whitespace "$SRC_DIR/tools/dotnet-linker/dotnet-linker.csproj"
dotnet format whitespace "$SRC_DIR/tools/mmp/mmp.csproj"
dotnet format whitespace "$SRC_DIR/tools/mtouch/mtouch.csproj"
dotnet format whitespace "$SRC_DIR/tests/xharness/xharness.sln"
dotnet format whitespace "$SRC_DIR/tools/siminstaller/siminstaller.csproj"
dotnet format whitespace "$SRC_DIR/tests/introspection/dotnet/iOS/introspection.csproj"
dotnet format whitespace "$SRC_DIR/tests/introspection/dotnet/MacCatalyst/introspection.csproj"
dotnet format whitespace "$SRC_DIR/tests/introspection/dotnet/macOS/introspection.csproj"
dotnet format whitespace "$SRC_DIR/tests/introspection/dotnet/tvOS/introspection.csproj"
dotnet format whitespace "$SRC_DIR/tests/introspection/iOS/introspection-ios.csproj"
dotnet format whitespace "$SRC_DIR/tests/introspection/Mac/introspection-mac.csproj"
dotnet format whitespace "$SRC_DIR/tests/monotouch-test/dotnet/iOS/monotouch-test.csproj"
dotnet format whitespace "$SRC_DIR/tests/monotouch-test/dotnet/MacCatalyst/monotouch-test.csproj"
dotnet format whitespace "$SRC_DIR/tests/monotouch-test/dotnet/macOS/monotouch-test.csproj"
dotnet format whitespace "$SRC_DIR/tests/monotouch-test/dotnet/tvOS/monotouch-test.csproj"
dotnet format whitespace "$SRC_DIR/tests/xtro-sharpie/xtro-sharpie.csproj"
dotnet format whitespace "$SRC_DIR/tests/xtro-sharpie/u2ignore/u2ignore.csproj"
dotnet format whitespace "$SRC_DIR/tests/xtro-sharpie/u2todo/u2todo.csproj"
dotnet format whitespace "$SRC_DIR/tests/xtro-sharpie/xtro-report/xtro-report.csproj"
dotnet format whitespace "$SRC_DIR/tests/xtro-sharpie/xtro-sanity/xtro-sanity.csproj"
dotnet format whitespace --folder "$SRC_DIR/tests/common"
dotnet format whitespace --folder "$SRC_DIR/tests/dotnet"
dotnet format whitespace --folder "$SRC_DIR/tests/generator"
dotnet format whitespace --folder "$SRC_DIR/tests/monotouch-test"
dotnet format whitespace --folder "$SRC_DIR/tests/msbuild"
dotnet format whitespace --folder "$SRC_DIR/tests/xtro-sharpie"
dotnet format whitespace --folder "$SRC_DIR/tools"

dotnet format whitespace --folder "$SRC_DIR/src/Accelerate"
dotnet format whitespace --folder "$SRC_DIR/src/Accessibility"
dotnet format whitespace --folder "$SRC_DIR/src/Accounts"
dotnet format whitespace --folder "$SRC_DIR/src/AddressBook"
dotnet format whitespace --folder "$SRC_DIR/src/AddressBookUI"
dotnet format whitespace --folder "$SRC_DIR/src/AdSupport/"
dotnet format whitespace --folder "$SRC_DIR/src/AppKit/"
dotnet format whitespace --folder "$SRC_DIR/src/ARKit/"
dotnet format whitespace --folder "$SRC_DIR/src/AssetsLibrary/"
dotnet format whitespace --folder "$SRC_DIR/src/AudioToolbox/"
dotnet format whitespace --folder "$SRC_DIR/src/AudioUnit/"
dotnet format whitespace --folder "$SRC_DIR/src/AuthenticationServices/"
dotnet format whitespace --folder "$SRC_DIR/src/AVFoundation/"
dotnet format whitespace --folder "$SRC_DIR/src/AVKit/"
dotnet format whitespace --folder "$SRC_DIR/src/BackgroundTasks/"
dotnet format whitespace --folder "$SRC_DIR/src/BusinessChat/"
dotnet format whitespace --folder "$SRC_DIR/src/CFNetwork/"
dotnet format whitespace --folder "$SRC_DIR/src/CarPlay/"
dotnet format whitespace --folder "$SRC_DIR/src/Chip/"
dotnet format whitespace --folder "$SRC_DIR/src/ClockKit/"
dotnet format whitespace --folder "$SRC_DIR/src/CloudKit/"
dotnet format whitespace --folder "$SRC_DIR/src/Compression/"
dotnet format whitespace --folder "$SRC_DIR/src/Contacts/"
dotnet format whitespace --folder "$SRC_DIR/src/CoreAnimation/"
dotnet format whitespace --folder "$SRC_DIR/src/CoreBluetooth/"
dotnet format whitespace --folder "$SRC_DIR/src/CoreData/"
dotnet format whitespace --folder "$SRC_DIR/src/CoreFoundation/"
dotnet format whitespace --folder "$SRC_DIR/src/CoreGraphics/"
dotnet format whitespace --folder "$SRC_DIR/src/CoreHaptics"
dotnet format whitespace --folder "$SRC_DIR/src/CoreImage"
dotnet format whitespace --folder "$SRC_DIR/src/CoreLocation"
dotnet format whitespace --folder "$SRC_DIR/src/CoreML"
dotnet format whitespace --folder "$SRC_DIR/src/CoreMedia"
dotnet format whitespace --folder "$SRC_DIR/src/CoreMidi"
dotnet format whitespace --folder "$SRC_DIR/src/CoreMotion"
dotnet format whitespace --folder "$SRC_DIR/src/CoreServices"
dotnet format whitespace --folder "$SRC_DIR/src/CoreTelephony"
dotnet format whitespace --folder "$SRC_DIR/src/CoreText"
dotnet format whitespace --folder "$SRC_DIR/src/CoreVideo"
dotnet format whitespace --folder "$SRC_DIR/src/CoreWlan"
dotnet format whitespace --folder "$SRC_DIR/src/EventKit"
dotnet format whitespace --folder "$SRC_DIR/src/EventKitUI"
dotnet format whitespace --folder "$SRC_DIR/src/ExternalAccessory"
dotnet format whitespace --folder "$SRC_DIR/src/FileProvider"
dotnet format whitespace --folder "$SRC_DIR/src/FinderSync"
dotnet format whitespace --folder "$SRC_DIR/src/Foundation"
dotnet format whitespace --folder "$SRC_DIR/src/GLKit"
dotnet format whitespace --folder "$SRC_DIR/src/GameController"
dotnet format whitespace --folder "$SRC_DIR/src/GameKit"
dotnet format whitespace --folder "$SRC_DIR/src/GameplayKit"
dotnet format whitespace --folder "$SRC_DIR/src/HealthKit"
dotnet format whitespace --folder "$SRC_DIR/src/HomeKit"
dotnet format whitespace --folder "$SRC_DIR/src/IOSurface"
dotnet format whitespace --folder "$SRC_DIR/src/ImageCaptureCore"
dotnet format whitespace --folder "$SRC_DIR/src/ImageIO"
dotnet format whitespace --folder "$SRC_DIR/src/ImageKit"
dotnet format whitespace --folder "$SRC_DIR/src/Intents"
dotnet format whitespace --folder "$SRC_DIR/src/JavaScriptCore"
dotnet format whitespace --folder "$SRC_DIR/src/LocalAuthentication"
dotnet format whitespace --folder "$SRC_DIR/src/MLCompute"
dotnet format whitespace --folder "$SRC_DIR/src/MapKit"
dotnet format whitespace --folder "$SRC_DIR/src/MediaAccessibility"
dotnet format whitespace --folder "$SRC_DIR/src/MediaLibrary"
dotnet format whitespace --folder "$SRC_DIR/src/MediaPlayer"
dotnet format whitespace --folder "$SRC_DIR/src/MediaToolbox"
dotnet format whitespace --folder "$SRC_DIR/src/Network"
dotnet format whitespace --folder "$SRC_DIR/src/NetworkExtension"
dotnet format whitespace --folder "$SRC_DIR/src/NotificationCenter"
dotnet format whitespace --folder "$SRC_DIR/src/SceneKit"
dotnet format whitespace --folder "$SRC_DIR/src/PassKit"
dotnet format whitespace --folder "$SRC_DIR/src/PdfKit"
dotnet format whitespace --folder "$SRC_DIR/src/Photos"
dotnet format whitespace --folder "$SRC_DIR/src/PhotosUI"
dotnet format whitespace --folder "$SRC_DIR/src/PrintCore"
dotnet format whitespace --folder "$SRC_DIR/src/QTKit"
dotnet format whitespace --folder "$SRC_DIR/src/QuickLookUI"
dotnet format whitespace --folder "$SRC_DIR/src/ReplayKit"
dotnet format whitespace --folder "$SRC_DIR/src/SafariServices"
dotnet format whitespace --folder "$SRC_DIR/src/ScreenCaptureKit"
dotnet format whitespace --folder "$SRC_DIR/src/ScriptingBridge"
dotnet format whitespace --folder "$SRC_DIR/src/SearchKit"
dotnet format whitespace --folder "$SRC_DIR/src/Security"
dotnet format whitespace --folder "$SRC_DIR/src/SensorKit"
dotnet format whitespace --folder "$SRC_DIR/src/Social"
dotnet format whitespace --folder "$SRC_DIR/src/SpriteKit"
dotnet format whitespace --folder "$SRC_DIR/src/StoreKit"
dotnet format whitespace --folder "$SRC_DIR/src/SystemConfiguration"
dotnet format whitespace --folder "$SRC_DIR/src/TVServices"
dotnet format whitespace --folder "$SRC_DIR/src/UIKit"
dotnet format whitespace --folder "$SRC_DIR/src/VideoToolbox"
dotnet format whitespace --folder "$SRC_DIR/src/Vision"
dotnet format whitespace --folder "$SRC_DIR/src/WKWebKit"

# dotnet format "$SRC_DIR/[...]"
# add more projects here...

cd "$SRC_DIR"
