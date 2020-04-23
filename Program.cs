using System;
using System.Data.SqlClient;
using System.Data;
namespace ERT
{
    class Program
    {
         static void Main(string[] args)
        {
       // RegAdmin();
      
        const string constring=@"Data source=localhost; initial catalog=Client; Integrated Security=True";
        SqlConnection con = new SqlConnection(constring);
        
        Console.WriteLine(@"
Если вы уже регистрированый в приложении введите 1:
иначе чтобы регистрироваться введите 2
Если хотите войти в качестве Admina то выводите 3:
");

           string n=Console.ReadLine();
           int t=0;
           if(n=="1")
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
              t=1;
              Console.WriteLine("Добро пожаловать в свой личный кабинет");
              Console.WriteLine(@"
              выводите 1 Если хотите Заполнить  свою анкету
              выводите 2 Если хотите подать заявку 
              выводите 3 если хотите посмотреть свои заявки");
              string s3=Console.ReadLine();
              if(s3=="1")
              {
               Anceta(s);
              }
              if(s3=="2")
              {
                Zayavka(s);
              } 
              if(s3=="3")
              {
                ProsmotrZayavka(s);
              }
             }
             
            }
            if(t==0)
            {
                Console.WriteLine("Вы неправильно ввели Parol или Login");
            }
            con.Close();
           
           }
           }
           if(n=="2")
           {
             // con.Open();
              Registr();
           }
           string s5="", s6="";
           t=0;
           if(n=="3")
           {
             T1:Console.WriteLine("Введите Login:");
             s5=Console.ReadLine();
             Console.WriteLine("Введите Parol:");
             s6=Console.ReadLine();
             con.Open();
             string selectParol="Select * from Admin1";
             SqlCommand commandText1=new SqlCommand(selectParol,con);
             SqlDataReader reader=commandText1.ExecuteReader();
             while(reader.Read())
             {
               if(Convert.ToString(reader.GetValue("login"))==s5 && Convert.ToString(reader.GetValue("Parol"))==s6)
               {
                t=1; 
                Console.WriteLine("Добро пожаловать в личный кабинет Админа");
                Console.WriteLine("Если хотите посмотреть заявок всех клиентов выводите 1");
                if(Console.ReadLine()=="1")
                {
                  ProsmotrZayavkaAdmin();
                }

               }
               
             }
             if(t==1)
             {

             }
             else {
              Console.WriteLine("Не правильный Parol или Login");
              con.Close();
             goto T1;
             }
           }
           
         
        
        

        }

        static void RegAdmin()
        {
          const string constring=@"Data source=localhost;initial catalog=Client; Integrated Security=True";
          SqlConnection con = new SqlConnection(constring);
          con.Open();
      
          Console.WriteLine("Вводите Firstname");
          string s1=Console.ReadLine();
          Console.WriteLine("Вводите Lastname");
          string s2=Console.ReadLine();
          Console.WriteLine("Вводите Lastname");
          string s3=Console.ReadLine();
          Console.WriteLine("Вводите Login");
          string s4=Console.ReadLine();
          Console.WriteLine("Вводите Parol");
          string s5=Console.ReadLine();
          string InsertZayavka=$"insert into Admin1([Firstname],[LastName],[Middlename],[Login],[Parol]) Values('{s1}','{s2}','{s3}','{s4}','{s5}')";
          SqlCommand commandText12=new SqlCommand(InsertZayavka,con);
          var result = commandText12.ExecuteNonQuery(); 
          con.Close();



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
          Anceta(s2[10]);
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

        



        static void Anceta(string s4)
        {
         const string constring=@"Data source=localhost;initial catalog=Client; Integrated Security=True";
         SqlConnection con = new SqlConnection(constring);
         con.Open();
        //  string selectParol=$"select [Docunent №] from Registraciya where login='918270280'";
        //  SqlCommand commandText1=new SqlCommand(selectParol,con);
        //  SqlDataReader reader=commandText1.ExecuteReader();
        //  reader.Read();
        
         string[] s=new string[10]{"Серийный номер","пол","семейное положение","возраст","гражданство","сумма кредита от общего дохода","кредитная история","просрока в кредитной истории","цель кредита","срок кредита"};
         string[] s1=new string[]{};///////Массив для сохранения данных Анкет;
         /// 
         Array.Resize(ref s1,10);
         
         
         int t=0,i=0;
         s1[i]=s4;
        con.Close();
         i++;
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
                    s1[i]="холост";
                    t=1;
                    break;
                   }
                    case 2:
                   {
                    s1[i]="семеянин";
                    t=1;
                    break;
                   }
                    case 3:
                   {
                    s1[i]="вразводе";
                    t=1;
                    break;
                   }
                    case 4:
                   {
                    s1[i]="вдовец/вдова";
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
           i++;
          //  int a1=0,a2=0,a3=0,a4=0;
           Console.WriteLine("Введите возраст");
           s1[i]=Console.ReadLine();
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
                s1[i]="Таджикистан";
                t=1;
            }
            else{
                s1[i]="За рубежом";
                t=1;
            }
            if(t!=1)
            {
              Console.WriteLine("Пожалуйста вводите правильно то что требуется");
            }

           }
           i++;
           int number;
           
         T:Console.WriteLine("Введите Сумма кредита от общего дохода в %");
           string input=Console.ReadLine();
           if(int.TryParse(input, out number))
           {
             s1[i]=input;
           }
           else
           {
             goto T;
           }

           i++;
        T1:Console.WriteLine("Выводите кредитную историю");
           string input1=Console.ReadLine();
           if(int.TryParse(input1, out number))
           {
             s1[i]=input1;
           }
           else
           {
             goto T1;
           }

           i++;

           T5:Console.WriteLine("Выводите просрока в кредитной истории");
           string input3=Console.ReadLine();
           if(int.TryParse(input3, out number))
           {
             s1[i]=input1;
           }
           else
           {
             Console.WriteLine("Непрвильно ввели число");
             goto T5;
           }

           i++;
         T2:Console.WriteLine(@"Цель Кредита введите
           1 если это бытовая техника
           2 если это ремонт
           3 если телефон
           4 если прочее");
           string n1=Console.ReadLine();
           
           switch(n1)
           {
             case "1":
             {
              s1[i]="бытовая техника";
              break;
             }
             case "2":
             {
              s1[i]="ремонт";
              break;
             }
             case "3":
             {
              s1[i]=" телефон";
              break;
             }
              case "4":
              {
              s1[i]= "прочее";
              break;
              }
              default:
              {
               Console.WriteLine("Не правилно ввели команду повторите еще раз");
               goto T2;
               
              }
           }
            i++;
         T3: Console.WriteLine("Введите срок кредита");
          string input2=Console.ReadLine();
           if(int.TryParse(input1, out number))
           {
             s1[i]=input2;
           }
           else
           {
             goto T3;
           }
 
         con.Open();
         string InsertAncet=$"insert into Anceta([серийный номер],[пол],[семейное положение],[возраст],[гражданство],[сумма кредита от общего дохода],[кредитная история],[просрока в кредитной истории],[цель кредита],[срок кредита]) Values('{s1[0]}','{s1[1]}','{s1[2]}','{s1[3]}','{s1[4]}','{s1[5]}','{s1[6]}','{s1[7]}','{s1[8]}','{s1[9]}')";
         SqlCommand commandText12=new SqlCommand(InsertAncet,con);
         var result = commandText12.ExecuteNonQuery(); 
         con.Close();
          
         
        }
       
     static void Zayavka(string s)
     {
      
      T6:Console.WriteLine(@"Укажите цель, вводите 
      1 если это бытовая техника
      2 если это ремонт
      3 если это телефон
      4 если это прочее");
      string cel=Console.ReadLine(),cel1=" ";
      switch(cel)
      {
        case "1":
        cel1="бытовая техника";
        break;
        case "2":
        cel1="ремонт";
        break;
        case "3":
        cel1="телефон";
        break;
        case "4":
        cel1="прочее";
        break;
        default:
        {
          Console.WriteLine("Пожалуйста введите правильно то что требуется");
          goto T6;
        }
      }


      T7:Console.WriteLine("Укажите Cумму кредита");
      string sum=Console.ReadLine();
      int number; 
      if(string.IsNullOrWhiteSpace(sum)==true || int.TryParse(sum, out number)==false)
      {
        Console.WriteLine("Этот поля не должно быть пустим и не можеть быть строкам");
        goto T7;
      }
      

       
    T8:Console.WriteLine("Укажите срок кредита");
      string srok=Console.ReadLine();
      if(string.IsNullOrWhiteSpace(srok)==true || int.TryParse(sum, out number)==false)
      {
        Console.WriteLine("Этот поля не должно быть пустим");
        goto T8;
      }
      
      int srok1=Convert.ToInt32(srok),sum1=Convert.ToInt32(sum);
 
      const string constring=@"Data source=localhost;initial catalog=Client; Integrated Security=True";
      SqlConnection con = new SqlConnection(constring);
      con.Open();
      string InsertZayavka=$"insert into Zayavka Values('{s}','{sum1}','{srok1}','{cel1}')";
      SqlCommand commandText12=new SqlCommand(InsertZayavka,con);
      var result = commandText12.ExecuteNonQuery(); 
      con.Close();
      }
      static void ProsmotrZayavka(string s)
      {

      const string constring=@"Data source=localhost; initial catalog=Client; Integrated Security=True";
        SqlConnection con = new SqlConnection(constring);
        con.Open();
        string selectSql = $"Select * from Zayavka where [серийный номер]={s}";
        SqlCommand commandText = new SqlCommand(selectSql, con);
        SqlDataReader reader = commandText.ExecuteReader();
        while (reader.Read())
        {
System.Console.WriteLine($@"ID: {reader.GetValue("id")},
            Firstname: {reader.GetValue("серийный номер")},
            LastName: {reader.GetValue("сумма кредита")},
            MiddleName: {reader.GetValue("срок кредита")},
            BirthDate: {reader.GetValue("цель кредита")}, 
            ");
        }
        reader.Close();
        con.Close();
        
        }
        
      static void ProsmotrZayavkaAdmin()
      {
      const string constring=@"Data source=localhost; initial catalog=Client; Integrated Security=True";
        SqlConnection con = new SqlConnection(constring);
        con.Open();
        string selectSql = $"Select * from Zayavka";
        SqlCommand commandText = new SqlCommand(selectSql, con);
        SqlDataReader reader = commandText.ExecuteReader();
        while (reader.Read())
        {
System.Console.WriteLine($@"ID: {reader.GetValue("id")},
            Firstname: {reader.GetValue("серийный номер")},
            LastName: {reader.GetValue("сумма кредита")},
            MiddleName: {reader.GetValue("срок кредита")},
            BirthDate: {reader.GetValue("цель кредита")}, 
            ");
        }
        reader.Close();
        con.Close();
        
        }

    }
}
