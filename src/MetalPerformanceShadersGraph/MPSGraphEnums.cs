using System;
using System.Runtime.InteropServices;

using Foundation;
using ObjCRuntime;
using Metal;

namespace MetalPerformanceShadersGraph {
	[Flags]
	public enum MPSGraphOptions : ulong {
		None = 0,
		SynchronizeResults = 1,
		Verbose = 2,
		Default = SynchronizeResults,
	}

	[Native]
	public enum MPSGraphTensorNamedDataLayout : ulong {
		Nchw = 0,
		Nhwc = 1,
		Oihw = 2,
		Hwio = 3,
		Chw = 4,
		Hwc = 5,
		Hw = 6,
		[Mac (13, 2), iOS (16, 3), TV (16, 3), MacCatalyst (16, 3)]
		Ncdhw = 7,
		[Mac (13, 2), iOS (16, 3), TV (16, 3), MacCatalyst (16, 3)]
		Ndhwc = 8,
		[Mac (13, 2), iOS (16, 3), TV (16, 3), MacCatalyst (16, 3)]
		Oidhw = 9,
		[Mac (13, 2), iOS (16, 3), TV (16, 3), MacCatalyst (16, 3)]
		Dhwio = 10,
	}

	[Native]
	public enum MPSGraphPaddingStyle : ulong {
		Explicit = 0,
		Valid = 1,
		Same = 2,
		ExplicitOffset = 3,
		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
		OnnxSameLower = 4,
	}

	[Native]
	public enum MPSGraphPaddingMode : long {
		Constant = 0,
		Reflect = 1,
		Symmetric = 2,
		ClampToEdge = 3,
		Zero = 4,
		Periodic = 5,
		AntiPeriodic = 6,
	}

	[Native]
	public enum MPSGraphReductionMode : ulong {
		Min = 0,
		Max = 1,
		Sum = 2,
		Product = 3,
		ArgumentMin = 4,
		ArgumentMax = 5,
	}

	[Native]
	public enum MPSGraphResizeMode : ulong {
		Nearest = 0,
		Bilinear = 1,
	}

	[Native]
	public enum MPSGraphScatterMode : long {
		Add = 0,
		Sub = 1,
		Mul = 2,
		Div = 3,
		Min = 4,
		Max = 5,
		Set = 6,
	}

	public enum MPSGraphDeviceType : uint {
		Metal = 0,
	}

	public enum MPSGraphLossReductionType : ulong {
		Axis = 0,
		Sum = 1,
		Mean = 2,
	}

	// For COO, indexTensor0 is x index and indexTensor1 is y index
	// For CSC, indexTensor0 and indexTensor1 correspond to rowIndex and colStarts respectively.
	// For CSR, indexTensor0 and indexTensor1 correspond to colIndex and rowStarts respectively.
	public enum MPSGraphSparseStorageType : ulong {
		Coo = 0,
		Csc = 1,
		Csr = 2,
	}

	public enum MPSGraphRandomDistribution : ulong {
		Uniform = 0,
		Normal = 1,
		TruncatedNormal = 2,
	}

	public enum MPSGraphRandomNormalSamplingMethod : ulong {
		InvCdf = 0,
		BoxMuller = 1,
	}

	[TV (15, 4), Mac (12, 3), iOS (15, 4), MacCatalyst (15, 4)]
	public enum MPSGraphOptimization : ulong {
		Level0 = 0,
		Level1 = 1L,
	}

	[TV (15, 4), Mac (12, 3), iOS (15, 4), MacCatalyst (15, 4)]
	public enum MPSGraphOptimizationProfile : ulong {
		Performance = 0,
		PowerEfficiency = 1L,
	}
}
