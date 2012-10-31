using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace NsfwHandler
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length >= 1)
            {
                // take some argument

                if (args[0].StartsWith("/") || args[0].StartsWith("-"))
                {

                    // find out where I am
                    string myLocation = System.Reflection.Assembly.GetEntryAssembly().Location;

                    // it is a setting
                    switch (args[0].ToLowerInvariant())
                    {
                        case "/i":
                        case "-i":
                            // install url handler
                            try
                            {
                                RegistryKey proto = Registry.ClassesRoot.CreateSubKey("nsfw");
                                proto.SetValue(null, "URL:NSFW Protocol");
                                proto.SetValue("URL Protocol", "");
                                proto.CreateSubKey("DefaultIcon").SetValue(null, myLocation + ",1");
                                proto.CreateSubKey("shell").CreateSubKey("open").CreateSubKey("command").SetValue(null, string.Format("\"{0}\" \"%1\"", myLocation));
                                proto.Close();

                                proto = Registry.ClassesRoot.CreateSubKey("nsfws");
                                proto.SetValue(null, "URL:NSFWS Protocol");
                                proto.SetValue("URL Protocol", "");
                                proto.CreateSubKey("DefaultIcon").SetValue(null, myLocation + ",1");
                                proto.CreateSubKey("shell").CreateSubKey("open").CreateSubKey("command").SetValue(null, string.Format("\"{0}\" \"%1\"", myLocation));
                                proto.Close();

                                MessageBox.Show("nsfw and nsfws protocol handlers installed!");
                            }
                            catch (UnauthorizedAccessException)
                            {
                                MessageBox.Show("Permission denied.  Please run this command as an administrative user.");
                            }
                            break;

                            


                        case "/u":
                        case "-u":
                            try
                            {
                                // uninstall url handler
                                Registry.ClassesRoot.DeleteSubKeyTree("nsfw");
                                Registry.ClassesRoot.DeleteSubKeyTree("nsfws");
                                MessageBox.Show("nsfw and nsfws protocol handlers uninstalled!");
                            }
                            catch (UnauthorizedAccessException)
                            {
                                MessageBox.Show("Permission denied.  Please run this command as an administrative user.");
                            }
                            break;

                        case "/?":
                        case "-h":
                            MessageBox.Show("nsfwhandler\r\n   -i     Installs the protocol handlers for nsfw and nsfws\r\n   -u     Uninstalls the protocol handlers for nsfw and nsfws\r\n (URL)    Handles the nsfw/nsfws URL");
                            break;

                        default:
                            MessageBox.Show("Unknown option, try -h");
                            break;
                    }

                }
                else
                {
                    // it is a url
                    // parse it
                    Uri u = new Uri(args[0]);

                    // pass to form
                    Application.Run(new frmMain(u));

                }


            }
            else
            {
                // no url given
                // die
                MessageBox.Show("No URL given or command line option. :(");


            }



        }
    }
}
