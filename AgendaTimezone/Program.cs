Console.WriteLine("========= AGENDA =========");
Console.WriteLine("[1] - Agendar compromisso");
Console.WriteLine("[2] - Exibir compromissos de hoje");
Console.WriteLine("[3] - Exibir compromissos de outro dia");
Console.WriteLine("[4] - Sair");
Console.Write("Selecione uma opção: ");
var opcao = Console.ReadLine();

switch(opcao)
{
    case "1":
        Console.Write("Digite a data e hora (formato: dd/MM/yyyy HH:mm): ");
        var dataCompromisso = Console.ReadLine();
        Console.WriteLine("Digite o timezone desejado: ");
        var timezone = Console.ReadLine();
        Console.WriteLine("Digite o título do compromisso: ");
        var tituloCompromisso = Console.ReadLine();
        AgendarCompromisso();
        break;
    case "2":
        ExibirCompromissosHoje();
        break;
    case "3":
        ExibirCompromissosDataEspecifica();
        break;
    case "4":
        Console.WriteLine("Saindo...");
        break;
    default:
        Console.WriteLine("Opção inválida. Tente novamente.");
        break;
}


// TESTES
foreach (var tz in TimeZoneInfo.GetSystemTimeZones())
{
    Console.WriteLine($"{tz.Id} | {tz.DisplayName}");
}
