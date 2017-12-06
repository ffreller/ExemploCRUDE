using System;
using System.Collections.Generic;

namespace ExemploCRUDE
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sistema Papelaria");
            Console.WriteLine("");
            Console.WriteLine("Digite um das opções abaixo para seguir: ");
            int opcao;
            do
            {   
                Console.WriteLine("1-Cadastrar categoria\n2-Deletar categoria\n3-Atualizar Categoria\n4-Pesquisar Categorias\n9-Sair");
                opcao = int.Parse(Console.ReadLine());
                BancoDados bada = new BancoDados();
                Categoria cate = new Categoria();
                
                switch(opcao)
                    {
                        case 1:
                        Console.WriteLine("Qual o titulo da categoria?");
                        cate.titulo = Console.ReadLine();
                        if(bada.AddCategoria(cate))
                            Console.WriteLine("Categoria adicionada com sucesso!");
                        
                        break;

                        case 2:
                        Console.WriteLine("Qual o id da categoria?");
                        cate.idcategoria = Convert.ToInt32(Console.ReadLine());
                        if(bada.DelCategoria(cate))
                            Console.WriteLine("Categoria deletada com sucesso!");
                        else
                        {Console.WriteLine("ID inválido");}
                        break;

                        case 3:
                        Console.WriteLine("Qual o ID da categoria?");
                        cate.idcategoria = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Que nome gostaria de dar à categoria?" + cate.titulo + "\"?");
                        cate.titulo = Console.ReadLine();
                        if(bada.UpdCategoria(cate))
                        {
                            Console.WriteLine("Categoria atualizada com sucesso!");
                        }
                        else
                            {Console.WriteLine("ID inválido");}
                            
                        break;

                        case 4:
                            int opcao1;
                            do
                            {
                                Console.WriteLine("Como deseja pesquisar? (1 para ID, 2 para título)");
                                opcao1= int.Parse(Console.ReadLine());
                                switch(opcao1)
                                {
                                    case 1:
                                        Console.WriteLine("Qual o id da categoria?");
                                        int idcat = Convert.ToInt32(Console.ReadLine());
                                        List <Categoria> listacategoria0 = bada.SelCategoria(idcat);
                                        if (listacategoria0.Count != 0)
                                        {
                                            foreach (Categoria x in listacategoria0)
                                            {
                                                Console.WriteLine("Categoria encontrada!");
                                                Console.WriteLine("ID:" + x.idcategoria + "; Título: " + x.titulo);
                                            }
                                        }
                                        else
                                            {Console.WriteLine("ID não encontrado!");}
                                    break;
                                    case 2:
                                        Console.WriteLine("Qual o título da categoria?");
                                        string titcat = Console.ReadLine();
                                        List <Categoria> listacategoria1 = bada.SelCategoria(titcat);
                                        if(listacategoria1.Count!=0)
                                        {
                                            foreach (Categoria x in listacategoria1)
                                            {
                                                Console.WriteLine("Categoria encontrada!");
                                                Console.WriteLine("ID:" + x.idcategoria + "; Título: " + x.titulo);
                                            }
                                        }
                                        else
                                            {Console.WriteLine("ID não encontrado!");}
                                    break;
                                }
                            }
                            while (opcao1 != 1 && opcao1 !=2);
                        break;

                        case 9:
                        return;
                        
                    }
            }
            while (opcao != 9);  
        }
    }
}

