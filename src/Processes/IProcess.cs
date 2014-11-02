using System;
using System.Diagnostics;
using System.IO;

namespace Rothko
{
    public interface IProcess : IDisposable
    {
        event DataReceivedEventHandler OutputDataReceived;
        event DataReceivedEventHandler ErrorDataReceived;

        int Id { get; }
        ProcessStartInfo StartInfo { get; set; }
        StreamWriter StandardInput { get; }
        int ExitCode { get; }
        IntPtr MainWindowHandle { get; }
        string ProcessName { get; }

        void BeginOutputReadLine();
        void BeginErrorReadLine();
        bool Start();
        bool WaitForExit(int milliseconds);
        void Close();
        void Kill();
        void KillProcessTree();

        /// <summary>
        /// Gives the process focus and restores it if it's minimized.
        /// </summary>
        bool Show();
    }
}
