using System;
using ThunderSharpLibrary;

namespace SampleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			Logger_class myLog = new Logger_class();
			ThunderBorg_class myBorg = new ThunderBorg_class(myLog);

			ThunderBorgSettings_class initialSettings = new ThunderBorgSettings_class();
			initialSettings.GetCurrentEnvironment(myBorg, myLog);

			TestLogger(myLog);
			myLog.DefaultLogLevel = ILogger.Priority.Information;

			int intCurrentAddress = ThunderBorg_class.ScanForThunderBorg(log: myLog);
			byte currentAddress = Convert.ToByte(intCurrentAddress);
			ThunderBorg_class.SetNewAddress(33, currentAddress, 1, myLog);

			int newIntCurrentAddress = ThunderBorg_class.ScanForThunderBorg(log: myLog);
			byte newCurrentAddress = Convert.ToByte(newIntCurrentAddress);
			ThunderBorg_class.SetNewAddress(currentAddress, newCurrentAddress, 1, myLog);

			myLog.DefaultLogLevel = ILogger.Priority.Medium;

            myBorg.SetFailsafe(false, myLog);
			//TestBorg(myBorg, myLog);
			//TestLEDs(myBorg, myLog);
			//myBorg.SetLEDBatteryMonitor(true, myLog);
			//myBorg.WaveLEDs(myLog);
			//myBorg.TestSpeeds(myLog);
			//myBorg.SetLEDBatteryMonitor(false, myLog);
			myLog.WriteLog("Place Borg in location with 1 meter clearance in front, then press any key.");
			Console.ReadKey(true);
			myBorg.TestDistance(0.5M, myLog);

            initialSettings.SetCurrentEnvironment(myBorg, myLog);
		}

		private static void TestLogger(Logger_class log)
        {
			ILogger.Priority existing = log.DefaultLogLevel;

			log.DefaultLogLevel = ILogger.Priority.Medium;

			log.WriteLog("Testing overall log capability.  I'll write five messages, one for each log level, with");
			log.WriteLog("deescalating priorities.");
			log.WriteLog();
			log.WriteLog("------------------------------------------------------------------");
			log.WriteLog("Critical", ILogger.Priority.Critical);
			log.WriteLog("High", ILogger.Priority.High);
			log.WriteLog("Medium", ILogger.Priority.Medium);
			log.WriteLog("Low", ILogger.Priority.Low);
			log.WriteLog("Information", ILogger.Priority.Information);

			log.DefaultLogLevel = existing;
        }

		private static void TestLEDs(ThunderBorg_class myBorg, Logger_class log)
        {
			log.WriteLog("------------------------------------------------------------------");
			log.WriteLog("Starting LED test...");

			log.WriteLog("Setting battery LED monitor to off...");
			myBorg.SetLEDBatteryMonitor(false, log);

			log.WriteLog();
			log.WriteLog("Current battery LED monitoring setting: " + myBorg.GetLEDBatteryMonitor(log).ToString());
			log.WriteLog();

			log.WriteLog("Starting test");
			log.WriteLog("Setting all LEDs to 255, 255, 255...");
			myBorg.SetLEDs(255, 255, 255, log);

			log.WriteLog("Getting LED values...");
			log.WriteLog("LED1: " + myBorg.BytesToString(myBorg.GetLED1(log)));
			log.WriteLog("LED2: " + myBorg.BytesToString(myBorg.GetLED2(log)));
			log.WriteLog();
			log.WriteLog("Sleeping for one second...");

			System.Threading.Thread.Sleep(1000);

			log.WriteLog("Setting LED1 to 0, 0, 0...");
			myBorg.SetLED1(0, 0, 0, log);

			log.WriteLog("LED1: " + myBorg.BytesToString(myBorg.GetLED1(log)));
			log.WriteLog();
			log.WriteLog("Sleeping for one second...");

			System.Threading.Thread.Sleep(1000);

			log.WriteLog("Setting LED2 to 0, 0, 0...");
			myBorg.SetLED2(0, 0, 0, log);

			log.WriteLog("LED2: " + myBorg.BytesToString(myBorg.GetLED2(log)));
			log.WriteLog();
			log.WriteLog("Sleeping for one second...");

			System.Threading.Thread.Sleep(1000);

			log.WriteLog("Setting all LEDs to 128, 128, 128...");
			myBorg.SetLED1(128, 128, 128, log);
			myBorg.SetLED2(128, 128, 128, log);
			log.WriteLog("LED1: " + myBorg.BytesToString(myBorg.GetLED1(log)));
			log.WriteLog("LED2: " + myBorg.BytesToString(myBorg.GetLED2(log)));
			log.WriteLog();
			log.WriteLog("Sleeping for one second...");

			System.Threading.Thread.Sleep(1000);

			log.WriteLog("Setting back to battery monitoring...");
			myBorg.SetLEDBatteryMonitor(true, log);
			log.WriteLog("Finished test.");
		}

		private static void TestBorg(ThunderBorg_class myBorg, Logger_class log)
		{
			myBorg.SetLEDBatteryMonitor(false, log);

			myBorg.SetMotorA(128, log);
			System.Threading.Thread.Sleep(1000);
			int getx = myBorg.GetMotorA(log);
			log.WriteLog("Reporting speed A: " + getx.ToString());
			myBorg.GetDriveFaultA(log);

			myBorg.AllStop(log);

			myBorg.SetMotorB(128, log);
			System.Threading.Thread.Sleep(1000);
			int gety = myBorg.GetMotorB(log);
			log.WriteLog("Reporting speed B: " + gety.ToString());
			myBorg.GetDriveFaultB(log);

			myBorg.AllStop(log);

			myBorg.SetMotorA(-128, log);
			System.Threading.Thread.Sleep(1000);
			getx = myBorg.GetMotorA(log);
			log.WriteLog("Reporting speed A: " + getx.ToString());
			myBorg.GetDriveFaultA(log);

			myBorg.AllStop(log);

			myBorg.SetMotorB(-128, log);
			System.Threading.Thread.Sleep(1000);
			gety = myBorg.GetMotorB(log);
			log.WriteLog("Reporting speed B: " + gety.ToString());
			myBorg.GetDriveFaultB(log);

			myBorg.AllStop(log);

			myBorg.SetAllMotors(128, log);
			System.Threading.Thread.Sleep(1000);
			myBorg.AllStop();

			myBorg.SetAllMotors(-128, log);
			System.Threading.Thread.Sleep(1000);
			myBorg.AllStop();

			myBorg.GetFailsafe(log);
			myBorg.SetFailsafe(true, log);
			myBorg.SetFailsafe(true, log);
			myBorg.SetFailsafe(false, log);
			myBorg.SetFailsafe(false, log);

			myBorg.GetLED1(log);
			myBorg.GetLED2(log);

			myBorg.GetLEDBatteryMonitor(log);
			myBorg.SetLEDBatteryMonitor(false, log);
			myBorg.GetLEDBatteryMonitor(log);

			myBorg.SetLED1(255, 255, 255, log);
			myBorg.SetLED2(255, 255, 255, log);
			System.Threading.Thread.Sleep(1000);

			myBorg.SetLEDs(0, 0, 0, log);

			log.WriteLog("Battery voltage: " + myBorg.GetBatteryVoltage(log).ToString());

			myBorg.SetLEDBatteryMonitor(true, log);
			log.WriteLog("Board ID: 0x" + myBorg.GetBoardID(log).ToString("X2"));
			myBorg.GetBatteryMonitoringLimits(log);

			myBorg.SetBatteryMonitoringLimits(7.0M, 35.0M, log);

		}
	}
}
