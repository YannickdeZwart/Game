//var builder = WebApplication.CreateBuilder(args);
//var app = builder.Build();

//app.MapGet("/", () => {});

//app.Run(); 

Character character = new Character();

Mob mob = new Mob(100);

Console.WriteLine(character.baseDamage.getDamage());