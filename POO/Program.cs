namespace POO;

class Program
{ 
    static void Main(string[] args)
    {

        Animal[] animais =
        [
            new Cachorro("Thor", 3),
            new Vaca("Mimosa", 4),
            new Gato("Bela", 3),
        ];

        foreach (Animal animalAtual in animais)
        {
            animalAtual.Comer();
            animalAtual.FazerBarulho();
        }
        
    }
    
    
}