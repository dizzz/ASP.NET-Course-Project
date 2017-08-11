using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 实验8
{
    public partial class Default : System.Web.UI.Page
    {
        private string root = "File";
        private void ShowDirectory(string path)
        {
            tvDir.Nodes.Clear();            //创建文件夹列表的根节点
            TreeNode node = new TreeNode(root, Server.MapPath(root));
            tvDir.Nodes.Add(node);
            node.Selected = true;           //设置根节点的文件夹为默认文件夹
            DirectoryInfo dir = new System.IO.DirectoryInfo(path);
            ShowSubDirectory(node, node.Value); //创建指定文件夹的子文件夹节点
        }
        private void ShowDirectoryContents(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);        // 定义当前文件夹
            FileInfo[] files = dir.GetFiles("*.txt");               // 获取FileInfo对象
            gridFileList.DataSource = files;                    // 显示文件列表       
            Page.DataBind();
            gridFileList.SelectedIndex = -1;                    // 清除已选择项
            btnDeleteFile.Enabled = false;
        }

        private void ShowSubDirectory(TreeNode parent, string path)
        {
            System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(path);
            foreach (System.IO.DirectoryInfo d in directory.GetDirectories())
            {
                TreeNode node = new TreeNode(d.Name, d.FullName);
                parent.ChildNodes.Add(node);
                ShowSubDirectory(node, d.FullName);         // 对当前文件夹递归调用本函数
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strCurrentDir;
                strCurrentDir = Server.MapPath(root);       // 获取指定文件夹的实际路径           
                ShowDirectory(strCurrentDir);           // 显示文件夹列表
                ShowDirectoryContents(strCurrentDir);
            }
        }

        protected void tvDir_SelectedNodeChanged(object sender, EventArgs e)
        {
            string path;
            if (tvDir.SelectedNode != null)         // 文件夹切换后重新显示文件列表
                path = tvDir.SelectedNode.Value;
            else path = Server.MapPath(root);
            ShowDirectoryContents(path);
        }


        protected void btnCreateDir_Click(object sender, EventArgs e)
        {
            phCreate.Visible = true;        // 允许文件夹创建
        }


        protected void btnCreateOk_Click(object sender, EventArgs e)
        {
            if (txtCreate.Text == "")
                Response.Write("<script>window.alert('请输入要创建的文件夹名称')</script>");
            else
            {
                string strPathName = txtCreate.Text;
                string strFullPath = tvDir.SelectedValue;
                string strPathFullName = strFullPath + "\\" + strPathName;  // 获取新文件夹的实际路径
                Directory.CreateDirectory(strPathFullName);             // 创建新文件夹
                TreeNode node = new TreeNode(strPathName, strPathFullName);
                tvDir.SelectedNode.ChildNodes.Add(node);    // 向文件夹列表中添加新节点
                node.Selected = true;                   // 选中新节点
                txtCreate.Text = "";
                phCreate.Visible = false;
            }
        }


        protected void btnCreateCancel_Click(object sender, EventArgs e)
        {
            txtCreate.Text = "";
            phCreate.Visible = false;       // 取消文件夹创建
        }

        protected void btnDeleteDir_Click(object sender, EventArgs e)
        {
            if (tvDir.Nodes[0].Checked == true)                  // 不允许删除根目录
                return;
            DirectoryInfo dir = new DirectoryInfo(tvDir.SelectedValue);
            try
            {
                dir.Delete();                           // 删除文件夹
                ShowDirectory(root);                    // 重新显示文件夹列表
            }
            catch (Exception)
            {
                Response.Write("<script>window.alert('文件夹不为空')</script>");  //不允许删除非空文件夹
            }
            finally { }
        }
        protected void ReadFile(string FileName)
        {
            //建立StreamReader，打开文本文件        
            StreamReader sr = File.OpenText(FileName);
            StringBuilder output = new StringBuilder();
            string rl;
            //按行读取文件并显示
            while ((rl = sr.ReadLine()) != null)
                output.Append(rl + "\n");
            txtFile.Text = output.ToString();
            sr.Close();
        }
        protected void WriteFile(string FileName)
        {
            //建立StreamWrite        
            StreamWriter rw = File.CreateText(FileName);
            rw.Write(txtFile.Text);
            rw.Flush(); //将缓冲区的内容写入文件
            rw.Close(); //关闭rw对象
        }
        protected void gridFileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gridFileList.SelectedIndex != -1)
            {
                string fileName = (string)gridFileList.DataKeys[gridFileList.SelectedIndex].Value;
                txtNewFileName.Text = Path.GetFileNameWithoutExtension(fileName);
                ReadFile(fileName);             //读取当前选中文件         
                btnDeleteFile.Enabled = true;   //允许当前文件被删除
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string fileName;
            if (txtNewFileName.Text == "")
                Response.Write("<script>window.alert('请输入文件名')</script>");
            else
            {
                string strFullPath = tvDir.SelectedValue;        // 保存文件
                fileName = strFullPath + "\\" + txtNewFileName.Text + ".txt";
                WriteFile(fileName);
                ShowDirectoryContents(strFullPath);
                txtNewFileName.Text = "";
                txtFile.Text = "";
            }
        }

        protected void btnDeleteFile_Click(object sender, EventArgs e)
        {
            //获取当前选中的文件名
            string fileName = (string)gridFileList.DataKeys[gridFileList.SelectedIndex].Value;
            System.IO.File.Delete(fileName);                // 删除文件
            txtNewFileName.Text = "";
            txtFile.Text = "";
            string strFullPath = tvDir.SelectedValue;
            ShowDirectoryContents(strFullPath);     // 重新显示文件列表
        }

    }
}