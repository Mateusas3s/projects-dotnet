using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var ind = 0;
            string opUser = showMenu();
            
            while (opUser.ToUpper() != "X")
            {
                switch (opUser)
                {
                    case "1":
                        Console.WriteLine("Digite o nome do aluno: ");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Digite a nota do aluno: ");
                        if(decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException("Valor da nota deve ser decimal!");
                        }

                        alunos[ind] = aluno;
                        ind++;

                        Console.WriteLine();
                        break;

                    case "2":
                        foreach(var a in alunos)
                            if(!string.IsNullOrEmpty(a.Nome))
                                Console.WriteLine($"ALUNO: {a.Nome} - NOTA: {a.Nota}");
                        
                        Console.WriteLine();
                        break;

                    case "3":
                        decimal notaTotal = 0;
                        var nAlunos = 0;

                        for (int i = 0; i < alunos.Length; i++)
                            if(!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal += alunos[i].Nota;
                                nAlunos++;
                            }

                        var mediaGeral = notaTotal/nAlunos;
                        Conceito conceitoGeral = 0;

                        if(mediaGeral<1)
                        {
                            conceitoGeral = Conceito.F; 
                        }
                        else if(mediaGeral<3)
                        {
                            conceitoGeral = Conceito.E; 
                        }
                        else if(mediaGeral<5)
                        {
                            conceitoGeral = Conceito.D; 
                        }
                        else if(mediaGeral<7)
                        {
                            conceitoGeral = Conceito.C; 
                        }
                        else if(mediaGeral<9)
                        {
                            conceitoGeral = Conceito.B; 
                        }
                        else if(mediaGeral<=10)
                        {
                            conceitoGeral = Conceito.A; 
                        }

                        Console.WriteLine($"MÉDIA GERAL: {mediaGeral} - CONCEITO GERAL: {conceitoGeral}");

                        Console.WriteLine();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException("Selecione uma opção válida!");
                }
                opUser = showMenu();
            }
        }

        private static string showMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Inserir novo aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opUser = Console.ReadLine();
            Console.WriteLine();
            return opUser;
        }
    }
}
