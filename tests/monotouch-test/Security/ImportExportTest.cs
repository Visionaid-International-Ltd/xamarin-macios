// Copyright 2011 Xamarin Inc. All rights reserved

using System;
using Foundation;
using Security;
using NUnit.Framework;

namespace MonoTouchFixtures.Security {

	[TestFixture]
	[Preserve (AllMembers = true)]
	public class ImportExportTest {

		// copy-pasted from mono/mcs/class/corlib/Test/System.Security.Cryptography.X509Certificates/X509Cert20Test.cs
		static public byte [] farscape_pfx = { 0x30, 0x82, 0x06, 0xA3, 0x02, 0x01, 0x03, 0x30, 0x82, 0x06, 0x63, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x07, 0x01, 0xA0, 0x82, 0x06, 0x54, 0x04, 0x82, 0x06, 0x50, 0x30, 0x82, 0x06, 0x4C, 0x30, 0x82, 0x03, 0x8D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x07, 0x01, 0xA0, 0x82, 0x03, 0x7E, 0x04, 0x82, 0x03, 0x7A, 0x30, 0x82, 0x03, 0x76, 0x30, 0x82, 0x03, 0x72, 0x06, 0x0B, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x0C, 0x0A, 0x01, 0x02, 0xA0, 0x82, 0x02, 0xB6, 0x30, 0x82, 0x02, 0xB2, 0x30, 0x1C, 0x06, 0x0A, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x0C, 0x01, 0x03, 0x30,
			0x0E, 0x04, 0x08, 0x67, 0xFE, 0x3A, 0x52, 0x75, 0xF3, 0x82, 0x1F, 0x02, 0x02, 0x07, 0xD0, 0x04, 0x82, 0x02, 0x90, 0x31, 0x6B, 0x00, 0xFA, 0x73, 0xE6, 0x8D, 0x3D, 0x62, 0x93, 0x41, 0xA1, 0x44, 0x04, 0x17, 0x8D, 0x66, 0x7A, 0x75, 0x14, 0x89, 0xA8, 0xD1, 0x4D, 0x2A, 0xD7, 0x20, 0x27, 0x71, 0x58, 0x81, 0x16, 0xB5, 0xA6, 0x41, 0x75, 0x92, 0xB2, 0xF4, 0x0C, 0xAA, 0x9B, 0x00, 0x46, 0x85, 0x85, 0x3B, 0x09, 0x2A, 0x62, 0x33, 0x3F, 0x3D, 0x06, 0xC7, 0xE7, 0x16, 0x0C, 0xA7, 0x1D, 0x9C, 0xDA, 0x9D, 0xD3, 0xC9, 0x05, 0x60, 0xA5, 0xBE, 0xF0, 0x07, 0xD5, 0xA9, 0x4F, 0x8A, 0x80, 0xF8, 0x55, 0x7B, 0x7B, 0x3C,
			0xA0, 0x7C, 0x29, 0x29, 0xAB, 0xB1, 0xE1, 0x5A, 0x25, 0xE3, 0x23, 0x6A, 0x56, 0x98, 0x37, 0x68, 0xAF, 0x9C, 0x87, 0xBB, 0x21, 0x6E, 0x68, 0xBE, 0xAE, 0x65, 0x0C, 0x41, 0x8F, 0x5C, 0x3A, 0xB8, 0xB1, 0x9D, 0x42, 0x37, 0xE4, 0xA0, 0x37, 0xA6, 0xB8, 0xAC, 0x85, 0xD7, 0x85, 0x27, 0x68, 0xD0, 0xB6, 0x3D, 0xC7, 0x39, 0x92, 0x41, 0x46, 0x24, 0xDD, 0x08, 0x57, 0x22, 0x6A, 0xC0, 0xB7, 0xAD, 0x52, 0xC6, 0x7F, 0xE5, 0x74, 0x6A, 0x5E, 0x28, 0xA3, 0x85, 0xBD, 0xE8, 0xAD, 0x5D, 0xA3, 0x55, 0xE6, 0x63, 0x15, 0x56, 0x7B, 0x01, 0x26, 0x68, 0x5F, 0x11, 0xA3, 0x12, 0x37, 0x02, 0xA5, 0xD0, 0xB7, 0x73, 0x0C, 0x7C,
			0x97, 0xE1, 0xC6, 0x2F, 0x98, 0x82, 0x67, 0x2F, 0x5F, 0x3F, 0xBE, 0x32, 0x16, 0x25, 0x9D, 0x51, 0x48, 0x32, 0xCB, 0x42, 0xD1, 0x31, 0x07, 0xBE, 0x5D, 0xF8, 0xCD, 0x2C, 0x38, 0x0A, 0x33, 0x3B, 0x7B, 0x04, 0x84, 0xAE, 0x9C, 0xA7, 0x6B, 0x36, 0x39, 0x12, 0x87, 0x9D, 0x5B, 0x56, 0x00, 0x44, 0x11, 0xB1, 0xE2, 0x78, 0x14, 0x60, 0xF3, 0xE4, 0x1A, 0x08, 0x14, 0xC0, 0x9E, 0x49, 0x9F, 0xE0, 0x4C, 0xEC, 0x95, 0x15, 0x18, 0x48, 0x0E, 0xB9, 0x0B, 0x3A, 0xFE, 0x45, 0xB0, 0x2D, 0x0D, 0x4F, 0x94, 0x5A, 0x3C, 0x43, 0xB7, 0x40, 0x8E, 0x7B, 0xA2, 0x8E, 0x23, 0x9F, 0x75, 0x97, 0xE7, 0x21, 0x0D, 0xEB, 0xA3, 0x9D,
			0x6C, 0xC0, 0xDC, 0x73, 0xED, 0x15, 0x98, 0xE3, 0xE8, 0x32, 0x2C, 0x12, 0x92, 0x45, 0x25, 0x45, 0x76, 0x18, 0xF5, 0x97, 0x7F, 0xAC, 0xCE, 0xCF, 0x23, 0xF7, 0xD1, 0xCF, 0x06, 0xAB, 0x82, 0x96, 0x1F, 0xF8, 0x68, 0x4F, 0x5D, 0xE1, 0x09, 0xAA, 0xCB, 0xB3, 0x50, 0x85, 0x46, 0x72, 0x14, 0x6C, 0x49, 0x84, 0x57, 0x55, 0x00, 0x78, 0x3E, 0xD9, 0xAA, 0xBD, 0xCC, 0xE2, 0x7B, 0x18, 0xAA, 0x2E, 0x5D, 0xB9, 0x28, 0xEA, 0x8F, 0x8C, 0xFA, 0xB7, 0x06, 0x27, 0x07, 0x89, 0x41, 0x3F, 0x66, 0x1A, 0x91, 0xCA, 0xE9, 0xEC, 0x09, 0x12, 0x1C, 0x67, 0xB2, 0x2A, 0x8B, 0x4A, 0xF0, 0x97, 0x17, 0xDC, 0x3E, 0xCD, 0x9F, 0x03,
			0x15, 0xEF, 0x03, 0x84, 0x08, 0x4A, 0x73, 0xAE, 0xE4, 0x07, 0x30, 0x27, 0xF7, 0x25, 0x69, 0x9D, 0x6C, 0x7D, 0x81, 0x88, 0xCC, 0xFA, 0xD4, 0xC7, 0x64, 0x11, 0xC0, 0xC8, 0x2C, 0x23, 0xF6, 0xFF, 0x9B, 0xE3, 0xC8, 0x89, 0x85, 0x0B, 0x3E, 0x81, 0xD8, 0x9C, 0xBD, 0xD0, 0x2D, 0xCD, 0x15, 0xA9, 0x30, 0x84, 0xF7, 0x6D, 0xEF, 0x62, 0x3B, 0xA7, 0x8C, 0xC2, 0x93, 0x90, 0x6F, 0x91, 0xB4, 0x8A, 0x71, 0x4E, 0x41, 0x4E, 0x5C, 0x67, 0xB5, 0x49, 0xF8, 0x56, 0x3A, 0x83, 0x03, 0x4F, 0xB1, 0xF6, 0xB7, 0x31, 0x5B, 0x68, 0x26, 0x70, 0x89, 0xB1, 0x1E, 0x67, 0x4F, 0xBA, 0xE7, 0xD9, 0xDF, 0x91, 0xD8, 0xFB, 0x8A, 0xDD,
			0xB2, 0xD3, 0x4B, 0xBB, 0x9F, 0x5C, 0xA3, 0x04, 0x2C, 0x87, 0xBC, 0xD5, 0xBE, 0x8C, 0xD7, 0xCF, 0x9B, 0x72, 0x82, 0xA6, 0x99, 0xDA, 0xD7, 0x66, 0x48, 0xE7, 0x8F, 0xE9, 0x48, 0x56, 0x9D, 0xD2, 0xB9, 0x28, 0x84, 0x4F, 0x6A, 0x83, 0xB2, 0xB9, 0x4D, 0x91, 0x10, 0x58, 0x22, 0x4C, 0xE7, 0x9D, 0xC6, 0x0C, 0x74, 0xF4, 0x16, 0x58, 0x30, 0xB7, 0xB7, 0x96, 0x39, 0x6C, 0x5D, 0xFA, 0xB2, 0x03, 0x8C, 0x98, 0xD2, 0xC0, 0x64, 0xB8, 0x05, 0x29, 0x4F, 0xF0, 0x4C, 0x43, 0x48, 0xD3, 0xD8, 0xBD, 0xC7, 0xC1, 0xEA, 0x39, 0x2A, 0xDF, 0xD4, 0xDA, 0x79, 0x7C, 0xB9, 0x06, 0xC7, 0x10, 0x8D, 0x8B, 0xF1, 0xA8, 0x8E, 0x44,
			0x9E, 0x99, 0xFF, 0x81, 0x84, 0x8F, 0xD0, 0x38, 0xE1, 0xF0, 0x5A, 0x12, 0x5F, 0xC5, 0xA6, 0xED, 0x6D, 0xEE, 0xE7, 0x69, 0xC0, 0xA2, 0xB4, 0x13, 0xCA, 0x7A, 0x5D, 0xDE, 0x88, 0x75, 0xE7, 0xE2, 0x6D, 0x8A, 0xEC, 0x0F, 0x88, 0x3F, 0xE2, 0xCB, 0x60, 0xF0, 0x6A, 0xEC, 0xD0, 0xF4, 0x0D, 0x11, 0xC2, 0x84, 0x19, 0x67, 0x52, 0xAD, 0xC0, 0xC0, 0x20, 0x84, 0x6D, 0x7D, 0xEA, 0xD2, 0xF9, 0x3F, 0xE5, 0x58, 0x00, 0xED, 0x24, 0xD6, 0x50, 0x9B, 0x80, 0x80, 0x0A, 0x31, 0x81, 0xA8, 0x30, 0x0D, 0x06, 0x09, 0x2B, 0x06, 0x01, 0x04, 0x01, 0x82, 0x37, 0x11, 0x02, 0x31, 0x00, 0x30, 0x13, 0x06, 0x09, 0x2A, 0x86, 0x48,
			0x86, 0xF7, 0x0D, 0x01, 0x09, 0x15, 0x31, 0x06, 0x04, 0x04, 0x01, 0x00, 0x00, 0x00, 0x30, 0x17, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x09, 0x14, 0x31, 0x0A, 0x1E, 0x08, 0x00, 0x4D, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x6F, 0x30, 0x69, 0x06, 0x09, 0x2B, 0x06, 0x01, 0x04, 0x01, 0x82, 0x37, 0x11, 0x01, 0x31, 0x5C, 0x1E, 0x5A, 0x00, 0x4D, 0x00, 0x69, 0x00, 0x63, 0x00, 0x72, 0x00, 0x6F, 0x00, 0x73, 0x00, 0x6F, 0x00, 0x66, 0x00, 0x74, 0x00, 0x20, 0x00, 0x52, 0x00, 0x53, 0x00, 0x41, 0x00, 0x20, 0x00, 0x53, 0x00, 0x43, 0x00, 0x68, 0x00, 0x61, 0x00, 0x6E, 0x00, 0x6E, 0x00, 0x65, 0x00, 0x6C,
			0x00, 0x20, 0x00, 0x43, 0x00, 0x72, 0x00, 0x79, 0x00, 0x70, 0x00, 0x74, 0x00, 0x6F, 0x00, 0x67, 0x00, 0x72, 0x00, 0x61, 0x00, 0x70, 0x00, 0x68, 0x00, 0x69, 0x00, 0x63, 0x00, 0x20, 0x00, 0x50, 0x00, 0x72, 0x00, 0x6F, 0x00, 0x76, 0x00, 0x69, 0x00, 0x64, 0x00, 0x65, 0x00, 0x72, 0x30, 0x82, 0x02, 0xB7, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x07, 0x06, 0xA0, 0x82, 0x02, 0xA8, 0x30, 0x82, 0x02, 0xA4, 0x02, 0x01, 0x00, 0x30, 0x82, 0x02, 0x9D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x07, 0x01, 0x30, 0x1C, 0x06, 0x0A, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x0C, 0x01,
			0x06, 0x30, 0x0E, 0x04, 0x08, 0xB8, 0x22, 0xEA, 0x3C, 0x70, 0x6A, 0xFC, 0x39, 0x02, 0x02, 0x07, 0xD0, 0x80, 0x82, 0x02, 0x70, 0x76, 0xBE, 0x5B, 0xD5, 0x3D, 0x05, 0xC1, 0xDB, 0x10, 0xA3, 0x02, 0xBB, 0x7F, 0x0A, 0x8B, 0x54, 0xC1, 0x7D, 0x19, 0xDA, 0x7E, 0x82, 0xDF, 0xAD, 0x6B, 0x42, 0xC2, 0x95, 0x95, 0x00, 0x6E, 0x82, 0x77, 0xD5, 0x42, 0x6E, 0x21, 0xA2, 0x95, 0xB4, 0x98, 0xF5, 0xDD, 0x18, 0x6F, 0xC4, 0xF3, 0xB6, 0x93, 0xA0, 0x6C, 0xF4, 0x34, 0x7A, 0x48, 0x72, 0x08, 0xB1, 0x28, 0x51, 0x54, 0x10, 0x7F, 0x35, 0xB2, 0xE5, 0x89, 0x5C, 0x0A, 0x14, 0x31, 0x1C, 0x9D, 0xA9, 0xE4, 0x94, 0x91, 0x28, 0x65,
			0xC4, 0xE7, 0x5E, 0xA9, 0x37, 0x08, 0x3D, 0xB1, 0x16, 0x61, 0x9D, 0xA9, 0x44, 0x6F, 0x20, 0x0C, 0x55, 0xD7, 0xCC, 0x48, 0x82, 0x13, 0x5D, 0xE1, 0xBD, 0x9D, 0xCE, 0x64, 0x28, 0x6D, 0x69, 0x4E, 0x08, 0x53, 0x09, 0xE0, 0xCC, 0xA8, 0x79, 0x04, 0xCF, 0xFA, 0x35, 0x1C, 0xA6, 0x70, 0x37, 0x64, 0x70, 0x74, 0xF8, 0xD0, 0xC4, 0x34, 0x0F, 0x71, 0xEF, 0x57, 0xC2, 0x43, 0x7D, 0xFA, 0xE5, 0x1B, 0x8C, 0x15, 0xA5, 0x08, 0x60, 0x78, 0xAF, 0xDA, 0x36, 0xDF, 0x79, 0x2D, 0xD7, 0x54, 0x35, 0xD7, 0x8D, 0x99, 0xD5, 0x81, 0xEC, 0x6D, 0x9F, 0x2D, 0x5E, 0xF8, 0x48, 0x85, 0x50, 0x20, 0x7D, 0xBB, 0x16, 0x4E, 0x39, 0x64,
			0xB7, 0xBC, 0xED, 0xA9, 0x6A, 0x7A, 0x06, 0x09, 0x6B, 0xBC, 0x2C, 0x5A, 0xE1, 0x4F, 0xD4, 0xA9, 0x82, 0x83, 0x5B, 0xBD, 0xCE, 0x14, 0x31, 0x89, 0x66, 0xB3, 0x9C, 0x31, 0x23, 0x00, 0x4B, 0x02, 0x34, 0x85, 0x30, 0x39, 0x77, 0x80, 0x5D, 0x72, 0x0A, 0xCE, 0x43, 0x2A, 0x1F, 0x02, 0x09, 0xAB, 0x2D, 0x46, 0x3A, 0x1C, 0xD2, 0x7B, 0xF6, 0x02, 0x92, 0xCA, 0xDA, 0x26, 0x0C, 0xF8, 0xE2, 0x67, 0x7E, 0xE2, 0x55, 0xB1, 0x3F, 0x6A, 0x06, 0x65, 0x6D, 0x74, 0x98, 0x59, 0xE2, 0x8A, 0x1E, 0x61, 0x03, 0x4D, 0xFC, 0x68, 0x31, 0x6A, 0xE7, 0xCF, 0x52, 0x88, 0x8E, 0x06, 0x97, 0x77, 0xB3, 0x20, 0x7E, 0x09, 0x5D, 0x3B,
			0xAF, 0x56, 0xF4, 0xE8, 0x4C, 0x69, 0x09, 0xB9, 0x80, 0x38, 0xDC, 0x66, 0x2E, 0x06, 0xF6, 0xCB, 0x1F, 0x1B, 0xAD, 0x51, 0xFF, 0xFD, 0x38, 0x8D, 0x03, 0x90, 0xCF, 0x31, 0x01, 0x30, 0xEA, 0x48, 0x4C, 0xBB, 0x40, 0x87, 0x1D, 0x97, 0x6A, 0x56, 0x4C, 0xED, 0x07, 0x23, 0x45, 0x50, 0x2F, 0x56, 0xC9, 0x90, 0x79, 0x09, 0xC5, 0x45, 0xB9, 0xAD, 0x58, 0x2B, 0x4C, 0xA3, 0x01, 0xE0, 0x2D, 0xE5, 0x30, 0xBC, 0x54, 0xEC, 0x65, 0xB4, 0x79, 0x22, 0x7D, 0x15, 0xF6, 0x28, 0xCD, 0x84, 0x7E, 0x27, 0x95, 0xA1, 0xC7, 0x82, 0x6D, 0xFB, 0xDF, 0x03, 0xD9, 0x14, 0xFE, 0x0A, 0x06, 0x6F, 0x14, 0xFF, 0x8A, 0x27, 0x80, 0x36,
			0xDC, 0xBA, 0xAE, 0xDD, 0x44, 0x15, 0xA5, 0x6E, 0x64, 0x73, 0xBD, 0xFB, 0xAE, 0x6D, 0x6F, 0x42, 0x96, 0xDF, 0x90, 0xE5, 0x6A, 0x9B, 0x05, 0xAE, 0xD5, 0x0A, 0x22, 0x88, 0xD6, 0x5D, 0x4C, 0x7B, 0xB1, 0x3A, 0xFC, 0x0C, 0x32, 0x02, 0xB1, 0x18, 0x0D, 0xAF, 0xE0, 0xFE, 0x7E, 0x07, 0x96, 0x85, 0xBB, 0xC8, 0x21, 0x68, 0x12, 0xD4, 0xC8, 0xBF, 0x91, 0x47, 0xE2, 0xF3, 0xA5, 0xA3, 0x86, 0xE6, 0x30, 0x42, 0xF5, 0xA9, 0xB9, 0x48, 0xCB, 0x18, 0xE6, 0x64, 0x3B, 0xE0, 0x8E, 0xC3, 0x03, 0x45, 0xA0, 0xED, 0x1A, 0x09, 0xFF, 0xB3, 0x99, 0x14, 0x5F, 0xDA, 0x90, 0x58, 0x61, 0x8E, 0xF7, 0x0A, 0x00, 0xC7, 0x44, 0xE7,
			0x73, 0x78, 0xC4, 0x8B, 0x39, 0xCE, 0x70, 0x0E, 0x24, 0x03, 0x95, 0x94, 0x73, 0x76, 0x10, 0x7E, 0x4C, 0xFF, 0xCA, 0x49, 0x93, 0x89, 0xD4, 0x3E, 0x1A, 0x88, 0xCC, 0x48, 0xA7, 0x78, 0x2F, 0x83, 0x4F, 0x6C, 0x33, 0x55, 0xDD, 0x7F, 0x7D, 0x4D, 0xE5, 0xCD, 0x9C, 0x3D, 0x04, 0x1E, 0xC1, 0x9B, 0x6D, 0x7E, 0x7A, 0xAC, 0x93, 0x5E, 0x2B, 0xC3, 0x85, 0x36, 0x07, 0x66, 0xE8, 0xC9, 0xC0, 0xD1, 0x54, 0xF4, 0x4C, 0x6A, 0x02, 0x24, 0x9A, 0x7D, 0x10, 0xD9, 0x79, 0x94, 0x00, 0x64, 0x63, 0x36, 0xDC, 0x35, 0x0C, 0x8F, 0x79, 0xBA, 0xC7, 0x10, 0x76, 0xF8, 0x4A, 0xD3, 0x69, 0x95, 0x23, 0x89, 0x66, 0xC4, 0x5A, 0xE7,
			0xCE, 0x21, 0xBC, 0xCB, 0xF2, 0x4F, 0x92, 0x33, 0xE7, 0x89, 0xD6, 0x23, 0xF7, 0x67, 0x5B, 0x20, 0xD9, 0xDA, 0x1A, 0xD1, 0xF6, 0x9E, 0x01, 0x83, 0x51, 0xAF, 0x35, 0x43, 0xDD, 0x3A, 0xAB, 0xCA, 0x0E, 0xED, 0x2E, 0x4D, 0x1E, 0x91, 0xCF, 0x2E, 0xA9, 0x4D, 0x08, 0xD9, 0x48, 0x30, 0x37, 0x30, 0x1F, 0x30, 0x07, 0x06, 0x05, 0x2B, 0x0E, 0x03, 0x02, 0x1A, 0x04, 0x14, 0xA2, 0xED, 0x05, 0x50, 0x89, 0x91, 0x1D, 0xEB, 0xF6, 0x57, 0x66, 0xAF, 0x70, 0x15, 0xDD, 0x1A, 0xA1, 0x94, 0xB7, 0xB2, 0x04, 0x14, 0x09, 0xE4, 0x0B, 0xEC, 0x1D, 0x93, 0x3E, 0x32, 0x94, 0x6A, 0x95, 0x36, 0xDD, 0xBA, 0x93, 0x9D, 0x75, 0xB6,
			0x3E, 0xF5 };

		[Test]
		public void P12_Success ()
		{
			NSDictionary [] array;
			using (NSMutableDictionary options = new NSMutableDictionary ()) {
				options [SecImportExport.Passphrase] = new NSString ("farscape");
				Assert.That (SecImportExport.ImportPkcs12 (farscape_pfx, options, out array), Is.EqualTo (SecStatusCode.Success), "Success");
			}
			Assert.That (array.Length, Is.EqualTo (1), "1");
			NSDictionary dict = array [0];
			foreach (var x in dict) {
				switch (x.Key.ToString ()) {
				case "trust":
				case "identity":
					Assert.That (x.Value, Is.TypeOf (typeof (NSObject)), "NSObject");
					break;
				case "chain":
					Assert.True (x.Value is NSArray, "NSArray");
					NSArray a = (x.Value as NSArray);
					Assert.That (a.Count, Is.EqualTo ((nuint) 1), "Count");
					break;
#if MONOMAC
				case "label":
					Assert.That (x.Value.ToString (), Is.EqualTo ("FARSCAPE"), "Label");
					break;
				case "keyid":
					Assert.That (x.Value, Is.TypeOf (typeof (NSMutableData)), "Keyid");
					Assert.That ((x.Value as NSData).Length, Is.EqualTo ((nuint) 20), "keyid");
					break;
#endif
				default:
					Assert.Fail ("Unexpected {0}", x.Key);
					break;
				}
			}
		}

		[Test]
		public void P12_AuthFailed ()
		{
			using (NSMutableDictionary options = new NSMutableDictionary ()) {
				options [SecImportExport.Passphrase] = new NSString ("b5");
				NSDictionary [] array;
				Assert.That (SecImportExport.ImportPkcs12 (farscape_pfx, options, out array), Is.EqualTo (SecStatusCode.AuthFailed).Or.EqualTo (SecStatusCode.Pkcs12VerifyFailure), "AuthFailed");
			}
		}
	}
}
