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
			ThunderBorg myBorg = new ThunderBorg(myLog);

			TestBorg(myBorg, myLog);
		}

		private static void TestBorg(ThunderBorg myBorg, Logger_class log)
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

			System.Threading.Thread.Sleep(500);

			myBorg.SetLED1(255, 255, 255, log);
			myBorg.SetLED2(255, 255, 255, log);
			System.Threading.Thread.Sleep(1000);

			myBorg.SetLEDs(0, 0, 0, log);

			//for (int i = 0; i < 255; i = i + 10)
			//         {
			//	for (int j = 0; j < 255; j = j + 10)
			//             {
			//		for (int k = 0; k < 255; k = k + 10)
			//                 {
			//			myBorg.SetLEDs(Convert.ToByte(i), Convert.ToByte(j), Convert.ToByte(k), log);
			//                 }
			//             }
			//         }

			log.WriteLog("Battery voltage: " + myBorg.GetBatteryVoltage(log).ToString());

			myBorg.SetLEDBatteryMonitor(true, log);
			log.WriteLog("Board ID: 0x" + myBorg.GetBoardID(log).ToString("X2"));
			myBorg.GetBatteryMonitoringLimits(log);

			myBorg.SetBatteryMonitoringLimits(7.0M, 35.0M, log);

		}
	}
}
