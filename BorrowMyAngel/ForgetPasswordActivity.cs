﻿using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using static Android.Views.View;

namespace BorrowMyAngel
    {
    [Activity(Label = "Forgot Password")]
    public class ForgetPasswordActivity : AppCompatActivity, IOnClickListener, IOnCompleteListener { 
    //public class ForgetPasswordActivity : Activity, IOnClickListener, IOnCompleteListener {
        EditText input_email;
        Button btnResetPas;
        TextView btnBack;
        RelativeLayout activity_forget;
        FirebaseAuth auth;
        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.forget_btn_back)
            {
                StartActivity(new Intent(this, typeof(SignUpActivity)));
                Finish();
            }
            else if (v.Id == Resource.Id.forget_btn_reset)
            {
                ResetPassword(input_email.Text);
            }
        }
        private void ResetPassword(string email)
        {
            auth.SendPasswordResetEmail(email).AddOnCompleteListener(this, this);
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ForgetPassword);
            //Init Firebase  
            auth = FirebaseAuth.GetInstance(LoginActivity.app);
            //Views  
            input_email = FindViewById<EditText>(Resource.Id.forget_email);
            btnResetPas = FindViewById<Button>(Resource.Id.forget_btn_reset);
            btnBack = FindViewById<TextView>(Resource.Id.forget_btn_back);
            //activity_forget = FindViewById<RelativeLayout>(Resource.Id.activity_forget);
            btnResetPas.SetOnClickListener(this);
            btnBack.SetOnClickListener(this);
        }
        public void OnComplete(Task task)
        {
            if (task.IsSuccessful == false)
            {
                Toast.MakeText(this, "Reset Password Failed!", ToastLength.Long).Show();

            }
            else
            {
               
            }
        }
    }
}