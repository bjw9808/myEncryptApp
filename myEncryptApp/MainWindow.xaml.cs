using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;


namespace myEncryptApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string inputString = psd_1.Password;
            if (inputString != "")
            {
                myPopupText_1.Text = "Success";
                popup_1.IsOpen = true;
                psd_1.Password = "";

                // generate secret key
                string secretKey = EncryptStringByMD5(inputString);
                string textFromFile = ReadFile("encryptFile.txt");
                string decryptText = AesDecryptBase64(textFromFile, secretKey);
                WriteFile("decryptFile.txt", decryptText);

                System.Diagnostics.Process pro = new System.Diagnostics.Process();
                pro.StartInfo.FileName = "notepad.exe";
                pro.StartInfo.Arguments = "decryptFile.txt";
                pro.Start();
            }
            else
            {
                myPopupText_1.Text = "PSD Error";
                popup_1.IsOpen = true;
                psd_1.Password = "";
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string inputString = psd_1.Password;
            if (inputString != "")
            {
                // input legal password
                myPopupText_2.Text = "Success";
                popup_2.IsOpen = true;
                psd_1.Password = "";

                // generate secret key
                string secretKey = EncryptStringByMD5(inputString);
                string textFromFile = "";
                try
                {
                    textFromFile = ReadFile("decryptFile.txt");
                }
                catch (Exception exception)
                {
                    myPopupText_2.Text = exception.Message;
                    popup_2.IsOpen = true;
                }
                string encryptText = AesEncryptBase64(textFromFile, secretKey);
                WriteFile("encryptFile.txt", encryptText);
                System.IO.File.Delete("decryptFile.txt");
            }
            else
            {
                // illegal password
                myPopupText_2.Text = "PSD Error";
                popup_2.IsOpen = true;
                psd_1.Password = "";
            }
        }

        public static string EncryptStringByMD5(string str)
        {
            MD5 md5 = MD5.Create();
            byte[] byteOld = Encoding.UTF8.GetBytes(str);
            byte[] byteNew = md5.ComputeHash(byteOld);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in byteNew)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        public static string AesEncryptBase64(string EncryptStr, string Key)
        {
            try
            {
                byte[] keyArray = Convert.FromBase64String(Key);
                byte[] toEncryptArray = Encoding.UTF8.GetBytes(EncryptStr);

                RijndaelManaged rDel = new RijndaelManaged();
                rDel.Key = keyArray;
                rDel.Mode = CipherMode.ECB;
                rDel.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = rDel.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string AesDecryptBase64(string DecryptStr, string Key)
        {
            try
            {
                byte[] keyArray = Convert.FromBase64String(Key);
                byte[] toEncryptArray = Convert.FromBase64String(DecryptStr);
                RijndaelManaged rDel = new RijndaelManaged();
                rDel.Key = keyArray;
                rDel.Mode = CipherMode.ECB;
                rDel.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = rDel.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                return Encoding.UTF8.GetString(resultArray);//  UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string ReadFile(string filePath)
        {
            string textFromFile = System.IO.File.ReadAllText(filePath);
            return textFromFile;
        }

        public static void WriteFile(string filePath, string textToFile)
        {
            try
            {
                System.IO.File.WriteAllText(filePath, textToFile);
            }

            catch (Exception ex)
            {
                
            }
        }
    }
}
