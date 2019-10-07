using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPMUtility.Interfaces
{
    public interface ISlopeDataFormatter
    {
        double Slope { get; set; }
        int Duration { get; set; }

        List<IEnvelopeItem> Load(List<byte> bytes);

        int TotalLength(List<IEnvelopeItem> items);

        List<int> GetPcmData(List<IEnvelopeItem> items, int downSampleAmount, int minValue, int maxValue);

        List<string> GetSource(List<IEnvelopeItem> items, int downsampleAmount);
    }
}
