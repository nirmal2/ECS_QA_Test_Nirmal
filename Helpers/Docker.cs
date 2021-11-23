using System.Diagnostics;
using System.Threading;

namespace ECS_QA_Test.Helpers
{
    public static class Docker
    {
        static Process process;
        static ProcessStartInfo startInfo;
        public static void StartDocker()
        {
            StartProcess(out process, out startInfo);
            startInfo.Arguments = "/C docker build -t ecsd-tech-test .";
            process.Start();
            startInfo.Arguments = "/C docker run -it -p 3000:3000 ecsd-tech-test:latest";
            process.Start();
            Thread.Sleep(20000);
        }

        public static void StopDocker()
        {
            StartProcess(out process, out startInfo);
            startInfo.Arguments = "/C docker ps -q -l";
            process.Start();
            var dockerContainerId = process.StandardOutput.ReadToEnd();
            startInfo.Arguments = $"/C docker stop {dockerContainerId}";
            process.Start();
            process.WaitForExit();
        }

        private static void StartProcess(out Process process, out ProcessStartInfo startInfo)
        {
            process = new Process();
            startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            process.StartInfo = startInfo;
            process.StartInfo.RedirectStandardOutput = true;
        }
    }
}

