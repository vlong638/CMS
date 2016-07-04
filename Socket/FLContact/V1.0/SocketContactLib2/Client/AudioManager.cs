using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NAudio.Wave;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using SocketContactLib.Base;

namespace SocketContactLib.Client
{
    public class AudioManager
    {
        public CLSClientBase Parent { set; get; }

        public Guid ID { set; get; }
        public string Name { set; get; }
        //编号 
        public string Code
        {
            private set { }
            get
            {
                return Host.Substring(Host.LastIndexOf(".") + 1) + Port.ToString();
            }
        }

        public string ServerHost = "192.168.1.100";
        public int ServerPort = 8099;
        public string TargetName { set; get; }
        public string TargetIP { set; get; }
        public int TargetPort { set; get; }

        public string Host { set; get; }
        public int Port { set; get; }
        public Guid CallerID { set; get; }
        public UserState State { set; get; }
        public bool Stopped = true;

        public AudioManager()
        {
            State = UserState.Available;
        }
        public AudioManager(Guid id, string name = "default")
        {
            ID = id;
            Name = name;
            State = UserState.Available;
        }

        public Socket Connection { set; get; }

        #region Play
        //音频接收
        private byte[] _bufferReceived = new byte[RequestConstants.DefaultBufferSize];
        public byte[] BufferReceived { set { _bufferReceived = value; } get { return _bufferReceived; } }
        public MemoryStream RStream = new MemoryStream();//TODO 用户的缓存量处理
        public bool IsPlaying = false;//是否正在播放
        public int PlayNotifySize = RequestConstants.PlayNotifySize;//设置通知大小20000
        public long PlayPosition = 0;//内存流中播放指针位移
        /// <summary>
        /// 接收语音数据
        /// </summary>
        /// <param name="length"></param>
        public void AcceptStream(int length)
        {
            if (RequestConstants.IsPlaySaved)
            {
                using (FileStream stream = File.Open(@"C:\test.mp3", FileMode.Append, FileAccess.Write))
                {
                    stream.Write(BufferReceived, 0, length);
                }
            }
            else
            {
                RStream.Write(BufferReceived, 0, length);
                if (RStream.Length > PlayNotifySize)
                {
                    Parent.Log.WriteLog("启用播放S");
                    if (IsPlaying != true)
                    {
                        IsPlaying = true;
                    }
                }
                if (RStream.Length > 0 && length == 0)
                {
                    Parent.Log.WriteLog("启用播放E");
                    if (IsPlaying != true)
                    {
                        IsPlaying = true;
                    }
                }
            }
        }
        IWavePlayer _waveOut = new WaveOut();
        IMp3FrameDecompressor decompressor = null;
        BufferedWaveProvider bufferedWaveProvider = null;
        public void Play()
        {
            byte[] buffer = new byte[RequestConstants.DepressLength]; //[16384 * 4]; // needs to be big enough to hold a decompressed frame
            while (true)
            {
                while ( RStream.Length==0&&(IsPlaying || RStream.Length > PlayNotifySize))
                {
                    IsPlaying = true;
                    //播放流程待优化
                    Mp3Frame frame = null;
                    if (bufferedWaveProvider != null && bufferedWaveProvider.BufferLength - bufferedWaveProvider.BufferedBytes < bufferedWaveProvider.WaveFormat.AverageBytesPerSecond / 4)
                    {
                        Thread.Sleep(500);
                        continue;
                    }

                    try
                    {
                        RStream.Position = PlayPosition;
                        frame = Mp3Frame.LoadFromStream(RStream);
                        PlayPosition += frame.FrameLength;
                        Parent.Log.WriteLog(string.Format("目标播放至{0},{1}", PlayPosition, DateTime.Now.ToString()));
                        if (frame == null)
                        {
                            //出现错误
                            IsPlaying = false;
                            throw new NotImplementedException();
                        }
                    }
                    catch (Exception)
                    {
                        Parent.Log.WriteLog("缓冲中");
                        IsPlaying = false;
                        break;
                    }

                    if (decompressor == null)
                    {
                        WaveFormat waveFormat = new Mp3WaveFormat(frame.SampleRate, frame.ChannelMode == ChannelMode.Mono ? 1 : 2, frame.FrameLength, frame.BitRate);
                        decompressor = new AcmMp3FrameDecompressor(waveFormat);
                        bufferedWaveProvider = new BufferedWaveProvider(decompressor.OutputFormat);
                        _waveOut.Init(bufferedWaveProvider);
                        _waveOut.Play();

                    }
                    int decompressed = decompressor.DecompressFrame(frame, buffer, 0);
                    bufferedWaveProvider.AddSamples(buffer, 0, decompressed);
                }
                if (Stopped)
                {
                    RStream = new MemoryStream();
                    break;
                }
                Thread.Sleep(200);
            }
        }
        #endregion

        #region Record
        //音频发送
        private byte[] _bufferSend = new byte[RequestConstants.DefaultBufferSize];
        public byte[] BufferSend { set { _bufferSend = value; } get { return _bufferSend; } }
        public MemoryStream SStream = new MemoryStream();//TODO 用户的缓存量处理
        public int WritePosition = 0;//内存流中写指针位移
        public int WriteNotifySize = RequestConstants.WriteNotifySize;//设置通知大小20000
        public WaveIn WaveIn;
        /// <summary>
        /// 发送语音数据
        /// </summary>
        /// <param name="length"></param>
        public void LoadStream(int length)
        {
            lock (SStream)
            {
                SStream.Position = WritePosition;
                SStream.Read(BufferSend, 0, length);
                WritePosition += length;
            }
        }
        public void StartRecord()
        {
            Parent.Log.WriteLog("客户{0}启用语音输出", Parent.Name);
            if (!RequestConstants.VoiceFromFile)
            {
                //Lame init
                _lameConfig = new BE_CONFIG(new LameWaveFormat(SAMPLE_RATE, BITS, CHANNELS));
                Lame.beInitStream(_lameConfig, ref _lameInSamples, ref  _lameOutBufferSize, ref _lameStream);
                _lameInBuffer = new byte[_lameInSamples * 2]; //Input buffer is expected as short[]
                _lameOutBuffer = new byte[_lameOutBufferSize];

                WaveIn = new WaveIn();
                //waveIn.BufferMilliseconds = 50;
                //waveIn.DeviceNumber = inputDeviceNumber;
                WaveIn.WaveFormat = new WaveFormat(SAMPLE_RATE, CHANNELS);
                //配置waveIn以优化发送间隔
                //font
                WaveIn.DataAvailable += waveIn_DataAvailable;
                ////background
                //WaveInEvent waveInE = new WaveInEvent();
                //waveInE.DataAvailable += waveIn_DataAvailable;
                //waveIn.DataAvailable = waveInE;
                WaveIn.StartRecording();
            }
            else
            {
                //模拟持续录入
                byte[] buffer = File.ReadAllBytes(RequestConstants.FilePath);
                Parent.Log.WriteLog("音频数据已加载");
                int length = buffer.Length;
                int position = 0;

                #region WriteData需要的初始化内容
                ////Lame init
                //_lameConfig = new BE_CONFIG(new LameWaveFormat(SAMPLE_RATE, BITS, CHANNELS));
                //Lame.beInitStream(_lameConfig, ref _lameInSamples, ref  _lameOutBufferSize, ref _lameStream);
                //_lameInBuffer = new byte[_lameInSamples * 2]; //Input buffer is expected as short[]
                //_lameOutBuffer = new byte[_lameOutBufferSize];
                //WriteData(buffer, 0, length);
                #endregion
                try
                {
                    while (length - position > 0)
                    {
                        int sendLength = Math.Min(length, Parent.TargetClient.SendBufferSize);
                        Parent.TargetClient.Send(buffer, sendLength, SocketFlags.None);
                        Thread.Sleep(100);
                        position += sendLength;
                        Parent.Log.WriteLog("{0}已传输{1}位数据", Parent.Name, sendLength);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                int j = 1;
            }
        }
        public void StopRecord()
        {
            WaveIn.StopRecording();
            SStream = new MemoryStream();
            WritePosition = 0;
        }

        void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            WriteData(e.Buffer, 0, e.BytesRecorded);


            //if (Stopped)
            //{
            //    WaveIn.StopRecording();
            //    SStream = new MemoryStream();
            //    WritePosition = 0;
            //    //vlong638 测试用 主动关闭
            //    //if (Parent.IsActive)
            //    //{
            //    //    Parent.CloseConnection(true);
            //    //}
            //}
            //else
            //{
            //    WriteData(e.Buffer, 0, e.BytesRecorded);
            //}

            //Parent.SendTarget.Send(e.Buffer,0, e.BytesRecorded, SocketFlags.None);
        }
        public const int SAMPLE_RATE = 8000;
        public const int CHANNELS = 1;
        public const int BITS = 16;
        private BE_CONFIG _lameConfig;
        private uint _lameStream = 0;
        private uint _lameInSamples = 0;
        private uint _lameOutBufferSize = 0;
        private byte[] _lameInBuffer = null;
        private int _lameInBufferPos = 0;
        private byte[] _lameOutBuffer = null;

        private void WriteData(byte[] buffer, int index, int count)
        {
            int ToCopy = 0;
            uint EncodedSize = 0;
            uint LameResult;
            while (count > 0)
            {
                if (_lameInBufferPos > 0)
                {
                    ToCopy = Math.Min(count, _lameInBuffer.Length - _lameInBufferPos);
                    Buffer.BlockCopy(buffer, index, _lameInBuffer, _lameInBufferPos, ToCopy);
                    _lameInBufferPos += ToCopy;
                    index += ToCopy;
                    count -= ToCopy;
                    if (_lameInBufferPos >= _lameInBuffer.Length)
                    {
                        _lameInBufferPos = 0;
                        if ((LameResult = Lame.EncodeChunk(_lameStream, _lameInBuffer, _lameOutBuffer, ref EncodedSize)) == Lame.BE_ERR_SUCCESSFUL)
                        {
                            if (EncodedSize > 0)
                            {
                                if (Parent.SendBuffer(Parent.TargetClient, _lameOutBuffer, (int)EncodedSize) == -1)
                                    break;
                            }
                        }
                        else
                        {
                            throw new ApplicationException(string.Format("Lame.EncodeChunk failed with the error code {0}", LameResult));
                        }
                    }
                }
                else
                {
                    if (count >= _lameInBuffer.Length)
                    {
                        if ((LameResult = Lame.EncodeChunk(_lameStream, buffer, index, (uint)_lameInBuffer.Length, _lameOutBuffer, ref EncodedSize)) == Lame.BE_ERR_SUCCESSFUL)
                        {
                            if (EncodedSize > 0)
                            {
                                if (Parent.SendBuffer(Parent.TargetClient, _lameOutBuffer, (int)EncodedSize) == -1)
                                    break;
                            }
                        }
                        else
                        {
                            throw new ApplicationException(string.Format("Lame.EncodeChunk failed with the error code {0}", LameResult));
                        }
                        count -= _lameInBuffer.Length;
                        index += _lameInBuffer.Length;
                    }
                    else
                    {
                        Buffer.BlockCopy(buffer, index, _lameInBuffer, 0, count);
                        _lameInBufferPos = count;
                        index += count;
                        count = 0;
                    }
                }
            }
        }
        #endregion
    }
}
