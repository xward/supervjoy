using NsSupervJoy.engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VJoyNerdClient;
using SharpDX;
using SharpDX.DirectInput;
using System.Threading;
using NsSupervJoy.userland;
using System.Windows.Forms;
using static NsSupervJoy.Engine.SuperVJoy;
using System.Drawing;
using SupervJoy.engine.Frm;

namespace NsSupervJoy.Engine
{
    public static class SuperVJoy
    {
        public static int MAX_RANGE = 65536;
        public static int MID_RANGE = MAX_RANGE / 2;

        // engine
        private static Logger logger = new Logger("Engine");
        public static ClassMegaVJoy vjoy = new ClassMegaVJoy();
        private static IList<JoystickInput> hardwareInput = new List<JoystickInput>();
        public static Dictionary<string, int[]> outputCurves = new Dictionary<string, int[]>();
        public static int maxOutputAxisCountIWantToUse = 6;
        public static bool disable = false;
        public static double engineLag = 0;

        public static bool debugOutputRawInputInLog = false;
        public static bool showKekeFrom = false;
        public static bool showDebugForm = false;

        // debug to window
        public static long processed = 0;
        public static bool plzOutputToDebugFrm = false;
        public static Dictionary<string, double> debugFrmCurvedAxis = new Dictionary<string, double>();
        public static IList<string> debugFrmEvents = new List<string>();


        public static IList<string> latest = new List<string>();

        // userland config
        private static IList<string> inputNames = new List<string>();
        private static Dictionary<string, string> inputAliases = new Dictionary<string, string>();

        // userland output
        public static IList<string> inputValuesIs = new List<string>();
        public static Dictionary<string, int> inputValueUpdate = new Dictionary<string, int>();
        private static Dictionary<string, int> inputValues = new Dictionary<string, int>();
        private static Dictionary<string, int> inputPreviousValues = new Dictionary<string, int>();
        private static Dictionary<string, InputValueChangeTrigger> inputValuesChangeTriggers = new Dictionary<string, InputValueChangeTrigger>();

        public enum OutAxis {X = 1, Y = 2, Z = 3, RX = 4, RY = 5, RZ = 6, S1 = 7, S2 = 8, X2 = 9, Y2 = 10, Z2 = 11, RX2 = 12, RY2 = 13, RZ2 = 14, S3 = 15, S4 = 16};
        public enum TriggerWay { Up, Down, Both };
        public enum KeyModifier { Shift, Alt, AltGr };

        public static void AddHardware(string hardwareCodeName)
        {
            inputNames.Add(hardwareCodeName);
        }

        public static void AddHardware(string hardwareCodeName, string alias)
        {
            inputAliases.Add(alias, hardwareCodeName);
            inputNames.Add(hardwareCodeName);
        }

        private static string UnaliasCode(string code)
        {
            foreach (string key in inputAliases.Keys)
            {
                if (code.Contains(key))
                {
                    code = code.Replace(key, inputAliases[key]);
                }
            }
            return code;
        }

        public static void AddInputValueChangeTrigger(string triggerName, string code, int value, TriggerWay way)
        {
            Console.WriteLine("Add Trigger \"" + triggerName + "\" on " + code + " " + value);
            InputValueChangeTrigger trigger = new InputValueChangeTrigger
            {
                value = value,
                code = UnaliasCode(code),
                way = way
            };
            inputValuesChangeTriggers[triggerName] = trigger;
        }

        public static void SetDefaultValue(string code, int value)
        {
            inputValues[code] = value;
        }

        // Getter
        public static int GetInputValue(string code)
        {
            code = UnaliasCode(code);
            return (inputValues.ContainsKey(code) ? inputValues[code] : MID_RANGE);
        }

        public static bool OnInputValueChange(string intputActionCode)
        {
            intputActionCode = UnaliasCode(intputActionCode);
            return inputValuesIs.Contains(intputActionCode);
        }

        public static bool OnTrigger(string triggerName) // I know it's more a threshold
        {
            return inputValuesChangeTriggers[triggerName].triggered; // todo: manage triggerName 404
        }

        public static bool OnHardwareInputUpdate(string code)
        {
            code = UnaliasCode(code);
            return SuperVJoy.inputValueUpdate.ContainsKey(code);
        }

        public static int ApplyCurve(OutAxis axis, int value)
        {
            if (value > MAX_RANGE - 1) value = MAX_RANGE - 1;
            if (value < 0) value = 0;
            if (plzOutputToDebugFrm) debugFrmCurvedAxis[axis.ToString()] = (int) (100.0 * value / MAX_RANGE); // this is shitty

            return outputCurves[axis.ToString()][value];
        }

        // Setter
        public static void SetOutputValue(OutAxis axis, int value)
        {
            if (value > MAX_RANGE - 1) value = MAX_RANGE - 1;
            if (value < 0) value = 0;

            if (plzOutputToDebugFrm) debugFrmCurvedAxis[axis.ToString()] = (int) (100.0 * value / MAX_RANGE);

            value = SuperVJoy.ApplyCurve(axis, value);

            vjoy.setAxisPerc(100.0 * value / MAX_RANGE, (int) axis);
        }
        public static void SetOutputValue(OutAxis axis, string hardwareInputCode)
        {
            hardwareInputCode = UnaliasCode(hardwareInputCode);
            int value = SuperVJoy.GetInputValue(hardwareInputCode);
            SetOutputValue(axis, value);
        }
        public static void SetOutputValueOnHardwareInputChange(OutAxis axis, string hardwareInputCode)
        {
            hardwareInputCode = UnaliasCode(hardwareInputCode);
            if (SuperVJoy.inputValueUpdate.ContainsKey(hardwareInputCode))
            {
                SetOutputValue(axis, hardwareInputCode);
            }
        }

        private static int jiggleIndex = 0;
        public static void JiggleOutput(OutAxis axis)
        {
            if(jiggleIndex > 1000)
                SetOutputValue(axis, MID_RANGE);
        }
        public static void JiggleOutput(OutAxis axis, int withValue)
        {
            if (jiggleIndex > 1000)
                SetOutputValue(axis, withValue);
        }

        public static void AsyncKeyPress(Keys key)
        {
            Global.AsyncKeyPress(key);
        }
        public static void AsyncKeyPress(Keys key, Keys modifier)
        {
            Global.AsyncKeyPress(key, modifier);
        }
        public static void AsyncKeyDown(Keys key)
        {
            Global.AsyncKeyDown(key);
        }
        public static void AsyncKeyDown(Keys key, Keys modifier)
        {
            Global.AsyncKeyDown(key, modifier);
        }
        public static void AsyncKeyUp(Keys key)
        {
            Global.AsyncKeyUp(key);
        }
        public static void AsyncKeyUp(Keys key, Keys modifier)
        {
            Global.AsyncKeyUp(key, modifier);
        }

        // Config tools
        public static void SimulateJoyOutputAxis(OutAxis axis)
        {
            Console.WriteLine("SimulateJoyOutputAxis " + axis.ToString());
            while (true)
            {
                vjoy.setAxisPerc(98, (int)axis);
                vjoy.applyValues();
                Thread.Sleep(45);
                vjoy.setAxisPerc(95, (int)axis);
                vjoy.applyValues();
                Thread.Sleep(250);
            }
        }

        // Main
        public static void Start()
        {
            logger.Debug("start()");
            int[] vJoyOutIndexes = {7,8};
            vjoy.init(vJoyOutIndexes);
            vjoy.resolution = MID_RANGE - 1;
            logger.Debug("MegaVjoy initialized !");


            // init curves
            foreach (OutAxis axe in (OutAxis[])Enum.GetValues(typeof(OutAxis)))
            {
                outputCurves[axe.ToString()] = new int[MAX_RANGE];
                for (int i = 0; i < MAX_RANGE; ++i)
                {
                    outputCurves[axe.ToString()][i] = i;
                }
                debugFrmCurvedAxis[axe.ToString()] = 50.0;
            }
            // config from user
            Curves.CurveConfigure();
            logger.Debug("Curves initialized !");

            UserMain.Init();
            vjoy.applyValues();
            logger.Debug("UserConfig initialized !");

            // CurveTool.generateBitmapCurve(OutAxis.X);

            logger.JumpLine(3);

            DirectInput directInput = new DirectInput();
            IList<DeviceInstance> devices = directInput.GetDevices();

            logger.Debug("Available devices (" + devices.Count + "):");
            logger.JumpLine(1);

            // print available hardware devices
            foreach (DeviceInstance device in devices)
            {
                string name = Global.ReturnCleanASCII(device.InstanceName);
                Guid guid = device.InstanceGuid;
                Console.WriteLine(name + "[" + guid.ToString() + "]");
            }

            logger.JumpLine(3);
            logger.Debug("Linking hardware devices:");
            logger.JumpLine(1);
            foreach (string expectedInputCode in inputNames)
            {
                bool found = false;

                foreach (DeviceInstance device in devices)
                {
                    string name = Global.ReturnCleanASCII(device.InstanceName);
                    Guid guid = device.InstanceGuid;

                    if (expectedInputCode == name || expectedInputCode == name + "[" + guid.ToString() + "]")
                    {
                        Console.WriteLine("Acquiring hardware " + expectedInputCode + " ...");
                        JoystickInput joy = new JoystickInput(name, guid, expectedInputCode);
                        hardwareInput.Add(joy);
                        Console.WriteLine("   success !!");
                        logger.JumpLine(1);
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    MessageBox.Show("Input \"" + expectedInputCode + "\" not found.\n Fix code in UserLand:init().");
                    Console.WriteLine(expectedInputCode + " WAS NOT FOUND IN AVAILABLE HARDWARE. Won't be used.");
                }
            }

            // tray icon & window
            new Thread(() =>
            {
                Application.Run(new FrmTrayIcon());
            }).Start();

            if (showDebugForm)
            {
                new Thread(() =>
                {
                   Application.Run(new FrmVisualDebug());
                }).Start();
            }

            if (showKekeFrom)
            {
                new Thread(() =>
                {
                    Application.Run(new FrmStreamKeke());
                }).Start();
            }


            string inputName;
            string inputValue;

            // main refresh run
            while (true)
            {
                if (disable)
                {
                    Thread.Sleep(100);
                    continue;
                }

                Thread.Sleep(1);
                inputValuesIs.Clear();
                inputValueUpdate.Clear();
                long lagStartTick = DateTime.Now.Ticks;

                jiggleIndex++;
                if (jiggleIndex > 1001)
                    jiggleIndex = 0;

                foreach (JoystickInput joyInput in hardwareInput)
                {
                    joyInput.joy.Poll();
                    JoystickUpdate[] data = joyInput.joy.GetBufferedData();
                    processed += data.Length;
                    for (int i = 0;i < data.Length; ++i) {
                        JoystickUpdate dat = data[i];
                        inputName = joyInput.codeId + ":" + dat.Offset.ToString();
                        inputValue = inputName + ":" + dat.Value;

                        if (debugOutputRawInputInLog) Console.WriteLine(inputValue);

                        inputValues[inputName] = dat.Value;
                        inputValuesIs.Add(inputValue);
                        inputValueUpdate[inputName] = dat.Value;

                    }
                } // foreach inputs
                
                // manage triggers
                foreach (string triggerName in inputValuesChangeTriggers.Keys)
                {
                    InputValueChangeTrigger trigger = inputValuesChangeTriggers[triggerName];
                    trigger.triggered = false;

                    // triggerable
                    if (inputValues.ContainsKey(trigger.code) && inputPreviousValues.ContainsKey(trigger.code))
                    {
                        int previous = inputPreviousValues[trigger.code];
                        int value = inputValues[trigger.code];
                        bool triggered = false;
                        switch (trigger.way)
                        {
                            case TriggerWay.Up:
                                if (value > trigger.value && previous <= trigger.value) triggered = true;
                                break;
                            case TriggerWay.Down:
                                if (value < trigger.value && previous >= trigger.value) triggered = true;
                                break;
                            case TriggerWay.Both:
                                if ((value > trigger.value && previous <= trigger.value) || (value > trigger.value && previous <= trigger.value)) triggered = true;
                                break;
                        }
                        if (triggered)
                        {
                            trigger.triggered = true;
                            Console.WriteLine("Triggered " + triggerName);
                            if (plzOutputToDebugFrm) debugFrmEvents.Add(triggerName);
                        }
                    }
             
                }

           
                // update previous value
                foreach (string triggerName in inputValuesChangeTriggers.Keys)
                {
                    InputValueChangeTrigger trigger = inputValuesChangeTriggers[triggerName];
                    if (inputValues.ContainsKey(trigger.code)) inputPreviousValues[trigger.code] = inputValues[trigger.code];
                }

                UserMain.Process(); // todo: check time if too slow warn user
                vjoy.applyValues(); // I made all my modifications, apply them
                engineLag = DateTime.Now.Ticks - lagStartTick;
            } // main loop
        }
    }


    public class JoystickInput
    {
        public string codeId;
        public string name;
        public Guid guid;
        public Joystick joy;

        public JoystickInput(string name, Guid guid, string codeId)
        {
            this.name = name;
            this.guid = guid;
            this.codeId = codeId;

            DirectInput directInput = new DirectInput();
            joy = new Joystick(directInput, guid);
            joy.Properties.BufferSize = 64;
            joy.Acquire();
        }
    }

    public class InputValueChangeTrigger
    {
        public bool triggered = false;
        public string code; // input concerned
        public int value = 0;
        public TriggerWay way = TriggerWay.Both;
    }
}
