//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// <copyright file="iDeviceActivationNativeMethods.cs" company="Quamotion">
// Copyright (c) 2016-2019 Quamotion. All rights reserved.
// </copyright>
#pragma warning disable 1591
#pragma warning disable 1572
#pragma warning disable 1573

namespace iMobileDevice.iDeviceActivation
{
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using iMobileDevice.iDevice;
    using iMobileDevice.Lockdown;
    using iMobileDevice.Afc;
    using iMobileDevice.Plist;
    
    
    public partial class iDeviceActivationNativeMethods
    {
        
        public static void idevice_activation_request_get_field(iDeviceActivationRequestHandle request, string key, out string value)
        {
            System.Runtime.InteropServices.ICustomMarshaler valueMarshaler = NativeStringMarshaler.GetInstance(null);
            System.IntPtr valueNative = System.IntPtr.Zero;
            iDeviceActivationNativeMethods.idevice_activation_request_get_field(request, key, out valueNative);
            value = ((string)valueMarshaler.MarshalNativeToManaged(valueNative));
            valueMarshaler.CleanUpNativeData(valueNative);
        }
        
        public static void idevice_activation_request_get_url(iDeviceActivationRequestHandle request, out string url)
        {
            System.Runtime.InteropServices.ICustomMarshaler urlMarshaler = NativeStringMarshaler.GetInstance(null);
            System.IntPtr urlNative = System.IntPtr.Zero;
            iDeviceActivationNativeMethods.idevice_activation_request_get_url(request, out urlNative);
            url = ((string)urlMarshaler.MarshalNativeToManaged(urlNative));
            urlMarshaler.CleanUpNativeData(urlNative);
        }
        
        public static iDeviceActivationError idevice_activation_response_to_buffer(iDeviceActivationResponseHandle response, out string buffer, ref uint size)
        {
            System.Runtime.InteropServices.ICustomMarshaler bufferMarshaler = NativeStringMarshaler.GetInstance(null);
            System.IntPtr bufferNative = System.IntPtr.Zero;
            iDeviceActivationError returnValue = iDeviceActivationNativeMethods.idevice_activation_response_to_buffer(response, out bufferNative, ref size);
            buffer = ((string)bufferMarshaler.MarshalNativeToManaged(bufferNative));
            bufferMarshaler.CleanUpNativeData(bufferNative);
            return returnValue;
        }
        
        public static void idevice_activation_response_get_field(iDeviceActivationResponseHandle response, string key, out string value)
        {
            System.Runtime.InteropServices.ICustomMarshaler valueMarshaler = NativeStringMarshaler.GetInstance(null);
            System.IntPtr valueNative = System.IntPtr.Zero;
            iDeviceActivationNativeMethods.idevice_activation_response_get_field(response, key, out valueNative);
            value = ((string)valueMarshaler.MarshalNativeToManaged(valueNative));
            valueMarshaler.CleanUpNativeData(valueNative);
        }
        
        public static void idevice_activation_response_get_label(iDeviceActivationResponseHandle response, string key, out string value)
        {
            System.Runtime.InteropServices.ICustomMarshaler valueMarshaler = NativeStringMarshaler.GetInstance(null);
            System.IntPtr valueNative = System.IntPtr.Zero;
            iDeviceActivationNativeMethods.idevice_activation_response_get_label(response, key, out valueNative);
            value = ((string)valueMarshaler.MarshalNativeToManaged(valueNative));
            valueMarshaler.CleanUpNativeData(valueNative);
        }
        
        public static void idevice_activation_response_get_placeholder(iDeviceActivationResponseHandle response, string key, out string value)
        {
            System.Runtime.InteropServices.ICustomMarshaler valueMarshaler = NativeStringMarshaler.GetInstance(null);
            System.IntPtr valueNative = System.IntPtr.Zero;
            iDeviceActivationNativeMethods.idevice_activation_response_get_placeholder(response, key, out valueNative);
            value = ((string)valueMarshaler.MarshalNativeToManaged(valueNative));
            valueMarshaler.CleanUpNativeData(valueNative);
        }
        
        public static void idevice_activation_response_get_title(iDeviceActivationResponseHandle response, out string title)
        {
            System.Runtime.InteropServices.ICustomMarshaler titleMarshaler = NativeStringMarshaler.GetInstance(null);
            System.IntPtr titleNative = System.IntPtr.Zero;
            iDeviceActivationNativeMethods.idevice_activation_response_get_title(response, out titleNative);
            title = ((string)titleMarshaler.MarshalNativeToManaged(titleNative));
            titleMarshaler.CleanUpNativeData(titleNative);
        }
        
        public static void idevice_activation_response_get_description(iDeviceActivationResponseHandle response, out string description)
        {
            System.Runtime.InteropServices.ICustomMarshaler descriptionMarshaler = NativeStringMarshaler.GetInstance(null);
            System.IntPtr descriptionNative = System.IntPtr.Zero;
            iDeviceActivationNativeMethods.idevice_activation_response_get_description(response, out descriptionNative);
            description = ((string)descriptionMarshaler.MarshalNativeToManaged(descriptionNative));
            descriptionMarshaler.CleanUpNativeData(descriptionNative);
        }
    }
}
