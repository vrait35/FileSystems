using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IO
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isTrue = false ;
            Console.WriteLine("Домашнее задание на тему : Взаимодействие с файловой системой");           
            int numberHomeWork = -1;
            while (numberHomeWork < 1 || numberHomeWork > 2 && !isTrue)
            {                
                Console.Write("введите номер домашнего задания(1,2):");
                isTrue = int.TryParse(Console.ReadLine(), out numberHomeWork);
            }
            isTrue = false;
            if (numberHomeWork == 1)
            {
                DriveInfo[] driveInfo = DriveInfo.GetDrives();
                for (int i = 0; i < driveInfo.Length; i++)
                    Console.WriteLine(i + " : " + driveInfo[i]);
                Console.WriteLine("введите номер диска для операции");
                int numberDrive = -1;
                isTrue = false;
                while (!isTrue || numberDrive < 0 || numberDrive >= driveInfo.Length)
                {
                    isTrue = int.TryParse(Console.ReadLine(), out numberDrive);
                }
                isTrue = false;
                string path = driveInfo[numberDrive].ToString();
                string directoryName = @"dzAnuar1";
                string fileName = "dzFile1.txt";
                path += directoryName;

                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (IOException exp)
                {
                    Console.WriteLine(exp.Message);
                    Console.WriteLine("----------Перезапустите программу !!!");
                    Environment.Exit(0);
                }

                path += @"\" + fileName;
                FileStream fileStream = null;
                string result = null;
                if (!File.Exists(path))
                {
                    try
                    {
                        fileStream = new FileStream(path, FileMode.CreateNew);
                        string str = ":0,1,"; // :0,1,1,2,3,5,8,13,21,34,
                        byte[] bytes;
                        bytes = Encoding.ASCII.GetBytes(str);
                        fileStream.Write(bytes, 0, bytes.Length);
                        Console.WriteLine("Файл создан первоначальные значения записаны  : " + str);
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    using (fileStream = new FileStream(path, FileMode.Open))
                    {
                        byte[] bytes = new byte[fileStream.Length];
                        fileStream.Read(bytes, 0, (int)fileStream.Length);
                        result = Encoding.ASCII.GetString(bytes);
                    }

                    int countZapata = 0;
                    for (int i = 0; i < result.Length; i++)
                        if (result[i] == ',') countZapata++;
                    for (int ii = 0; ii < countZapata; ii++)
                    {
                        int indexSymbolEnd = 0, indexSymbolEnd2 = 0;
                        for (int i = 0; i < result.Length - 1; i++)
                        {
                            if (result[i] == ',') indexSymbolEnd = i;
                        }
                        for (int i = 0; i < indexSymbolEnd; i++)
                        {
                            if ((result[i] == ',' || result[i] == ':')) indexSymbolEnd2 = i;
                        }

                        string number1 = "", number2 = "";
                        for (int i = indexSymbolEnd2 + 1; result[i] != ','; i++)
                        {
                            number1 += result[i];
                        }
                        for (int i = indexSymbolEnd + 1; result[i] != ','; i++)
                        {
                            number2 += result[i];
                        }
                        long a = long.Parse(number1);
                        long b = long.Parse(number2);
                        long c = a + b;
                        result += c.ToString() + ",";
                    }

                    using (fileStream = new FileStream(path, FileMode.Create))
                    {
                        byte[] bytes = Encoding.ASCII.GetBytes(result);
                        fileStream.Write(bytes, 0, result.Length);
                        Console.WriteLine("Содержимое файла: " + result);
                    }

                }
            }

            else  //  2 -Домашка
            {

                DriveInfo[] driveInfo = DriveInfo.GetDrives();
                for (int i = 0; i < driveInfo.Length; i++)
                    Console.WriteLine(i + " : " + driveInfo[i]);
                Console.WriteLine("введите номер диска для операции");
                int numberDrive = -1;
                isTrue = false;
                while (!isTrue || numberDrive < 0 || numberDrive >= driveInfo.Length)
                {
                    isTrue = int.TryParse(Console.ReadLine(), out numberDrive);
                }
                isTrue = false;
                string path = driveInfo[numberDrive].ToString();
                string directoryName = @"dzAnuar2";
                string fileName = "INPUT.txt";
                path += directoryName;

                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (IOException exp)
                {
                    Console.WriteLine(exp.Message);
                    Console.WriteLine("----------Перезапустите программу !!!");
                    Environment.Exit(0);
                }

                path += @"\" + fileName;
                FileStream fileStream = null;
                FileInfo fileInfo = new FileInfo(path);
                if (!File.Exists(path) || fileInfo.Length==0)
                {
                    try
                    {
                        fileStream = new FileStream(path, FileMode.Create);                        
                        double a = 0,b=0;
                        while (!isTrue)
                        {
                            Console.WriteLine("введите первое натуральное число: ");
                            isTrue = double.TryParse(Console.ReadLine(), out a);
                            if (!isTrue) continue;
                            Console.WriteLine("введите второе натуральное число: ");
                            isTrue = double.TryParse(Console.ReadLine(), out b);
                        }
                        isTrue = false;
                        string str = a.ToString() + " " + b.ToString();
                        byte[] bytes;
                        bytes = Encoding.ASCII.GetBytes(str);
                        fileStream.Write(bytes, 0, bytes.Length);
                        Console.WriteLine("Файл создан первоначальные значения записаны  : " + str);
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    finally
                    {
                        fileStream.Close();
                    }
                }
               
                    double c;
                    using (fileStream = new FileStream(path, FileMode.Open))
                    {
                        byte[] buf = new byte[fileStream.Length];
                        fileStream.Read(buf, 0, (int)fileStream.Length);
                        string res = Encoding.ASCII.GetString(buf);
                        string str1 = "",str2="";
                        int index = 0;
                        for (; res[index] != ' '; index++)
                            str1 += res[index];
                        for (; index < res.Length; index++)
                            str2 += res[index];
                        double a = double.Parse(str1);
                        double b = double.Parse(str2);
                        c = a + b;
                    }
                    string pathOutput = driveInfo[numberDrive].ToString();
                    pathOutput += directoryName;
                    fileName = "OUTPUT.TXT";
                pathOutput += @"\" + fileName;
                    using (fileStream=new FileStream(pathOutput, FileMode.Create))
                    {
                        byte[] bytes = Encoding.ASCII.GetBytes(c.ToString());
                        fileStream.Write(bytes,0,bytes.Length);
                    Console.WriteLine("в файл "+fileName+" записан : "+c);
                    }
                File.Delete(path);
            }
        }
    }
}
