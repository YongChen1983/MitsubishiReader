using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ActUtlTypeLib;

namespace MitsubishiD45Reader
{
    public partial class Form1 : Form
    {
        private ActUtlType _plc;
        private bool _connected;
        private readonly Timer _rangeReadTimer;

        public Form1()
        {
            InitializeComponent();
            _connected = false;
            _rangeReadTimer = new Timer();
            _rangeReadTimer.Interval = 1000;
            _rangeReadTimer.Tick += RangeReadTimer_Tick;
            try
            {
                _plc = new ActUtlType();
            }
            catch (Exception ex)
            {
                MessageBox.Show("创建 MX Component 对象失败: " + ex.Message + "\n请确认已添加 COM 引用 ActUtlTypeLib（嵌入互操作类型=False）。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (_plc == null)
            {
                MessageBox.Show("MX Component 未就绪，请确认已安装三菱 MX Component。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_connected)
            {
                MessageBox.Show("已经处于连接状态。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int stationNumber = (int)numStation.Value;
                _plc.ActLogicalStationNumber = stationNumber;
                _plc.ActPassword = "";

                int ret = _plc.Open();
                if (ret != 0)
                {
                    MessageBox.Show("连接失败，错误码: 0x" + ret.ToString("X8"), "连接错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _connected = true;
                lblStatus.Text = "状态: 已连接";
                lblStatus.ForeColor = System.Drawing.Color.Green;
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
                btnRead.Enabled = true;
                btnWrite.Enabled = true;
                btnReadX1396.Enabled = true;
                btnReadBit.Enabled = true;
                btnWriteBit.Enabled = true;
                btnReadD2460Ascii.Enabled = true;
                btnStartTimerRead.Enabled = true;
                btnStopTimerRead.Enabled = false;
                btnExportMonitorExcel.Enabled = true;
                btnExportAllRecipes.Enabled = true;
                btnModelLoginMode.Enabled = true;
                btnModelCfgRead.Enabled = true;
                btnModelCfgWrite.Enabled = true;
                numStation.Enabled = false;
                UpdateModelLoginModeButton();
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接异常: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void Disconnect()
        {
            if (!_connected || _plc == null)
                return;

            try { _plc.Close(); }
            catch { }

            _connected = false;
            lblStatus.Text = "状态: 未连接";
            lblStatus.ForeColor = System.Drawing.Color.Gray;
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            btnRead.Enabled = false;
            btnWrite.Enabled = false;
            btnReadX1396.Enabled = false;
            btnReadBit.Enabled = false;
            btnWriteBit.Enabled = false;
            btnReadD2460Ascii.Enabled = false;
            btnStartTimerRead.Enabled = false;
            btnStopTimerRead.Enabled = false;
            btnExportMonitorExcel.Enabled = false;
            btnExportAllRecipes.Enabled = false;
            numStation.Enabled = true;
            txtValue.Text = "--";
            txtX1396.Text = "--";
            txtBitValue.Text = "--";
            txtD2460Ascii.Text = "（连接后点击「读取」）";
            lblAsciiInline.Text = "ASCII: --";
            txtD6202.Text = "--";
            txtD6005.Text = "--";
            txtExportStyle.Text = "";
            txtExportCode.Text = "";
            btnModelLoginMode.Enabled = false;
            btnModelCfgRead.Enabled = false;
            btnModelCfgWrite.Enabled = false;
            ResetModelLoginModeButton();
            SetFixedMonitorFieldsReadOnly(true);
            _rangeReadTimer.Stop();
        }

        private string GetDeviceName()
        {
            string s = (txtDevice.Text ?? "").Trim();
            return string.IsNullOrEmpty(s) ? "D45" : s;
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            if (!_connected || _plc == null)
            {
                MessageBox.Show("请先连接 PLC。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string deviceName = GetDeviceName();
            try
            {
                short[] arr = new short[1];
                int ret = _plc.ReadDeviceBlock2(deviceName, 1, out arr[0]);

                if (ret != 0)
                {
                    MessageBox.Show("读取失败，错误码: 0x" + ret.ToString("X8"), "读取错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                txtValue.Text = arr[0].ToString();
                lblStatus.Text = "状态: 已连接 (读取成功)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("读取异常: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            if (!_connected || _plc == null)
            {
                MessageBox.Show("请先连接 PLC。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string deviceName = GetDeviceName();
            if (!short.TryParse(txtWriteValue.Text.Trim(), out short writeVal))
            {
                MessageBox.Show("写入值必须是 -32768 ～ 32767 之间的整数。", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                short[] arr = new short[] { writeVal };
                int ret = _plc.WriteDeviceBlock2(deviceName, 1, ref arr[0]);

                if (ret != 0)
                {
                    MessageBox.Show("写入失败，错误码: 0x" + ret.ToString("X8"), "写入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                txtValue.Text = writeVal.ToString();
                lblStatus.Text = "状态: 已连接 (写入成功)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("写入异常: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReadX1396_Click(object sender, EventArgs e)
        {
            if (!_connected || _plc == null)
            {
                MessageBox.Show("请先连接 PLC。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 按 BOOLEAN 读取 X1396：直接使用 GetDevice("X1396")，非 0 即为 true
                int raw;
                int ret = _plc.GetDevice("X1396", out raw);

                if (ret != 0)
                {
                    MessageBox.Show("读取 X1396 失败，错误码: 0x" + ret.ToString("X8"), "读取错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtX1396.Text = "错误";
                    lblStatus.Text = "状态: 已连接 (X1396 读取失败)";
                    return;
                }

                bool isOn = raw != 0;
                txtX1396.Text = isOn ? "1 (ON)" : "0 (OFF)";
                lblStatus.Text = "状态: 已连接 (X1396 读取成功)";
            }
            catch (Exception ex)
            {
                txtX1396.Text = "异常";
                MessageBox.Show("读取 X1396 异常: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReadBit_Click(object sender, EventArgs e)
        {
            if (!_connected || _plc == null)
            {
                MessageBox.Show("请先连接 PLC。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string deviceName = (txtBitDevice.Text ?? "").Trim();
            if (string.IsNullOrEmpty(deviceName))
            {
                MessageBox.Show("请输入位软元件地址（如 X1396、M1005、Y50）。", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int value = 0;
                int ret = -1;

                // 按 BOOLEAN 读取任意位软元件：直接使用 GetDevice
                try
                {
                    int raw;
                    ret = _plc.GetDevice(deviceName, out raw);
                    if (ret == 0)
                        value = raw;
                }
                catch
                {
                    ret = -1;
                }

                if (ret != 0)
                {
                    string errMsg = "0x" + ret.ToString("X8");
                    txtBitValue.Text = "读取失败(" + errMsg + ")";
                    lblStatus.Text = "状态: 已连接 (" + deviceName + " 读取失败)";
                    MessageBox.Show("读取 " + deviceName + " 失败，错误码: " + errMsg, "读取错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                txtBitValue.Text = value != 0 ? "1 (ON)" : "0 (OFF)";
                lblStatus.Text = "状态: 已连接 (" + deviceName + " 读取成功)";
            }
            catch (Exception ex)
            {
                txtBitValue.Text = "异常";
                lblStatus.Text = "状态: 已连接 (读取异常)";
                MessageBox.Show("读取异常: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnWriteBit_Click(object sender, EventArgs e)
        {
            if (!_connected || _plc == null)
            {
                MessageBox.Show("请先连接 PLC。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string deviceName = (txtBitDevice.Text ?? "").Trim();
            if (string.IsNullOrEmpty(deviceName))
            {
                MessageBox.Show("请输入位软元件地址（如 M1、Y10）。", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string writeText = (txtBitWriteValue.Text ?? "").Trim();
            if (writeText != "0" && writeText != "1" && !writeText.Equals("ON", StringComparison.OrdinalIgnoreCase) && !writeText.Equals("OFF", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("写入值请输入 0 或 1（也可输入 OFF/ON）。", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            short writeVal = (short)(writeText == "1" || writeText.Equals("ON", StringComparison.OrdinalIgnoreCase) ? 1 : 0);

            try
            {
                int ret = _plc.SetDevice(deviceName, writeVal);

                if (ret != 0)
                {
                    MessageBox.Show("写入 " + deviceName + " 失败，错误码: 0x" + ret.ToString("X8"), "写入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                txtBitValue.Text = writeVal != 0 ? "1 (ON)" : "0 (OFF)";
                lblStatus.Text = "状态: 已连接 (" + deviceName + " 写入成功)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("写入异常: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>解析位软元件字符串，如 X1396、M100、Y50，得到类型和编号</summary>
        private static bool TryParseBitDevice(string deviceName, out string deviceType, out int deviceNum)
        {
            deviceType = "";
            deviceNum = 0;
            if (string.IsNullOrWhiteSpace(deviceName) || deviceName.Length < 2)
                return false;
            deviceType = deviceName.Substring(0, 1).ToUpperInvariant();
            string numPart = deviceName.Substring(1).Trim();
            return int.TryParse(numPart, out deviceNum) && deviceNum >= 0;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _rangeReadTimer.Stop();
            Disconnect();
        }

        private void grpBit_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 启动时定点监视四项默认不可编辑（连接后随 M160 再放开）
            SetFixedMonitorFieldsReadOnly(true);
        }

        /// <summary>手动读取当前 D 区间并显示 ASCII。</summary>
        private void btnReadD2460Ascii_Click(object sender, EventArgs e)
        {
            ReadDRangeAndRender(showErrorDialog: true);
        }

        private void btnStartTimerRead_Click(object sender, EventArgs e)
        {
            if (!_connected || _plc == null)
            {
                MessageBox.Show("请先连接 PLC。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!TryGetDRange(out int startNo, out int endNo, out int count, out string validationError))
            {
                MessageBox.Show(validationError, "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _rangeReadTimer.Interval = (int)numIntervalMs.Value;
            _rangeReadTimer.Start();
            btnStartTimerRead.Enabled = false;
            btnStopTimerRead.Enabled = true;
            lblStatus.Text = "状态: 已连接 (定时读取中 D" + startNo + "～D" + endNo + ", " + _rangeReadTimer.Interval + "ms)";
            ReadDRangeAndRender(showErrorDialog: true);
        }

        private void btnStopTimerRead_Click(object sender, EventArgs e)
        {
            _rangeReadTimer.Stop();
            btnStartTimerRead.Enabled = _connected;
            btnStopTimerRead.Enabled = false;
            lblStatus.Text = "状态: 已连接 (定时读取已停止)";
        }

        private void RangeReadTimer_Tick(object sender, EventArgs e)
        {
            ReadDRangeAndRender(showErrorDialog: false);
        }

        /// <summary>导出：编号、车型、样式、代码均取当前界面可编辑内容（样式/代码在下方 D 区间组，与读取范围同步后可改）。</summary>
        private void btnExportMonitorExcel_Click(object sender, EventArgs e)
        {
            if (!_connected || _plc == null)
            {
                MessageBox.Show("请先连接 PLC。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string bianhao = (txtD6202.Text ?? "").Trim();
            string chexing = (txtD6005.Text ?? "").Trim();
            string yangshi = (txtExportStyle.Text ?? "").Trim();
            string daima = (txtExportCode.Text ?? "").Trim();

            using (var sfd = new SaveFileDialog())
            {
                sfd.Title = "导出到 Excel (CSV)";
                sfd.Filter = "Excel CSV (*.csv)|*.csv";
                sfd.FileName = "定点监视_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";
                if (sfd.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    var sb = new StringBuilder();
                    sb.AppendLine("编号,车型,样式,代码");
                    sb.AppendLine(
                        CsvEscapeField(bianhao) + "," +
                        CsvEscapeField(chexing) + "," +
                        CsvEscapeField(yangshi) + "," +
                        CsvEscapeField(daima));

                    File.WriteAllText(sfd.FileName, sb.ToString(), new UTF8Encoding(true));
                    lblStatus.Text = "状态: 已连接 (已导出定点监视 CSV)";
                    MessageBox.Show("导出完成：\n" + sfd.FileName, "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导出异常: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static string CsvEscapeField(string s)
        {
            if (string.IsNullOrEmpty(s))
                return "";
            string t = s.Replace("\"", "\"\"");
            if (t.IndexOfAny(new[] { ',', '\r', '\n', '"' }) >= 0)
                return "\"" + t + "\"";
            return t;
        }

        /// <summary>
        /// 读取 M160：若为 0（非车型配置模式）则提示「不是车型配置模式或线体不能启动」并中止；
        /// 仅当 M160=1 时继续：将 D6202 依次写入 1～100，读取编号/车型/样式/代码导出 CSV，结束后写回原先 D6202。
        /// </summary>
        private void btnExportAllRecipes_Click(object sender, EventArgs e)
        {
            if (!_connected || _plc == null)
            {
                MessageBox.Show("请先连接 PLC。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // M160=0 时 TryEnsureModelConfigMode 返回 false，提示后不再执行导出
            if (!TryEnsureModelConfigMode(out string modeMsg))
            {
                MessageBox.Show(modeMsg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            short prevD6202;
            int retPrev = _plc.ReadDeviceBlock2("D6202", 1, out prevD6202);
            if (retPrev != 0)
            {
                MessageBox.Show("读取当前 D6202 失败，错误码: 0x" + retPrev.ToString("X8"), "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Title = "导出全部配方 (CSV，Excel 打开)";
                sfd.Filter = "Excel CSV (*.csv)|*.csv";
                sfd.FileName = "全部配方_D6202_1-100_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";
                if (sfd.ShowDialog(this) != DialogResult.OK)
                    return;

                bool hiFirst = chkD2460HiByteFirst != null && chkD2460HiByteFirst.Checked;
                var sb = new StringBuilder();
                sb.AppendLine("编号,车型,样式,代码");
                bool abortedByWrite = false;

                Cursor = Cursors.WaitCursor;
                Enabled = false;
                try
                {
                    for (int n = 1; n <= 100; n++)
                    {
                        short w = (short)n;
                        int retW = _plc.WriteDeviceBlock2("D6202", 1, ref w);
                        if (retW != 0)
                        {
                            MessageBox.Show("写入 D6202=" + n + " 失败，错误码: 0x" + retW.ToString("X8") + "\n已中止，将尝试恢复原先编号。",
                                "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            abortedByWrite = true;
                            break;
                        }

                        System.Threading.Thread.Sleep(50);

                        short d6202Read;
                        int retR = _plc.ReadDeviceBlock2("D6202", 1, out d6202Read);
                        string colBianhao = retR == 0 ? d6202Read.ToString() : ("读取失败0x" + retR.ToString("X8"));

                        short d6005;
                        int ret5 = _plc.ReadDeviceBlock2("D6005", 1, out d6005);
                        string colChexing = ret5 == 0 ? d6005.ToString() : ("读取失败0x" + ret5.ToString("X8"));

                        string colStyle;
                        if (TryReadDWordsAsciiLine(6010, 8, hiFirst, out string rawStyle, out int erS))
                            colStyle = FormatStyleCodeForDisplay(rawStyle);
                        else
                            colStyle = "读取失败0x" + erS.ToString("X8");

                        string colCode;
                        if (TryReadDWordsAsciiLine(6020, 8, hiFirst, out string rawCode, out int erC))
                            colCode = FormatStyleCodeForDisplay(rawCode);
                        else
                            colCode = "读取失败0x" + erC.ToString("X8");

                        sb.AppendLine(
                            CsvEscapeField(colBianhao) + "," +
                            CsvEscapeField(colChexing) + "," +
                            CsvEscapeField(colStyle) + "," +
                            CsvEscapeField(colCode));

                        if (n % 10 == 0)
                            lblStatus.Text = "状态: 已连接 (导出配方 " + n + "/100)";
                        Application.DoEvents();
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), new UTF8Encoding(true));
                    lblStatus.Text = abortedByWrite
                        ? "状态: 已连接 (配方导出已中止，已保存部分 CSV)"
                        : "状态: 已连接 (已全部配方导出 CSV)";
                    if (abortedByWrite)
                        MessageBox.Show("因写入 D6202 失败，仅保存已读取的行。\n" + sfd.FileName, "提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show("导出完成：\n" + sfd.FileName, "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导出异常: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Enabled = true;
                    Cursor = Cursors.Default;
                    short restore = prevD6202;
                    int retRest = _plc.WriteDeviceBlock2("D6202", 1, ref restore);
                    if (retRest != 0)
                    {
                        MessageBox.Show("警告：恢复原先 D6202=" + prevD6202 + " 失败，错误码: 0x" + retRest.ToString("X8") +
                            "\n请在 PLC 侧确认编号。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        UpdateModelLoginModeButton();
                }
            }
        }

        private bool TryGetDRange(out int startNo, out int endNo, out int count, out string error)
        {
            startNo = 0;
            endNo = 0;
            count = 0;
            error = "";

            if (!int.TryParse((txtDStart.Text ?? "").Trim(), out startNo) ||
                !int.TryParse((txtDEnd.Text ?? "").Trim(), out endNo))
            {
                error = "起始/结束地址请输入整数（只填数字，如 2460）。";
                return false;
            }
            if (startNo < 0 || endNo < 0)
            {
                error = "D 地址不能为负数。";
                return false;
            }
            if (endNo < startNo)
            {
                error = "结束地址必须大于或等于起始地址。";
                return false;
            }

            count = endNo - startNo + 1;
            if (count > 256)
            {
                error = "单次读取范围过大，请控制在 256 个字以内。";
                return false;
            }

            return true;
        }

        private void ReadDRangeAndRender(bool showErrorDialog)
        {
            if (!_connected || _plc == null)
            {
                if (showErrorDialog)
                    MessageBox.Show("请先连接 PLC。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!TryGetDRange(out int startNo, out int endNo, out int count, out string validationError))
            {
                if (_rangeReadTimer.Enabled)
                {
                    _rangeReadTimer.Stop();
                    btnStartTimerRead.Enabled = _connected;
                    btnStopTimerRead.Enabled = false;
                }
                if (showErrorDialog)
                    MessageBox.Show(validationError, "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                short[] arr = new short[count];
                for (int i = 0; i < count; i++)
                {
                    string dev = "D" + (startNo + i);
                    int ret = _plc.ReadDeviceBlock2(dev, 1, out arr[i]);
                    if (ret != 0)
                    {
                        if (_rangeReadTimer.Enabled)
                        {
                            _rangeReadTimer.Stop();
                            btnStartTimerRead.Enabled = _connected;
                            btnStopTimerRead.Enabled = false;
                        }
                        if (showErrorDialog)
                        {
                            MessageBox.Show("读取 " + dev + " 失败，错误码: 0x" + ret.ToString("X8"),
                                "读取错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            lblStatus.Text = "状态: 已连接 (定时读取失败: " + dev + ", 0x" + ret.ToString("X8") + ")";
                        }
                        lblAsciiInline.Text = "ASCII: --";
                        return;
                    }
                }

                bool hiFirst = chkD2460HiByteFirst.Checked;
                SyncExportStyleCodeFromRange(startNo, endNo, arr, hiFirst);

                var sb = new StringBuilder();

                sb.AppendLine("地址范围: D" + startNo + " ～ D" + endNo + "（" + count + " 字，" + (count * 2) + " 字节）");
                sb.AppendLine("字节序: " + (hiFirst ? "每字 高字节→低字节（与 GX 相反）" : "每字 低字节→高字节（与 GX Works「W+ASC」一致）"));
                sb.AppendLine();

                sb.AppendLine("── 与 GX 监视窗口逐字对照（未勾选「高字节在前」时应一致）──");
                sb.AppendLine(BuildGxStylePerWordLine(arr, startNo, hiFirst));
                sb.AppendLine();

                sb.AppendLine("── 各字数值 ──");
                for (int i = 0; i < count; i++)
                {
                    int addr = startNo + i;
                    ushort uw = (ushort)arr[i];
                    sb.AppendLine("D" + addr + " = " + arr[i] + "  (0x" + uw.ToString("X4") + ")");
                }

                sb.AppendLine();
                sb.AppendLine("── ASCII 连续串（不可显/0x00 显示为 ·）──");
                string asciiContinuous = WordsToAsciiLine(arr, hiFirst);
                sb.AppendLine(asciiContinuous);

                sb.AppendLine();
                sb.AppendLine("── 连续十六进制字节 ──");
                sb.AppendLine(WordsToHexByteString(arr, hiFirst));

                // 追加固定监视区：D6202、D6005 以及两段 8 字 ASCII，并更新对应文本框
                AppendFixedMonitorArea(sb);

                txtD2460Ascii.Text = sb.ToString();
                lblAsciiInline.Text = "ASCII: " + asciiContinuous;
                if (_rangeReadTimer.Enabled)
                    lblStatus.Text = "状态: 已连接 (定时读取中 D" + startNo + "～D" + endNo + ", " + _rangeReadTimer.Interval + "ms)";
                else
                    lblStatus.Text = "状态: 已连接 (D" + startNo + "～D" + endNo + " 读取成功)";
            }
            catch (Exception ex)
            {
                if (_rangeReadTimer.Enabled)
                {
                    _rangeReadTimer.Stop();
                    btnStartTimerRead.Enabled = _connected;
                    btnStopTimerRead.Enabled = false;
                }
                if (showErrorDialog)
                    MessageBox.Show("读取异常: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    lblStatus.Text = "状态: 已连接 (定时读取异常)";
                lblAsciiInline.Text = "ASCII: --";
            }
            finally
            {
                if (_connected && _plc != null)
                    UpdateModelLoginModeButton();
            }
        }

        private static char ByteToAsciiDisplay(byte b)
        {
            if (b == 0)
                return '·';
            if (b >= 32 && b < 127)
                return (char)b;
            return '·';
        }

        /// <summary>与 GX Works 字+ASC 相同：每行两字，默认先低字节再高字节。</summary>
        private static string BuildGxStylePerWordLine(short[] words, int startAddr, bool highByteFirst)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < words.Length; i++)
            {
                if (i > 0) sb.Append("  ");
                sb.Append("D");
                sb.Append(startAddr + i);
                sb.Append("=");
                sb.Append(WordToTwoCharAscii(words[i], highByteFirst));
            }
            return sb.ToString();
        }

        private static string WordToTwoCharAscii(short w, bool highByteFirst)
        {
            ushort uw = (ushort)w;
            byte lo = (byte)(uw & 0xFF);
            byte hi = (byte)(uw >> 8);
            if (highByteFirst)
                return string.Concat(ByteToAsciiDisplay(hi), ByteToAsciiDisplay(lo));
            return string.Concat(ByteToAsciiDisplay(lo), ByteToAsciiDisplay(hi));
        }

        /// <summary>样式/代码显示用：从第一个英文句点「.」起截断（句点及之后不显示）。若句点在最前导致截断后为空，则保留原串（避免整框空白）。</summary>
        private static string TruncateStyleCodeAtFirstDot(string asciiLine)
        {
            if (string.IsNullOrEmpty(asciiLine))
                return asciiLine;
            int i = asciiLine.IndexOf('.');
            if (i < 0)
                return asciiLine;
            string before = asciiLine.Substring(0, i).TrimEnd();
            if (before.Length == 0)
                return asciiLine.TrimEnd();
            return before;
        }

        /// <summary>去掉末尾由空字节转换来的占位「·」及空白（与状态栏连续串观感一致，不显示尾部“点”）。</summary>
        private static string TrimTrailingAsciiPlaceholders(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;
            int end = s.Length;
            while (end > 0)
            {
                char c = s[end - 1];
                if (c == '·' || c == ' ' || c == '\t' || c == '\u00A0')
                    end--;
                else
                    break;
            }
            return end == s.Length ? s : s.Substring(0, end);
        }

        /// <summary>样式/代码框：先按英文句点截断，再去掉尾部 ·/空白。</summary>
        private static string FormatStyleCodeForDisplay(string asciiLine)
        {
            if (string.IsNullOrEmpty(asciiLine))
                return asciiLine;
            return TrimTrailingAsciiPlaceholders(TruncateStyleCodeAtFirstDot(asciiLine));
        }

        /// <summary>将字数组按指定字节序转为可见 ASCII 一行。</summary>
        private static string WordsToAsciiLine(short[] words, bool highByteFirst)
        {
            var sb = new StringBuilder(words.Length * 2);
            foreach (short w in words)
            {
                ushort uw = (ushort)w;
                byte lo = (byte)(uw & 0xFF);
                byte hi = (byte)(uw >> 8);
                if (highByteFirst)
                {
                    sb.Append(ByteToAsciiDisplay(hi));
                    sb.Append(ByteToAsciiDisplay(lo));
                }
                else
                {
                    sb.Append(ByteToAsciiDisplay(lo));
                    sb.Append(ByteToAsciiDisplay(hi));
                }
            }
            return sb.ToString();
        }

        private static string WordsToHexByteString(short[] words, bool highByteFirst)
        {
            var sb = new StringBuilder(words.Length * 6);
            for (int i = 0; i < words.Length; i++)
            {
                ushort uw = (ushort)words[i];
                byte lo = (byte)(uw & 0xFF);
                byte hi = (byte)(uw >> 8);
                if (highByteFirst)
                {
                    if (i > 0) sb.Append(' ');
                    sb.Append(hi.ToString("X2"));
                    sb.Append(' ');
                    sb.Append(lo.ToString("X2"));
                }
                else
                {
                    if (i > 0) sb.Append(' ');
                    sb.Append(lo.ToString("X2"));
                    sb.Append(' ');
                    sb.Append(hi.ToString("X2"));
                }
            }
            return sb.ToString();
        }

        /// <summary>逐字读取连续 D，拼成 ASCII 一行（与 D 区间读取相同方式）。</summary>
        private bool TryReadDWordsAsciiLine(int startD, int wordCount, bool highByteFirst, out string asciiLine, out int failRet)
        {
            asciiLine = "";
            failRet = 0;
            var arr = new short[wordCount];
            for (int i = 0; i < wordCount; i++)
            {
                string dev = "D" + (startD + i);
                int ret = _plc.ReadDeviceBlock2(dev, 1, out arr[i]);
                if (ret != 0)
                {
                    failRet = ret;
                    return false;
                }
            }

            asciiLine = WordsToAsciiLine(arr, highByteFirst);
            return true;
        }

        /// <summary>定点监视：D6202、D6005；样式/代码每次 D 区间读取（含定时）时从 PLC 直接读 D6010～6017 / D6020～6027（与下方勾选字节序一致），不必把起始地址设到 6010。</summary>
        private void AppendFixedMonitorArea(StringBuilder sb)
        {
            if (_plc == null || !_connected)
                return;

            try
            {
                sb.AppendLine();
                sb.AppendLine("── 固定监视区 ──");

                bool hiFirst = chkD2460HiByteFirst != null && chkD2460HiByteFirst.Checked;

                // D6202
                short v6202;
                int ret = _plc.ReadDeviceBlock2("D6202", 1, out v6202);
                if (ret == 0)
                {
                    sb.AppendLine("D6202 = " + v6202);
                    if (!txtD6202.Focused)
                        txtD6202.Text = v6202.ToString();
                }
                else
                {
                    sb.AppendLine("D6202 读取失败: 0x" + ret.ToString("X8"));
                    if (!txtD6202.Focused)
                        txtD6202.Text = "--";
                }

                // D6005
                short v6005;
                ret = _plc.ReadDeviceBlock2("D6005", 1, out v6005);
                if (ret == 0)
                {
                    sb.AppendLine("D6005 = " + v6005);
                    if (!txtD6005.Focused)
                        txtD6005.Text = v6005.ToString();
                }
                else
                {
                    sb.AppendLine("D6005 读取失败: 0x" + ret.ToString("X8"));
                    if (!txtD6005.Focused)
                        txtD6005.Text = "--";
                }

                // D6010～6017、D6020～6027：与导出栏同一数据源，范围不含这些地址时仍刷新
                if (txtExportStyle != null && !txtExportStyle.Focused)
                {
                    if (TryReadDWordsAsciiLine(6010, 8, hiFirst, out string rawStyle, out int erS))
                    {
                        string disp = FormatStyleCodeForDisplay(rawStyle);
                        txtExportStyle.Text = disp;
                        sb.AppendLine("D6010～6017 ASCII: " + disp);
                    }
                    else
                    {
                        txtExportStyle.Text = "--";
                        sb.AppendLine("D6010～6017 读取失败: 0x" + erS.ToString("X8"));
                    }
                }

                if (txtExportCode != null && !txtExportCode.Focused)
                {
                    if (TryReadDWordsAsciiLine(6020, 8, hiFirst, out string rawCode, out int erC))
                    {
                        string disp = FormatStyleCodeForDisplay(rawCode);
                        txtExportCode.Text = disp;
                        sb.AppendLine("D6020～6027 ASCII: " + disp);
                    }
                    else
                    {
                        txtExportCode.Text = "--";
                        sb.AppendLine("D6020～6027 读取失败: 0x" + erC.ToString("X8"));
                    }
                }
            }
            catch
            {
                sb.AppendLine("固定监视区读取异常。");
                if (!txtD6202.Focused) txtD6202.Text = "--";
                if (!txtD6005.Focused) txtD6005.Text = "--";
                if (txtExportStyle != null && !txtExportStyle.Focused) txtExportStyle.Text = "--";
                if (txtExportCode != null && !txtExportCode.Focused) txtExportCode.Text = "--";
                ResetModelLoginModeButton();
            }
        }

        /// <summary>当 D 区间读取包含整块 D6010～6017 / D6020～6027 时，同步到导出用文本框（与当前字节序一致；正在编辑的框不覆盖）。</summary>
        private void SyncExportStyleCodeFromRange(int rangeStart, int rangeEnd, short[] arr, bool highByteFirst)
        {
            if (rangeStart <= 6010 && rangeEnd >= 6017)
            {
                int off = 6010 - rangeStart;
                if (off >= 0 && off + 8 <= arr.Length && txtExportStyle != null && !txtExportStyle.Focused)
                {
                    var slice = new short[8];
                    Array.Copy(arr, off, slice, 0, 8);
                    txtExportStyle.Text = FormatStyleCodeForDisplay(WordsToAsciiLine(slice, highByteFirst));
                }
            }

            if (rangeStart <= 6020 && rangeEnd >= 6027)
            {
                int off = 6020 - rangeStart;
                if (off >= 0 && off + 8 <= arr.Length && txtExportCode != null && !txtExportCode.Focused)
                {
                    var slice = new short[8];
                    Array.Copy(arr, off, slice, 0, 8);
                    txtExportCode.Text = FormatStyleCodeForDisplay(WordsToAsciiLine(slice, highByteFirst));
                }
            }
        }

        /// <summary>定点监视：未连接或 M160=0 时编号/车型/样式/代码只读；M160=1 时可编辑。</summary>
        private void SetFixedMonitorFieldsReadOnly(bool readOnly)
        {
            if (txtD6202 != null) txtD6202.ReadOnly = readOnly;
            if (txtD6005 != null) txtD6005.ReadOnly = readOnly;
            if (txtExportStyle != null) txtExportStyle.ReadOnly = readOnly;
            if (txtExportCode != null) txtExportCode.ReadOnly = readOnly;
        }

        /// <summary>M160=0 红色（非登陆模式），M160=1 绿色（登陆模式）。仅指示，不写入 PLC。</summary>
        private void UpdateModelLoginModeButton()
        {
            if (btnModelLoginMode == null || !_connected || _plc == null)
            {
                SetFixedMonitorFieldsReadOnly(true);
                return;
            }
            try
            {
                int raw;
                int ret = _plc.GetDevice("M160", out raw);
                if (ret != 0)
                {
                    ResetModelLoginModeButton();
                    SetFixedMonitorFieldsReadOnly(true);
                    return;
                }

                btnModelLoginMode.FlatStyle = FlatStyle.Flat;
                btnModelLoginMode.FlatAppearance.BorderSize = 0;
                btnModelLoginMode.UseVisualStyleBackColor = false;

                if (raw != 0)
                {
                    btnModelLoginMode.BackColor = Color.LimeGreen;
                    btnModelLoginMode.ForeColor = Color.Black;
                    SetFixedMonitorFieldsReadOnly(false);
                }
                else
                {
                    btnModelLoginMode.BackColor = Color.Red;
                    btnModelLoginMode.ForeColor = Color.White;
                    SetFixedMonitorFieldsReadOnly(true);
                }
            }
            catch
            {
                ResetModelLoginModeButton();
                SetFixedMonitorFieldsReadOnly(true);
            }
        }

        private void ResetModelLoginModeButton()
        {
            if (btnModelLoginMode == null)
                return;
            btnModelLoginMode.UseVisualStyleBackColor = true;
            btnModelLoginMode.BackColor = SystemColors.Control;
            btnModelLoginMode.ForeColor = SystemColors.ControlText;
            btnModelLoginMode.FlatStyle = FlatStyle.Standard;
        }

        /// <summary>车型配置操作前：必须 M160=1（车型登陆模式）。</summary>
        private bool TryEnsureModelConfigMode(out string message)
        {
            message = "";
            if (!_connected || _plc == null)
            {
                message = "请先连接 PLC。";
                return false;
            }

            int raw;
            int ret = _plc.GetDevice("M160", out raw);
            if (ret != 0)
            {
                message = "读取 M160 失败，错误码: 0x" + ret.ToString("X8");
                return false;
            }

            if (raw == 0)
            {
                message = "不是车型配置模式或线体不能启动";
                return false;
            }

            return true;
        }

        /// <summary>M160=1 时将 M16 置 1。</summary>
        private void btnModelCfgRead_Click(object sender, EventArgs e)
        {
            if (!TryEnsureModelConfigMode(out string msg))
            {
                MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int ret = _plc.SetDevice("M16", 1);
                if (ret != 0)
                {
                    MessageBox.Show("写入 M16 失败，错误码: 0x" + ret.ToString("X8"), "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                lblStatus.Text = "状态: 已连接 (已置位 M16=1)";
                UpdateModelLoginModeButton();
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作异常: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>M160=1 时将 M15 置 1。</summary>
        private void btnModelCfgWrite_Click(object sender, EventArgs e)
        {
            if (!TryEnsureModelConfigMode(out string msg))
            {
                MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int ret = _plc.SetDevice("M15", 1);
                if (ret != 0)
                {
                    MessageBox.Show("写入 M15 失败，错误码: 0x" + ret.ToString("X8"), "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                lblStatus.Text = "状态: 已连接 (已置位 M15=1)";
                UpdateModelLoginModeButton();
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作异常: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModelLoginMode_Click(object sender, EventArgs e)
        {

        }
    }
}
