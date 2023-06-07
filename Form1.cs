using System.Data.Odbc;
using System.Diagnostics;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void �m�F_Click(object sender, EventArgs e)
        {
            // �K�v�ȃN���X
            OdbcConnection myCon = new OdbcConnection();
            OdbcCommand myCommand = new OdbcCommand();

            bool result = MysqlConnect(myCon, myCommand);
            if (result == false)
            {
                return;
            }


            // �R�}���h�I�u�W�F�N�g��ڑ��Ɋ֌W�t���� 
            myCommand.Connection = myCon;
            // �Ј��R�[�h���݃`�F�b�N�p�� SQL �쐬
            string strQuery = @$"select * from �Ј��}�X�^
                                    where �Ј��R�[�h = '{this.�Ј��R�[�h.Text}'";

            myCommand.CommandText = strQuery;
            Debug.WriteLine($"DBG:{strQuery}");

            OdbcDataReader myReader = myCommand.ExecuteReader();
            bool check = myReader.Read();
            // �����敪���V�K�ŁA�f�[�^�����݂�����G���[
            if (this.�����敪.SelectedIndex == 0 && check)
            {
                myReader.Close();
                myCon.Close();
                MessageBox.Show($"���͂��ꂽ�Ј��R�[�h�͊��ɓo�^����Ă��܂� : {this.�Ј��R�[�h.Text}");

                // �ē��͂��K�v�Ȃ̂ŁA�t�H�[�J�X���đI��
                this.�Ј��R�[�h.Focus();
                this.�Ј��R�[�h.SelectAll();
                return;
            }

            // �ڑ�����
            myCon.Close();

            // ����b�֑J��
            this.�w�b�h��.Enabled = false;
            this.�{�f�B��.Enabled = true;

            // �ŏ��ɓ��͕K�v�ȃt�B�[���h�Ƀt�H�[�J�X���đI��
            this.����.Focus();
            this.����.SelectAll();

        }

        private bool MysqlConnect(OdbcConnection myCon, OdbcCommand myCommand)
        {
            bool result = true;


            // �ڑ�������̍쐬
            string server = "localhost";
            string database = "lightbox";
            string user = "root";
            string pass = "";
            string strCon = $"Driver={{MySQL ODBC 8.0 Unicode Driver}};SERVER={server};DATABASE={database};UID={user};PWD={pass}";
            Debug.WriteLine($"DBG:{strCon}");

            myCon.ConnectionString = strCon;

            bool functionExit = false;
            try
            {
                // �ڑ� 
                myCon.Open();
            }
            catch (Exception ex)
            {
                functionExit = true;
                MessageBox.Show($"�ڑ��G���[ : {ex.Message}");
            }
            // �ڑ��G���[�̈�
            if (functionExit)
            {
                result = false;
            }



            return result;
        }

        private void �L�����Z��_Click(object sender, EventArgs e)
        {
            // ����b(����)�֑J��
            this.�w�b�h��.Enabled = true;
            this.�{�f�B��.Enabled = false;

            // �ŏ��ɓ��͕K�v�ȃt�B�[���h�Ƀt�H�[�J�X���đI��
            this.�Ј��R�[�h.Focus();
            this.�Ј��R�[�h.SelectAll();

            // �L�����Z���Ȃ̂œ��͂����t�B�[���h�̃N���A
            this.����.Clear();
            this.���^.Clear();
            this.���N����.Value = DateTime.Now;

        }

        private void �X�V_Click(object sender, EventArgs e)
        {
            // ���b�Z�[�W�{�b�N�X��\��
            DialogResult result = MessageBox.Show(
                "�X�V���Ă���낵���ł���?",
                "�X�V�m�F",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2
            );

            if (result == DialogResult.Yes)
            {
                // �������Ȃ�
            }
            else
            {
                // �X�V���Ȃ��̂ŏ����𔲂���( No ��I�� )
                this.����.Focus();
                this.����.SelectAll();
                return;
            }


            // �K�v�ȃN���X
            OdbcConnection myCon = new OdbcConnection();
            OdbcCommand myCommand = new OdbcCommand();

            bool result2 = MysqlConnect(myCon, myCommand);
            if (result2 == false)
            {
                return;
            }

            // �X�V����

            // �R�}���h�I�u�W�F�N�g��ڑ��Ɋ֌W�t���� 
            myCommand.Connection = myCon;
            // �Ј��R�[�h���݃`�F�b�N�p�� SQL �쐬
            string strQuery = @$"insert into `�Ј��}�X�^` (
	`�Ј��R�[�h` 
	,`����` 
	,`���^` 
	,`���N����` 
)
 values(
	'{this.�Ј��R�[�h.Text}'
	,'{this.����.Text}'
	,{this.���^.Text}
	,'{this.���N����.Value}'
)";

            myCommand.CommandText = strQuery;
            Debug.WriteLine($"DBG:{strQuery}");


            bool functionExit = false;
            try
            {
                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                functionExit = true;
                MessageBox.Show($"�ڑ��G���[ : {ex.Message}");
            }
            // �ڑ��G���[�̈�
            if (functionExit)
            {
                myCon.Close();
                return;
            }


            // �ڑ�����
            myCon.Close();

            // ����b(����)�֑J��
            this.�w�b�h��.Enabled = true;
            this.�{�f�B��.Enabled = false;

            // �ŏ��ɓ��͕K�v�ȃt�B�[���h�Ƀt�H�[�J�X���đI��
            this.�Ј��R�[�h.Focus();
            this.�Ј��R�[�h.SelectAll();

            // �L�����Z���Ȃ̂œ��͂����t�B�[���h�̃N���A
            this.�Ј��R�[�h.Clear();
            this.����.Clear();
            this.���^.Clear();
            this.���N����.Value = DateTime.Now;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.�����敪.SelectedIndex = 0;
        }
    }
}