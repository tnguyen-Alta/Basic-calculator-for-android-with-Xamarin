using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Calc
{
    [Activity(Label = "Calc", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button button0;
        Button button1;
        Button button2;
        Button button3;
        Button button4;
        Button button5;
        Button button6;
        Button button7;
        Button button8;
        Button button9;

        Button buttonadd;
        Button buttondiff;
        Button buttondiv;
        Button buttonmul;
        Button buttonequal;
        Button buttonreset;
        Button ButtonCE;
        Button Buttonadddiff;
        Button Buttonpoint;
        Button Buttonbackspace;

        TextView edittext;


        public string n=string.Empty;
        public double first=0;
        public double second ;
        public double k;

        public Type oper;
        public enum Type {add,diff,div ,mul};

        public double ActionType(Type k, double x, double y)
        {
            switch(k)
                {
                case Type.add:
                    return x+y;
                
                case Type.diff:
                    return x - y;

                case Type.div:
                    return x / y;

                case Type.mul:
                    return x * y;
                default:
                    return 0;                    
            }
            
        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.layout1);

            // Get our button from the layout resource,
            // and attach an event to it

             buttonadd = FindViewById<Button>(Resource.Id.Buttonadd);
             buttondiff = FindViewById<Button>(Resource.Id.Buttondiff);
             buttondiv = FindViewById<Button>(Resource.Id.Buttondiv);
             buttonmul = FindViewById<Button>(Resource.Id.Buttonmul);
             buttonequal = FindViewById<Button>(Resource.Id.Buttonequal);
             buttonreset = FindViewById<Button>(Resource.Id.Buttonreset);
            ButtonCE = FindViewById<Button>(Resource.Id.ButtonCE);
            Buttonadddiff = FindViewById<Button>(Resource.Id.Buttonadddiff);
            Buttonpoint = FindViewById<Button>(Resource.Id.Buttonpoint);
            Buttonbackspace = FindViewById<Button>(Resource.Id.Buttonbackspace);


             button1 = FindViewById<Button>(Resource.Id.Button1);
             button2 = FindViewById<Button>(Resource.Id.Button2);
             button3 = FindViewById<Button>(Resource.Id.Button3);
             button4 = FindViewById<Button>(Resource.Id.Button4);
             button5 = FindViewById<Button>(Resource.Id.Button5);
             button6 = FindViewById<Button>(Resource.Id.Button6);
             button7 = FindViewById<Button>(Resource.Id.Button7);
             button8 = FindViewById<Button>(Resource.Id.Button8);
             button9 = FindViewById<Button>(Resource.Id.Button9);
             button0 = FindViewById<Button>(Resource.Id.Button0);

                edittext = FindViewById<TextView>(Resource.Id.Edittext);
            edittext.Text = first.ToString();
           // n = edittext.Text;
           
            button1.Click += delegate {
                append(1);                
            };
            button2.Click += delegate {
                append(2);
            };
            button3.Click += delegate {
                append(3);
            };
            button4.Click += delegate {
                append(4);
            };
            button5.Click += delegate {
                append(5);
            };
            button6.Click += delegate {
                append(6);
            };
            button7.Click += delegate {
                append(7);
            };
            button8.Click += delegate {
                append(8);
            };
            button9.Click += delegate {
                append(9);
            };

            
            button0.Click += delegate {
                if (n == string.Empty)
                    append(0);
                else if (n == "0")
                    edittext.Text = n;
                else
                    if (n.EndsWith(".0000000"))
                    edittext.Text = n;
                else
                    edittext.Text = append(0);
                
            };

            Buttonbackspace.Click += delegate {
                if (n.Length > 1)
                {
                    n = n.Remove(n.Length - 1);
                    edittext.Text = n;
                }
                else
                {
                    n = string.Empty;
                    edittext.Text = 0.ToString()      ;
                }
            };

            Buttonpoint.Click +=delegate
                {
                    if (!n.Contains("."))
                    {
                        n = n + ".";
                        edittext.Text = n;
                    }
                    if (n == string.Empty || first == 0)
                    {
                        n = "0.";
                        edittext.Text = n;
                    }
                    else
                    {
                        //n.Remove(n.Length - 1);
                        edittext.Text = n;
                    }
                };

            Buttonadddiff.Click += delegate {
                if (first == 0 && n == string.Empty)
                    edittext.Text = first.ToString();
               else if (first != 0 && n == string.Empty)
                {
                    first = -first;
                    edittext.Text = first.ToString();
                }
                else
                {
                    n = "-" + n;
                    edittext.Text = n;
                }
            };
            ButtonCE.Click += delegate {

                if (n != string.Empty)
                {
                    n = string.Empty;                   
                    second = 0;
                    edittext.Text = second.ToString();
                }
                else
                {
                    first = 0;
                    edittext.Text = first.ToString();
                }
            };

            buttonadd.Click += delegate {
                try
                {
                        oper = Type.add;
                    if (n == "Error")
                    {
                        n = string.Empty;
                        first = 0;
                        edittext.Text = first.ToString();
                    }
                    if (first == 0 && n == string.Empty)
                        n = first.ToString();
                    else
                    if (first != 0 && n == string.Empty)
                        edittext.Text = first.ToString();
                    else
                        first = first + double.Parse(n);
                        n = string.Empty;
                    }
                
                catch (Exception ex) {
                    edittext.Text = ex.Message;
                }
            };

            buttondiff.Click += delegate {
                try
                {
                    
                        oper = Type.diff;
                    if (n == "Error")
                    {
                        n = string.Empty;
                        first = 0;
                        edittext.Text = first.ToString();
                    }

                    //first = double.Parse(n);
                    //    double.TryParse(n, out first);
                    //    n = string.Empty;               
                    if (first == 0 && n == string.Empty)
                        n = first.ToString();
                    else
                    if (first != 0 && n == string.Empty)
                        edittext.Text = first.ToString();
                    else
                    {
                        first = double.Parse(n);
                        n = string.Empty;
                    }

                }
                catch (Exception ex)
                {
                    edittext.Text = ex.Message;
                }
            };
            buttondiv.Click += delegate {
                try
                {
                   
                        oper = Type.div;
                    // textview1.Text = n;
                    if (n == "Error")
                    {
                        n = string.Empty;
                        first = 0;
                        edittext.Text = first.ToString();
                    }
                    if (first == 0 && n == string.Empty)
                        n = first.ToString();
                    else
                    if (first != 0 && n == string.Empty)
                        edittext.Text = first.ToString();
                    else
                    {
                        first = double.Parse(n);
                        n = string.Empty;
                    }
                   
                    
                }
                catch (Exception ex)
                {
                    edittext.Text = ex.Message;
                }
            };

            buttonmul.Click += delegate {
                try
                {
                    
                    // textview1.Text = n;
                   // first = double.Parse(n);

                    oper = Type.mul;
                    if (n == "Error")
                    {
                        n = string.Empty;
                        first = 0;
                        edittext.Text = first.ToString();
                    }
                    
                    if (first == 0 && n == string.Empty)
                        n = first.ToString();
                    else
                    if (first != 0 && n == string.Empty)
                        edittext.Text = first.ToString();
                    else
                    {
                        first = double.Parse(n);
                        n = string.Empty;
                    }
                    // first = double.Parse(n);
                }
                catch (Exception ex)
                {
                    edittext.Text = ex.Message;
                }
            };
            buttonequal.Click += delegate {
                double.TryParse(n, out second);
               // double k = first;
                double z;
                //  textview2.Text = n;
                if (oper == Type.div && second == 0)
                {

                    edittext.Text = "Error";
                    n = "Error";

                }
                else
                {
                    if (n == string.Empty)
                    {
                        //second = first;

                        z = ActionType(oper, first, k);

                        edittext.Text = z.ToString();
                        first = z;

                        // edittext.Text = ActionType(oper, first, k).ToString();

                        n = string.Empty;
                    }
                    else
                    {
                        k = second;
                        z = ActionType(oper, first, second);

                        edittext.Text = z.ToString();
                        first = z;
                        n = string.Empty;
                    }
                }
               
            };

            buttonreset.Click += delegate {
                n = string.Empty;
                first = 0;
                second = 0;
                edittext.Text = first.ToString();
            };
            //button.Click += delegate {
            //    button.Text = string.Format("{0} clicks!", count++); };
        }
        public string append(Int16 m)

        {
            if (n.Length <= 9)
            {
                n += m.ToString();
                
            }

            if (n.Contains("Error"))
            { n = string.Empty;
                n += m.ToString();

            }
            edittext.Text = n;

            return n;

        }

        //public void app() {


            
        //   double z= double.Parse(edittext.Text);
        //    z = -z;
        //    n = z.ToString();
        //    edittext.Text = n;

        //}
    }


   

}

