internal class Program
{
    private static void Main(string[] args)
    {
        Train[] trains = new Train[5];
        trains[0] = new Train("Сочи", 418, "12:00");
        trains[1] = new Train("Сочи", 092, "19:00");
        trains[2] = new Train("Москва", 120, "22:00");
        trains[3] = new Train("Пенза", 221, "10:00");
        trains[4] = new Train("Рязань", 055, "09:00");

        Console.WriteLine("Сортировка по номерам");
        var sortTrainsNum = from t in trains
                            orderby t.NumTrain ascending
                            select t;
        foreach (var t in trains)
        {
            t.GetInfo();
        }
        
        Console.WriteLine("\n Сортировка по пунктам назначения");
        var sortTrainsDest = from t in trains
                             orderby t.DestTrain, t.DepartureTime ascending
                             select t;
        foreach (var t in trains)
        {
            t.GetInfo();
        }

        Console.WrtieLine("\n Введите номер поезда");
        bool inputTrue;
        while (!inputTrue) 
        {
            int input = Console.ReadLine();
            for (int i = 0; i < trains.Length; i++) 
            {
                if (input == trains[i].NumTrain)
                {
                    inputTrue = true;
                    trains[i].GetInfo();
                    break;
                }
                else
                {
                    Console.WriteLine("Неправильно введён номер поезда или такого поезда нет");
                }
            }
        }
    }
}

class Train
{
    public string Destination { get; set; }
    public int NumTrain { get; set; }
    public string DepartureTime { get; set; }

    public Train(string destination, int numTrain, int departureTime)
    {
        Destination = destination;
        NumTrain = numTrain;
        DepartureTime = departureTime;
    }

    public void GetInfo()
    {
        Console.WriteLine($"Поезд с номером {NumTrain} отправлен в {Destination} и прибудет туда в {DepartureTime}");
    }
}