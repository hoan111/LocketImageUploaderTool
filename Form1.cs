using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using Firebase.Auth;
using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices.ComTypes;
using Imazen.WebP;
using System.CodeDom;

namespace LocketImageUploader
{
    public partial class Form1 : Form
    {
        private string Username {  get; set; }
        private string Password { get; set; }

        private static FirebaseAuthClient FirebaseAuthClient = null;
        private static UserCredential UserCredential = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Username = UserNameTextBox.Text;
            Password = PasswordTextBox.Text;
            LoginToFireBase(Username, Password);
        }

        public async void LoginToFireBase(string username, string password)
        {
            if(String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password)) 
            {
                MessageBox.Show("Username hoặc Password không được bỏ trống", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
            var imageUrl = "";
            var videoUrl = "";
            try
            {
                var authConfig = new FirebaseAuthConfig
                {
                    ApiKey = "AIzaSyCQngaaXQIfJaH0aS2l7REgIjD7nL431So",
                    AuthDomain = "locket-4252a.firebaseapp.com",
                    Providers = new FirebaseAuthProvider[]
{
                            new EmailProvider(),
},
                    UserRepository = new FileUserRepository("FirebaseRepo"), // Có thể được sử dụng để lưu thông tin login
                };
                FirebaseAuthClient = new FirebaseAuthClient(authConfig);
                UserCredential = await FirebaseAuthClient.SignInWithEmailAndPasswordAsync(username, password);
                var user = UserCredential.User;
                var token = await user.GetIdTokenAsync();

                using (var stream = File.Open(TxtBoxFilePath.Text, FileMode.Open))
                {

                    var task = new FirebaseStorage("locket-img", new FirebaseStorageOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(token), //Token = IdToken trên locket
                        ThrowOnCancel = true,

                    })
                    .Child("users")
                    .Child(user.Uid) //User ID trên locket
                    .Child("moments")
                    .Child("thumbnails")
                    .Child($"{System.Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21)}.webp")
                    .PutAsync(stream);

                    //task.Progress.ProgressChanged += (s, e) => UploadProgessBar.Value = e.Percentage;
                    imageUrl = await task;

                    //TODO: call locket function
                    string FirebaseFunctions = "api.locketcamera.com";
                    string FirebaseCallFunction = "postMomentV2";
                    ChangeButtonStateAfterLogin();
                }

                bool uploadVideo = CheckBoxUploadVideo.Checked;
                if(uploadVideo)
                {
                    using (var streamVideo = File.Open(TxtBoxFilePath.Text, FileMode.Open))
                    {
                        var task = new FirebaseStorage("locket-video", new FirebaseStorageOptions
                        {
                            AuthTokenAsyncFactory = () => Task.FromResult(token), //Token = IdToken trên locket
                            ThrowOnCancel = true,

                        })
                        .Child("users")
                        .Child(user.Uid) //User ID trên locket
                        .Child("moments")
                        .Child("videos")
                        .Child($"{System.Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21)}.mp4")
                        .PutAsync(streamVideo);

                        //task.Progress.ProgressChanged += (s, e) => UploadProgessBar.Value = e.Percentage;
                        videoUrl = await task;
                    }
                }
            } catch(Exception e)
            {
                MessageBox.Show(e.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LinkTextBox.Text = $"ImageUrl: {imageUrl} ------ videoUrl: {videoUrl}";
        }
        private void ChangeButtonStateAfterLogin()
        {
            LoginBtn.Enabled = false;
            LogoutBtn.Enabled = true;
            UserNameTextBox.Text = string.Empty;
            PasswordTextBox.Text = string.Empty;
        }
        private void ChangeButtonStateAfterLogout()
        {
            LoginBtn.Enabled = true;
            LogoutBtn.Enabled = false;
            LinkTextBox.Text = string.Empty;
        }
        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            try
            {
                FirebaseAuthClient.SignOut();
                MessageBox.Show("Logout successfully");

                FirebaseAuthClient = null;
                UserCredential = null;
                ChangeButtonStateAfterLogout();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public byte[] convertImageToWebpAsync(string path)
        {
            using (Bitmap bitmap = new Bitmap(path))
            using (var outStream = new MemoryStream())
            {
                var encoder = new SimpleEncoder();
                encoder.Encode(bitmap, outStream, 20);
                return outStream.ToArray();
            } 
        }

        private void BtnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select an image";
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog.ShowDialog();
            if (String.IsNullOrEmpty(openFileDialog.FileName))
            {
                MessageBox.Show("Please select a file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                openFileDialog.ShowDialog();
                return;
            }
            TxtBoxFilePath.Text = openFileDialog.FileName;
        }
    }
}
