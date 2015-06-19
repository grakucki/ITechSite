using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace InstrukcjeProdukcyjne
{
    public class StartupApp
    {
        public static void GetRole()
        {
            System.AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
     
            WindowsIdentity curIdentity = WindowsIdentity.GetCurrent();
            WindowsPrincipal myPrincipal = new WindowsPrincipal(curIdentity);
     
            List<string> groups = new List<string>();
     
            foreach (IdentityReference irc in curIdentity.Groups)
            {
                groups.Add(((NTAccount)irc.Translate(typeof(NTAccount))).Value);
             }
    
            Console.WriteLine( @"Name:           {0}, System: {1}  Authenticated:  {2}  BuiltinAdmin:   {3}  Identity:       {4}  Groups:         {5}",
           curIdentity.Name,  curIdentity.IsSystem, curIdentity.IsAuthenticated, myPrincipal.IsInRole(  WindowsBuiltInRole.Administrator ) ? "True" : "False", myPrincipal.Identity,string.Join(string.Format(",{0}\t\t", Environment.NewLine), groups.ToArray()));
    
    
       try
       {
           Console.WriteLine(Environment.NewLine);
           //ManagersOnly();
       }
       catch (System.Security.SecurityException scx)
       {
           Console.WriteLine(scx.Message + " " + scx.FirstPermissionThatFailed.ToString());
       }
       Console.WriteLine(Environment.NewLine);
   }


        public static void AllUser()
        {
            SaveSettings("AllUser ");
        }


        //[PrincipalPermissionAttribute(SecurityAction.Demand, Role = @"BUILTIN\Administratorzy")]
        [PermissionSetAttribute(SecurityAction.Demand)]
        public static void ManagersOnly()
        {
            System.AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            Console.WriteLine("Key to the Executive Wash Room");
            SaveSettings("ManagersOnly ");
        }


        public static void SaveSettings(string ss)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData).ToString();

            var s= ss+ DateTime.Now.ToString();
            File.WriteAllText(Path.Combine(path, "settings.xml"), s);
        }

        private static void SetPermissions(string dirPath)
        {
            DirectoryInfo info = new DirectoryInfo(dirPath);
            WindowsIdentity self = System.Security.Principal.WindowsIdentity.GetCurrent();
            DirectorySecurity ds = info.GetAccessControl();
            ds.AddAccessRule(new FileSystemAccessRule( @"BUILTIN\Użytkownicy", //self.Name,
            FileSystemRights.Modify | FileSystemRights.Write,
            InheritanceFlags.ObjectInherit |  InheritanceFlags.ContainerInherit,
            PropagationFlags.None,
            AccessControlType.Allow));
            info.SetAccessControl(ds);
        }

        internal static void CreateWorkDirektory(string p)
        {
            if (Directory.Exists(p))
            {
                //Directory.Delete(p);
                //File.AppendAllText(Path.Combine(p, "outtest.txt"), DateTime.Now.ToString() + WindowsIdentity.GetCurrent().Name + Environment.NewLine);
                return;
            }

            Directory.CreateDirectory(p);
            SetPermissions(p);
 
        }

        // Adds an ACL entry on the specified directory for the specified account. 
        public static void AddDirectorySecurity(string FileName, string Account, FileSystemRights Rights, AccessControlType ControlType)
        {
            // Create a new DirectoryInfo object.
            DirectoryInfo dInfo = new DirectoryInfo(FileName);

            // Get a DirectorySecurity object that represents the  
            // current security settings.
            DirectorySecurity dSecurity = dInfo.GetAccessControl();

            // Add the FileSystemAccessRule to the security settings. 
            dSecurity.AddAccessRule(new FileSystemAccessRule(Account,
                                                            Rights,
                                                            ControlType));
            // Set the new access settings.
            dInfo.SetAccessControl(dSecurity);
        }
    }
}
