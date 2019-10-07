using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPMUtility
{
    public class SoundCapture
    {
        public SoundCapture(byte soundId)
        {
            SoundId = soundId;
        }

        public List<ChannelCapture> channels = new List<ChannelCapture>();

        public byte SoundId = 0;
        public int TotalTicks = 0;

        public string Summary
        {
            get
            {
                return SoundId.ToString() + " - " + channels.Count().ToString() + " channels";
            }
        }

        public ChannelCapture GetChannel(byte channelNumber)
        {
            ChannelCapture channel = channels.Where(c => c.ChannelNumber == channelNumber).FirstOrDefault();
            if (channel == null)
            {
                //didn't exist, make a new one..
                channel = new ChannelCapture(channelNumber);
                channels.Add(channel);
            }
            return channel;
        }

        public void Tick()
        {
            //for each tick of the sound clock, each channel is ticked
            foreach(ChannelCapture channel in channels)
            {
                channel.Tick();
            }
        }

        public void Clean()
        {
            foreach (ChannelCapture channel in channels)
            {
                channel.Clean();
            }
        }

        public string ToOutput(OutputFormat format)
        {
            StringBuilder sb = new StringBuilder();

            foreach(ChannelCapture channel in channels)
            {
                string label = "s" + SoundId.ToString("X2");
                sb.AppendLine(channel.ToOutput(label, format));
            }

            return sb.ToString();
        }
    }
}
