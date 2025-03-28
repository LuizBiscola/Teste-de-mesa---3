using System;
class Rendimento
{
    public static void problema6()
    {
        decimal renda_acumulada = 0;
        decimal saldo = 0;
        decimal valor_atual = 0;
        decimal valor_inicio_mes = 0;

        Console.Write("Informe o valor presente: ");
        decimal valor_presente = decimal.Parse(Console.ReadLine());
        valor_atual = valor_presente;
        valor_inicio_mes = valor_presente;

        Console.Write("Informe a taxa de juros mensal em %: ");
        decimal taxa_juros = decimal.Parse(Console.ReadLine());

        Console.Write("Digite o número de meses: ");
        int meses_entrada = int.Parse(Console.ReadLine());

        Console.Write("Digite o número de dias: ");
        int dias_entrada = int.Parse(Console.ReadLine());

        DateTime data_inicial = DateTime.Now;
        DateTime data_final = data_inicial.AddMonths(meses_entrada).AddDays(dias_entrada);

        Console.Write("Informe o valor a ser resgatado no quinto mes: ");
        decimal resgate = decimal.Parse(Console.ReadLine());

        // muda a taxa mensal para diaria
        double taxa_mensal = (double)(taxa_juros / 100);
        double taxa_diaria = Math.Pow(1 + taxa_mensal, 1.0/30) - 1;

        decimal taxa_juros_diaria = (decimal)taxa_diaria;
        decimal rendimento;

        Console.WriteLine("\nTabela de Iteração - Problema 6\n");
        Console.WriteLine("Data\t\tValor Atual\tRendimento Mensal\tRenda Líquida Mensal\tRenda Acumulada\tSaldo");

        bool resgate_realizado = false;

        DateTime data_atual = data_inicial;
        int mes_atual = 0;
        DateTime ultimo_dia_mes = data_atual;

        while(data_atual <= data_final)
        {
            // calculo do rednimento por taxa diaria
            rendimento = valor_atual * taxa_juros_diaria;
            decimal rendimento_liquido = rendimento;

            valor_atual = valor_atual + rendimento;
            renda_acumulada = renda_acumulada + rendimento_liquido;

            //mostrar os rendimentos do mes e fazer os controles de meses
            if (data_atual.Month != ultimo_dia_mes.Month)
            {
                mes_atual++;
                
                decimal rendimento_mensal = valor_atual - valor_inicio_mes;
                
                Console.WriteLine($"|{ultimo_dia_mes:dd/MM/yyyy}\t|{valor_atual:C2}\t|{rendimento_mensal:C2}\t|{rendimento_mensal:C2}\t|{renda_acumulada:C2}\t|{saldo:C2}");
                
                ultimo_dia_mes = data_atual;
                valor_inicio_mes = valor_atual; 
            }

            // fazer o resgate no quinto mes
            if (mes_atual == 4 && !resgate_realizado)
            {
                valor_atual = valor_atual - resgate;
                renda_acumulada = renda_acumulada - resgate;
                valor_inicio_mes = valor_atual; 
                Console.WriteLine($"Resgate de {resgate:C2} realizado com sucesso no mês {mes_atual + 1}");
                resgate_realizado = true;
            }

            saldo = valor_atual;

            //mostrar os rednimentos do ultimo mes
            if (data_atual.Date == data_final.Date && data_atual.Month == ultimo_dia_mes.Month)
            {
                decimal rendimento_mensal = valor_atual - valor_inicio_mes;
                Console.WriteLine($"|{data_atual:dd/MM/yyyy}\t|{valor_atual:C2}\t|{rendimento_mensal:C2}\t|{rendimento_mensal:C2}\t|{renda_acumulada:C2}\t|{saldo:C2}");
            }
            data_atual = data_atual.AddDays(1);
        }
    }
}
