using Android.App;
using Android.Widget;
using Android.OS;
using System.Threading;
using Android.Views;
using Android.Content;

namespace MyLoginSystem
{
    [Activity(Label = "MyLoginSystem", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private Button mBtnSignUp;
        private Button mBtnSignIn;
        private ProgressBar mProgressBar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource

            SetContentView(Resource.Layout.Main);

            mBtnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);
            mBtnSignIn = FindViewById<Button>(Resource.Id.btnSignIn);
            mProgressBar = FindViewById<ProgressBar>(Resource.Id.progressBar1);

            mBtnSignUp.Click += MBtnSignUp_Click;
            mBtnSignIn.Click += MBtnSignIn_Click;
        }

        private void MBtnSignIn_Click(object sender, System.EventArgs e)
        {
            Intent scrollViewActivity = new Intent(this, typeof(ChargeScrollViewActivity));
            StartActivity(scrollViewActivity);
        }

        private void MBtnSignUp_Click(object sender, System.EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            dialog_SignUp signUpDialog = new dialog_SignUp();
            signUpDialog.Show(transaction, "dialog fragment.");

            signUpDialog.mOnSignUpComplete += SignUpDialog_mOnSignUpComplete;

        }

        private void SignUpDialog_mOnSignUpComplete(object sender, OnSignUpEventArgs e)
        {
            mProgressBar.Visibility = Android.Views.ViewStates.Visible;
            Thread thread = new Thread(AuthRequest);
            thread.Start();
        }

        private void AuthRequest()
        {
            Thread.Sleep(3000);
            RunOnUiThread(() => { mProgressBar.Visibility = Android.Views.ViewStates.Invisible; });
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.actionbar_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }
    }
}

