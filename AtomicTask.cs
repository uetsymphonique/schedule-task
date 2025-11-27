using System;
using Microsoft.Win32.TaskScheduler;
class P {
  static void Main() {
    using(TaskService ts = new TaskService()) {
      TaskDefinition td = ts.NewTask();
      td.RegistrationInfo.Description = "Atomic C# Task";
      td.Triggers.Add(new TimeTrigger { StartBoundary = DateTime.Now.AddMinutes(1) });
      td.Actions.Add(new ExecAction("C:\\Windows\\System32\\calc.exe", null, null));
      ts.RootFolder.RegisterTaskDefinition("AtomicCSharpTask", td);
    }
  }
}
