using System;


namespace project30

{
    class Program
    {
        static void Main(string[] args)
        {

        int[] arrint=new int[10]{1,2,3,4,5,8,2,6,9,10};
        string[] arrstring=new string[10]{"11","21","32","4","55","8","20","60","90","103"};
        double[] arrdouble=new double[10]{13,22,35,4,54,88,28,67,99,10};
        float[] arrfloat=new float[10]{15f,26f,38f,47f,58f,86f,26f,64f,92f,103f};
        decimal[] arrdecimal=new decimal[10]{15M,25M,34M,42M,50M,8M,2M,6M,9M,10M};

          ArrayHelp.Pop(ref arrint);
          ArrayHelp.Pop(ref arrstring);
          ArrayHelp.Pop(ref arrdouble);
          ArrayHelp.Pop(ref arrfloat);
          ArrayHelp.Pop(ref arrdecimal);

        int[] arrint1=new int[10]{11,21,31,41,51,81,25,64,93,10};
        string[] arrstring1=new string[10]{"18","25","32","46","57","83","29","67","94","102"};
        double[] arrdouble1=new double[10]{13,25,36,48,54,81,22,63,98,106};
        float[] arrfloat1=new float[10]{1f,2f,3f,4f,5f,8f,2f,6f,9f,10f};
        decimal[] arrdecimal1=new decimal[10]{1M,2M,3M,4M,5M,8M,2M,6M,9M,10M}; 


          ArrayHelp.Push(ref arrint1, 45);
          ArrayHelp.Push(ref arrstring1, "23" );
          ArrayHelp.Push(ref arrdouble1, 45);
          ArrayHelp.Push(ref arrfloat1, 45f);
          ArrayHelp.Push(ref arrdecimal1, 26M);

        
        } 

        public static class ArrayHelp
        {
         

          public static int  Pop(ref int[] arrint)
          {
            
            int n=arrint.Length,a;
            
            int [] arr2=new int[n-1];

            for(int i=0;i<n-1;i++)
            {
                arr2[i]=arrint[i];
            }
            Console.WriteLine("Задания N-1.1.1");
            Console.WriteLine("Массив до изменения ");
            getinfo(arrint);
            
            a=arrint[n-1];
            arrint=arr2;
            
            Console.WriteLine("Массив после изменения ");
            getinfo(arrint);
            
            return a;           
          }
          
           public static string  Pop(ref string[] arrstring)
          {
            
           
            
            int n=arrstring.Length;
            string b;
            string[] arr2=new string[n-1];

            for(int i=0;i<n-1;i++)
            {
                arr2[i]=arrstring[i];
            }
            Console.WriteLine("Задания N-1.1.2");
            Console.WriteLine("Массив до изменения ");
            b=arrstring[n-1];
            getinfo(arrstring);
            arrstring=arr2;
            Console.WriteLine("Массив после изменения ");
            getinfo(arrstring);
            return b;           
          }
           public static double  Pop(ref double[] arrdouble)
          {
            
            int n=arrdouble.Length;
            double b;
            double[] arr2=new double[n-1];

            for(int i=0;i<n-1;i++)
            {
                arr2[i]=arrdouble[i];
            }
            b=arrdouble[n-1];
            Console.WriteLine("Задания N-1.1.3");
            Console.WriteLine("Массив до изменения ");
            getinfo(arrdouble);
            arrdouble=arr2;
            Console.WriteLine("Массив после изменения ");
            getinfo(arrdouble);
            return b;           
          }
           public static float Pop(ref float[] arrfloat)
          {
            
           
            
            int n=arrfloat.Length;
            float b;
            float[] arr2=new float[n-1];

            for(int i=0;i<n-1;i++)
            {
                arr2[i]=arrfloat[i];
            }
            Console.WriteLine("Задания N-1.1.4");
            Console.WriteLine("Массив до изменения ");
            getinfo(arrfloat);
            b=arrfloat[n-1];
            arrfloat=arr2;
            Console.WriteLine("Массив после изменения ");
            getinfo(arrfloat);
            return b;           
          
          }
           public static decimal Pop(ref decimal[] arrdecimal)
          {
            int n=arrdecimal.Length;
            decimal b;
            decimal[] arr2=new decimal[n-1];

            for(int i=0;i<n-1;i++)
            {
                arr2[i]=arrdecimal[i];
            }
            Console.WriteLine("Задания N-1.1.5");
            Console.WriteLine("Массив до изменения ");
            getinfo(arrdecimal);
            b=arrdecimal[n-1];
            arrdecimal=arr2;
            Console.WriteLine("Массив после изменения ");
            getinfo(arrdecimal);
            return b;           
          
          }
        public static int Push(ref int[] arrint, int element) 
        {
            int n=arrint.Length;
            int [] arr2=new int[n+1];
            for(int i=0;i<n;i++)
            {
                arr2[i]=arrint[i];
            }
            arr2[n]=element;
            Console.WriteLine("Задания N-1.2.1");
            Console.WriteLine("Массив до изменения ");
            getinfo(arrint);
            Console.WriteLine("Массив после изменения ");
            arrint=arr2;
            getinfo(arrint);
           return n+1;
          
        }     
       
         public static int Push(ref string[] arrstring, string element) 
        {
             int n=arrstring.Length;
             string [] arr2=new string[n+1];
            for(int i=0;i<n;i++)
            {
                arr2[i]=arrstring[i];
            }
            arr2[n]=element; 
            Console.WriteLine("Задания N-1.2.2");
            Console.WriteLine("Массив до изменения "); 
            getinfo(arrstring);
            Console.WriteLine("Массив после изменения ");
            arrstring=arr2;
            getinfo(arrstring);
            return n+1;

        }     
          public static int Push(ref double[] arrdouble, double element) 
        {
            Console.WriteLine("Задания N-1.2.3");
            Console.WriteLine("Массив до изменения ");
            getinfo(arrdouble);
            int n=arrdouble.Length;
            Array.Resize(ref arrdouble,11);
            arrdouble[n]=element;
            Console.WriteLine("Массив после изменения ");
            getinfo(arrdouble);
            return n+1; 
        }   
          public static int Push(ref decimal[] arrdecimal, decimal element) 
        {
            Console.WriteLine("Задания N-1.2.4");
            Console.WriteLine("Массив до изменения ");
            getinfo(arrdecimal);
            int n=arrdecimal.Length;
            Array.Resize(ref arrdecimal,11);
            arrdecimal[n]=element;
            Console.WriteLine("Массив после изменения ");
            getinfo(arrdecimal);
            return n+1; 
        }   
         
        public static int Push(ref float[] arrfloat, float element) 
        {
            Console.WriteLine("Задания N-1.2.5");
            Console.WriteLine("Массив до изменения ");
            getinfo(arrfloat);
            int n=arrfloat.Length;
            Array.Resize(ref arrfloat,11);
            Console.WriteLine("Массив после изменения ");
            arrfloat[n]=element;
            getinfo(arrfloat);

            return n+1; 
        }   
         
       
        
         public static void getinfo(int[] arr)
          {
              for(int i=0;i<arr.Length;i++)
              {
                  Console.Write($"{arr[i]} ");
              }
              Console.WriteLine();
              
          }
           public static void getinfo(string[] arr)
          {
              for(int i=0;i<arr.Length;i++)
              {
                  Console.Write($"{arr[i]} ");
              }
               Console.WriteLine();
          }
           public static void getinfo(double[] arr)
          {
              for(int i=0;i<arr.Length;i++)
              {
                  Console.Write($"{arr[i]} ");
              }
               Console.WriteLine();
          }
           public static void getinfo(float[] arr)
          {
              for(int i=0;i<arr.Length;i++)
              {
                  Console.Write($"{arr[i]} ");
              }
               Console.WriteLine();
          }
           public static void getinfo(decimal[] arr)
          {
              for(int i=0;i<arr.Length;i++)
              {
                  Console.Write($"{arr[i]} ");
              }
               Console.WriteLine();
          }
          
        }
        
        
        

    }
}

