using BlogEF.Data;
using BlogEF.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogEF;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new BlogDataContext())
        {
            //create
            var tagInsert = new Tag
            {
                Name = "Dapper",
                Slug = "dapper"
            };
            context.Tags.Add(tagInsert);
            context.SaveChanges(); //so salva no banco com o SaveChanges()
            
            //update
            var tagUpdate = context.Tags.FirstOrDefault(t => t.Id == 2); //pega a versao da tag mais atual por id trakeada(com metadados que ajudam no update ou delete)
            if (tagUpdate == null)
                return;
            tagUpdate.Name = ".NET";
            tagUpdate.Slug = "dotnet";
            
            context.Update(tagUpdate);
            context.SaveChanges();
            
            // //delete
            var tagDelete = context.Tags.FirstOrDefault(t => t.Id == 2);
            if (tagDelete == null)
                return;
            
            context.Remove(tagDelete);
            context.SaveChanges();
            
            //list all
            var tags = context
                .Tags
                .AsNoTracking() //desabilita o trakeamento, tornando mais perfomatico(ideal para listagens)
                .ToList(); //executa a query
            foreach (var tag in tags)
            {
                Console.WriteLine(tag.Name);
            }
            
            //query com where
            var tagsByName = context
                .Tags
                .AsNoTracking()
                .Where(t => t.Name.Contains(".NET"))
                .ToList(); //listar sempre ao final, performatico, pois executa a query apos usar o where, nao passando por todos os dados do banco
            foreach (var tag in tagsByName)
            {
                Console.WriteLine(tag.Name);
            }
            
            //read by id
            var tagById = context
                .Tags
                .AsNoTracking()
                .FirstOrDefault(t => t.Id == 2); //pega o primeiro ou null
                //.SingleOrDefault() pega o item especifico, se tiver mais de um da erro
            
            Console.WriteLine(tagById?.Name);
        }
    }
}
