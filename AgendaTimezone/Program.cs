Dictionary<DateTime, string> compromissos = new Dictionary<DateTime, string>();
var opcao = "1";

while (opcao != "4")
{
    Console.WriteLine("\n========= AGENDA =========");
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
            ExibirCompromissosDataEspecifica();
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
    var dataCompromisso = ObterDataValida("dd/MM/yyyy HH:mm");
    var timezone = ObterTimeZone();

    String tituloCompromisso;
    do
    {
        Console.Write("Digite o título do compromisso: ");
        tituloCompromisso = Console.ReadLine();
    } while (string.IsNullOrWhiteSpace(tituloCompromisso));

    var dataTimezone = TimeZoneInfo.ConvertTime(dataCompromisso, timezone);
    compromissos.Add(dataTimezone, tituloCompromisso);

    Console.WriteLine("\nCompromisso agendado com sucesso!");
}

void ExibirCompromissosHoje() 
{
    var timezone = ObterTimeZone();
    var dataAtual = TimeZoneInfo.ConvertTime(DateTime.Now, timezone);
    var hoje = dataAtual.Date;

    Console.WriteLine($"\nCompromissos para hoje ({hoje:dd/MM/yyyy}):");
    foreach (var compromisso in compromissos)
    {
        if (compromisso.Key.Date == hoje)
        {
            Console.WriteLine($"Data: {TimeZoneInfo.ConvertTime(compromisso.Key, timezone)} | Título: {compromisso.Value}");
        }
    }
}

void ExibirCompromissosDataEspecifica() 
{
    var dataEspecifica = ObterDataValida("dd/MM/yyyy");
    var timezone = ObterTimeZone();

    Console.WriteLine($"\nCompromissos para {dataEspecifica:dd/MM/yyyy}:");
    foreach (var compromisso in compromissos)
    {
        if (compromisso.Key.Date == dataEspecifica.Date)
        {
            Console.WriteLine($"Data: {TimeZoneInfo.ConvertTime(compromisso.Key, timezone)} | Título: {compromisso.Value}");
        }
    }
}

DateTime ObterDataValida(String formato)
{
    DateTime dataFormatada;
    bool isValido;
    do
    {
        Console.Write($"Digite a data (formato: {formato}): ");
        var dataTexto = Console.ReadLine();
        isValido = DateTime.TryParseExact(dataTexto, formato, null, System.Globalization.DateTimeStyles.None, out dataFormatada);

        if(!isValido)
            Console.WriteLine("Data inválida. Tente novamente.");
    } while (!isValido);
    return dataFormatada;
}

TimeZoneInfo ObterTimeZone()
{
    Console.Write("Digite o timezone atual: ");
    var timezoneAtual = Console.ReadLine();
    try
    {
        return TimeZoneInfo.FindSystemTimeZoneById(timezoneAtual);
    } catch
    {
        return TimeZoneInfo.Local;
    }
}