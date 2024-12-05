using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using GTechFlasher.Utils;
using GTechFlasher.Models;

namespace GTechFlasher
{
    public partial class Form1 : Form
    {
        private Device device = new();
        private readonly Excel excel = new();
        private string filePath;
        private string userInput;
        private string serialNumberNext;
        private int newSerialNumber;
        private readonly int[] baudrate = { 4800, 9600, 115200 };
        private SerialPort Serial = new SerialPort();
        private bool isTestRunning = false;
        private const string TempJlinkFileName = "temp_jlink_file.jlink";

        private void UpdateCOMPortList()
        {
            string[] Ports = SerialPort.GetPortNames();
            portBox.Items.Clear();
            baudRateBox.Items.Clear();

            foreach (var items in Ports)
            {
                portBox.Items.Add(items);
            }

            foreach (var baud in baudrate)
            {
                baudRateBox.Items.Add(baud.ToString());
            }
        }
        public Form1()
        {
            InitializeComponent();
            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "lgt_Serial.txt");
            serialNumberNext = string.Empty;
            portBox.DropDown += (s, ev) => UpdateCOMPortList();
        }

        private void ExecuteCommand()
        {
            try
            {

                string? selectedFile = comboBox1.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(selectedFile))
                {
                    MessageBox.Show("Please select a HEX file from the dropdown.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string firmwareDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "firmware");
                string hexFile = Path.Combine(firmwareDirectory, selectedFile);

                if (!File.Exists(hexFile))
                {
                    throw new FileNotFoundException($"File {selectedFile} not found in the firmware folder: {hexFile}");
                }

                string tempJlinkFilePath = Path.Combine(Path.GetTempPath(), TempJlinkFileName);
                string hexSerialNumber;

                if (autoRadio.Checked == true)
                {
                    hexSerialNumber = int.Parse(serialNumberNext).ToString("X");
                }
                else
                {
                    hexSerialNumber = int.Parse(userInput).ToString("X");
                }

                string jlinkCommands = $@"
                device STM32WLE5JC
                if SWD
                speed 4000
                r
                erase
                loadfile ""{hexFile}""
                w4 0x0803F000 {hexSerialNumber}
                r
                exit";

                File.WriteAllText(tempJlinkFilePath, jlinkCommands);

                string arguments = $"-CommandFile \"{tempJlinkFilePath}\"";

                ProcessStartInfo processInfo = new ProcessStartInfo
                {
                    FileName = "JLink.exe",
                    Arguments = arguments,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                };

                Process process = Process.Start(processInfo);
                string result = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();


                if (process.ExitCode == 0)
                {
                    string successMessage = "Programming completed successfully.";
                    label15.BackColor = Color.Green;
                    label15.ForeColor = Color.White;
                    label15.Text = "SUCCESS";

                    if (autoRadio.Checked == true)
                    {
                        newSerialNumber = int.Parse(serialNumberNext) + 1;
                    }
                    else
                    {
                        newSerialNumber = int.Parse(userInput) + 1;
                    }
                    
                    File.WriteAllText(filePath, newSerialNumber.ToString());
                    textBox1.Clear();
                    textBox1.AppendText($"{result}\n{successMessage}");
                }
                else
                {
                    string errorMessage = $"Error occurred during programming:\n{error}";
                    label15.BackColor = Color.Red;
                    label15.ForeColor = Color.White;
                    label15.Text = "FAILED";
                    textBox1.AppendText(errorMessage);
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FileNotFoundException fnfEx)
            {
                textBox1.AppendText($"File Error: {fnfEx.Message}");
                MessageBox.Show(fnfEx.Message, "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                textBox1.AppendText($"Error: {ex.Message}");
                MessageBox.Show($"Error executing command: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (connectButton.Text == "Connect")
                {
                    if (!SerialPort.GetPortNames().Contains(portBox.Text))
                    {
                        MessageBox.Show($"The selected COM port '{portBox.Text}' is not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Serial.PortName = portBox.Text;
                    Serial.BaudRate = int.Parse(baudRateBox.Text);
                    Serial.DataBits = 8;
                    Serial.Parity = Parity.None;
                    Serial.StopBits = StopBits.One;
                    Serial.DataReceived += Serial_DataReceived;

                    Serial.Open();

                    if (Serial.IsOpen)
                    {
                        textBox1.Clear();
                        textBox1.AppendText($"Connected to {Serial.PortName} at {Serial.BaudRate} baud.");
                        connectButton.Text = "Disconnect";

                        rfidRadio.Enabled = true;
                        autoRadio.Enabled = true;
                        manualRadio.Enabled = true;
                        productionButton.Enabled = true;
                        testButton.Enabled = true;
                        debugButton.Enabled = true;
                        packButton.Enabled = true;
                        comboBox1.Enabled = true;
                    }
                    else
                    {
                        throw new Exception("Failed to open the COM port.");
                    }
                }
                else
                {
                    Serial.Close();
                    connectButton.Text = "Connect";

                    startButton.Enabled = false;
                    stopButton.Enabled = false;
                    rfidRadio.Enabled = false;
                    autoRadio.Enabled = false;
                    manualRadio.Enabled = false;
                    productionButton.Enabled = false;
                    testButton.Enabled = false;
                    debugButton.Enabled = false;
                    packButton.Enabled = false;
                    comboBox1.Enabled = false;

                    textBox1.Clear();
                    textBox1.AppendText("Disconnected");
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid baud rate. Please select a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("The COM port is not accessible. It may be in use by another application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                Thread.Sleep(100);
                string data = Serial.ReadExisting();
                string cleanedData = Regex.Replace(data, @"\x1B\[[0-9;]*[a-zA-Z]|prism:~ \$", string.Empty);

                Invoke((MethodInvoker)delegate
                {
                    textBox1.AppendText(cleanedData);
                });

                string[] lines = data.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
                foreach (string line in lines)
                {
                    if (line.Contains("Serial Number :"))
                    {
                        device.SerialNumber = line.Split(":")[1].Trim();
                    }
                    else if (line.Contains("Firmware revision:"))
                    {
                        device.FirmwareVersion = line.Split(":")[1].Trim();
                    }
                    else if (line.Contains("Vbatt :"))
                    {
                        device.Vbatt = line.Split(":")[1].Trim();
                    }
                    else if (line.Contains("Location Fix Time :"))
                    {
                        device.LocationFixTime = line.Split(":")[1].Trim();
                    }
                    else if (line.Contains("Latitude :"))
                    {
                        device.Latitude = decimal.Parse(line.Split(':')[1].Trim());
                    }
                    else if (line.Contains("Longitude :"))
                    {
                        device.Longitude = decimal.Parse(line.Split(':')[1].Trim());
                    }
                    else if (line.Contains("Timestamps :"))
                    {
                        device.Timestamp = Regex.Replace(line.Split(" :")[1].Trim(), @"\x1B\[[0-9;]*[a-zA-Z]", string.Empty);
                    }
                }

                // If "motion test done" is detected, display the results
                if (data.Contains("END"))
                {
                    Invoke((MethodInvoker)delegate
                    {
                        label2.Text = device.SerialNumber;
                        label4.Text = device.FirmwareVersion;
                        label6.Text = device.Vbatt;
                        label8.Text = device.LocationFixTime;
                        label10.Text = device.Latitude.ToString();
                        label18.Text = device.Longitude.ToString();
                        label19.Text = device.Timestamp;

                        excel.SaveDataToExcel(device);

                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading serial port data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            bool processSucceeded = true;

            while (processSucceeded)
            {
                if (rfidRadio.Checked || manualRadio.Checked)
                {
                    userInput = ShowInputDialog("Scan or enter the serial number!");
                    if (string.IsNullOrEmpty(userInput))
                    {
                        MessageBox.Show("No serial number provided. Stopping the process.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }

                    if (userInput.Length != 8 || !userInput.All(char.IsDigit))
                    {
                        MessageBox.Show("Invalid serial number. Please enter 8 numeric digits.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }

                    try
                    {
                        File.WriteAllText(filePath, userInput);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to write to file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
                else if (autoRadio.Checked)
                {

                    try
                    {
                        if (File.Exists(filePath))
                        {
                            serialNumberNext = File.ReadAllText(filePath);
                        }
                        else
                        {
                            MessageBox.Show("lgt_Serial.txt file not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }

                        DialogResult dialogResult = MessageBox.Show($"Do you want to proceed with flashing?\n\nSerial Number: {serialNumberNext}",
                                                                    "Confirm Flash", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dialogResult == DialogResult.No)
                        {
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to read from file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }

                try
                {
                    ExecuteCommand();
                    processSucceeded = label15.Text == "SUCCESS";
                    serialNumberNext = File.ReadAllText(filePath);
                    label17.Text = serialNumberNext;

                    if (processSucceeded)
                    {
                        textBox1.Clear();
                        textBox1.AppendText("Flashing succeeded. Ready for the next iteration.\n");

                        if (Serial.IsOpen)
                        {
                            textBox1.Clear();
                            textBox1.AppendText("Waiting for data from serial port...");
                            textBox1.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Process failed. Stopping the loop.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processSucceeded = false;
                }
            }
        }

        private static string ShowInputDialog(string prompt)
        {
            Form inputForm = new Form
            {
                Width = 400,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Input Serial Number",
                StartPosition = FormStartPosition.CenterScreen
            };

            Label label = new Label { Left = 20, Top = 20, Text = prompt, AutoSize = true };
            TextBox textBox = new TextBox { Left = 20, Top = 50, Width = 340 };
            Button confirmation = new Button { Text = "OK", Left = 260, Width = 100, Top = 100, DialogResult = DialogResult.OK };

            confirmation.Click += (sender, e) => inputForm.Close();

            inputForm.Controls.Add(label);
            inputForm.Controls.Add(textBox);
            inputForm.Controls.Add(confirmation);
            inputForm.AcceptButton = confirmation;

            return inputForm.ShowDialog() == DialogResult.OK ? textBox.Text : string.Empty;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateCOMPortList();
            startButton.Enabled = false;
            stopButton.Enabled = false;
            rfidRadio.Enabled = false;
            autoRadio.Enabled = false;
            manualRadio.Enabled = false;
            productionButton.Enabled = false;
            testButton.Enabled = false;
            debugButton.Enabled = false;
            packButton.Enabled = false;
            comboBox1.Enabled = false;

            serialNumberNext = File.ReadAllText(filePath);
            label17.Text = serialNumberNext;

            string firmwareDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Firmware");

            if (Directory.Exists(firmwareDirectory))
            {
                string[] files = Directory.GetFiles(firmwareDirectory, "*.bin");
                files = files.Concat(Directory.GetFiles(firmwareDirectory, "*.hex"))
                             .Concat(Directory.GetFiles(firmwareDirectory, "*.jflash"))
                             .ToArray();

                comboBox1.Items.Clear();

                foreach (string file in files)
                {
                    comboBox1.Items.Add(Path.GetFileName(file));
                }
            }
            else
            {
                MessageBox.Show("Firmware directory not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void productionButton_Click(object sender, EventArgs e)
        {
            try
            {
                Serial.WriteLine("diag mode set 1");
                textBox1.Clear();
                textBox1.AppendText(Environment.NewLine);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            try
            {
                Serial.WriteLine("diag mode set 2");
                textBox1.Clear();
                textBox1.AppendText(Environment.NewLine);
                isTestRunning = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void debugButton_Click(object sender, EventArgs e)
        {
            try
            {
                Serial.WriteLine("diag mode set 3");
                textBox1.Clear();
                textBox1.AppendText(Environment.NewLine);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void packButton_Click(object sender, EventArgs e)
        {
            try
            {
                Serial.WriteLine("diag mode set 4");
                textBox1.Clear();
                textBox1.AppendText(Environment.NewLine);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rfidRadio_CheckedChanged(object sender, EventArgs e)
        {
            startButton.Enabled = true;
            stopButton.Enabled = true;
        }

        private void autoRadio_CheckedChanged(object sender, EventArgs e)
        {
            startButton.Enabled = true;
            stopButton.Enabled = true;
        }

        private void manualRadio_CheckedChanged(object sender, EventArgs e)
        {
            startButton.Enabled = true;
            stopButton.Enabled = true;
        }
    }
}
