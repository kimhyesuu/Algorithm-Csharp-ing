using System;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace SendingCstructsthroughTCPinCsharp
{
    //Why do you have to use the unmanaged memory in order to copy to the bytearray? Isn't possible copy to the bytearray directly?
    //I guess is something with how C# works but explanation will be good..

    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct MLocation
    {
        public int x;
        public int y;
    };

    class Program
    {
        static void Main(string[] args)
        {
            MLocation test = new MLocation();

            // Gets size of struct in bytes
            int structureSize = Marshal.SizeOf(test);

            // Builds byte array
            byte[] byteArray = new byte[structureSize];

            IntPtr memPtr = IntPtr.Zero;

            try
            {
                // Allocate some unmanaged memory
                memPtr = Marshal.AllocHGlobal(structureSize);

                // Copy struct to unmanaged memory
                Marshal.StructureToPtr(test, memPtr, true);

                // Copies to byte array
                Marshal.Copy(memPtr, byteArray, 0, structureSize);
            }
            finally
            {
                if (memPtr != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(memPtr);
                }
            }

            // Now you can send your byte array through TCP
            using (TcpClient client = new TcpClient("host", 8080))
            {
                using (NetworkStream stream = client.GetStream())
                {
                    stream.Write(byteArray, 0, byteArray.Length);
                }
            }

            Console.ReadLine();
        }
    }
}
