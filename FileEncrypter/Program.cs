// See https://aka.ms/new-console-template for more information
using FileEncrypter.Class;

Console.Write("Path: ");
string path =Console.ReadLine();

Console.WriteLine("1.To Encrypt");
Console.WriteLine("2.To Decrypt");
string option=Console.ReadLine();

EncrypterAndDecrypter encrypterAndDecrypter = new EncrypterAndDecrypter();

if (option == "1") 
{

    var data = File.ReadAllText(path);

    string data1 = encrypterAndDecrypter.EnCode(data); ;

    File.WriteAllText(path, data1);

    

}
else if (option == "2") 
{
    var data = File.ReadAllText(path);

    string data1 = encrypterAndDecrypter.DeCode(data); ;

    File.WriteAllText(path, data1);
}