using System;
using System.Management;

namespace TestVersion
{
    public class Software
    {
        // Method that will fetch the version of a given software
        public string GetSoftwateVersion(string softWareName)
        {
            string strVersion;
            try
            {
                var version = (object)null;
                //Query the system registery for the verion of the given software                
                var searcher = new ManagementObjectSearcher(
                  "SELECT * FROM Win32_Product where Name LIKE " +
                  "'%" + softWareName + "%'");
                foreach (var o in searcher.Get())
                {
                    var obj = (ManagementObject)o;
                    version = obj["Version"];
                }

                if (version != null)
                {
                    strVersion = (String)version;
                }
                // if given product is not found in list of installed products in control panel
                else
                {
                    strVersion = "Given Product is not found the list of Installed Programs";
                }
            }
            // Exception Handling
            catch (Exception e)
            {
                strVersion = "An Error occured while fetching Version" +
                  " (" + e.Message + ")";
            }
            return strVersion;
        }
    }
}