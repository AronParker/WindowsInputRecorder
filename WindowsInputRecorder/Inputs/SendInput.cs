using WindowsInputRecorder.Win32;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace WindowsInputRecorder.Inputs
{
    public class SendInput
    {
        private List<INPUT> inputs;

        public SendInput()
        {
            inputs = new List<INPUT>();
        }

        public void Flush()
        {
            if (inputs.Count == 0)
                return;

            int totalInputs = inputs.Count;
            int executedInputs = NativeMethods.SendInput(totalInputs, inputs.ToArray(), Marshal.SizeOf(inputs[0]));

            if (totalInputs != executedInputs)
                throw new Win32Exception(Marshal.GetLastWin32Error());

            inputs.Clear();
        }

        public void Send(Input value)
        {
            value.InternalQueue(this);
            Flush();
        }

        public void Queue(Input value)
        {
            value.InternalQueue(this);
        }

        internal void InternalQueue(INPUT input)
        {
            inputs.Add(input);
        }

        internal void InternalQueue(INPUT[] inputArray)
        {
            inputs.AddRange(inputArray);
        }
    }
}
