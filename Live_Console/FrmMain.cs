using System.Diagnostics;

namespace Live_Console
{
    public partial class FrmMain : Form
    {
        int nowNums = 0;
        public FrmMain()
        {
            InitializeComponent();
            if (File.Exists(filePath))
            {
                numAppNums.Value = int.Parse(INIHelper.Read("设置", "应用数量", "0", filePath));
                nowNums = (int)numAppNums.Value;
                GenerateControls();
            }
        }

        void GenerateControls()
        {
            if (File.Exists(filePath))
            {
                panlApps.Controls.Clear();
                //ini文件里的应用程序数量
                int iniNums = int.Parse(INIHelper.Read("设置", "应用数量", "0", filePath));
                int nowNums = (int)numAppNums.Value;
                for (int i = 0; i < nowNums; i++)
                {
                    CheckBox chk = new CheckBox();
                    chk.AutoSize = true;
                    chk.Location = new System.Drawing.Point(17, 13 + i * 30);
                    chk.Name = "chkStart" + i;
                    chk.Size = new System.Drawing.Size(15, 14);
                    chk.Text = "名称：";

                    Label lab2 = new Label();
                    lab2.Location = new System.Drawing.Point(188, 12 + i * 30);
                    lab2.Size = new System.Drawing.Size(44, 17);
                    lab2.TabIndex = i;
                    lab2.Text = "路径：";

                    Label lab3 = new Label();
                    lab3.AutoSize = true;
                    lab3.Location = new System.Drawing.Point(498, 12 + i * 30);
                    lab3.Size = new System.Drawing.Size(44, 17);
                    lab3.Text = "命令：";

                    TextBox txtName = new TextBox();
                    txtName.Location = new System.Drawing.Point(80, 10 + i * 30);
                    txtName.Name = "txtName" + i;
                    txtName.Size = new System.Drawing.Size(100, 23);

                    TextBox txtPath = new TextBox();
                    txtPath.Location = new System.Drawing.Point(238, 10 + i * 30);
                    txtPath.Name = "txtPath" + i;
                    txtPath.Size = new System.Drawing.Size(164, 23);


                    TextBox txtCommand = new TextBox();
                    txtCommand.Location = new System.Drawing.Point(543, 10 + i * 30);
                    txtCommand.Name = "txtCmd" + i;
                    txtCommand.Size = new System.Drawing.Size(196, 23);

                    Button btnPath = new Button();
                    btnPath.Name = "btnPath" + i;
                    btnPath.Location = new System.Drawing.Point(408, 10 + i * 30);
                    btnPath.Size = new System.Drawing.Size(75, 23);
                    btnPath.Text = "选择";
                    btnPath.UseVisualStyleBackColor = true;
                    btnPath.Click += new System.EventHandler(btnPathClick);

                    CheckBox chk2 = new CheckBox();
                    chk2.AutoSize = true;
                    chk2.Location = new System.Drawing.Point(745, 13 + i * 30);
                    chk2.Name = "chkView" + i;
                    chk2.Size = new System.Drawing.Size(15, 14);
                    chk2.Text = "显示";
                    chk2.UseVisualStyleBackColor = true;

                    if (i < iniNums)
                    {
                        chk.Checked = INIHelper.Read("应用" + i.ToString(), "启动", "0", filePath) == "1" ? true : false;
                        txtName.Text = INIHelper.Read("应用" + i.ToString(), "名称", "", filePath);
                        txtPath.Text = INIHelper.Read("应用" + i.ToString(), "路径", "", filePath);
                        txtCommand.Text = INIHelper.Read("应用" + i.ToString(), "命令", "", filePath);
                        chk2.Checked = INIHelper.Read("应用" + i.ToString(), "显示", "0", filePath) == "1" ? true : false;
                    }
                    panlApps.Controls.Add(chk);
                    panlApps.Controls.Add(lab2);
                    panlApps.Controls.Add(lab3);
                    panlApps.Controls.Add(txtName);
                    panlApps.Controls.Add(txtPath);
                    panlApps.Controls.Add(txtCommand);
                    panlApps.Controls.Add(btnPath);
                    panlApps.Controls.Add(chk2);
                }
            }
        }
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sys.ini");//在当前程序路径创建


        private void btnPathClick(object sender, EventArgs e)
        {
            string index = ((Button)sender).Name.Replace("btnPath", "");
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";//注意这里写路径时要用c:\\而不是c:\
            //openFileDialog.Filter = "文本文件|*.*|C#文件|*.cs|所有文件|*.*";
            openFileDialog.Filter = "应用程序|*.exe";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var item in panlApps.Controls)
                {
                    if (item is TextBox && ((TextBox)item).Name.Contains("txtPath"))
                    {
                        if (((TextBox)item).Name.Replace("txtPath", "") == index)
                        {
                            ((TextBox)item).Text = openFileDialog.FileName;
                            return;
                        }
                    }
                }
            }
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            foreach (var item in panlApps.Controls)
            {
                //获取路径
                if (item is CheckBox)
                {
                    if (((CheckBox)item).Name.Contains("chkStart"))
                    {
                        dic.Add("启动" + ((CheckBox)item).Name.Replace("chkStart", ""), ((CheckBox)item).Checked ? "1" : "0");
                    }
                    else if (((CheckBox)item).Name.Contains("chkView"))
                    {
                        dic.Add("显示" + ((CheckBox)item).Name.Replace("chkView", ""), ((CheckBox)item).Checked ? "1" : "0");
                    }
                }
                else if (item is TextBox)
                {
                    if (((TextBox)item).Name.Contains("txtPath"))
                    {
                        dic.Add("路径" + ((TextBox)item).Name.Replace("txtPath", ""), ((TextBox)item).Text);
                    }
                    else if (((TextBox)item).Name.Contains("txtCmd"))
                    {
                        dic.Add("命令" + ((TextBox)item).Name.Replace("txtCmd", ""), ((TextBox)item).Text);
                    }
                    if (((TextBox)item).Name.Contains("txtName"))
                    {
                        dic.Add("名称" + ((TextBox)item).Name.Replace("txtName", ""), ((TextBox)item).Text);
                    }
                }
            }

            for (int i = 0; i < nowNums; i++)
            {
                if (dic["启动" + i] == "1")
                {

                    if (string.IsNullOrEmpty(dic["命令" + i].Trim()))
                    {
                        try
                        {
                            //直接启动程序
                            Process.Start(dic["路径" + i]);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show(dic["名称" + i] + "直接启动失败,请使用命令行模式");
                        }
                    }
                    else
                    {
                        string path = dic["路径" + i].Remove(dic["路径" + i].LastIndexOf('\\'));
                        Process p = new Process();
                        //设置要启动的应用程序
                        p.StartInfo.FileName = "cmd.exe";
                        p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息]
                        if (dic["显示" + i] == "0")
                        {
                            p.StartInfo.CreateNoWindow = true;//不显示程序窗口
                        }
                        p.Start();
                        //进入目录
                        p.StandardInput.WriteLine(path.Substring(0, 1) + ":");
                        p.StandardInput.WriteLine(@"cd " + path);
                        //执行命令
                        p.StandardInput.WriteLine(dic["命令" + i]);
                    }

                }

            }

        }


        private void btnChangeNums_Click(object sender, EventArgs e)
        {
            nowNums = (int)numAppNums.Value;
            GenerateControls();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath);//创建INI文件
            }
            INIHelper.Write("设置", "应用数量", nowNums.ToString(), filePath);
            foreach (var item in panlApps.Controls)
            {
                if (item is CheckBox)
                {
                    if (((CheckBox)item).Name.Contains("chkStart"))
                    {
                        string index = ((CheckBox)item).Name.Replace("chkStart", "");
                        INIHelper.Write("应用" + index, "启动", ((CheckBox)item).Checked ? "1" : "0", filePath);
                    }
                    else if (((CheckBox)item).Name.Contains("chkView"))
                    {
                        string index = ((CheckBox)item).Name.Replace("chkView", "");
                        INIHelper.Write("应用" + index, "显示", ((CheckBox)item).Checked ? "1" : "0", filePath);
                    }
                }
                else if (item is TextBox)
                {
                    if (((TextBox)item).Name.Contains("txtName"))
                    {
                        string index = ((TextBox)item).Name.Replace("txtName", "");
                        INIHelper.Write("应用" + index, "名称", ((TextBox)item).Text, filePath);
                    }
                    else if (((TextBox)item).Name.Contains("txtPath"))
                    {
                        string index = ((TextBox)item).Name.Replace("txtPath", "");
                        INIHelper.Write("应用" + index, "路径", ((TextBox)item).Text, filePath);

                    }
                    else if (((TextBox)item).Name.Contains("txtCmd"))
                    {
                        string index = ((TextBox)item).Name.Replace("txtCmd", "");
                        INIHelper.Write("应用" + index, "命令", ((TextBox)item).Text, filePath);
                    }
                }
            }
        }
    }
}