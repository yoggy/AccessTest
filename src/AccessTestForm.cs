//
//  AccessTestForm.cs - C#からAccessファイル(*.accdb)をSQL文で操作するメモ 
//
//  このプログラムを実行する場合はあらかじめ
//  「Microsoft Access データベース エンジン 2010 再頒布可能コンポーネント」
//  をインストールしておくこと。
//
//    Download Microsoft Access データベース エンジン 2010 再頒布可能コンポーネント from Official Microsoft Download Center
//    https://www.microsoft.com/ja-jp/download/details.aspx?id=13255
//
//    Microsoft Access データベース エンジン 2010 Service Pack (64 ビット版): KB2460011
//    http://www.microsoft.com/ja-jp/download/details.aspx?id=26605
//
//    Microsoft Access データベース エンジン 2010 Service Pack (32 ビット版): KB2460011
//    http://www.microsoft.com/ja-jp/download/details.aspx?id=26607
//   
using System;
using System.IO;
using System.Windows.Forms;
using System.Data.OleDb;

namespace AccessTest
{
    public partial class AccessTest : Form
    {
        public AccessTest()
        {
            InitializeComponent();
            textAccdbFilePath.Text = Properties.Settings.Default.AccdbFilePath;
        }

        private void buttonChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "accdbファイルを選択してください";
            dlg.RestoreDirectory = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textAccdbFilePath.Text = dlg.FileName;
                Properties.Settings.Default.AccdbFilePath = dlg.FileName;
                Properties.Settings.Default.Save();
            }
        }

        private OleDbConnection connection;
        private OleDbCommand command;

        private string AccdbFilePath()
        {
            return textAccdbFilePath.Text;
        }

        private string CreateAccFilePath(string prefix)
        {
            string dir = Path.GetDirectoryName(AccdbFilePath());
            string name = Path.GetFileNameWithoutExtension(AccdbFilePath()); // 拡張子抜きのファイル名

            string filename = dir + @"\" + name + "-" + prefix + ".accdb";

            return filename;
        }

        private string NewAccdbFilePath()
        {
            return CreateAccFilePath("new");
        }

        private string BackupAccdbFilePath()
        {
            return CreateAccFilePath("backup");
        }

        private void Connect()
        {
            if (connection != null) return;

            connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AccdbFilePath();
            connection.Open();

            command = new OleDbCommand();
            command.Connection = connection;
        }

        private void Disconnect()
        {
            if (connection == null) return;

            command.Dispose();
            command = null;

            connection.Close();
            connection.Dispose();
            connection = null;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Connect();

            command.CommandText = @"CREATE TABLE T_売り上げ(ID COUNTER PRIMARY KEY, 日付 DATETIME, 店舗名 VARCHAR(255) NOT NULL, 商品名 VARCHAR(255) NOT NULL, 個数 INT NOT NULL);";
            command.ExecuteNonQuery();

            Console.WriteLine(command.CommandText);

            Disconnect();
        }

        private void buttonDropTable_Click(object sender, EventArgs e)
        {
            Connect();

            command.CommandText = @"DROP TABLE T_売り上げ;";
            command.ExecuteNonQuery();

            Console.WriteLine(command.CommandText);

            Disconnect();
        }

        private void buttonCompactDatabase_Click(object sender, EventArgs e)
        {
            //
            // 参考
            //   Microsoft Access Compact and Repair using C# .accdb files - Stack Overflow
            //   http://stackoverflow.com/questions/29201611/microsoft-access-compact-and-repair-using-c-sharp-accdb-files
            //
            // "プロジェクト"→"参照の追加"で参照マネージャーを表示
            // 次に"COM"→"Microsoft Office 14.0 Access Database Engine Object Library"を選択し
            // 参照を追加するとMicrosoft.Office.Interop.Access.Dao.DBEngineを使えるようになる
            //
            var dbengine = new Microsoft.Office.Interop.Access.Dao.DBEngine();

            var src = AccdbFilePath();
            var dst = NewAccdbFilePath();
            var bak = BackupAccdbFilePath();

            if (File.Exists(dst))
            {
                File.Delete(dst);
            }

            dbengine.CompactDatabase(src, dst);

            if (File.Exists(bak))
            {
                File.Delete(bak);
            }

            File.Move(src, bak);
            File.Move(dst, src);

            Console.WriteLine("buttonCompactDatabase_Click");
        }

        //
        // INSERT INTOのサンプル
        //
        private void buttonInsert_Click(object sender, EventArgs e)
        {
            Random r = new Random();

            Connect();

            // プリペアドステートメントを使用
            command.CommandText = @"INSERT INTO T_売り上げ(日付,店舗名,商品名,個数) VALUES(?,?,?,?)";
            command.Parameters.Add("日付", OleDbType.Date);
            command.Parameters.Add("店舗名", OleDbType.VarChar);
            command.Parameters.Add("商品名", OleDbType.VarChar);
            command.Parameters.Add("個数", OleDbType.Integer);

            for (int i = 0; i < 10000; ++i)
            {
                // command.Parameters.Addした順番で配列でアクセス
                command.Parameters[0].Value = DateTime.Now;
                command.Parameters[1].Value = "店舗" + String.Format("{0:D8}", r.Next(20) + 1);
                command.Parameters[2].Value = "商品" + String.Format("{0:D8}", r.Next(20) + 1);
                command.Parameters[3].Value = r.Next(1000);

                command.ExecuteNonQuery();

                if (i % 10000 == 0)
                {
                    Console.WriteLine(String.Format("INSERT INTO count={0}", i));
                }
            }

            Disconnect();
        }

        //
        // SELECT のサンプル
        //
        private void buttonSelect_Click(object sender, EventArgs e)
        {
            Connect();

            // 店舗00000001の表示
            command.CommandText = @"SELECT ID,日付,店舗名,商品名,個数 FROM T_売り上げ WHERE 店舗名='店舗00000001'";
            OleDbDataReader reader = command.ExecuteReader();

            Console.WriteLine(command.CommandText);

            while (reader.Read())
            {
                Int32 id = reader.GetInt32(0);

                // nullが入る可能性があるものは、IsDBNull()での確認が必要。ここではnull許容型を使用
                DateTime? dt = null;
                if (!reader.IsDBNull(1))
                {
                    dt = reader.GetDateTime(1);
                }

                string shop_name = reader.GetString(2);
                string product_name = reader.GetString(3);
                Int32 number = reader.GetInt32(4);

                Console.WriteLine(String.Format("id={0}, 日付={1}, 店舗名={2}, 商品名={3}, 個数={4}", id, dt, shop_name, product_name, number));
            }
            command.Dispose();

            // 店舗00000001のカウント表示
            OleDbCommand tmp = new OleDbCommand(@"SELECT COUNT(ID) FROM T_売り上げ WHERE 店舗名='店舗00000001'", connection);
            reader = tmp.ExecuteReader();
            reader.Read();
            Int32 count = reader.GetInt32(0);
            Console.WriteLine("COUNT=" + count);
            tmp.Dispose();

            Disconnect();
        }

        //
        // UPDATE のサンプル
        //
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Connect();

            // プリペアドステートメントを使用
            command.CommandText = @"UPDATE T_売り上げ SET 個数=? WHERE 店舗名='店舗00000001'";
            command.Parameters.Add("個数", OleDbType.Integer).Value = 99999;

            command.ExecuteNonQuery();

            Console.WriteLine(command.CommandText);

            Disconnect();
        }

        //
        // DELETE のサンプル
        //
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Connect();

            // プリペアドステートメントを使用
            command.CommandText = @"DELETE FROM T_売り上げ WHERE 店舗名='店舗00000001'";
            command.ExecuteNonQuery();

            Console.WriteLine(command.CommandText);

            Disconnect();
        }

        //
        // 集計クエリのサンプル
        //
        private void buttonAggregateQuery_Click(object sender, EventArgs e)
        {
            Connect();

            command.CommandText = @"SELECT 店舗名, 商品名, Sum(個数) FROM T_売り上げ GROUP BY 店舗名,商品名 HAVING(店舗名='店舗00000001');";
            OleDbDataReader reader = command.ExecuteReader();

            Console.WriteLine(command.CommandText);

            while (reader.Read())
            {
                string shop_name = reader.GetString(0);
                string product_name = reader.GetString(1);
                double total = reader.GetDouble(2); // Sum()はdoubleで帰ってくるみたい

                Console.WriteLine(String.Format("店舗名={0}, 商品名={1}, 個数の合計={2}", shop_name, product_name, total));
            }

            Disconnect();
        }

        //
        // クロス集計クエリのサンプル
        //
        //     AccessではSELECT *の結果は255個までという制約がある。
        //     1列目に項目名が入るため、クロス集計をする際の列数は254が限界なので要注意
        //     (Accessでクロス集計を作るとQuery結果の2列目に合計が入るので実質253行が限界)
        //
        private void buttonSelectPivot_Click(object sender, EventArgs e)
        {            
            Connect();

            command.CommandText = @"TRANSFORM Sum(個数) SELECT 店舗名 FROM T_売り上げ GROUP BY 店舗名 PIVOT 商品名";

            OleDbDataReader reader = command.ExecuteReader();
            Console.WriteLine(command.CommandText);

            // フィールド名の取得
            Console.WriteLine("    FieldName:");
            for (int i = 0; i < reader.FieldCount; ++i)
            {
                Console.WriteLine(String.Format("        {0}:{1}", i, reader.GetName(i)));
            }

            while (reader.Read())
            {
                Object [] rows = new Object[reader.FieldCount];
                int count = reader.GetValues(rows);

                for (int i = 0; i < rows.Length; ++i)
                {
                    Console.Write(rows[i]);
                    Console.Write(",");
                }
                Console.WriteLine();
            }

            Disconnect();
        }

    }
}
