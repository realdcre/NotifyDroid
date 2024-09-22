; ModuleID = 'marshal_methods.armeabi-v7a.ll'
source_filename = "marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [111 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [222 x i32] [
	i32 42639949, ; 0: System.Threading.Thread => 0x28aa24d => 103
	i32 67008169, ; 1: zh-Hant\Microsoft.Maui.Controls.resources => 0x3fe76a9 => 33
	i32 72070932, ; 2: Microsoft.Maui.Graphics.dll => 0x44bb714 => 47
	i32 117431740, ; 3: System.Runtime.InteropServices => 0x6ffddbc => 98
	i32 165246403, ; 4: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 53
	i32 182336117, ; 5: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 71
	i32 195452805, ; 6: vi/Microsoft.Maui.Controls.resources.dll => 0xba65f85 => 30
	i32 199333315, ; 7: zh-HK/Microsoft.Maui.Controls.resources.dll => 0xbe195c3 => 31
	i32 205061960, ; 8: System.ComponentModel => 0xc38ff48 => 83
	i32 209399409, ; 9: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 51
	i32 280992041, ; 10: cs/Microsoft.Maui.Controls.resources.dll => 0x10bf9929 => 2
	i32 317674968, ; 11: vi\Microsoft.Maui.Controls.resources => 0x12ef55d8 => 30
	i32 318968648, ; 12: Xamarin.AndroidX.Activity.dll => 0x13031348 => 48
	i32 336156722, ; 13: ja/Microsoft.Maui.Controls.resources.dll => 0x14095832 => 15
	i32 342366114, ; 14: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 60
	i32 356389973, ; 15: it/Microsoft.Maui.Controls.resources.dll => 0x153e1455 => 14
	i32 379916513, ; 16: System.Threading.Thread.dll => 0x16a510e1 => 103
	i32 385762202, ; 17: System.Memory.dll => 0x16fe439a => 90
	i32 395744057, ; 18: _Microsoft.Android.Resource.Designer => 0x17969339 => 34
	i32 435591531, ; 19: sv/Microsoft.Maui.Controls.resources.dll => 0x19f6996b => 26
	i32 442565967, ; 20: System.Collections => 0x1a61054f => 80
	i32 450948140, ; 21: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 59
	i32 469710990, ; 22: System.dll => 0x1bff388e => 106
	i32 498788369, ; 23: System.ObjectModel => 0x1dbae811 => 95
	i32 500358224, ; 24: id/Microsoft.Maui.Controls.resources.dll => 0x1dd2dc50 => 13
	i32 503918385, ; 25: fi/Microsoft.Maui.Controls.resources.dll => 0x1e092f31 => 7
	i32 513247710, ; 26: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 42
	i32 539058512, ; 27: Microsoft.Extensions.Logging => 0x20216150 => 39
	i32 592146354, ; 28: pt-BR/Microsoft.Maui.Controls.resources.dll => 0x234b6fb2 => 21
	i32 627609679, ; 29: Xamarin.AndroidX.CustomView => 0x2568904f => 57
	i32 627931235, ; 30: nl\Microsoft.Maui.Controls.resources => 0x256d7863 => 19
	i32 672442732, ; 31: System.Collections.Concurrent => 0x2814a96c => 78
	i32 688181140, ; 32: ca/Microsoft.Maui.Controls.resources.dll => 0x2904cf94 => 1
	i32 706645707, ; 33: ko/Microsoft.Maui.Controls.resources.dll => 0x2a1e8ecb => 16
	i32 709557578, ; 34: de/Microsoft.Maui.Controls.resources.dll => 0x2a4afd4a => 4
	i32 722857257, ; 35: System.Runtime.Loader.dll => 0x2b15ed29 => 99
	i32 759454413, ; 36: System.Net.Requests => 0x2d445acd => 93
	i32 775507847, ; 37: System.IO.Compression => 0x2e394f87 => 87
	i32 777317022, ; 38: sk\Microsoft.Maui.Controls.resources => 0x2e54ea9e => 25
	i32 780075347, ; 39: notifyd.dll => 0x2e7f0153 => 77
	i32 782051976, ; 40: notifyd => 0x2e9d2a88 => 77
	i32 789151979, ; 41: Microsoft.Extensions.Options => 0x2f0980eb => 41
	i32 823281589, ; 42: System.Private.Uri.dll => 0x311247b5 => 96
	i32 830298997, ; 43: System.IO.Compression.Brotli => 0x317d5b75 => 86
	i32 904024072, ; 44: System.ComponentModel.Primitives.dll => 0x35e25008 => 81
	i32 926902833, ; 45: tr/Microsoft.Maui.Controls.resources.dll => 0x373f6a31 => 28
	i32 967690846, ; 46: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 60
	i32 992768348, ; 47: System.Collections.dll => 0x3b2c715c => 80
	i32 1012816738, ; 48: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 70
	i32 1028951442, ; 49: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 38
	i32 1029334545, ; 50: da/Microsoft.Maui.Controls.resources.dll => 0x3d5a6611 => 3
	i32 1035644815, ; 51: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 49
	i32 1044663988, ; 52: System.Linq.Expressions.dll => 0x3e444eb4 => 88
	i32 1052210849, ; 53: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 62
	i32 1082857460, ; 54: System.ComponentModel.TypeConverter => 0x408b17f4 => 82
	i32 1084122840, ; 55: Xamarin.Kotlin.StdLib => 0x409e66d8 => 75
	i32 1098259244, ; 56: System => 0x41761b2c => 106
	i32 1118262833, ; 57: ko\Microsoft.Maui.Controls.resources => 0x42a75631 => 16
	i32 1168523401, ; 58: pt\Microsoft.Maui.Controls.resources => 0x45a64089 => 22
	i32 1178241025, ; 59: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 67
	i32 1203215381, ; 60: pl/Microsoft.Maui.Controls.resources.dll => 0x47b79c15 => 20
	i32 1234928153, ; 61: nb/Microsoft.Maui.Controls.resources.dll => 0x499b8219 => 18
	i32 1260983243, ; 62: cs\Microsoft.Maui.Controls.resources => 0x4b2913cb => 2
	i32 1293217323, ; 63: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 58
	i32 1324164729, ; 64: System.Linq => 0x4eed2679 => 89
	i32 1373134921, ; 65: zh-Hans\Microsoft.Maui.Controls.resources => 0x51d86049 => 32
	i32 1376866003, ; 66: Xamarin.AndroidX.SavedState => 0x52114ed3 => 70
	i32 1406073936, ; 67: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 54
	i32 1430672901, ; 68: ar\Microsoft.Maui.Controls.resources => 0x55465605 => 0
	i32 1461004990, ; 69: es\Microsoft.Maui.Controls.resources => 0x57152abe => 6
	i32 1462112819, ; 70: System.IO.Compression.dll => 0x57261233 => 87
	i32 1469204771, ; 71: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 50
	i32 1470490898, ; 72: Microsoft.Extensions.Primitives => 0x57a5e912 => 42
	i32 1480492111, ; 73: System.IO.Compression.Brotli.dll => 0x583e844f => 86
	i32 1493001747, ; 74: hi/Microsoft.Maui.Controls.resources.dll => 0x58fd6613 => 10
	i32 1514721132, ; 75: el/Microsoft.Maui.Controls.resources.dll => 0x5a48cf6c => 5
	i32 1543031311, ; 76: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 102
	i32 1551623176, ; 77: sk/Microsoft.Maui.Controls.resources.dll => 0x5c7be408 => 25
	i32 1622152042, ; 78: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 64
	i32 1624863272, ; 79: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 73
	i32 1636350590, ; 80: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 56
	i32 1639515021, ; 81: System.Net.Http.dll => 0x61b9038d => 91
	i32 1639986890, ; 82: System.Text.RegularExpressions => 0x61c036ca => 102
	i32 1657153582, ; 83: System.Runtime => 0x62c6282e => 100
	i32 1658251792, ; 84: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 74
	i32 1677501392, ; 85: System.Net.Primitives.dll => 0x63fca3d0 => 92
	i32 1679769178, ; 86: System.Security.Cryptography => 0x641f3e5a => 101
	i32 1729485958, ; 87: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 52
	i32 1736233607, ; 88: ro/Microsoft.Maui.Controls.resources.dll => 0x677cd287 => 23
	i32 1743415430, ; 89: ca\Microsoft.Maui.Controls.resources => 0x67ea6886 => 1
	i32 1766324549, ; 90: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 71
	i32 1770582343, ; 91: Microsoft.Extensions.Logging.dll => 0x6988f147 => 39
	i32 1780572499, ; 92: Mono.Android.Runtime.dll => 0x6a216153 => 109
	i32 1782862114, ; 93: ms\Microsoft.Maui.Controls.resources => 0x6a445122 => 17
	i32 1788241197, ; 94: Xamarin.AndroidX.Fragment => 0x6a96652d => 59
	i32 1793755602, ; 95: he\Microsoft.Maui.Controls.resources => 0x6aea89d2 => 9
	i32 1808609942, ; 96: Xamarin.AndroidX.Loader => 0x6bcd3296 => 64
	i32 1813058853, ; 97: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 75
	i32 1813201214, ; 98: Xamarin.Google.Android.Material => 0x6c13413e => 74
	i32 1818569960, ; 99: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 68
	i32 1828688058, ; 100: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 40
	i32 1842015223, ; 101: uk/Microsoft.Maui.Controls.resources.dll => 0x6dcaebf7 => 29
	i32 1853025655, ; 102: sv\Microsoft.Maui.Controls.resources => 0x6e72ed77 => 26
	i32 1858542181, ; 103: System.Linq.Expressions => 0x6ec71a65 => 88
	i32 1875935024, ; 104: fr\Microsoft.Maui.Controls.resources => 0x6fd07f30 => 8
	i32 1910275211, ; 105: System.Collections.NonGeneric.dll => 0x71dc7c8b => 79
	i32 1968388702, ; 106: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 35
	i32 2003115576, ; 107: el\Microsoft.Maui.Controls.resources => 0x77651e38 => 5
	i32 2019465201, ; 108: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 62
	i32 2025202353, ; 109: ar/Microsoft.Maui.Controls.resources.dll => 0x78b622b1 => 0
	i32 2045470958, ; 110: System.Private.Xml => 0x79eb68ee => 97
	i32 2055257422, ; 111: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 61
	i32 2066184531, ; 112: de\Microsoft.Maui.Controls.resources => 0x7b277953 => 4
	i32 2079903147, ; 113: System.Runtime.dll => 0x7bf8cdab => 100
	i32 2090596640, ; 114: System.Numerics.Vectors => 0x7c9bf920 => 94
	i32 2127167465, ; 115: System.Console => 0x7ec9ffe9 => 84
	i32 2159891885, ; 116: Microsoft.Maui => 0x80bd55ad => 45
	i32 2169148018, ; 117: hu\Microsoft.Maui.Controls.resources => 0x814a9272 => 12
	i32 2181898931, ; 118: Microsoft.Extensions.Options.dll => 0x820d22b3 => 41
	i32 2192057212, ; 119: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 40
	i32 2193016926, ; 120: System.ObjectModel.dll => 0x82b6c85e => 95
	i32 2201107256, ; 121: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 76
	i32 2201231467, ; 122: System.Net.Http => 0x8334206b => 91
	i32 2207618523, ; 123: it\Microsoft.Maui.Controls.resources => 0x839595db => 14
	i32 2266799131, ; 124: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 36
	i32 2270573516, ; 125: fr/Microsoft.Maui.Controls.resources.dll => 0x875633cc => 8
	i32 2279755925, ; 126: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 69
	i32 2303942373, ; 127: nb\Microsoft.Maui.Controls.resources => 0x89535ee5 => 18
	i32 2305521784, ; 128: System.Private.CoreLib.dll => 0x896b7878 => 107
	i32 2353062107, ; 129: System.Net.Primitives => 0x8c40e0db => 92
	i32 2368005991, ; 130: System.Xml.ReaderWriter.dll => 0x8d24e767 => 105
	i32 2371007202, ; 131: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 35
	i32 2395872292, ; 132: id\Microsoft.Maui.Controls.resources => 0x8ece1c24 => 13
	i32 2427813419, ; 133: hi\Microsoft.Maui.Controls.resources => 0x90b57e2b => 10
	i32 2435356389, ; 134: System.Console.dll => 0x912896e5 => 84
	i32 2475788418, ; 135: Java.Interop.dll => 0x93918882 => 108
	i32 2480646305, ; 136: Microsoft.Maui.Controls => 0x93dba8a1 => 43
	i32 2550873716, ; 137: hr\Microsoft.Maui.Controls.resources => 0x980b3e74 => 11
	i32 2593496499, ; 138: pl\Microsoft.Maui.Controls.resources => 0x9a959db3 => 20
	i32 2605712449, ; 139: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 76
	i32 2617129537, ; 140: System.Private.Xml.dll => 0x9bfe3a41 => 97
	i32 2620871830, ; 141: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 56
	i32 2626831493, ; 142: ja\Microsoft.Maui.Controls.resources => 0x9c924485 => 15
	i32 2663698177, ; 143: System.Runtime.Loader => 0x9ec4cf01 => 99
	i32 2732626843, ; 144: Xamarin.AndroidX.Activity => 0xa2e0939b => 48
	i32 2737747696, ; 145: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 50
	i32 2752995522, ; 146: pt-BR\Microsoft.Maui.Controls.resources => 0xa41760c2 => 21
	i32 2758225723, ; 147: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 44
	i32 2764765095, ; 148: Microsoft.Maui.dll => 0xa4caf7a7 => 45
	i32 2778768386, ; 149: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 72
	i32 2785988530, ; 150: th\Microsoft.Maui.Controls.resources => 0xa60ecfb2 => 27
	i32 2801831435, ; 151: Microsoft.Maui.Graphics => 0xa7008e0b => 47
	i32 2806116107, ; 152: es/Microsoft.Maui.Controls.resources.dll => 0xa741ef0b => 6
	i32 2810250172, ; 153: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 54
	i32 2831556043, ; 154: nl/Microsoft.Maui.Controls.resources.dll => 0xa8c61dcb => 19
	i32 2853208004, ; 155: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 72
	i32 2861189240, ; 156: Microsoft.Maui.Essentials => 0xaa8a4878 => 46
	i32 2909740682, ; 157: System.Private.CoreLib => 0xad6f1e8a => 107
	i32 2916838712, ; 158: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 73
	i32 2919462931, ; 159: System.Numerics.Vectors.dll => 0xae037813 => 94
	i32 2959614098, ; 160: System.ComponentModel.dll => 0xb0682092 => 83
	i32 2978675010, ; 161: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 58
	i32 3038032645, ; 162: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 34
	i32 3057625584, ; 163: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 65
	i32 3059408633, ; 164: Mono.Android.Runtime => 0xb65adef9 => 109
	i32 3059793426, ; 165: System.ComponentModel.Primitives => 0xb660be12 => 81
	i32 3077302341, ; 166: hu/Microsoft.Maui.Controls.resources.dll => 0xb76be845 => 12
	i32 3178803400, ; 167: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 66
	i32 3220365878, ; 168: System.Threading => 0xbff2e236 => 104
	i32 3258312781, ; 169: Xamarin.AndroidX.CardView => 0xc235e84d => 52
	i32 3305363605, ; 170: fi\Microsoft.Maui.Controls.resources => 0xc503d895 => 7
	i32 3316684772, ; 171: System.Net.Requests.dll => 0xc5b097e4 => 93
	i32 3317135071, ; 172: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 57
	i32 3346324047, ; 173: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 67
	i32 3357674450, ; 174: ru\Microsoft.Maui.Controls.resources => 0xc8220bd2 => 24
	i32 3362522851, ; 175: Xamarin.AndroidX.Core => 0xc86c06e3 => 55
	i32 3366347497, ; 176: Java.Interop => 0xc8a662e9 => 108
	i32 3374999561, ; 177: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 69
	i32 3381016424, ; 178: da\Microsoft.Maui.Controls.resources => 0xc9863768 => 3
	i32 3428513518, ; 179: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 37
	i32 3463511458, ; 180: hr/Microsoft.Maui.Controls.resources.dll => 0xce70fda2 => 11
	i32 3471940407, ; 181: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 82
	i32 3476120550, ; 182: Mono.Android => 0xcf3163e6 => 110
	i32 3479583265, ; 183: ru/Microsoft.Maui.Controls.resources.dll => 0xcf663a21 => 24
	i32 3484440000, ; 184: ro\Microsoft.Maui.Controls.resources => 0xcfb055c0 => 23
	i32 3580758918, ; 185: zh-HK\Microsoft.Maui.Controls.resources => 0xd56e0b86 => 31
	i32 3608519521, ; 186: System.Linq.dll => 0xd715a361 => 89
	i32 3641597786, ; 187: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 61
	i32 3643446276, ; 188: tr\Microsoft.Maui.Controls.resources => 0xd92a9404 => 28
	i32 3643854240, ; 189: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 66
	i32 3657292374, ; 190: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 36
	i32 3672681054, ; 191: Mono.Android.dll => 0xdae8aa5e => 110
	i32 3682565725, ; 192: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 51
	i32 3697841164, ; 193: zh-Hant/Microsoft.Maui.Controls.resources.dll => 0xdc68940c => 33
	i32 3724971120, ; 194: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 65
	i32 3748608112, ; 195: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 85
	i32 3786282454, ; 196: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 53
	i32 3792276235, ; 197: System.Collections.NonGeneric => 0xe2098b0b => 79
	i32 3823082795, ; 198: System.Security.Cryptography.dll => 0xe3df9d2b => 101
	i32 3841636137, ; 199: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 38
	i32 3849253459, ; 200: System.Runtime.InteropServices.dll => 0xe56ef253 => 98
	i32 3889960447, ; 201: zh-Hans/Microsoft.Maui.Controls.resources.dll => 0xe7dc15ff => 32
	i32 3896106733, ; 202: System.Collections.Concurrent.dll => 0xe839deed => 78
	i32 3896760992, ; 203: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 55
	i32 3928044579, ; 204: System.Xml.ReaderWriter => 0xea213423 => 105
	i32 3931092270, ; 205: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 68
	i32 3955647286, ; 206: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 49
	i32 3980434154, ; 207: th/Microsoft.Maui.Controls.resources.dll => 0xed409aea => 27
	i32 3987592930, ; 208: he/Microsoft.Maui.Controls.resources.dll => 0xedadd6e2 => 9
	i32 4025784931, ; 209: System.Memory => 0xeff49a63 => 90
	i32 4046471985, ; 210: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 44
	i32 4073602200, ; 211: System.Threading.dll => 0xf2ce3c98 => 104
	i32 4094352644, ; 212: Microsoft.Maui.Essentials.dll => 0xf40add04 => 46
	i32 4100113165, ; 213: System.Private.Uri => 0xf462c30d => 96
	i32 4102112229, ; 214: pt/Microsoft.Maui.Controls.resources.dll => 0xf48143e5 => 22
	i32 4125707920, ; 215: ms/Microsoft.Maui.Controls.resources.dll => 0xf5e94e90 => 17
	i32 4126470640, ; 216: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 37
	i32 4150914736, ; 217: uk\Microsoft.Maui.Controls.resources => 0xf769eeb0 => 29
	i32 4182413190, ; 218: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 63
	i32 4213026141, ; 219: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 85
	i32 4271975918, ; 220: Microsoft.Maui.Controls.dll => 0xfea12dee => 43
	i32 4292120959 ; 221: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 63
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [222 x i32] [
	i32 103, ; 0
	i32 33, ; 1
	i32 47, ; 2
	i32 98, ; 3
	i32 53, ; 4
	i32 71, ; 5
	i32 30, ; 6
	i32 31, ; 7
	i32 83, ; 8
	i32 51, ; 9
	i32 2, ; 10
	i32 30, ; 11
	i32 48, ; 12
	i32 15, ; 13
	i32 60, ; 14
	i32 14, ; 15
	i32 103, ; 16
	i32 90, ; 17
	i32 34, ; 18
	i32 26, ; 19
	i32 80, ; 20
	i32 59, ; 21
	i32 106, ; 22
	i32 95, ; 23
	i32 13, ; 24
	i32 7, ; 25
	i32 42, ; 26
	i32 39, ; 27
	i32 21, ; 28
	i32 57, ; 29
	i32 19, ; 30
	i32 78, ; 31
	i32 1, ; 32
	i32 16, ; 33
	i32 4, ; 34
	i32 99, ; 35
	i32 93, ; 36
	i32 87, ; 37
	i32 25, ; 38
	i32 77, ; 39
	i32 77, ; 40
	i32 41, ; 41
	i32 96, ; 42
	i32 86, ; 43
	i32 81, ; 44
	i32 28, ; 45
	i32 60, ; 46
	i32 80, ; 47
	i32 70, ; 48
	i32 38, ; 49
	i32 3, ; 50
	i32 49, ; 51
	i32 88, ; 52
	i32 62, ; 53
	i32 82, ; 54
	i32 75, ; 55
	i32 106, ; 56
	i32 16, ; 57
	i32 22, ; 58
	i32 67, ; 59
	i32 20, ; 60
	i32 18, ; 61
	i32 2, ; 62
	i32 58, ; 63
	i32 89, ; 64
	i32 32, ; 65
	i32 70, ; 66
	i32 54, ; 67
	i32 0, ; 68
	i32 6, ; 69
	i32 87, ; 70
	i32 50, ; 71
	i32 42, ; 72
	i32 86, ; 73
	i32 10, ; 74
	i32 5, ; 75
	i32 102, ; 76
	i32 25, ; 77
	i32 64, ; 78
	i32 73, ; 79
	i32 56, ; 80
	i32 91, ; 81
	i32 102, ; 82
	i32 100, ; 83
	i32 74, ; 84
	i32 92, ; 85
	i32 101, ; 86
	i32 52, ; 87
	i32 23, ; 88
	i32 1, ; 89
	i32 71, ; 90
	i32 39, ; 91
	i32 109, ; 92
	i32 17, ; 93
	i32 59, ; 94
	i32 9, ; 95
	i32 64, ; 96
	i32 75, ; 97
	i32 74, ; 98
	i32 68, ; 99
	i32 40, ; 100
	i32 29, ; 101
	i32 26, ; 102
	i32 88, ; 103
	i32 8, ; 104
	i32 79, ; 105
	i32 35, ; 106
	i32 5, ; 107
	i32 62, ; 108
	i32 0, ; 109
	i32 97, ; 110
	i32 61, ; 111
	i32 4, ; 112
	i32 100, ; 113
	i32 94, ; 114
	i32 84, ; 115
	i32 45, ; 116
	i32 12, ; 117
	i32 41, ; 118
	i32 40, ; 119
	i32 95, ; 120
	i32 76, ; 121
	i32 91, ; 122
	i32 14, ; 123
	i32 36, ; 124
	i32 8, ; 125
	i32 69, ; 126
	i32 18, ; 127
	i32 107, ; 128
	i32 92, ; 129
	i32 105, ; 130
	i32 35, ; 131
	i32 13, ; 132
	i32 10, ; 133
	i32 84, ; 134
	i32 108, ; 135
	i32 43, ; 136
	i32 11, ; 137
	i32 20, ; 138
	i32 76, ; 139
	i32 97, ; 140
	i32 56, ; 141
	i32 15, ; 142
	i32 99, ; 143
	i32 48, ; 144
	i32 50, ; 145
	i32 21, ; 146
	i32 44, ; 147
	i32 45, ; 148
	i32 72, ; 149
	i32 27, ; 150
	i32 47, ; 151
	i32 6, ; 152
	i32 54, ; 153
	i32 19, ; 154
	i32 72, ; 155
	i32 46, ; 156
	i32 107, ; 157
	i32 73, ; 158
	i32 94, ; 159
	i32 83, ; 160
	i32 58, ; 161
	i32 34, ; 162
	i32 65, ; 163
	i32 109, ; 164
	i32 81, ; 165
	i32 12, ; 166
	i32 66, ; 167
	i32 104, ; 168
	i32 52, ; 169
	i32 7, ; 170
	i32 93, ; 171
	i32 57, ; 172
	i32 67, ; 173
	i32 24, ; 174
	i32 55, ; 175
	i32 108, ; 176
	i32 69, ; 177
	i32 3, ; 178
	i32 37, ; 179
	i32 11, ; 180
	i32 82, ; 181
	i32 110, ; 182
	i32 24, ; 183
	i32 23, ; 184
	i32 31, ; 185
	i32 89, ; 186
	i32 61, ; 187
	i32 28, ; 188
	i32 66, ; 189
	i32 36, ; 190
	i32 110, ; 191
	i32 51, ; 192
	i32 33, ; 193
	i32 65, ; 194
	i32 85, ; 195
	i32 53, ; 196
	i32 79, ; 197
	i32 101, ; 198
	i32 38, ; 199
	i32 98, ; 200
	i32 32, ; 201
	i32 78, ; 202
	i32 55, ; 203
	i32 105, ; 204
	i32 68, ; 205
	i32 49, ; 206
	i32 27, ; 207
	i32 9, ; 208
	i32 90, ; 209
	i32 44, ; 210
	i32 104, ; 211
	i32 46, ; 212
	i32 96, ; 213
	i32 22, ; 214
	i32 17, ; 215
	i32 37, ; 216
	i32 29, ; 217
	i32 63, ; 218
	i32 85, ; 219
	i32 43, ; 220
	i32 63 ; 221
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 4

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 4

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 4

; Functions

; Function attributes: "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 4, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 1

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }

; Metadata
!llvm.module.flags = !{!0, !1, !7}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.2xx @ 96b6bb65e8736e45180905177aa343f0e1854ea3"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"min_enum_size", i32 4}
