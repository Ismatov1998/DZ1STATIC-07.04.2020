using System;
using System.Data.SqlClient;
using System.Data;
namespace ERT
{
    class Program
    {
         static void Main(string[] args)

        {
        const string constring=@"Data source=localhost; initial catalog=Client; Integrated Security=True";
        SqlConnection con = new SqlConnection(constring);
        
        Console.WriteLine(@"
Если вы уже регистрированый в приложении введите 1:
иначе чтобы регистрироваться введите 2");

           int n=Convert.ToInt32(Console.ReadLine()),t=0;
           if(n==1)
           {
           while(t!=1)
           {
            con.Open();
            Console.WriteLine("Введите Login:");
            string s=Console.ReadLine();
            Console.WriteLine("Введите Parol:");
            string s1=Console.ReadLine();
            string selectParol="Select * from Registraciya";
            SqlCommand commandText1=new SqlCommand(selectParol,con);
            SqlDataReader reader=commandText1.ExecuteReader();
            while(reader.Read())
            {
                
             if(Convert.ToString(reader.GetValue("login"))==s && Convert.ToString(reader.GetValue("Parol"))==s1)
             {
              Console.WriteLine("Добро пожаловать в свой личный кабинет");
              Console.WriteLine(@"Если хотите посмотреть свои заявки выводите 1
              Если хотите подать заявку ");

              t=1;
              Anceta();
             }
             
            }
            if(t==0)
            {
                Console.WriteLine("Вы неправильно ввели Parol или Login");
            }
            con.Close();
           
           }
           }
           if(n==2)
           {
               con.Open();
               Registr();
           }

        
        
        

        }




        static void Registr()
        {
       
        const string constring=@"Data source=localhost; initial catalog=Client; Integrated Security=True";
        SqlConnection con = new SqlConnection(constring);
      
        string[] s2=new string[]{"Firstname:","Lastname:","Middlename:","BirthDate:","Date of issue:","Date of expire:","Document №:","Addres:","Marital status","Pol","login","Parol"};
        
        string[] S= new string[]{};
        string s1="";
        Array.Resize(ref S,12);
        int t=0,k=0;
        for(int i=0;i<10;i++)
        { 
            t=0;
            while(t!=1)
            {
            Console.WriteLine($"Выводите {s2[i]}");
            s1=Console.ReadLine();
            if(string.IsNullOrWhiteSpace(s1))
            {
             Console.WriteLine("Этот поля не должно быть пустым");
            }
            else
            {
              t=1;
              S[i]=s1;
            }
            }
        }

        t=0;
        while(t!=1)
        {
        con.Open();
        string selectParol="Select * from Registraciya";
        SqlCommand commandText1=new SqlCommand(selectParol,con);
        SqlDataReader reader=commandText1.ExecuteReader();
        string n="";
        Console.WriteLine($"Выводите {s2[10]}");
        n=Console.ReadLine();
        k=0;
        while(reader.Read())
        {
            
          if(Convert.ToString(reader.GetValue("login"))==n)
            {
             k=1;
            }
        }
        if(k!=1)
        {
          S[10]=n; 
          t=1; 
        }
        else
        {
         Console.WriteLine("Такой Login уже существуеть");
        }
          con.Close();
        } 
        Console.WriteLine($"Введите {s2[11]}");
        S[11]=Console.ReadLine();       

        
        con.Open();
        string  insertSql=$"insert into Registraciya([Firstname],[Lastname],[Middlename],[BirthDate],[Date of issue],[Date of expire],[Docunent №],[Address],[Marital status],[Pol],[login],[Parol]) Values('{S[0]}','{S[1]}','{S[2]}','{S[3]}','{S[4]}','{S[5]}','{S[6]}','{S[7]}','{S[8]}','{S[9]}','{S[10]}','{S[11]}')";
        SqlCommand commandText=new SqlCommand(insertSql,con);
        var result = commandText.ExecuteNonQuery(); 
        
        con.Close();
        Console.WriteLine("Вы успешно регистрировались");
        t=0;
        while(t!=1)
        {
         Console.WriteLine("Если хотите заполнить анкету для кредита нажмите 1");
         if(Console.ReadLine()=="1")
         {
          Anceta();
          t=1;
         }
         else
         Console.WriteLine("Пажалуйста Введите правилно то что требуется");
        }
        }




        static void Read()
        {
        const string constring=@"Data source=localhost; initial catalog=Client; Integrated Security=True";
        SqlConnection con = new SqlConnection(constring);
        con.Open();
        string selectSql = "Select * from Registraciya";
        SqlCommand commandText = new SqlCommand(selectSql, con);
        SqlDataReader reader = commandText.ExecuteReader();
        while (reader.Read())
        {
System.Console.WriteLine($@"ID: {reader.GetValue("id")},
            Firstname: {reader.GetValue("Firstname")},
            LastName: {reader.GetValue("Lastname")},
            MiddleName: {reader.GetValue("Middlename")},
            BirthDate: {reader.GetValue("BirthDate")}, 
            Date of issue:{reader.GetValue("Date of issue")},
            Data of expire:{reader.GetValue("Date of expire")},
            Document:{reader.GetValue("Docunent №")},
            Address:{reader.GetValue("Address")},
            Marital status:{reader.GetValue("Marital status")},
            Pol:{reader.GetValue("Pol")},
            login:{reader.GetValue("login")},
            Parol:{reader.GetValue("Parol")}");
        }
        
        reader.Close();
        con.Close();
        }

        



        static void Anceta()
        {
         const string constring=@"Data source=localhost;initial catalog=Client; Integrated Security=True";
         string[] s=new string[9]{"pol","семейное положение","возраст","гражданство","сумма кредита от общего дохода","кредитная история","просрока в кредитной истории","цель кредита ","срок кредита"};
         string[] s1=new string[]{};///////Массив для сохранения данных заявки
         Array.Resize(ref s1,5);
         SqlConnection con=new SqlConnection(constring);
         con.Open();
         int t=0,i=0;

           while(t!=1)
           {
            Console.WriteLine($"Выберите {s[0]}");
            Console.WriteLine(@"выводите 1 если муж
выводите 2 если жен");
            string n=Console.ReadLine(); 
    
            
            if(n=="1")
            {
              s1[i]="муж";
              t=1;
            }
            if(n=="2")
            {
                s1[i]="жен";
                t=1;
            }
            if(t!=1)
            {
                Console.WriteLine("Пожалуйста вывоводите то что требуется правильно");
            }
           }
           
           t=0;i++;
           while(t!=1)
           {
               Console.WriteLine($"Выберите {s[1]}");
               Console.WriteLine(@"Выводите 
1 если холост
2 если семянин
3 если вразвоед
4 если вдовец/вдова");
               int n=Convert.ToInt32(Console.ReadLine());
               switch(n)
               {
                   case 1:
                   {
                    s[i]="холост";
                    t=1;
                    break;
                   }
                    case 2:
                   {
                    s[i]="семеянин";
                    t=1;
                    break;
                   }
                    case 3:
                   {
                    s[i]="вразводе";
                    t=1;
                    break;
                   }
                    case 4:
                   {
                    s[i]="вдовец/вдова";
                    t=1;
                    break;
                   }
               }
            if(t!=1)
            {
                Console.WriteLine("Пожалуйста вывоводите правильно то что требуется ");

            }
               
           }
           t=0;
           int a1=0,a2=0,a3=0,a4=0;
           Console.WriteLine("Введите возраст");
           a1=Convert.ToInt32(Console.ReadLine());
           t=0;
           while(t!=1)
           {
           
           Console.WriteLine(@"Введите 
1 если  вы Гражданин Таджикистана
2 если  вы гражданин другого государство");
            string n=Console.ReadLine();
            i++;
            if(n=="1")
            {
                s[i]="Таджикистан";
                t=1;
            }
            else{
                s[i]="За рубежом";
                t=1;
            }
            if(t!=1)
            {
                Console.WriteLine("Пожалуйста вводите правильно то что требуется");
            }

           }
        
        }
        class Zayavok
        {
          public string cel;
          public int summa;
          public int srokkredita;

        }

    }
}
