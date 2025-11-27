using System;
using Microsoft.Win32.TaskScheduler;

class P {
    static void Main() {
        using (TaskService ts = new TaskService()) {
            string folderName = "googlesystem\\googleupdater";

            TaskFolder folder = null;
            try {
                folder = ts.GetFolder("\\" + folderName);
            }
            catch {
                folder = ts.RootFolder.CreateFolder(folderName);
            }

            TaskDefinition td = ts.NewTask();
            td.RegistrationInfo.Description = "Atomic C# Task in subfolder";
            td.Triggers.Add(new TimeTrigger { StartBoundary = DateTime.Now.AddMinutes(1) });
            td.Actions.Add(new ExecAction(@"C:\Windows\System32\calc.exe", null, null));

            folder.RegisterTaskDefinition("AtomicCSharpTask", td);
        }
    }
}
