using System.Reflection.Metadata.Ecma335;


Dictionary<DateTime, string> compromissos = new Dictionary<DateTime, string>();
var opcao = "1";

while (opcao != "4")
{
    Console.WriteLine("========= AGENDA =========");
    Console.WriteLine("[1] - Agendar compromisso");
    Console.WriteLine("[2] - Exibir compromissos de hoje");
    Console.WriteLine("[3] - Exibir compromissos de outro dia");
    Console.WriteLine("[4] - Sair");
    Console.Write("Selecione uma opção: ");
    opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            AgendarCompromisso();
            break;
        case "2":
            ExibirCompromissosHoje();
            break;
        case "3":
            //ExibirCompromissosDataEspecifica();
            break;
        case "4":
            Console.WriteLine("Saindo...");
            break;
        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }
}

void AgendarCompromisso() 
{
    Console.Write("Digite a data e hora (formato: dd/MM/yyyy HH:mm): ");
    var _dataCompromisso = Console.ReadLine();
    var dataCompromisso = DateTime.ParseExact(_dataCompromisso, "dd/MM/yyyy HH:mm", null);
    Console.Write("Digite o timezone desejado: ");
    var _timezone = Console.ReadLine();
    var timezone = TimeZoneInfo.FindSystemTimeZoneById(_timezone);
    Console.Write("Digite o título do compromisso: ");
    var tituloCompromisso = Console.ReadLine();

    var dataTimezone = TimeZoneInfo.ConvertTime(dataCompromisso, timezone);
    compromissos.Add(dataTimezone, tituloCompromisso);

    Console.WriteLine("\nCompromisso agendado com sucesso!");
}

void ExibirCompromissosHoje() 
{
    var hoje = DateTime.Today;
    Console.WriteLine($"\nCompromissos para hoje ({hoje:dd/MM/yyyy}):");
    foreach (var compromisso in compromissos)
    {
        if (compromisso.Key.Date == hoje)
        {
            Console.WriteLine($"Data: {compromisso.Key} | Título: {compromisso.Value}");
        }
    }
}

// TESTES
//foreach (var tz in TimeZoneInfo.GetSystemTimeZones())
//{
//    Console.WriteLine($"{tz.Id} | {tz.DisplayName}");
//}
