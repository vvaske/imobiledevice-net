﻿using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace iMobileDevice
{
    public static class NativeLibraries
    {
        public static bool LibraryFound
        {
            get;
            private set;
        }

        public static void Load()
        {
            Load(Path.GetDirectoryName(typeof(NativeLibraries).GetTypeInfo().Assembly.Location));
        }

        public static void Load(string directory)
        {
            if (directory == null)
            {
                throw new ArgumentNullException(nameof(directory));
            }

            if (!Directory.Exists(directory))
            {
                throw new ArgumentOutOfRangeException(nameof(directory), $"The directory '{directory}' does not exist.");
            }

            // When the library is first called, call LoadLibrary with the full path to the
            // path of the various libaries, to make sure they are loaded from the exact
            // path we specify.

            // Any load errors would also be caught by us here, making it easier to troubleshoot.

            bool isWindows = false;
            bool isLinux = false;
            bool isOsX = false;

#if !NETSTANDARD1_5
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Win32NT:
                    isWindows = true;
                    break;

                case PlatformID.Unix:
                    isLinux = true;
                    break;

                case PlatformID.MacOSX:
                    isOsX = true;
                    break;
            }
#else
            isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            isLinux = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
            isOsX =  RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
#endif

            if (isWindows)
            {
                string[] windowsLibariesToLoad = new string[]
                {
                    "msvcr110",
                    "vcruntime140",
                    "zlib",
                    "libiconv",
                    "libxml2",
                    "getopt",
                    "libeay32",
                    "ssleay32",
                    "libimobiledevice",
                };

                string nativeLibrariesDirectory;

#if !NETSTANDARD1_5
                if (Environment.Is64BitProcess)
#else
                if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
#endif
                {
                    nativeLibrariesDirectory = Path.Combine(directory, "win7-x64");
                }
                else
                {
                    nativeLibrariesDirectory = Path.Combine(directory, "win7-x86");
                }

                if (!Directory.Exists(nativeLibrariesDirectory))
                {
                    throw new ArgumentOutOfRangeException(nameof(directory), $"The directory '{directory}' does not contain a subdirectory for the current architecture. The directory '{nativeLibrariesDirectory}' does not exist.");
                }

                foreach (var libraryToLoad in windowsLibariesToLoad)
                {
                    string path = Path.Combine(nativeLibrariesDirectory, string.Format("{0}.dll", libraryToLoad));

                    // Attempt to load the libraries. If they are not found, throw an error.
                    // See also http://blogs.msdn.com/b/adam_nathan/archive/2003/04/25/56643.aspx for
                    // more information about GetLastWin32Error
                    IntPtr result = NativeMethods.LoadLibrary(path);
                    if (result == IntPtr.Zero)
                    {
                        var lastError = Marshal.GetLastWin32Error();
                        var error = new Win32Exception(lastError);
                        throw error;
                    }
                }

                LibraryFound = true;
            }
            else if (isLinux)
            {
                string[] linuxLibariesToLoad = new string[]
                    {
                        "libimobiledevice",
                    };

                // Clear any value from dlerror
                NativeMethods.dlerror();

                foreach (var libraryToLoad in linuxLibariesToLoad)
                {
                    // Attempt to load the libraries. If they are not found, throw an error.
                    IntPtr result = NativeMethods.dlopen($"{libraryToLoad}.so", DlOpenFlags.RTLD_NOW);

                    if (result == IntPtr.Zero)
                    {
                        var lastError = NativeMethods.dlerror();
                        var errorMessage = Marshal.PtrToStringAnsi(lastError);

                        return;
                    }
                }

                LibraryFound = true;
            }
            else
            {
                LibraryFound = false;
            }
        }
    }
}
