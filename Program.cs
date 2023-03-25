public class Program
{
    public static List<string> GetTexts()
    {
        List<string> listText = new List<string>();
        string textValue = string.Empty;
        var closeSession = false;
        var willContinue = false;

        do
        {
            Console.WriteLine("Digite uma palavra: ");
            textValue = Console.ReadLine();

            if (string.IsNullOrEmpty(textValue.Trim()))
                Console.WriteLine("Por favor, não deixe em branco!");
            else
            {
                listText.Add(textValue);
                do
                {
                    Console.WriteLine("Deseja digitar outra palavra? S/N");
                    string anotherSum = Console.ReadLine();

                    switch (anotherSum.ToUpper())
                    {
                        case "S":
                            willContinue = false;
                            break;

                        case "N":
                            willContinue = false;
                            closeSession = true;
                            break;

                        default:
                            Console.WriteLine("Valor inválido, digite S(sim) ou N(não)");
                            break;

                    }

                } while (willContinue);
            }

            if (closeSession)
                break;

            textValue = string.Empty;

        } while (true);

        return listText;
    }

    public static string RemoveDuplicate(string text)
    {
        var newText = string.Empty;

        newText = text;

        for (var i = 0; i < text.Length; i++)
        {
            var letra = text.Substring(i, 1);

            newText = newText.Replace(letra + letra, letra);
        }

        return newText;
    }

    public static string[] newArray(List<string> textList)
    {
        List<string> newArray = new List<string>();

        foreach (var text in textList)
            newArray.Add(RemoveDuplicate(text));

        return newArray.ToArray();
    }

    public static void Main()
    {
        var texts = GetTexts();

        var newTextArray = newArray(texts);

        Console.Write("Palavras digitadas: " + string.Join(", ", texts));
        Console.ReadLine();
        Console.Write("Palavras com duplicação removida: " + string.Join(", ", newTextArray));
        Console.ReadLine();
    }
}