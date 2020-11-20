using AlienLabs.GraphicsAmplifier.Domain;
using AlienLabs.GraphicsAmplifier.Domain.Classes.Factories;
using AlienLabs.GraphicsAmplifier.ServiceController;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace OpenCaldera
{
    class Program
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Assembly ResolveAssemblies(object sender, ResolveEventArgs args)
        {
            // Parse the requested assembly name.
            string requestedAssembly = args.Name.Substring(0, args.Name.IndexOf(','));

            // Retrieve a list of already loaded assemblies; if the requested assembly is already loaded, return it.
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                if (assembly.FullName.Contains(requestedAssembly))
                    return assembly;

            List<string> paths = new List<string>();

            paths.Add(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Alienware\\Graphics Amplifier"));
            paths.Add(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Alienware\\Graphics Amplifier"));
            paths.Add(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Alienware\\Alienware Command Center"));
            paths.Add(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Alienware\\Alienware Command Center"));

            List<string> files = new List<string>();

            foreach (var path in paths)
                if (Directory.Exists(path))
                    foreach (var filepath in Directory.GetFiles(path))
                        files.Add(filepath);

            string found = String.Empty;

            foreach (var file in files)
            {
                if (file.Contains(requestedAssembly))
                {
                    found = file;
                    break;
                }
            }

            if (string.IsNullOrWhiteSpace(found))
                Console.WriteLine($"! The requested Assembly could not be located: {requestedAssembly}");

            //Console.WriteLine($"Loaded Assembly: {found}\n");

            // Load the Assembly.
            try
            {
                using (var stream = new FileStream(found, FileMode.Open, FileAccess.Read))
                {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);

                    return Assembly.Load(assemblyData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"! Error loading requested Assembly: {requestedAssembly}");
                Console.WriteLine($"! Error: {ex.Message}\n");

                Console.WriteLine("Press Enter to close.");
                Console.ReadLine();

                Environment.Exit(-1);
            }

            return null;
        }

        static void Main(string[] args)
        {
            Console.WriteLine($"OpenCaldera {FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion}\n");

            // Add an Assembly Resolver to locate Alienware Libraries as needed.
            // No code utilizing an Alienware Library can be referenced in this method, or .NET will attempt to resolve the Assembly prior to adding this custom handler.
            AppDomain.CurrentDomain.AssemblyResolve += ResolveAssemblies;

            ReadAGABIOSProperties();
        }

        static void ReadAGABIOSProperties()
        {
            // Must be constructed first, otherwise GraphicsAmplifierBIOSProvider will not populate, regardless of calling "Initialize()".
            ApplicationController ac = AlienLabs.GraphicsAmplifier.ServiceController.Classes.Factories.ObjectFactory.NewApplicationControllerClass(IntPtr.Zero, false);
            ac.Load();

            GraphicsAmplifierBIOSProvider biosProvider = ObjectFactory.NewGraphicsAmplifierBIOSProvider();
            // Not necessary; already populated during ApplicationController.Load() above?
            //biosProvider.Initialize();

            Console.WriteLine("Reading Alienware Graphics Amplifier BIOS Properties:\n");
            Console.WriteLine($"Is Present:\t\t\t{biosProvider.IsPresent}");
            Console.WriteLine($"Is Connected:\t\t\t{biosProvider.IsConnected}");
            Console.WriteLine($"Is Card Type Supported:\t\t{biosProvider.IsCardTypeSupported}");
            Console.WriteLine($"Is Restart Pending:\t\t{biosProvider.IsRestartPending}");
            Console.WriteLine($"Is Undock Request Set:\t\t{biosProvider.IsUndockRequestSet}");
            Console.WriteLine($"Is Surprise Removal Set:\t{biosProvider.IsSurpriseRemovalSet}");
            Console.WriteLine($"MState:\t\t\t\t{biosProvider.MState}");
            Console.WriteLine();

            Console.WriteLine("Press Enter to close.");
            Console.ReadLine();
        }
    }
}
