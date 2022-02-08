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
                numAppNums.Value = int.Parse(INIHelper.Read("����", "Ӧ������", "0", filePath));
                nowNums = (int)numAppNums.Value;
                GenerateControls();
            }
        }

        void GenerateControls()
        {
            if (File.Exists(filePath))
            {
                panlApps.Controls.Clear();
                //ini�ļ����Ӧ�ó�������
                int iniNums = int.Parse(INIHelper.Read("����", "Ӧ������", "0", filePath));
                int nowNums = (int)numAppNums.Value;
                for (int i = 0; i < nowNums; i++)
                {
                    CheckBox chk = new CheckBox();
                    chk.AutoSize = true;
                    chk.Location = new System.Drawing.Point(17, 13 + i * 30);
                    chk.Name = "chkStart" + i;
                    chk.Size = new System.Drawing.Size(15, 14);
                    chk.Text = "���ƣ�";

                    Label lab2 = new Label();
                    lab2.Location = new System.Drawing.Point(188, 12 + i * 30);
                    lab2.Size = new System.Drawing.Size(44, 17);
                    lab2.TabIndex = i;
                    lab2.Text = "·����";

                    Label lab3 = new Label();
                    lab3.AutoSize = true;
                    lab3.Location = new System.Drawing.Point(498, 12 + i * 30);
                    lab3.Size = new System.Drawing.Size(44, 17);
                    lab3.Text = "���";

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
                    btnPath.Text = "ѡ��";
                    btnPath.UseVisualStyleBackColor = true;
                    btnPath.Click += new System.EventHandler(btnPathClick);

                    CheckBox chk2 = new CheckBox();
                    chk2.AutoSize = true;
                    chk2.Location = new System.Drawing.Point(745, 13 + i * 30);
                    chk2.Name = "chkView" + i;
                    chk2.Size = new System.Drawing.Size(15, 14);
                    chk2.Text = "��ʾ";
                    chk2.UseVisualStyleBackColor = true;

                    if (i < iniNums)
                    {
                        chk.Checked = INIHelper.Read("Ӧ��" + i.ToString(), "����", "0", filePath) == "1" ? true : false;
                        txtName.Text = INIHelper.Read("Ӧ��" + i.ToString(), "����", "", filePath);
                        txtPath.Text = INIHelper.Read("Ӧ��" + i.ToString(), "·��", "", filePath);
                        txtCommand.Text = INIHelper.Read("Ӧ��" + i.ToString(), "����", "", filePath);
                        chk2.Checked = INIHelper.Read("Ӧ��" + i.ToString(), "��ʾ", "0", filePath) == "1" ? true : false;
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
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sys.ini");//�ڵ�ǰ����·������


        private void btnPathClick(object sender, EventArgs e)
        {
            string index = ((Button)sender).Name.Replace("btnPath", "");
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";//ע������д·��ʱҪ��c:\\������c:\
            //openFileDialog.Filter = "�ı��ļ�|*.*|C#�ļ�|*.cs|�����ļ�|*.*";
            openFileDialog.Filter = "Ӧ�ó���|*.exe";
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
                //��ȡ·��
                if (item is CheckBox)
                {
                    if (((CheckBox)item).Name.Contains("chkStart"))
                    {
                        dic.Add("����" + ((CheckBox)item).Name.Replace("chkStart", ""), ((CheckBox)item).Checked ? "1" : "0");
                    }
                    else if (((CheckBox)item).Name.Contains("chkView"))
                    {
                        dic.Add("��ʾ" + ((CheckBox)item).Name.Replace("chkView", ""), ((CheckBox)item).Checked ? "1" : "0");
                    }
                }
                else if (item is TextBox)
                {
                    if (((TextBox)item).Name.Contains("txtPath"))
                    {
                        dic.Add("·��" + ((TextBox)item).Name.Replace("txtPath", ""), ((TextBox)item).Text);
                    }
                    else if (((TextBox)item).Name.Contains("txtCmd"))
                    {
                        dic.Add("����" + ((TextBox)item).Name.Replace("txtCmd", ""), ((TextBox)item).Text);
                    }
                    if (((TextBox)item).Name.Contains("txtName"))
                    {
                        dic.Add("����" + ((TextBox)item).Name.Replace("txtName", ""), ((TextBox)item).Text);
                    }
                }
            }

            for (int i = 0; i < nowNums; i++)
            {
                if (dic["����" + i] == "1")
                {

                    if (string.IsNullOrEmpty(dic["����" + i].Trim()))
                    {
                        try
                        {
                            //ֱ����������
                            Process.Start(dic["·��" + i]);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show(dic["����" + i] + "ֱ������ʧ��,��ʹ��������ģʽ");
                        }
                    }
                    else
                    {
                        string path = dic["·��" + i].Remove(dic["·��" + i].LastIndexOf('\\'));
                        Process p = new Process();
                        //����Ҫ������Ӧ�ó���
                        p.StartInfo.FileName = "cmd.exe";
                        p.StartInfo.RedirectStandardInput = true;//�������Ե��ó����������Ϣ]
                        if (dic["��ʾ" + i] == "0")
                        {
                            p.StartInfo.CreateNoWindow = true;//����ʾ���򴰿�
                        }
                        p.Start();
                        //����Ŀ¼
                        p.StandardInput.WriteLine(path.Substring(0, 1) + ":");
                        p.StandardInput.WriteLine(@"cd " + path);
                        //ִ������
                        p.StandardInput.WriteLine(dic["����" + i]);
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
                File.Create(filePath);//����INI�ļ�
            }
            INIHelper.Write("����", "Ӧ������", nowNums.ToString(), filePath);
            foreach (var item in panlApps.Controls)
            {
                if (item is CheckBox)
                {
                    if (((CheckBox)item).Name.Contains("chkStart"))
                    {
                        string index = ((CheckBox)item).Name.Replace("chkStart", "");
                        INIHelper.Write("Ӧ��" + index, "����", ((CheckBox)item).Checked ? "1" : "0", filePath);
                    }
                    else if (((CheckBox)item).Name.Contains("chkView"))
                    {
                        string index = ((CheckBox)item).Name.Replace("chkView", "");
                        INIHelper.Write("Ӧ��" + index, "��ʾ", ((CheckBox)item).Checked ? "1" : "0", filePath);
                    }
                }
                else if (item is TextBox)
                {
                    if (((TextBox)item).Name.Contains("txtName"))
                    {
                        string index = ((TextBox)item).Name.Replace("txtName", "");
                        INIHelper.Write("Ӧ��" + index, "����", ((TextBox)item).Text, filePath);
                    }
                    else if (((TextBox)item).Name.Contains("txtPath"))
                    {
                        string index = ((TextBox)item).Name.Replace("txtPath", "");
                        INIHelper.Write("Ӧ��" + index, "·��", ((TextBox)item).Text, filePath);

                    }
                    else if (((TextBox)item).Name.Contains("txtCmd"))
                    {
                        string index = ((TextBox)item).Name.Replace("txtCmd", "");
                        INIHelper.Write("Ӧ��" + index, "����", ((TextBox)item).Text, filePath);
                    }
                }
            }
        }
    }
}