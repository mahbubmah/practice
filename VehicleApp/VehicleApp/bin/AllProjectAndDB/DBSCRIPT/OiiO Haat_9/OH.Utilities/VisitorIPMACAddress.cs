using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Runtime.InteropServices;


namespace OH.Utilities
{
    public class VisitorIPMACAddress
    {
       
        public string GetVisitorIPAddress(bool GetLan = false)
        {
            string visitorIPAddress = "";
            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null
              && HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != "")
            {
                visitorIPAddress = (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null
                                    && HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != "")
                                    ? HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]
                                    : HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                if (visitorIPAddress.Contains(","))
                    visitorIPAddress = visitorIPAddress.Split(',').First().Trim();// Return real client IP.


            }
            else
            {
                // not using proxy or can't get the Client IP

                visitorIPAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                if (String.IsNullOrEmpty(visitorIPAddress))
                    visitorIPAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

                if (string.IsNullOrEmpty(visitorIPAddress))
                    visitorIPAddress = HttpContext.Current.Request.UserHostAddress;

                if (string.IsNullOrEmpty(visitorIPAddress) || visitorIPAddress.Trim() == "::1")
                {
                    GetLan = true;
                    visitorIPAddress = string.Empty;
                }

                if (GetLan && string.IsNullOrEmpty(visitorIPAddress))
                {
                    //This is for Local(LAN) Connected ID Address
                    string stringHostName = Dns.GetHostName();
                    //Get Ip Host Entry
                    IPHostEntry ipHostEntries = Dns.GetHostEntry(stringHostName);
                    //Get Ip Address From The Ip Host Entry Address List
                    IPAddress[] arrIpAddress = ipHostEntries.AddressList;

                    try
                    {
                        visitorIPAddress = arrIpAddress[arrIpAddress.Length - 2].ToString();
                    }
                    catch
                    {
                        try
                        {
                            visitorIPAddress = arrIpAddress[0].ToString();
                        }
                        catch
                        {
                            try
                            {
                                arrIpAddress = Dns.GetHostAddresses(stringHostName);
                                visitorIPAddress = arrIpAddress[0].ToString();
                            }
                            catch
                            {
                                visitorIPAddress = "127.0.0.1";
                            }
                        }
                    }
                }
            }

            return visitorIPAddress;
        }

        //public string GetVisitorMACAddress()
        //{

        //    NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
        //    String sMacAddress = string.Empty;
        //    foreach (NetworkInterface adapter in nics)
        //    {
        //        if (sMacAddress == String.Empty)// only return MAC Address from first card  
        //        {
        //            IPInterfaceProperties properties = adapter.GetIPProperties();
        //            sMacAddress = adapter.GetPhysicalAddress().ToString();
        //        }
        //    }
        //    return sMacAddress;
        //}


        /// <summary>
        /// Hasan Add 2015.03.29 GetVisitorMACAddress
        /// </summary>
        /// <returns></returns>
        public string GetVisitorMACAddress()
        {
            string macAddress = string.Empty;
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Only consider Ethernet network interfaces
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet &&
                    nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddress = nic.GetPhysicalAddress().ToString();
                }
                // Only consider Wireless network interfaces
                else if (nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 &&
                    nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddress = nic.GetPhysicalAddress().ToString();
                }
                // Only consider GenericModem network interfaces
                else if (nic.NetworkInterfaceType == NetworkInterfaceType.GenericModem &&
                     nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddress = nic.GetPhysicalAddress().ToString();
                }
                // Only consider HighPerformanceSerialBus network interfaces
                else if (nic.NetworkInterfaceType == NetworkInterfaceType.HighPerformanceSerialBus &&
                     nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddress = nic.GetPhysicalAddress().ToString();
                }
                // Only consider Unknown network interfaces
                else if (nic.NetworkInterfaceType == NetworkInterfaceType.Unknown &&
                     nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddress = nic.GetPhysicalAddress().ToString();
                }




            }
            return macAddress;
        }


    

    }
}
