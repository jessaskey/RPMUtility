using RPMUtility.DataFormats;
using RPMUtility.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPMUtility
{
    public partial class Mainform : Form
    {
        private List<SoundCapture> captures = new List<SoundCapture>();

        public Mainform()
        {
            InitializeComponent();

            textBoxHavocParserInput.KeyDown += Mainform_KeyDown;
            textBoxHavocParserOutput.KeyDown += Mainform_KeyDown;
            textBoxHavocParserVisual.KeyDown += Mainform_KeyDown;

            comboBoxHavocParserDataType.SelectedIndex = 0;
        }

        private void buttonParse_Click(object sender, EventArgs e)
        {
            
            if (File.Exists(textBoxLogFile.Text))
            {
                Cursor.Current = Cursors.WaitCursor;
                captures.Clear();

                string[] logLines = File.ReadAllLines(textBoxLogFile.Text);
                int pos = 0;
                bool started = false;

                SoundCapture capture = null;
                int totalTicks = 0;
                int tickCounter = 0;

                foreach (string line in logLines)
                {

                    
                    string cleanLine = CleanLine(line);
                    if (cleanLine.StartsWith("SoundID: " + textBoxFirstSoundID.Text))
                    {
                        byte soundId = GetSoundId(cleanLine);
                        if (!started)
                        {
                            started = true;
                            capture = new SoundCapture(soundId);
                            tickCounter = 0;
                            totalTicks = 0;
                            //UpdateUI();
                        }
                    }
                    else if (started)
                    {
                        if (cleanLine.StartsWith("SoundID: "))
                        {
                            byte soundId = GetSoundId(cleanLine);
                            //we already started, this means we have a new SoundCapture
                            if (capture != null)
                            {
                                //save it
                                capture.TotalTicks = totalTicks;
                                captures.Add(capture);
                                capture = new SoundCapture(soundId);
                                tickCounter = 0;
                                totalTicks = 0;
                                //UpdateUI();
                            }
                        }
                        if (cleanLine == "TICK")
                        {
                            tickCounter++;
                            totalTicks++;
                            if (capture != null)
                            {
                                capture.Tick();
                            }
                        }
                        else if (cleanLine.StartsWith("[:] Pokey Config:"))
                        {
                            //skip config lines for now

                        }
                        else if (cleanLine.StartsWith("[:] Pokey "))
                        {
                            //pokey data here... 
                            string type = cleanLine.Replace("[:] Pokey ", "").Substring(0, 4);
                            int pokeyNumber = int.Parse(cleanLine.Replace(("[:] Pokey " + type + ": "), "").Substring(0, 1));
                            int registerNumber = int.Parse(cleanLine.Replace("[:] Pokey " + type + ": " + pokeyNumber.ToString() + " Register:  ", "").Substring(0, 1));
                            byte channelNumber = (byte)((pokeyNumber << 2) + (registerNumber / 2));
                            //[:] Pokey FREQ: 1 Register:  6 Data: 
                            string hexDataString = cleanLine.Substring(37, 2);
                            byte data = byte.Parse(hexDataString, System.Globalization.NumberStyles.HexNumber);

                            ChannelCapture channel = capture.GetChannel(channelNumber);
                            switch (type)
                            {
                                case "CONT":
                                    channel.ControlBytes.Add(data);
                                    break;
                                case "FREQ":
                                    channel.FrequencyBytes.Add(data);
                                    break;
                            }
                        }
                    }
                }
                if (capture != null)
                {
                    capture.TotalTicks = totalTicks;
                    captures.Add(capture);
                }

                UpdateUI();

                Cursor.Current = Cursors.Default;
            }
            else
            {
                MessageBox.Show("File not found: " + textBoxLogFile.Text);
            }
        }

        private string CleanLine(string line)
        {
            return line.Trim();
        }

        private byte GetSoundId(string line)
        {
            return byte.Parse(line.Replace("SoundID: ", ""), System.Globalization.NumberStyles.HexNumber);
        }

        private void UpdateUI()
        {
            listView1.Items.Clear();
            foreach(SoundCapture capture in captures)
            {
                ListViewItem item = new ListViewItem();
                item.Text = capture.SoundId.ToString("X2");
                item.SubItems.Add(capture.channels.Count().ToString());
                item.SubItems.Add(capture.TotalTicks.ToString());
                listView1.Items.Add(item);
            }
        }

        private void buttonDump_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach(SoundCapture capture in captures)
            {
                capture.Clean();
                sb.AppendLine(capture.ToOutput(OutputFormat.RPM40));
            }

            string outFile = textBoxLogFile.Text.Replace(".log", "") + ".out";
            File.WriteAllText(outFile, sb.ToString());
        }

        //private void buttonFREQ_Click(object sender, EventArgs e)
        //{
        //    List<byte> bytes = GetBytes(textBoxTemp.Text);
        //    textBoxTemp.Text = GetFREQ(bytes);
        //}

        private string GetFREQ(List<byte> bytes)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytes.Count; i += 6)
            {
                byte countV = bytes[i];
                int valueV = ((bytes[i + 2] << 8) + bytes[i + 1]) >> 4;
                if ((valueV & 0xF00) > 0)
                {
                    valueV = (int)(valueV | 0xFFFFFF00);
                }

                byte countD = bytes[i + 3];
                int valueD = ((bytes[i + 5] << 8) + bytes[i + 4]) >> 4;
                if ((valueD & 0xF00) > 0)
                {
                    valueD = (int)(valueD | 0xFFFFFF00);
                }

                sb.AppendLine("SDFREQ(" + countV.ToString() + "," + valueV.ToString() + "," + countD.ToString() + "," + valueD.ToString() + ")");
            }
            return sb.ToString();
        }



        private string GetCTRL(List<byte> bytes)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytes.Count; i += 2)
            {
                byte countV = bytes[i];
                int valueV = (bytes[i + 1]) >> 3;
                if ((valueV & 0xF0) > 0)
                {
                    valueV = (int)(valueV | 0xFFFFFFF0);
                }
                sb.AppendLine("SDCTRL(" + countV.ToString() + "," + valueV.ToString() + ")");
            }
            return sb.ToString();
        }

        public List<byte> GetBytes(string text)
        {
            string[] textBytes = text.ToLower().Replace(" ", "").Replace(";","").Replace(".byte", "").Replace("\t","").Replace(Environment.NewLine, ",").Replace("$","").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            List<byte> bytes = new List<byte>();

            foreach(string s in textBytes)
            {
                byte b = byte.Parse(s, System.Globalization.NumberStyles.HexNumber);
                bytes.Add(b);
            }
            return bytes;
        }

        //private void buttonCTRL_Click(object sender, EventArgs e)
        //{
        //    List<byte> bytes = GetBytes(textBoxTemp.Text);
        //    string encodedCtrl = GetCTRL(bytes);
        //    textBoxTemp.Text = encodedCtrl;
        //}



        private void ButtonDataParse_Click(object sender, EventArgs e)
        {
            List<byte> bytes = GetBytes(textBoxDataParserInput.Text);
            Envelope envelope = new Envelope();
            envelope.LoadFromBinary(bytes, new DataFormat12Bit());
            textBoxDataParserOutput.Text = envelope.GetVisual(";", 8);
        }

        private void ButtonHavocParserParseData_Click(object sender, EventArgs e)
        {
            List<byte> bytes = GetBytes(textBoxHavocParserInput.Text);
            List<string> source = null;
            Envelope envelope = new Envelope();

            ISlopeDataFormatter formatter = null;
            if (comboBoxHavocParserDataType.SelectedIndex == (int)SoundDataType.CTRL)
            {
                formatter = new DataFormat8Bit();
                envelope.LoadFromBinary(bytes, formatter);
                source = envelope.GetSource(7);
            }
            if (comboBoxHavocParserDataType.SelectedIndex == (int)SoundDataType.FREQ)
            {
                formatter = new DataFormat12Bit();
                envelope.LoadFromBinary(bytes, formatter);
                source = envelope.GetSource(8);
            }
            textBoxHavocParserOutput.Text = String.Join("\r\n", source);
            textBoxHavocParserVisual.Text = envelope.GetVisual(";", 8);
        }

        private void Mainform_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Control)
            {
                TextBox activeTextBox = sender as TextBox;
                if (activeTextBox != null)
                {
                    activeTextBox.SelectAll();
                }
            }
        }
    }
}
